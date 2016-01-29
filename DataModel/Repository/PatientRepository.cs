using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using DataModel.Model;
using Hl7.Fhir.Model;
using BusinessEntities;
using Dip.Interfaces;
using SqlForge.Query;
using SqlForge.Support;
using DataModel.ModelExtend;

namespace DataModel.Repository
{
  class PatientRepository : BaseRepository, Dip.Interfaces.IPatientRepository
  {
    private int _NumberOfRecordsPerPage = 10;

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
      return Patient.Id;
    }

    public IDatabaseOperationOutcome GetCurrentResource(string FhirResourceId)
    {
      IDatabaseOperationOutcome oDatabaseOperationOutcome = new DatabaseOperationOutcome();             
      //var oResource = (from x in _Context.Resource where x.PatientResource.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == false select x).SingleOrDefault();
      var oResource = (from x in _Context.Resource where x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == false select x).SingleOrDefault();
      if (oResource != null)
      {          
        oDatabaseOperationOutcome.ResourceMatchingSearch = new DtoResource();
        oDatabaseOperationOutcome.ResourceMatchingSearch.FhirResourceType = typeof(Patient);
        oDatabaseOperationOutcome.ResourceMatchingSearch.Id = oResource.Id;
        oDatabaseOperationOutcome.ResourceMatchingSearch.IsCurrent = oResource.IsCurrent;
        oDatabaseOperationOutcome.ResourceMatchingSearch.IsDeleted = oResource.IsDeleted;
        oDatabaseOperationOutcome.ResourceMatchingSearch.Received = oResource.Received;
        oDatabaseOperationOutcome.ResourceMatchingSearch.Version = oResource.Version;
        oDatabaseOperationOutcome.ResourceMatchingSearch.Xml = oResource.Xml;          
      }
      return oDatabaseOperationOutcome;
    }

    public int GetResourceCurrentVersion(string FhirResourceId)
    {
      return _Context.Resource.SingleOrDefault(x => x.ResourceIdentity.FhirResourceId == FhirResourceId && x.IsCurrent == true).Version;
    }

    public string UpdateResource(int ResourceVersion, Patient Patient)
    {
      //##issues## Check  if (entry.State != EntityState.Modified) here to see if not change results in modified
      var NewPatientResource = this.PopulatePatientResourceEntity(ResourceVersion, Patient);

      //Load the Patient Resource db record, remember this is the single Patient not the many history versions on the Resource so no need for IsCurrent
      var DbPatientResource = (from p in _Context.PatientResource
                               .Include(x => x.ResourceIdentity)
                                .Include(x => x.HumanName)
                                .Include(x => x.Identifier.Select(y => y.Type).Select(b => b.Coding))
                               where p.ResourceIdentity.FhirResourceId == Patient.Id
                               select p).FirstOrDefault();


      using (var scope = new TransactionScope())
      {

        //Active
        DbPatientResource.Active = NewPatientResource.Active;
        //DbPatientResource.Active = NewPatientResource.Active;

        //Birth date
        DbPatientResource.BirthDate = NewPatientResource.BirthDate;
        //DbPatientResource.BirthDate = NewPatientResource.BirthDate;

        //Gender (Sex)
        //DbPatientResource.Gender = NewPatientResource.Gender;
        DbPatientResource.Gender = NewPatientResource.Gender;

        //Delete the old HumanNames and any Periods 
        //foreach (var Name in DbPatientResource.HumanName.ToList())
        //{
        //  if (Name.Period != null)
        //    _Context.Period.Remove(Name.Period);
        //  _Context.HumanName.Remove(Name);
        //}

        foreach (var Name in DbPatientResource.HumanName.ToList())
        {
          if (Name.Period != null)
            _Context.Period.Remove(Name.Period);
          _Context.HumanName.Remove(Name);
        }

        //Add the new HumanNames
        //DbPatientResource.HumanName = NewPatientResource.HumanName;
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

        //Set the past Current resource to not current
        DbPatientResource.Resources.SingleOrDefault(x => x.IsCurrent == true).IsCurrent = false;

        //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
        //It is also set to current as the instance is populated.
        var InboundResource = NewPatientResource.Resources.SingleOrDefault(x => x.IsCurrent == true);
        InboundResource.Version = ResourceVersion;
        InboundResource.Received = (DateTimeOffset)Patient.Meta.LastUpdated;
        InboundResource.IsCurrent = true;
        InboundResource.ResourceIdentity = DbPatientResource.ResourceIdentity;
        DbPatientResource.Resources.Add(InboundResource);

        this.Save();

        scope.Complete();
      }
      return "";
    }

    public void UpdateResouceAsDeleted(string FhirResourceId)
    {

      var DbResource = (from r in _Context.Resource
                                .Include(x => x.ResourceIdentity)
                                .Include(x => x.PatientResource)
                                .Include(x => x.PatientResource.HumanName)
                                .Include(x => x.PatientResource.Identifier.Select(y => y.Type).Select(b => b.Coding))
                               where r.ResourceIdentity.FhirResourceId == FhirResourceId && r.IsCurrent == true 
                               select r).FirstOrDefault();

      //var DbResource = _Context.Resource.SingleOrDefault(x => x.IsCurrent && x.PatientResource.FhirResourceId == FhirResourceId);
      //var DbPatientResource = _Context.PatientResource.Single(x => x.FhirResourceId == FhirResourceId);

      using (var scope = new TransactionScope())
      {
        //=======================================================================
        DbResource.IsCurrent = false;
        
        //Active
        DbResource.PatientResource.Active = null;

        //Birth date
        DbResource.PatientResource.BirthDate = null;

        //Gender (Sex)
        DbResource.PatientResource.Gender = null;

        //Delete the old HumanNames and any Periods 
        foreach (var Name in DbResource.PatientResource.HumanName.ToList())
        {
          if (Name.Period != null)
            _Context.Period.Remove(Name.Period);
          _Context.HumanName.Remove(Name);
        }
        
        //Delete the old Identifiers
        if (DbResource.PatientResource.Identifier != null)
        {
          foreach (var Identifier in DbResource.PatientResource.Identifier.ToList())
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
                
        
        //=======================================================================
        //DbResource.IsCurrent = false;

        var NewResource = new DataModel.Model.Resource();
        NewResource.IsDeleted = true;
        NewResource.IsCurrent = true;
        NewResource.Xml = string.Empty;
        NewResource.Version = DbResource.Version + 1;
        NewResource.Received = DateTimeOffset.Now;
        NewResource.ResourceIdentity = DbResource.ResourceIdentity;
        NewResource.PatientResource = DbResource.PatientResource;
        
        //DbResource.PatientResource.Resources.Add(NewResource);
        //DbResource.ResourceIdentity.Resource.Add(NewResource);
        
        _Context.Resource.Add(NewResource);
        
        this.Save();

        scope.Complete();
      }
    }

    public IDatabaseOperationOutcome SearchByFhirId(string _Id, Tuple<string, string> ActiveSystemAndCode)
    {
      Dictionary<string, SqlTable> TableDic = new Dictionary<string, SqlTable>();
      TableDic.Add(DbInfo.Resource.TableNameIs, new SqlTable(DbInfo.Resource.TableNameIs, "R"));
      TableDic.Add(DbInfo.PatientResource.TableNameIs, new SqlTable(DbInfo.PatientResource.TableNameIs, "PR"));

      var Query = new SqlForge.Query.Query();

      var Select = new Select();
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Id));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsDeleted));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Version));
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

      var oParameterDictionary = new Dictionary<string, object>();

      oParameterDictionary.Add("FhirId", _Id);

      if (ActiveSystemAndCode != null)
      {
        if (ActiveSystemAndCode.Item2 != null)
        {
          //The System is implicitly http://hl7.org/fhir/special-values which in this case is True or False
          bool ActiveCode;
          Boolean.TryParse(ActiveSystemAndCode.Item2, out ActiveCode);
          oParameterDictionary.Add("ActiveCode", ActiveCode);
          Where.AddCondition(TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Active), Enums.Sign.Equal, "@ActiveCode");
          Where.AddOperator(Enums.Operator.AND);
        }
      }

      object[] parameters = SqlForge.Support.ParameterSupport.GetParameter(oParameterDictionary);

      DatabaseOperationOutcome oDatabaseOperationOutcome;
      var dbResourceList = new List<Model.Resource>();
      
      dbResourceList = _Context.Resource.SqlQuery(SqlQueryGetXml, parameters).ToList();      

      oDatabaseOperationOutcome = new DatabaseOperationOutcome();
      oDatabaseOperationOutcome.ResourcesMatchingSearchList = new List<DtoResource>(); 
      dbResourceList.ForEach( x => oDatabaseOperationOutcome.ResourcesMatchingSearchList.Add(x.GetDto()));
      oDatabaseOperationOutcome.NumberOfRecordsPerPage = _NumberOfRecordsPerPage;
      oDatabaseOperationOutcome.PageRequested = 1;
      oDatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;

      return oDatabaseOperationOutcome;

    }

    public IDatabaseOperationOutcome SearchByFamilyAndGiven(string Family, string Given, string Name, string Phonetic, Tuple<string, string> ActiveSystemAndCode, int PageRequired)
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

      var oParameterDictionary = new Dictionary<string, object>();
      if (Family != string.Empty)
      {
        oParameterDictionary.Add("family", Family);
        Where.AddCondition(TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.Value), Enums.Sign.Equal, "@family");
        Where.AddOperator(Enums.Operator.AND);
      }

      if (Given != string.Empty)
      {
        oParameterDictionary.Add("given", Given);
        Where.AddCondition(TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.Value), Enums.Sign.Equal, "@given");
        Where.AddOperator(Enums.Operator.AND);
      }

      if (Name != string.Empty)
      {
        var NameWhere = new Where();

        oParameterDictionary.Add("name", Name);
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

        NameWhere.AddCondition(ConditionFamilyGiven);
        NameWhere.AddOperator(Enums.Operator.OR);
        NameWhere.AddCondition(ConditionGivenFamily);
        Where.AddSubCondition(NameWhere);
        Where.AddOperator(Enums.Operator.AND);
      }

      if (Phonetic != string.Empty)
      {
        var PhoneticWhere = new Where();
        oParameterDictionary.Add("Phonetic", Phonetic);
        string Condition = "SOUNDEX({0}) = SOUNDEX({1} + ' ' + {2})";
        string ConditionFamilyGiven = String.Format(Condition, "@Phonetic",
                                                                StringSupport.Property(TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.Value)),
                                                                StringSupport.Property(TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.Value)));


        string ConditionGivenFamily = String.Format(Condition, "@Phonetic",
                                                                StringSupport.Property(TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.Value)),
                                                                StringSupport.Property(TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.Value)));

        PhoneticWhere.AddCondition(ConditionFamilyGiven);
        PhoneticWhere.AddOperator(Enums.Operator.OR);
        PhoneticWhere.AddCondition(ConditionGivenFamily);
        Where.AddSubCondition(PhoneticWhere);
        Where.AddOperator(Enums.Operator.AND);
      }

      if (ActiveSystemAndCode != null)
      {
        //The System is implicitly http://hl7.org/fhir/special-values which in this case is True or False
        if (ActiveSystemAndCode.Item2 != null)
        {
          bool ActiveCode;
          Boolean.TryParse(ActiveSystemAndCode.Item2, out ActiveCode);
          oParameterDictionary.Add("ActiveCode", ActiveCode);
          Where.AddCondition(TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Active), Enums.Sign.Equal, "@ActiveCode");
          Where.AddOperator(Enums.Operator.AND);
        }
      }

      HumanNameQuery.Where = Where;

      var GroupBy = new GroupBy();
      GroupBy.AddGroup(TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.FhirResourceId));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Id));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsDeleted));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Version));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Xml));


      HumanNameQuery.GroupBy = GroupBy;


      var OrderBy = new OrderBy();
      OrderBy.AddOrder(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      HumanNameQuery.OrderBy = OrderBy;

      var Paging = new Paging(PageRequired, _NumberOfRecordsPerPage);
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

      //New 'From' that takes the previous query as the sub query
      var CountFrom = new From();
      CountFrom.AddSubQuery(HumanNameQuery.CreateQuery());
      CountSQL.From = CountFrom;

      DatabaseOperationOutcome oDatabaseOperationOutcome;
      var dbResourceList = new List<Model.Resource>();
      object[] parameters2 = SqlForge.Support.ParameterSupport.GetParameter(oParameterDictionary);
      dbResourceList = _Context.Resource.SqlQuery(SqlQueryGetXml, parameters2).ToList();

      string SqlQueryCount = CountSQL.CreateQuery();
      object[] parameters1 = SqlForge.Support.ParameterSupport.GetParameter(oParameterDictionary);
      int SearchResultCount = 0;
      SearchResultCount = _Context.Database.SqlQuery<int>(SqlQueryCount, parameters1).SingleOrDefault();

      oDatabaseOperationOutcome = new DatabaseOperationOutcome();
      oDatabaseOperationOutcome.ResourcesMatchingSearchList = new List<DtoResource>();
      dbResourceList.ForEach(x => oDatabaseOperationOutcome.ResourcesMatchingSearchList.Add(x.GetDto()));
      oDatabaseOperationOutcome.NumberOfRecordsPerPage = _NumberOfRecordsPerPage;
      oDatabaseOperationOutcome.PageRequested = PageRequired;
      oDatabaseOperationOutcome.ResourcesMatchingSearchCount = SearchResultCount;

      return oDatabaseOperationOutcome;

    }

    public IDatabaseOperationOutcome SearchByIdentifier(Tuple<string, string> IdentiferSystemAndCode, Tuple<string, string> ActiveSystemAndCode, int PageRequired, Uri RequestUri)
    {

      //Tables            
      Dictionary<string, SqlTable> TableDic = new Dictionary<string, SqlTable>();
      TableDic.Add(DbInfo.Resource.TableNameIs, new SqlTable(DbInfo.Resource.TableNameIs, "R"));
      TableDic.Add(DbInfo.PatientResource.TableNameIs, new SqlTable(DbInfo.PatientResource.TableNameIs, "PR"));
      TableDic.Add(DbInfo.Identifier.TableNameIs, new SqlTable(DbInfo.Identifier.TableNameIs, "I"));

      var Query = new SqlForge.Query.Query();

      var Select = new Select();
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Id));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsDeleted));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Version));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Xml));
      Query.Select = Select;

      var From = new From();
      From.AddTable(TableDic[DbInfo.Resource.TableNameIs]);
      Query.From = From;

      var Join = new Join();
      Join.AddJoin(TableDic[DbInfo.PatientResource.TableNameIs], TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id), TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Id));
      Join.AddJoin(TableDic[DbInfo.Identifier.TableNameIs], TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Id), TableDic[DbInfo.Identifier.TableNameIs].Prop(DbInfo.Identifier.PatientResource_Id));
      Query.Join = Join;

      var Where = new Where();
      var oParameterDictionary = new Dictionary<string, object>();

      Where.AddCondition(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent), Enums.Sign.Equal, "1");
      Where.AddOperator(Enums.Operator.AND);

      if (IdentiferSystemAndCode != null)
      {
        if (IdentiferSystemAndCode.Item1 != null)
        {
          oParameterDictionary.Add("IdentiferSystem", IdentiferSystemAndCode.Item1);
          Where.AddCondition(TableDic[DbInfo.Identifier.TableNameIs].Prop(DbInfo.Identifier.System), Enums.Sign.Equal, "@IdentiferSystem");
          Where.AddOperator(Enums.Operator.AND);
        }

        if (IdentiferSystemAndCode.Item2 != null)
        {
          oParameterDictionary.Add("IdentiferCode", IdentiferSystemAndCode.Item2);
          Where.AddCondition(TableDic[DbInfo.Identifier.TableNameIs].Prop(DbInfo.Identifier.Value), Enums.Sign.Equal, "@IdentiferCode");
          Where.AddOperator(Enums.Operator.AND);
        }
      }

      if (ActiveSystemAndCode != null)
      {
        if (ActiveSystemAndCode.Item2 != null)
        {
          //The System is implicitly http://hl7.org/fhir/special-values which in this case is True or False
          bool ActiveCode;
          Boolean.TryParse(ActiveSystemAndCode.Item2, out ActiveCode);
          oParameterDictionary.Add("ActiveCode", ActiveCode);
          Where.AddCondition(TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Active), Enums.Sign.Equal, "@ActiveCode");
          Where.AddOperator(Enums.Operator.AND);
        }
      }

      Query.Where = Where;

      var GroupBy = new GroupBy();
      GroupBy.AddGroup(TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.FhirResourceId));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      GroupBy.AddGroup(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Xml));
      Query.GroupBy = GroupBy;


      var OrderBy = new OrderBy();
      OrderBy.AddOrder(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      Query.OrderBy = OrderBy;

      int NumberOfRecordsPerPage = 10;
      var Paging = new Paging(PageRequired, NumberOfRecordsPerPage);
      Query.Paging = Paging;

      string SqlQueryGetXml = Query.CreateQuery();

      //Query to get total Record count for previous query
      var CountSQL = new SqlForge.Query.Query();

      //Clear Paging and OrderBy for the count query
      Query.Paging = null;
      Query.OrderBy = null;

      var SelectCount = new Select();
      SelectCount.AddCountAll();
      CountSQL.Select = SelectCount;
      //New From that takes the previous query as the sub query
      var CountFrom = new From();
      CountFrom.AddSubQuery(Query.CreateQuery());
      CountSQL.From = CountFrom;

      DatabaseOperationOutcome oDatabaseOperationOutcome;
      var dbResourceList = new List<Model.Resource>();
      object[] parameters2 = SqlForge.Support.ParameterSupport.GetParameter(oParameterDictionary);

      dbResourceList = _Context.Resource.SqlQuery(SqlQueryGetXml, parameters2).ToList();

      string SqlQueryCount = CountSQL.CreateQuery();
      object[] parameters1 = SqlForge.Support.ParameterSupport.GetParameter(oParameterDictionary);
      int SearchResultCount = 0;

      SearchResultCount = _Context.Database.SqlQuery<int>(SqlQueryCount, parameters1).SingleOrDefault();

      oDatabaseOperationOutcome = new DatabaseOperationOutcome();
      oDatabaseOperationOutcome.ResourcesMatchingSearchList = new List<DtoResource>();
      dbResourceList.ForEach(x => oDatabaseOperationOutcome.ResourcesMatchingSearchList.Add(x.GetDto()));
      oDatabaseOperationOutcome.NumberOfRecordsPerPage = _NumberOfRecordsPerPage;
      oDatabaseOperationOutcome.PageRequested = PageRequired;
      oDatabaseOperationOutcome.ResourcesMatchingSearchCount = SearchResultCount;

      return oDatabaseOperationOutcome;
    }
   
    private SqlForge.Query.Query SetupHumanNameQuery(Dictionary<string, SqlTable> TableDic)
    {
      var Query = new SqlForge.Query.Query();

      var Select = new Select();
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Id));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsDeleted));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Version));
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

      var ResourceIdentity = new Model.ResourceIdentity();
      ResourceIdentity.FhirResourceId = FhirPatient.Id;
      
      var ResourceXml = new DataModel.Model.Resource();
      ResourceXml.Xml = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(FhirPatient);
      ResourceXml.Received = (DateTimeOffset)FhirPatient.Meta.LastUpdated;
      ResourceXml.Version = ResourceVersion;
      ResourceXml.IsCurrent = true;
      ResourceXml.IsDeleted = false;
      ResourceXml.ResourceIdentity = ResourceIdentity;            

      var DbResourcePatient = new PatientResource();
      DbResourcePatient.Resources.Add(ResourceXml);      
      DbResourcePatient.Active = FhirPatient.Active;
      DbResourcePatient.Gender = FhirPatient.Gender;
      DbResourcePatient.ResourceIdentity = ResourceIdentity;

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
          
          if (FhirName.Period.Start != null)
            DbHumanName.Period.Start = DateTimeOffset.Parse(FhirName.Period.Start);
          else
            DbHumanName.Period.Start = null;

          if (FhirName.Period.End != null)                    
            DbHumanName.Period.End = DateTimeOffset.Parse(FhirName.Period.End);                     
          else
            DbHumanName.Period.End = null;
        }

        DbResourcePatient.HumanName.Add(DbHumanName);

        if (FhirPatient.BirthDate != null)
          DbResourcePatient.BirthDate = DateTime.Parse(FhirPatient.BirthDate);
        else
          DbResourcePatient.BirthDate = null;

      }
      return DbResourcePatient;
    }
  }
}



