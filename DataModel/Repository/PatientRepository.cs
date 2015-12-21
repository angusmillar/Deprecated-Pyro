using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Linq.Expressions;
using DataModel.Interface;
using DataModel.Model;
using Fhir = Hl7.Fhir.Model;
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

    public string AddResource(Fhir.Patient Patient)
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

    public Fhir.Patient GetCurrentResource(string FhirResourceId)
    {
      var Xml = (from x in _Context.Resource where x.PatientResource.FhirResourceId == FhirResourceId && x.IsCurrent == true && x.IsDeleted == false select x.Xml).SingleOrDefault();
      if (Xml != null)
        return Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(Xml) as Fhir.Patient;
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

    public string UpdateResource(int ResourceVersion, Fhir.Patient Patient)
    {
      //##issues## Check  if (entry.State != EntityState.Modified) here to see if not change results in modified
      var NewPatientResource = this.PopulatePatientResourceEntity(ResourceVersion, Patient);
      var DbPatientResource = _Context.PatientResource.Single(x => x.FhirResourceId == Patient.Id);
      using (var scope = new TransactionScope())
      {
        //Delete the old HumanNames and any Periods 
        foreach (var Name in DbPatientResource.HumanNames)
        {
          if (Name.Period != null)
            _Context.Period.Remove(Name.Period);
          _Context.HumanName.Remove(Name);
        }

        //Add the new HumanNames
        DbPatientResource.HumanNames = NewPatientResource.HumanNames;

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

        var NewResource = new Resource();
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

    public Fhir.Bundle SearchByFamily(string family)
    {
      string given = "Zachary";

      //Tables            
      var TRes = new SqlTable(DbInfo.Resource.TableNameIs, "R");
      var TPatRes = new SqlTable(DbInfo.PatientResource.TableNameIs, "PR");
      var THuman = new SqlTable(DbInfo.HumanName.TableNameIs, "H");
      var TFamily = new SqlTable(DbInfo.Family.TableNameIs, "F");
      var TGiven = new SqlTable(DbInfo.Given.TableNameIs, "G");

      var Select = new Select();
      Select.AddProp(TRes.Prop(DbInfo.Resource.Xml));     
      
      var From = new From();
      From.AddTable(TRes);
      

      var Join = new Join();
      Join.AddJoin(TPatRes, TRes.Prop(DbInfo.Resource.PatientResourceId), TPatRes.Prop(DbInfo.PatientResource.Id));
      Join.AddJoin(THuman, TPatRes.Prop(DbInfo.PatientResource.Id), THuman.Prop(DbInfo.HumanName.PatientResourceId));
      Join.AddJoin(TFamily, THuman.Prop(DbInfo.HumanName.Id), TFamily.Prop(DbInfo.Family.HumanNameId));
      Join.AddJoin(TGiven, THuman.Prop(DbInfo.HumanName.Id), TGiven.Prop(DbInfo.Given.HumanNameId));      

      var Where = new Where();
      if (family != string.Empty)
      {
        Where.AddCondition(TFamily.Prop(DbInfo.Family.Value), Enums.Sign.Equal, "@family");
        Where.AddOperator(Enums.Operator.AND);
      }

      if (given != string.Empty)
      {
        Where.AddCondition(TGiven.Prop(DbInfo.Given.Value), Enums.Sign.Equal, "@given");
        Where.AddOperator(Enums.Operator.AND);
      }     
      

      var OrderBy = new OrderBy();
      OrderBy.AddOrder(TRes.Prop(DbInfo.Resource.Received));      
      
      var Paging = new Paging(1, 10);
      
      var sql = new Query();
      sql.Select = Select;
      sql.From = From;
      sql.Join = Join;
      sql.Where = Where;
      sql.OrderBy = OrderBy;
      sql.Paging = Paging;

      string SqlQueryGetXml = sql.CreateQuery();

      var SelectCount = new Select();
      SelectCount.AddCountAll();
      sql.Select = SelectCount;
      sql.OrderBy = null;
      sql.Paging = null;

      string SqlQueryCount = sql.CreateQuery();


      SqlParameter FamilyParam1 = new SqlParameter("family", family);
      SqlParameter GivenParam1 = new SqlParameter("given", given);

      SqlParameter FamilyParam2 = new SqlParameter("family", family);
      SqlParameter GivenParam2 = new SqlParameter("given", given);
      
      object[] parameters1 = new object[] { FamilyParam1, GivenParam1};
      object[] parameters2 = new object[] { FamilyParam2, GivenParam2 };


      Fhir.Bundle oBundle = new Fhir.Bundle() { Type = Fhir.Bundle.BundleType.Searchset };
      
      oBundle.Total = _Context.Database.SqlQuery<int>(SqlQueryCount, parameters1).SingleOrDefault();
      
      oBundle.Link = new List<Fhir.Bundle.BundleLinkComponent>();
      var TestLink = new Fhir.Bundle.BundleLinkComponent();
      TestLink.Relation = "first";
      //If I have the request URL I can just append the page=? info.
      TestLink.Url = "http://ThisNeedsToBeMyBlazeServerURL/Patient?name=peter&stateid=23&page=1";

      oBundle.Link.Add(TestLink);

      var PatientXmlList = _Context.Database.SqlQuery<string>(SqlQueryGetXml, parameters2);

      foreach (var Xml in PatientXmlList)
      {
        var PatientResource = Hl7.Fhir.Serialization.FhirParser.ParseResourceFromXml(Xml) as Fhir.Patient;
        Fhir.Bundle.BundleEntryComponent oResEntry = new Fhir.Bundle.BundleEntryComponent();
        oResEntry.Search = new Fhir.Bundle.BundleEntrySearchComponent();
        oResEntry.Search.Mode = Fhir.Bundle.SearchEntryMode.Match;
        oResEntry.Resource = PatientResource;
        oResEntry.Link = new List<Fhir.Bundle.BundleLinkComponent>();

        oBundle.Entry.Add(oResEntry);
      }

      return oBundle;

    }

    private PatientResource PopulatePatientResourceEntity(int ResourceVersion, Fhir.Patient Patient)
    {
      var ResourceXml = new Resource();
      ResourceXml.Xml = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(Patient);
      ResourceXml.Received = (DateTimeOffset)Patient.Meta.LastUpdated;
      ResourceXml.Version = ResourceVersion;
      ResourceXml.IsCurrent = true;
      ResourceXml.IsDeleted = false;

      var oResourcePatient = new PatientResource();
      oResourcePatient.Resources.Add(ResourceXml);
      oResourcePatient.FhirResourceId = Patient.Id;
      oResourcePatient.Gender = Patient.Gender;

      foreach (var Name in Patient.Name)
      {
        var HumanName = new Model.HumanName();

        if (Name.Text != null)
          HumanName.Text = Name.Text;

        if (Name.Family != null)
          foreach (var family in Name.Family)
            HumanName.Family.Add(new Family() { Value = family });

        if (Name.Given != null)
          foreach (var Given in Name.Given)
            HumanName.Given.Add(new Given() { Value = Given });

        if (Name.Prefix != null)
          foreach (var Prefix in Name.Prefix)
            HumanName.Prefix.Add(new Prefix() { Value = Prefix });

        if (Name.Suffix != null)
          foreach (var Suffix in Name.Suffix)
            HumanName.Suffix.Add(new Suffix() { Value = Suffix });

        if (Name.Use != null)
          HumanName.Use = Name.Use;
        else
          HumanName.Use = null;

        if (Name.Period != null)
        {
          HumanName.Period = new Period();
          if (Name.Period.StartElement != null)
            HumanName.Period.Start = DateTimeOffset.Parse(Name.Period.Start);
          else
            HumanName.Period.Start = null;

          if (Name.Period.EndElement != null)
            HumanName.Period.End = DateTimeOffset.Parse(Name.Period.End);
          else
            HumanName.Period.End = null;
        }

        oResourcePatient.HumanNames.Add(HumanName);
      }
      return oResourcePatient;
    }



  }
}



