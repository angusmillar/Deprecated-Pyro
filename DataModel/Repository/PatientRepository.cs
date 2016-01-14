using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using DataModel.Interface;
using DataModel.Model;
using Hl7.Fhir.Model;
using SqlForge.Query;
using SqlForge.Support;

namespace DataModel.Repository
{
  class PatientRepository : BaseRepository, IPatientRepository
  {
    public PatientRepository(BlazeDbContext Context)
    {
      _Context = Context;
    }

    public string AddResource(Patient Patient)
    {
      var NewPatientResource = this.PopulatePatientResourceEntity(1, Patient);
      using (var scope = new TransactionScope())
      {
        _Context.PatientResource.Add(NewPatientResource);
        this.Save();
        scope.Complete();
      }
      return NewPatientResource.FhirResourceId;
    }

    public Patient GetCurrentResource(string FhirResourceId)
    {
      var Xml = (from x in _Context.Resource where x.PatientResource.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == false select x.Xml).SingleOrDefault();
      if (Xml != null)
        return Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(Xml) as Patient;
      else
        return null;
    }

    public bool IsCurrentResourceDeleted(string FhirResourceId)
    {
      if (_Context.Resource.Any(x => x.PatientResource.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == true))
        return true;
      else
        return false;
    }

    public int LastDeletedResourceVersion(string FhirResourceId)
    {
      return _Context.Resource.SingleOrDefault(x => x.PatientResource.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == true).Version;
    }

    public bool ResourceExists(string FhirResourceId)
    {
      if (_Context.PatientResource.Any(x => x.FhirResourceId == FhirResourceId))
        return true;
      else
        return false;
    }

    public int GetResourceCurrentVersion(string FhirResourceId)
    {
      return _Context.Resource.SingleOrDefault(x => x.PatientResource.FhirResourceId == FhirResourceId && x.IsCurrent == true).Version;
    }

    public string UpdateResource(int ResourceVersion, Patient Patient)
    {
      //##issues## Check  if (entry.State != EntityState.Modified) here to see if not change results in modified
      var NewPatientResource = this.PopulatePatientResourceEntity(ResourceVersion, Patient);

      //Load the Patient Resource db record, remember this is the single Patient not the many history versions on the Resource so no need for IsCurrent
      var DbPatientResource = (from p in _Context.PatientResource
                                .Include(x => x.HumanName)
                                .Include(x => x.Identifier.Select(y => y.Type).Select(b => b.Coding))
                               where p.FhirResourceId == Patient.Id
                               select p).FirstOrDefault();

      using (var scope = new TransactionScope())
      {
        //Delete the old HumanNames and any Periods 
        foreach (var Name in DbPatientResource.HumanName.ToList())
        {
          if (Name.Period != null)
            _Context.Period.Remove(Name.Period);
          _Context.HumanName.Remove(Name);
        }

        //Add the new HumanNames
        DbPatientResource.HumanName = NewPatientResource.HumanName;

        //Delete the old Identifiers
        if (DbPatientResource.Identifier != null)
        {
          foreach (var Identifier in DbPatientResource.Identifier.ToList())
          {
            if (Identifier.Type != null)
            {
              if (Identifier.Type.Coding != null)
              {
                foreach (var Code in Identifier.Type.Coding.ToList())
                  _Context.Codeing.Remove(Code);
              }
              _Context.CodeableConcept.Remove(Identifier.Type);
            }
            if (Identifier.Period != null)
              _Context.Period.Remove(Identifier.Period);

            _Context.Identifier.Remove(Identifier);
          }
        }

        //Add the new Identifiers
        DbPatientResource.Identifier = NewPatientResource.Identifier;
        
        //Birth date
        DbPatientResource.BirthDate = NewPatientResource.BirthDate;
        
        //Set the past Current resource to not current
        DbPatientResource.Resources.SingleOrDefault(x => x.IsCurrent == true).IsCurrent = false;

        //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
        //It is also set to current as the instance is populated.
        var InboundResource = NewPatientResource.Resources.SingleOrDefault(x => x.IsCurrent == true);
        InboundResource.Version = ResourceVersion;
        InboundResource.Received = (DateTimeOffset)Patient.Meta.LastUpdated;
        InboundResource.IsCurrent = true;
        DbPatientResource.Resources.Add(InboundResource);

        this.Save();

        scope.Complete();
      }
      return "";
    }

    public void UpdateResouceAsDeleted(string FhirResourceId)
    {
      var DbResource = _Context.Resource.SingleOrDefault(x => x.IsCurrent && x.PatientResource.FhirResourceId == FhirResourceId);
      //var DbPatientResource = _Context.PatientResource.Single(x => x.FhirResourceId == FhirResourceId);

      using (var scope = new TransactionScope())
      {

        DbResource.IsCurrent = false;

        var NewResource = new DataModel.Model.Resource();
        NewResource.IsDeleted = true;
        NewResource.IsCurrent = true;
        NewResource.Xml = string.Empty;
        NewResource.Version = DbResource.Version + 1;
        NewResource.Received = DateTimeOffset.Now;

        DbResource.PatientResource.Resources.Add(NewResource);

        this.Save();

        scope.Complete();
      }
    }

    public Bundle SearchByFhirId(string _Id)
    {
      Dictionary<string, SqlTable> TableDic = new Dictionary<string, SqlTable>();
      TableDic.Add(DbInfo.Resource.TableNameIs, new SqlTable(DbInfo.Resource.TableNameIs, "R"));
      TableDic.Add(DbInfo.PatientResource.TableNameIs, new SqlTable(DbInfo.PatientResource.TableNameIs, "PR"));

      var Query = new SqlForge.Query.Query();

      var Select = new Select();
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Xml));
      Query.Select = Select;

      var From = new From();
      From.AddTable(TableDic[DbInfo.Resource.TableNameIs]);
      Query.From = From;

      var Join = new Join();
      Join.AddJoin(TableDic[DbInfo.PatientResource.TableNameIs], TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id), TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Id));
      Query.Join = Join;

      var Where = new Where();
      Where.AddCondition(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent), Enums.Sign.Equal, "1");
      Where.AddOperator(Enums.Operator.AND);
      Where.AddCondition(TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.FhirResourceId), Enums.Sign.Equal, "@FhirId");
      Query.Where = Where;

      string SqlQueryGetXml = Query.CreateQuery();

      var FhirID = new SqlParameter("FhirId", _Id);
      object[] parameters = new object[] { FhirID };

      Bundle oBundle = new Bundle() { Type = Bundle.BundleType.Searchset};

      var PatientXmlList = _Context.Database.SqlQuery<string>(SqlQueryGetXml, parameters);

      foreach (var Xml in PatientXmlList)
      {
        var PatientResource = Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(Xml) as Patient;
        
        //Three Changes below implemented on re-base to DSTU 2.1
        //Bundle.BundleEntryComponent oResEntry = new Bundle.BundleEntryComponent();
        Bundle.EntryComponent oResEntry = new Bundle.EntryComponent();

        //oResEntry.Search = new Bundle.BundleEntrySearchComponent();
        oResEntry.Search = new Bundle.SearchComponent();

        oResEntry.Search.Mode = Bundle.SearchEntryMode.Match;
        oResEntry.Resource = PatientResource;
        //oResEntry.Link = new List<Bundle.BundleLinkComponent>();
        oResEntry.Link = new List<Bundle.LinkComponent>();
        oBundle.Entry.Add(oResEntry);
      }

      return oBundle;

    }

    public Bundle SearchByFamilyAndGiven(string Family, string Given, string Name, string Phonetic, int PageRequired, Uri RequestUri)
    {
      //Tables            
      Dictionary<string, SqlTable> TableDic = new Dictionary<string, SqlTable>();
      TableDic.Add(DbInfo.Resource.TableNameIs, new SqlTable(DbInfo.Resource.TableNameIs, "R"));
      TableDic.Add(DbInfo.PatientResource.TableNameIs, new SqlTable(DbInfo.PatientResource.TableNameIs, "PR"));
      TableDic.Add(DbInfo.HumanName.TableNameIs, new SqlTable(DbInfo.HumanName.TableNameIs, "H"));
      TableDic.Add(DbInfo.Family.TableNameIs, new SqlTable(DbInfo.Family.TableNameIs, "F"));
      TableDic.Add(DbInfo.Given.TableNameIs, new SqlTable(DbInfo.Given.TableNameIs, "G"));

      var HumanNameQuery = SetupHumanNameQuery(TableDic);
      
      var Where = new Where();

      Where.AddCondition(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent), Enums.Sign.Equal, "1");
      Where.AddOperator(Enums.Operator.AND);

      if (Family != string.Empty)
      {
        Where.AddCondition(TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.Value), Enums.Sign.Equal, "@family");
        Where.AddOperator(Enums.Operator.AND);
      }

      if (Given != string.Empty)
      {
        Where.AddCondition(TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.Value), Enums.Sign.Equal, "@given");
        Where.AddOperator(Enums.Operator.AND);
      }

      if (Name != string.Empty)
      {
        //Condition = F.Value + ' ' +  G.Value LIKE '%Zachary MIllar%
        string Condition = "{0} + ' ' + {1} {2} '%'+{3}+'%'";
        string ConditionFamilyGiven = String.Format(Condition, StringSupport.Property(TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.Value)),
                                                                                 StringSupport.Property(TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.Value)),
                                                                                 StringSupport.SignToString(Enums.Sign.Like),
                                                                                 "@name");

        //F.Value + ' ' +  G.Value LIKE '%Zachary MIllar%
        string ConditionGivenFamily = String.Format(Condition, StringSupport.Property(TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.Value)),
                                                                                 StringSupport.Property(TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.Value)),
                                                                                 StringSupport.SignToString(Enums.Sign.Like),
                                                                                 "@name");

        Where.AddCondition(ConditionFamilyGiven);
        Where.AddOperator(Enums.Operator.OR);
        Where.AddCondition(ConditionGivenFamily);
      }

      if (Phonetic != string.Empty)
      {                
        string Condition = "SOUNDEX({0}) = SOUNDEX({1} + ' ' + {2})";
        string ConditionFamilyGiven = String.Format(Condition, "@Phonetic", 
                                                                StringSupport.Property(TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.Value)),
                                                                StringSupport.Property(TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.Value)));

        
        string ConditionGivenFamily = String.Format(Condition, "@Phonetic",
                                                                StringSupport.Property(TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.Value)),
                                                                StringSupport.Property(TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.Value)));

        Where.AddCondition(ConditionFamilyGiven);
        Where.AddOperator(Enums.Operator.OR);
        Where.AddCondition(ConditionGivenFamily);
      }

      HumanNameQuery.Where = Where;

     

      var GroupBy = new GroupBy();
      GroupBy.AddGroup(TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.FhirResourceId));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Xml));
      HumanNameQuery.GroupBy = GroupBy;
     

      var OrderBy = new OrderBy();
      OrderBy.AddOrder(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      HumanNameQuery.OrderBy = OrderBy;
     
      int NumberOfRecordsPerPage = 10;            
      var Paging = new Paging(PageRequired, NumberOfRecordsPerPage);
      HumanNameQuery.Paging = Paging;



      string SqlQueryGetXml = HumanNameQuery.CreateQuery();

      //Query to get total Record count for previous query
      var CountSQL = new SqlForge.Query.Query();
      
      //Clear Paging and OrderBy for the count query
      HumanNameQuery.Paging = null;
      HumanNameQuery.OrderBy = null;

      var SelectCount = new Select();
      SelectCount.AddCountAll();
      CountSQL.Select = SelectCount;
      //New From that takes the previous query as the sub query
      var CountFrom = new From();
      CountFrom.AddSubQuery(HumanNameQuery.CreateQuery());
      CountSQL.From = CountFrom;

      string SqlQueryCount = CountSQL.CreateQuery();

      //Silly but each SqlParameter instance must be unique to a SqlQuery.
      var FamilyParam1 = new SqlParameter("family", Family);
      var GivenParam1 = new SqlParameter("given", Given);
      var NameParam1 = new SqlParameter("name", Name);
      var PhoneticParam1 = new SqlParameter("phonetic", Phonetic);

      var FamilyParam2 = new SqlParameter("family", Family);
      var GivenParam2 = new SqlParameter("given", Given);
      var NameParam2 = new SqlParameter("name", Name);
      var PhoneticParam2 = new SqlParameter("phonetic", Phonetic);

      object[] parameters1 = new object[] { FamilyParam1, GivenParam1, NameParam1, PhoneticParam1 };
      object[] parameters2 = new object[] { FamilyParam2, GivenParam2, NameParam2, PhoneticParam2 };


      Bundle oBundle = new Bundle() { Type = Bundle.BundleType.Searchset };
      
      oBundle.Total = _Context.Database.SqlQuery<int>(SqlQueryCount, parameters1).SingleOrDefault();

      //Paging   
      int LastPageNumber = Paging.GetLastPageNumber(NumberOfRecordsPerPage, oBundle.Total ?? 0);
      oBundle.FirstLink = Paging.GetPageNavigationUri(RequestUri, 1);
      oBundle.LastLink = Paging.GetPageNavigationUri(RequestUri, LastPageNumber);
      oBundle.NextLink = Paging.GetPageNavigationUri(RequestUri, Paging.GetNextPageNumber(PageRequired, LastPageNumber));
      oBundle.PreviousLink = Paging.GetPageNavigationUri(RequestUri, Paging.GetPreviousPageNumber(PageRequired, LastPageNumber));
      
      var PatientXmlList = _Context.Database.SqlQuery<string>(SqlQueryGetXml, parameters2);

      foreach (var Xml in PatientXmlList)
      {
        var PatientResource = Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(Xml) as Patient;
        Bundle.EntryComponent oResEntry = new Bundle.EntryComponent();
        oResEntry.Search = new Bundle.SearchComponent();
        oResEntry.Search.Mode = Bundle.SearchEntryMode.Match;
        oResEntry.Resource = PatientResource;
        oResEntry.Link = new List<Bundle.LinkComponent>();

        oBundle.Entry.Add(oResEntry);
      }

      return oBundle;

    }

    private SqlForge.Query.Query SetupHumanNameQuery(Dictionary<string, SqlTable> TableDic)
    {
      var Query = new SqlForge.Query.Query();
      
      var Select = new Select();
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Xml));
      Query.Select = Select;

      var From = new From();
      From.AddTable(TableDic[DbInfo.Resource.TableNameIs]);
      Query.From = From;

      var Join = new Join();
      Join.AddJoin(TableDic[DbInfo.PatientResource.TableNameIs], TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id), TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Id));
      Join.AddJoin(TableDic[DbInfo.HumanName.TableNameIs], TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Id), TableDic[DbInfo.HumanName.TableNameIs].Prop(DbInfo.HumanName.PatientResource_Id));
      Join.AddJoin(TableDic[DbInfo.Family.TableNameIs], TableDic[DbInfo.HumanName.TableNameIs].Prop(DbInfo.HumanName.Id), TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.HumanName_Id));
      Join.AddJoin(TableDic[DbInfo.Given.TableNameIs], TableDic[DbInfo.HumanName.TableNameIs].Prop(DbInfo.HumanName.Id), TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.HumanName_Id));
      Query.Join = Join;

      return Query;
    }

    private PatientResource PopulatePatientResourceEntity(int ResourceVersion, Patient FhirPatient)
    {
      var ResourceXml = new DataModel.Model.Resource();
      ResourceXml.Xml = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(FhirPatient);
      ResourceXml.Received = (DateTimeOffset)FhirPatient.Meta.LastUpdated;
      ResourceXml.Version = ResourceVersion;
      ResourceXml.IsCurrent = true;
      ResourceXml.IsDeleted = false;

      var DbResourcePatient = new PatientResource();
      DbResourcePatient.Resources.Add(ResourceXml);
      DbResourcePatient.FhirResourceId = FhirPatient.Id;
      DbResourcePatient.Gender = FhirPatient.Gender;

      if (FhirPatient.Identifier != null)
      {
        DbResourcePatient.Identifier = new List<Model.Identifier>();
        foreach (var FhirIdentifier in FhirPatient.Identifier)
        {
          var DbIdentifier = new Model.Identifier();

          DbIdentifier.Use = FhirIdentifier.Use;
          DbIdentifier.System = FhirIdentifier.System;
          DbIdentifier.Value = FhirIdentifier.Value;

          if (FhirIdentifier.Type != null)
          {
            DbIdentifier.Type = new Model.CodeableConcept();
            DbIdentifier.Type.Text = FhirIdentifier.Type.Text;

            if (FhirIdentifier.Type.Coding != null)
            {
              DbIdentifier.Type.Coding = new List<Model.Coding>();
              foreach (var FhirCodeing in FhirIdentifier.Type.Coding)
              {
                var DbCoding = new Model.Coding();
                DbCoding.System = FhirCodeing.System;
                DbCoding.Version = FhirCodeing.Version;
                DbCoding.Code = FhirCodeing.Code;
                DbCoding.Display = FhirCodeing.Display;
                if (FhirCodeing.UserSelected != null)
                  DbCoding.UserSelected = (bool)FhirCodeing.UserSelected;
                DbIdentifier.Type.Coding.Add(DbCoding);
              }
            }
          }

          if (FhirIdentifier.Period != null)
          {
            DbIdentifier.Period = new Model.Period();
            if (FhirIdentifier.Period.Start != null && FhirDateTime.IsValidValue(FhirIdentifier.Period.Start))
              DbIdentifier.Period.Start = FhirIdentifier.Period.StartElement.ToDateTimeOffset();
            if (FhirIdentifier.Period.End != null && FhirDateTime.IsValidValue(FhirIdentifier.Period.End))
              DbIdentifier.Period.End = FhirIdentifier.Period.EndElement.ToDateTimeOffset();
          }
          DbResourcePatient.Identifier.Add(DbIdentifier);
        }
      }

      foreach (var FhirName in FhirPatient.Name)
      {
        var DbHumanName = new Model.HumanName();

        if (FhirName.Text != null)
          DbHumanName.Text = FhirName.Text;

        if (FhirName.Family != null)
          foreach (var family in FhirName.Family)
            DbHumanName.Family.Add(new Family() { Value = family });

        if (FhirName.Given != null)
          foreach (var Given in FhirName.Given)
            DbHumanName.Given.Add(new Given() { Value = Given });
        
        if (FhirName.Use != null)
          DbHumanName.Use = FhirName.Use;
        else
          DbHumanName.Use = null;

        if (FhirName.Period != null)
        {
          DbHumanName.Period = new DataModel.Model.Period();

          if (FhirName.Period.StartElement != null)
            if (FhirDateTime.IsValidValue(FhirName.Period.Start))
              DbHumanName.Period.Start = DateTimeOffset.Parse(FhirName.Period.Start);
          else
            DbHumanName.Period.Start = null;

          if (FhirName.Period.EndElement != null)
            if (FhirDateTime.IsValidValue(FhirName.Period.End))
              DbHumanName.Period.End = DateTimeOffset.Parse(FhirName.Period.End);
          else
            DbHumanName.Period.End = null;

        }

        DbResourcePatient.HumanName.Add(DbHumanName);
        
        DateTime FhirBirthDate;
        if (DateTime.TryParse(FhirPatient.BirthDate, out FhirBirthDate))
          DbResourcePatient.BirthDate = FhirBirthDate;
        //else
          //throw error
      }
      return DbResourcePatient;
    }



  }
}



