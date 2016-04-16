using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using DataModel.BlazeDbModel;
using DataModel.SearchParameterType;
using Hl7.Fhir.Model;
using Common.BusinessEntities;
using Common.Interfaces;
using Common.Interfaces.Repositories;
using Hl7.Fhir.Introspection;

namespace DataModel.Repository
{
  public class PatientRepository : BaseRepository, IPatientRepository
  {
    
    public PatientRepository(DataModel.BlazeDbModel.BlazeDbContext Context)
    {
      _Context = Context;
    }

    public string AddResource(Patient Patient, Uri RootUri)
    {
      var NewPatientResource = this.PopulatePatientResourceEntity(1, Patient, RootUri);
      using (var scope = new TransactionScope())
      {        
        //_Context.PatientResource.Add(NewPatientResource);
        this.Save();
        scope.Complete();
      }
      return Patient.Id;
    }

    //Stay in Patient
    public string UpdateResource(int ResourceVersion, Patient Patient)
    {      
      //var NewPatientResource = this.PopulatePatientResourceEntity(ResourceVersion, Patient);


      //var DbResource =   (from r in _Context.Resource
      //                    .Include(x => x.ResourceIdentity)
      //                    .Include(x => x.PatientResource)
      //                    .Include(x => x.PatientResource.HumanName)
      //                    .Include(x => x.PatientResource.Identifier.Select(y => y.Type).Select(b => b.Coding))
      //                         where r.ResourceIdentity.FhirResourceId == Patient.Id && r.IsCurrent == true
      //                         select r).FirstOrDefault();

      //if (DbResource.IsDeleted == true)
      //{
      //  using (var scope = new TransactionScope())
      //  {
      //    //== Add the Patient Structure as required =============================================          
      //    NewPatientResource.ResourceIdentity = DbResource.ResourceIdentity;
      //    DbResource.IsCurrent = false;
      //    //Value Set has nothing at present

      //    //==========================================================================================

      //    //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
      //    //It is also set to current as the instance is populated.
      //    var InboundResource = NewPatientResource.Resources.SingleOrDefault(x => x.IsCurrent == true);
      //    InboundResource.Version = ResourceVersion;
      //    InboundResource.Received = (DateTimeOffset)Patient.Meta.LastUpdated;
      //    InboundResource.IsCurrent = true;
      //    InboundResource.ResourceIdentity = DbResource.ResourceIdentity;
      //    InboundResource.PatientResource = NewPatientResource;
      //    _Context.Resource.Add(InboundResource);          

      //    this.Save();

      //    scope.Complete();
      //  }
      //  return string.Empty;
      //}
      //else
      //{
      //  using (var scope = new TransactionScope())
      //  {

      //    //Active
      //    DbResource.PatientResource.Active = NewPatientResource.Active;

      //    //Birth date
      //    DbResource.PatientResource.BirthDate = NewPatientResource.BirthDate;

      //    //Gender (Sex)        
      //    DbResource.PatientResource.Gender = NewPatientResource.Gender;

      //    //Delete the old HumanNames and any Periods         
      //    foreach (var Name in DbResource.PatientResource.HumanName.ToList())
      //    {
      //      if (Name.Period != null)
      //        _Context.Period.Remove(Name.Period);
      //      _Context.HumanName.Remove(Name);
      //    }

      //    //Add the new HumanNames        
      //    DbResource.PatientResource.HumanName = NewPatientResource.HumanName;

      //    //Delete the old Identifiers
      //    if (DbResource.PatientResource.Identifier != null)
      //    {
      //      foreach (var Identifier in DbResource.PatientResource.Identifier.ToList())
      //      {
      //        if (Identifier.Type != null)
      //        {
      //          if (Identifier.Type.Coding != null)
      //          {
      //            foreach (var Code in Identifier.Type.Coding.ToList())
      //              _Context.Codeing.Remove(Code);
      //          }
      //          _Context.CodeableConcept.Remove(Identifier.Type);
      //        }
      //        if (Identifier.Period != null)
      //          _Context.Period.Remove(Identifier.Period);

      //        _Context.Identifier.Remove(Identifier);
      //      }
      //    }

      //    //Add the new Identifiers
      //    DbResource.PatientResource.Identifier = NewPatientResource.Identifier;

      //    //Set the past Current resource to not current
      //    //DbResource.PatientResource.Resources.SingleOrDefault(x => x.IsCurrent == true).IsCurrent = false;

      //    //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
      //    //It is also set to current as the instance is populated.
      //    var InboundResource = NewPatientResource.Resources.SingleOrDefault(x => x.IsCurrent == true);
      //    InboundResource.Version = ResourceVersion;
      //    InboundResource.Received = (DateTimeOffset)Patient.Meta.LastUpdated;
      //    InboundResource.IsCurrent = true;
      //    InboundResource.ResourceIdentity = DbResource.PatientResource.ResourceIdentity;
      //    InboundResource.PatientResource = DbResource.PatientResource;
      //    _Context.Resource.Add(InboundResource);

      //    //Set the past Current Resource to not current
      //    DbResource.IsCurrent = false;
      //    //DbResource.ValueSetResource_Id = null;
      //    DbResource.PatientResource = null;

      //    this.Save();

      //    scope.Complete();
      //  }
      //  return string.Empty;
      //}
      throw new NotImplementedException();
    }

    //Stay in Patient
    public void UpdateResouceAsDeleted(string FhirResourceId)
    {

      //var DbResource = (from r in _Context.Resource
      //                          .Include(x => x.ResourceIdentity)
      //                          .Include(x => x.PatientResource)
      //                          .Include(x => x.PatientResource.HumanName)
      //                          .Include(x => x.PatientResource.Identifier.Select(y => y.Type).Select(b => b.Coding))
      //                         where r.ResourceIdentity.FhirResourceId == FhirResourceId && r.IsCurrent == true 
      //                         select r).FirstOrDefault();

      ////var DbResource = _Context.Resource.SingleOrDefault(x => x.IsCurrent && x.PatientResource.FhirResourceId == FhirResourceId);
      ////var DbPatientResource = _Context.PatientResource.Single(x => x.FhirResourceId == FhirResourceId);

      //using (var scope = new TransactionScope())
      //{
      //  //=======================================================================
                
      //  //Delete the old HumanNames and any Periods 
      //  foreach (var Name in DbResource.PatientResource.HumanName.ToList())
      //  {
      //    if (Name.Period != null)
      //      _Context.Period.Remove(Name.Period);
      //    _Context.HumanName.Remove(Name);
      //  }
        
      //  //Delete the old Identifiers
      //  if (DbResource.PatientResource.Identifier != null)
      //  {
      //    foreach (var Identifier in DbResource.PatientResource.Identifier.ToList())
      //    {
      //      if (Identifier.Type != null)
      //      {
      //        if (Identifier.Type.Coding != null)
      //        {
      //          foreach (var Code in Identifier.Type.Coding.ToList())
      //            _Context.Codeing.Remove(Code);
      //        }
      //        _Context.CodeableConcept.Remove(Identifier.Type);
      //      }
      //      if (Identifier.Period != null)
      //        _Context.Period.Remove(Identifier.Period);

      //      _Context.Identifier.Remove(Identifier);
      //    }
      //  }

        
      //  _Context.PatientResource.Remove(DbResource.PatientResource);
      //  DbResource.IsCurrent = false;        
      //  DbResource.PatientResource = null;

      //  //=======================================================================        

      //  var NewResource = new DataModel.Model.Resource();
      //  NewResource.IsDeleted = true;
      //  NewResource.IsCurrent = true;
      //  NewResource.Xml = string.Empty;
      //  NewResource.Version = DbResource.Version + 1;
      //  NewResource.Received = DateTimeOffset.Now;
      //  NewResource.ResourceType = DtoEnums.SupportedFhirResource.Patient;
      //  NewResource.ResourceIdentity = DbResource.ResourceIdentity;
      //  NewResource.PatientResource = DbResource.PatientResource;

      //  _Context.Resource.Add(NewResource);
        
      //  this.Save();

      //  scope.Complete();
      //}
      throw new NotImplementedException();
    }

    public bool ResourceExists(string FhirResourceId)
    {
      if (_Context.Res_Patient.Any(x => x.FhirId == FhirResourceId))
        return true;
      else
        return false;      
    }

    //Stay in Patient
    public IDatabaseOperationOutcome SearchByFhirId(string _Id, Tuple<string, string> ActiveSystemAndCode)
    {
      //Dictionary<string, SqlTable> TableDic = new Dictionary<string, SqlTable>();
      //TableDic.Add(DbInfo.Resource.TableNameIs, new SqlTable(DbInfo.Resource.TableNameIs, "R"));
      //TableDic.Add(DbInfo.PatientResource.TableNameIs, new SqlTable(DbInfo.PatientResource.TableNameIs, "PR"));
      //TableDic.Add(DbInfo.ResourceIdentity.TableNameIs, new SqlTable(DbInfo.ResourceIdentity.TableNameIs, "RID"));

      //var Query = new SqlForge.Query.Query();

      //var Select = new Select();
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Id));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsDeleted));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Version));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Xml));

      //Query.Select = Select;

      //var From = new From();
      //From.AddTable(TableDic[DbInfo.Resource.TableNameIs]);
      //Query.From = From;

      //var Join = new Join();
      //Join.AddJoin(TableDic[DbInfo.PatientResource.TableNameIs], TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id), TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Id));
      //Join.AddJoin(TableDic[DbInfo.ResourceIdentity.TableNameIs], TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.PatientResource.ResourceIdentity_Id), TableDic[DbInfo.ResourceIdentity.TableNameIs].Prop(DbInfo.ResourceIdentity.Id));
      //Query.Join = Join;

      //var Where = new Where();
      //Where.AddCondition(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent), Enums.Sign.Equal, "1");
      //Where.AddOperator(Enums.Operator.AND);
      //Where.AddCondition(TableDic[DbInfo.ResourceIdentity.TableNameIs].Prop(DbInfo.ResourceIdentity.FhirResourceId), Enums.Sign.Equal, "@FhirId");
      //Query.Where = Where;

      //string SqlQueryGetXml = Query.CreateQuery();

      //var oParameterDictionary = new Dictionary<string, object>();

      //oParameterDictionary.Add("FhirId", _Id);

      //if (ActiveSystemAndCode != null)
      //{
      //  if (ActiveSystemAndCode.Item2 != null)
      //  {
      //    //The System is implicitly http://hl7.org/fhir/special-values which in this case is True or False
      //    bool ActiveCode;
      //    Boolean.TryParse(ActiveSystemAndCode.Item2, out ActiveCode);
      //    oParameterDictionary.Add("ActiveCode", ActiveCode);
      //    Where.AddCondition(TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Active), Enums.Sign.Equal, "@ActiveCode");
      //    Where.AddOperator(Enums.Operator.AND);
      //  }
      //}

      //object[] parameters = SqlForge.Support.ParameterSupport.GetParameter(oParameterDictionary);

      //DatabaseOperationOutcome oDatabaseOperationOutcome;
      //var dbResourceList = new List<Model.Resource>();
      
      //dbResourceList = _Context.Resource.SqlQuery(SqlQueryGetXml, parameters).ToList();      

      //oDatabaseOperationOutcome = new DatabaseOperationOutcome();
      //oDatabaseOperationOutcome.ResourcesMatchingSearchList = new List<DtoResource>(); 
      //dbResourceList.ForEach( x => oDatabaseOperationOutcome.ResourcesMatchingSearchList.Add(x.GetDto()));
      //oDatabaseOperationOutcome.NumberOfRecordsPerPage = _NumberOfRecordsPerPage;
      //oDatabaseOperationOutcome.PageRequested = 1;
      //oDatabaseOperationOutcome.ResourcesMatchingSearchCount = 1;

      //return oDatabaseOperationOutcome;

      throw new NotImplementedException();
    }

    //Stay in Patient
    public IDatabaseOperationOutcome SearchByFamilyAndGiven2(string Family, string Given, string Name, string Phonetic, Tuple<string, string> ActiveSystemAndCode, int PageRequired)
    {
      //var DbResource = (from r in _Context.Resource select r);

      //if (Family != string.Empty)
      //{
      //  DbResource = (from f in DbResource
      //                where f.PatientResource.HumanName.Any(x => x.Family.Any(y => y.Value == Family))
      //                select f);
      //}

      //if (Given != string.Empty)
      //{
      //  DbResource = (from g in DbResource
      //                where g.PatientResource.HumanName.Any(x => x.Given.Any(y => y.Value == Given))
      //                select g);
      //}



      //var Listof = DbResource.ToList();

      //var oDatabaseOperationOutcome = new DatabaseOperationOutcome();

      //return oDatabaseOperationOutcome;

      throw new NotImplementedException();
    }

    //Stay in Patient
    public IDatabaseOperationOutcome SearchByFamilyAndGiven(string Family, string Given, string Name, string Phonetic, Tuple<string, string> ActiveSystemAndCode, int PageRequired)
    {

      throw new NotImplementedException();
    }

    //Stay in Patient
    public IDatabaseOperationOutcome SearchByIdentifier(Tuple<string, string> IdentiferSystemAndCode, Tuple<string, string> ActiveSystemAndCode, int PageRequired, Uri RequestUri)
    {
      throw new NotImplementedException();
    }
   
    //private SqlForge.Query.Query SetupHumanNameQuery(Dictionary<string, SqlTable> TableDic)
    //{

      //var Query = new SqlForge.Query.Query();

      //var Select = new Select();
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Id));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsCurrent));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.IsDeleted));
      ////Select.AddProp(TableDic[DbInfo.ResourceIdentity.TableNameIs].Prop(DbInfo.ResourceIdentity.FhirResourceId));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Received));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Version));
      //Select.AddProp(TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Xml));
      //Query.Select = Select;

      //var From = new From();
      //From.AddTable(TableDic[DbInfo.Resource.TableNameIs]);
      //Query.From = From;

      //var Join = new Join();
      //Join.AddJoin(TableDic[DbInfo.PatientResource.TableNameIs], TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.PatientResource_Id), TableDic[DbInfo.PatientResource.TableNameIs].Prop(DbInfo.PatientResource.Id));
      //Join.AddJoin(TableDic[DbInfo.ResourceIdentity.TableNameIs], TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.ResourceIdentity_Id), TableDic[DbInfo.ResourceIdentity.TableNameIs].Prop(DbInfo.ResourceIdentity.Id));
      //Join.AddJoin(TableDic[DbInfo.HumanName.TableNameIs], TableDic[DbInfo.Resource.TableNameIs].Prop(DbInfo.Resource.Id), TableDic[DbInfo.HumanName.TableNameIs].Prop(DbInfo.HumanName.PatientResource_Id));
      //Join.AddJoin(TableDic[DbInfo.Family.TableNameIs], TableDic[DbInfo.HumanName.TableNameIs].Prop(DbInfo.HumanName.Id), TableDic[DbInfo.Family.TableNameIs].Prop(DbInfo.Family.HumanName_Id));
      //Join.AddJoin(TableDic[DbInfo.Given.TableNameIs], TableDic[DbInfo.HumanName.TableNameIs].Prop(DbInfo.HumanName.Id), TableDic[DbInfo.Given.TableNameIs].Prop(DbInfo.Given.HumanName_Id));
      //Query.Join = Join;

      //return Query;

    //}    

    private Res_Patient PopulatePatientResourceEntity(int ResourceVersion, Patient FhirPatient, Uri RootUri)
    {

      var oResourse = new DataModel.BlazeDbModel.Res_Patient();
      oResourse.FhirId = FhirPatient.Id;
      oResourse.XmlBlob = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(FhirPatient);
      oResourse.Received = (DateTimeOffset)FhirPatient.Meta.LastUpdated;
      oResourse.Version = ResourceVersion;

      if (FhirPatient.Active != null)
      {
        oResourse.active_Code = FhirPatient.Active.ToString();
        oResourse.active_System = "http://hl7.org/fhir/ValueSet/special-values";
      }

      if (FhirPatient.BirthDate != null)
        oResourse.birthdate_DateTimeOffset = DateTime.Parse(FhirPatient.BirthDate);
      else
        oResourse.birthdate_DateTimeOffset = null;

      
      if (FhirPatient.Deceased != null)
      {
        if (FhirPatient.Deceased.TypeName == ModelInfo.FhirCsTypeToString[typeof(FhirBoolean)])
        {
          var Token = SearchParameterTypeFactory.CreateToken(FhirPatient.Deceased as FhirBoolean);
          oResourse.deceased_Code = Token.Code;
          oResourse.deceased_System = Token.CodeSystem;
        }
        else if (FhirPatient.Deceased.TypeName == ModelInfo.FhirCsTypeToString[typeof(FhirDateTime)])
        {           
          oResourse.deathdate_DateTimeOffset = (FhirPatient.Deceased as FhirDateTime).ToDateTimeOffset();
        }                  
      }

      if (FhirPatient.Gender != null)
      {
        oResourse.gender_Code = EnumMapping.Create(typeof(AdministrativeGender)).GetLiteral(FhirPatient.Gender);
        oResourse.gender_System = null;                
      }

      if (FhirPatient.ManagingOrganization != null)
      {
        if (!FhirPatient.ManagingOrganization.IsContainedReference)
        {
          if (!FhirPatient.ManagingOrganization.Url.IsAbsoluteUri)
          {
            var UrlTest2 = Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(FhirPatient.ManagingOrganization.Url.OriginalString);
            //FhirUri.
            oResourse.organization_Type = FhirPatient.ManagingOrganization.Url.OriginalString.Split('/')[0];
            oResourse.organization_FhirId = FhirPatient.ManagingOrganization.Url.OriginalString.Split('/')[1];
            oResourse.organization_Url = null;
          }
          else
          {
            var UrlTest2 = Hl7.Fhir.Rest.HttpUtil.IsRestResourceIdentity(FhirPatient.ManagingOrganization.Url.OriginalString);
            //FhirUri.
            oResourse.organization_Type = FhirPatient.ManagingOrganization.Url.OriginalString.Split('/')[0];
            oResourse.organization_FhirId = FhirPatient.ManagingOrganization.Url.OriginalString.Split('/')[1];
            oResourse.organization_Url = null;
          }
        }        
      }

      
      

      if (FhirPatient.Telecom != null)
      {        
        foreach(var Telecom in FhirPatient.Telecom)
        {
          if (Telecom.System != null)
          {
            if ((ContactPoint.ContactPointSystem)Telecom.System == ContactPoint.ContactPointSystem.Email)
            {               
              if (oResourse.email_List == null)
              {
                oResourse.email_List = new List<Res_Patient_Index_email>();
              }              
              var Token = SearchParameterTypeFactory.CreateToken(Telecom);
              oResourse.email_List.Add(new Res_Patient_Index_email() { Code = Token.Code, System = Token.CodeSystem });
            }
          }
        }
      }
      //oResourse.email_Code
      
      
      
      

      //var ResourceIdentity = new Model.ResourceIdentity();
      //ResourceIdentity.FhirResourceId = FhirPatient.Id;
      
      //var ResourceXml = new DataModel.Model.Resource();
      //ResourceXml.Xml = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(FhirPatient);
      //ResourceXml.Received = (DateTimeOffset)FhirPatient.Meta.LastUpdated;
      //ResourceXml.Version = ResourceVersion;
      //ResourceXml.IsCurrent = true;
      //ResourceXml.IsDeleted = false;
      //ResourceXml.ResourceType = DtoEnums.SupportedFhirResource.Patient;
      //ResourceXml.ResourceIdentity = ResourceIdentity;            

      //var DbResourcePatient = new PatientResource();
      //DbResourcePatient.Resources.Add(ResourceXml);     
      //DbResourcePatient.Active = FhirPatient.Active;
      //DbResourcePatient.Gender = FhirPatient.Gender;
      //DbResourcePatient.ResourceIdentity = ResourceIdentity;

      //if (FhirPatient.Identifier != null)
      //{
      //  DbResourcePatient.Identifier = new List<Model.Identifier>();
      //  foreach (var FhirIdentifier in FhirPatient.Identifier)
      //  {
      //    var DbIdentifier = new Model.Identifier();

      //    DbIdentifier.Use = FhirIdentifier.Use;
      //    DbIdentifier.System = FhirIdentifier.System;
      //    DbIdentifier.Value = FhirIdentifier.Value;
          
      //    if (FhirIdentifier.Type != null)
      //    {
      //      DbIdentifier.Type = new Model.CodeableConcept();
      //      DbIdentifier.Type.Text = FhirIdentifier.Type.Text;

      //      if (FhirIdentifier.Type.Coding != null)
      //      {
      //        DbIdentifier.Type.Coding = new List<Model.Coding>();
      //        foreach (var FhirCodeing in FhirIdentifier.Type.Coding)
      //        {
      //          var DbCoding = new Model.Coding();
      //          DbCoding.System = FhirCodeing.System;
      //          DbCoding.Version = FhirCodeing.Version;
      //          DbCoding.Code = FhirCodeing.Code;
      //          DbCoding.Display = FhirCodeing.Display;
      //          if (FhirCodeing.UserSelected != null)
      //            DbCoding.UserSelected = (bool)FhirCodeing.UserSelected;
      //          DbIdentifier.Type.Coding.Add(DbCoding);
      //        }
      //      }
      //    }

      //    if (FhirIdentifier.Period != null)
      //    {
      //      DbIdentifier.Period = new Model.Period();
      //      if (FhirIdentifier.Period.Start != null && FhirDateTime.IsValidValue(FhirIdentifier.Period.Start))
      //        DbIdentifier.Period.Start = FhirIdentifier.Period.StartElement.ToDateTimeOffset();
      //      if (FhirIdentifier.Period.End != null && FhirDateTime.IsValidValue(FhirIdentifier.Period.End))
      //        DbIdentifier.Period.End = FhirIdentifier.Period.EndElement.ToDateTimeOffset();
      //    }
      //    DbResourcePatient.Identifier.Add(DbIdentifier);
      //  }
      //}

      //foreach (var FhirName in FhirPatient.Name)
      //{
      //  var DbHumanName = new Model.HumanName();

      //  if (FhirName.Text != null)
      //    DbHumanName.Text = FhirName.Text;

      //  if (FhirName.Family != null)
      //    foreach (var family in FhirName.Family)
      //      DbHumanName.Family.Add(new Family() { Value = family });

      //  if (FhirName.Given != null)
      //    foreach (var Given in FhirName.Given)
      //      DbHumanName.Given.Add(new Given() { Value = Given });

      //  if (FhirName.Use != null)
      //    DbHumanName.Use = FhirName.Use;
      //  else
      //    DbHumanName.Use = null;

      //  if (FhirName.Period != null)
      //  {
      //    DbHumanName.Period = new DataModel.Model.Period();
          
      //    if (FhirName.Period.Start != null)
      //      DbHumanName.Period.Start = DateTimeOffset.Parse(FhirName.Period.Start);
      //    else
      //      DbHumanName.Period.Start = null;

      //    if (FhirName.Period.End != null)                    
      //      DbHumanName.Period.End = DateTimeOffset.Parse(FhirName.Period.End);                     
      //    else
      //      DbHumanName.Period.End = null;
      //  }

      //  DbResourcePatient.HumanName.Add(DbHumanName);

      //  if (FhirPatient.BirthDate != null)
      //    DbResourcePatient.BirthDate = DateTime.Parse(FhirPatient.BirthDate);
      //  else
      //    DbResourcePatient.BirthDate = null;

      //}
      //return DbResourcePatient;

      throw new NotImplementedException(); 

    }


    

  }
}



