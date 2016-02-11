using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using LinqKit;
using DataModel.Model;
using Hl7.Fhir.Model;
using BusinessEntities;
using BusinessEntities.Search;
using Dip.Interfaces;
using Dip.Interfaces.Repositories;
using DataModel.ModelExtend;
using DataModel.DynamicExpression;


namespace DataModel.Repository
{
  public class ValueSetRepository : BaseRepository, IValueSetRepository
  {
    public ValueSetRepository(BlazeDbContext Context)
    {
      _Context = Context;
    }

    public string AddResource(ValueSet ValueSet)
    {
      var NewPatientResource = this.PopulateDbResourceEntity(1, ValueSet);
      using (var scope = new TransactionScope())
      {
        _Context.ValueSetResource.Add(NewPatientResource);
        this.Save();
        scope.Complete();
      }
      return ValueSet.Id;
    }

    public string UpdateResource(int ResourceVersion, ValueSet ValueSet)
    {
      var NewValueSetResource = this.PopulateDbResourceEntity(ResourceVersion, ValueSet);

      Model.Resource DbResource = (from x in _Context.Resource
                          .Include(y => y.ResourceIdentity)
                          .Include(y => y.ValueSetResource.CodeSystem)
                          .Include(y => y.ValueSetResource.Compose.Include)
                          .Include(y => y.ValueSetResource.UseContext)
                                   where x.IsCurrent == true && x.ResourceIdentity.FhirResourceId == ValueSet.Id
                                   select x).SingleOrDefault();

      //The last update to the resource was a delete so no ValueSetResource to be found need to add one
      if (DbResource.IsDeleted == true)
      {
        using (var scope = new TransactionScope())
        {
          //== Add the ValueSet Structure as required =============================================          
          NewValueSetResource.ResourceIdentity = DbResource.ResourceIdentity;
          DbResource.IsCurrent = false;

          //==========================================================================================

          //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
          //It is also set to current as the instance is populated.
          var InboundResource = NewValueSetResource.Resource.SingleOrDefault(x => x.IsCurrent == true);
          InboundResource.Version = ResourceVersion;
          InboundResource.Received = (DateTimeOffset)ValueSet.Meta.LastUpdated;
          InboundResource.IsCurrent = true;
          InboundResource.ResourceIdentity = DbResource.ResourceIdentity;
          InboundResource.ValueSetResource = NewValueSetResource;
          _Context.Resource.Add(InboundResource);

          this.Save();

          scope.Complete();
        }
        return string.Empty;

      }
      else
      {
        //The last update to the resource was a found not deleted
        using (var scope = new TransactionScope())
        {
          //== Update the ValueSet Structure as required =============================================

          RemoveValueSetStructure(DbResource);

          //==========================================================================================

          //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
          //It is also set to current as the instance is populated.
          var InboundResource = NewValueSetResource.Resource.SingleOrDefault(x => x.IsCurrent == true);
          InboundResource.Version = ResourceVersion;
          InboundResource.Received = (DateTimeOffset)ValueSet.Meta.LastUpdated;
          InboundResource.IsCurrent = true;
          InboundResource.ResourceIdentity = DbResource.ResourceIdentity;
          NewValueSetResource.ResourceIdentity = DbResource.ResourceIdentity;
          InboundResource.ValueSetResource = NewValueSetResource;
          _Context.Resource.Add(InboundResource);

          //Set the past Current Resource to not current
          DbResource.IsCurrent = false;
          DbResource.ValueSetResource_Id = null;
          DbResource.ValueSetResource = null;

          this.Save();

          scope.Complete();
        }
        return string.Empty;
      }
    }

    public void UpdateResouceAsDeleted(string FhirResourceId)
    {
      var DbResource = (from r in _Context.Resource
                          .Include(y => y.ResourceIdentity)
                          .Include(y => y.ValueSetResource)
                          .Include(y => y.ValueSetResource.CodeSystem)
                          .Include(y => y.ValueSetResource.Compose.Include)
                        where r.ResourceIdentity.FhirResourceId == FhirResourceId && r.IsCurrent == true
                        select r).FirstOrDefault();

      using (var scope = new TransactionScope())
      {

        //=== Clean Up ==========================================================
        RemoveValueSetStructure(DbResource);
        DbResource.IsCurrent = false;
        DbResource.ValueSetResource = null;
        //_Context.ValueSetResource.Remove(DbResource.ValueSetResource);

        //=== Add Delete Record =================================================        
        var NewResource = new DataModel.Model.Resource();
        NewResource.ResourceType = DtoEnums.SupportedFhirResource.ValueSet;
        NewResource.IsDeleted = true;
        NewResource.IsCurrent = true;
        NewResource.Xml = string.Empty;
        NewResource.Version = DbResource.Version + 1;
        NewResource.Received = DateTimeOffset.Now;
        NewResource.ResourceIdentity = DbResource.ResourceIdentity;

        _Context.Resource.Add(NewResource);

        this.Save();

        scope.Complete();
      }
    }

    public IDatabaseOperationOutcome Search(DtoSearchParameters oSearchParameters)
    {
      var oDatabaseOperationOutcome = new DatabaseOperationOutcome();

      var ResourceFilter = _Context.Resource.AsExpandable();

      var FinalResourceExpression = ExpressionForge.Resource.ResourceTrue();

      //Parameter: Description
      foreach (var Parameter in oSearchParameters.SearchParametersList.FindAll(x => x.Name == DtoEnums.Search.SearchParameterName.Description))
      {
        var DescriptionParameter = Parameter as DtoSearchParameterString;
        var DescriptionExpression = ExpressionForge.Resource.ResourceFalse();
        foreach (string item in DescriptionParameter.Values)
        {
          if (DescriptionParameter.Modifier == SearchModifierType.None || DescriptionParameter.Modifier == SearchModifierType.Exact)
          {
            //(Description = "text")
            DescriptionExpression = DescriptionExpression.Or(ExpressionForge.Resource.ValueSet.Equals_Description(item));
          }
          else if (DescriptionParameter.Modifier == SearchModifierType.Contains)
          {
            //Description.Contains("Text1") or Description.Contains("Text2")..etc
            DescriptionExpression = DescriptionExpression.Or(ExpressionForge.Resource.ValueSet.Contains_Description(item));           
          }
        }
        FinalResourceExpression = FinalResourceExpression.And(DescriptionExpression);
      }

      //Parameter: Code
      foreach (var Parameter in oSearchParameters.SearchParametersList.FindAll(x => x.Name == DtoEnums.Search.SearchParameterName.Code))
      {
        var CodeParameter = Parameter as DtoSearchParameterToken;        
        var CodeSystemCodeSearchList = new List<Tuple<string, string>>();
        if (CodeParameter.Values.Count() > 0)
        {
          foreach (var item in CodeParameter.Values)
          {
            CodeSystemCodeSearchList.Add(new Tuple<string, string>(item.System, item.Code));
          }
          var CodeExpression = ExpressionForge.Resource.ValueSet.Any_ConceptCodeSystemAndCode(CodeSystemCodeSearchList);
          FinalResourceExpression = FinalResourceExpression.And(CodeExpression);
        }
      }

      //Parameter: Date
      foreach (var Parameter in oSearchParameters.SearchParametersList.FindAll(x => x.Name == DtoEnums.Search.SearchParameterName.Date))
      {
        var DateExpression = ExpressionForge.Resource.ResourceTrue();
        var DateParameter = Parameter as DtoSearchParameterDate;
        switch (DateParameter.Prefix)
        {
          case SearchPrefixType.None:
            break;
          case SearchPrefixType.Equal:
            DateExpression = ExpressionForge.Resource.ValueSet.Equals_Date(DateParameter.Value.DateTime);
            break;
          case SearchPrefixType.NotEqual:
            DateExpression = ExpressionForge.Resource.ValueSet.NotEqualTo_Date(DateParameter.Value.DateTime);
            break;
          case SearchPrefixType.Greater:
            DateExpression = ExpressionForge.Resource.ValueSet.GreaterThan_Date(DateParameter.Value.DateTime);
            break;
          case SearchPrefixType.Less:
            DateExpression = ExpressionForge.Resource.ValueSet.LessThan_Date(DateParameter.Value.DateTime);
            break;
          case SearchPrefixType.GreaterOrEqual:
            DateExpression = ExpressionForge.Resource.ValueSet.GreaterThanEqualTo_Date(DateParameter.Value.DateTime);
            break;
          case SearchPrefixType.LessOrEqual:
            DateExpression = ExpressionForge.Resource.ValueSet.LessThanEqualTo_Date(DateParameter.Value.DateTime);
            break;          
          default:
            //ToDo: how do we handle date with no prefix?
            break;
        }
        FinalResourceExpression = FinalResourceExpression.And(DateExpression);        
      }

      //Parameter: Date
      foreach (var Parameter in oSearchParameters.SearchParametersList.FindAll(x => x.Name == DtoEnums.Search.SearchParameterName.Context))
      {       
        var ContextParameter = Parameter as DtoSearchParameterToken;
        var ContextSearchList = new List<Tuple<string, string>>();
        if (ContextParameter.Values.Count() > 0)
        {
          foreach (var item in ContextParameter.Values)
          {
            ContextSearchList.Add(new Tuple<string, string>(item.System, item.Code));
          }
          var UseContextExpression = ExpressionForge.Resource.ValueSet.Any_UserContext(ContextSearchList);
          FinalResourceExpression = FinalResourceExpression.And(UseContextExpression);        
        }
      }
      


      int PageRequired = 0;
      foreach (var Parameter in oSearchParameters.SearchParametersList.FindAll(x => x.Name == DtoEnums.Search.SearchParameterName.Page))
      {
        var PageParameter = Parameter as DtoSearchParameterNumber;
        PageRequired = Convert.ToInt32(PageParameter.Values[0]);        
      }

      int SearchResultCount = ResourceFilter.Where(FinalResourceExpression).Count();
      ResourceFilter = ResourceFilter.Where(FinalResourceExpression).OrderBy(x => x.Received).Skip(PageRequired).Take(_NumberOfRecordsPerPage);

      var dbResourceList = ResourceFilter.ToList();

      oDatabaseOperationOutcome.ResourcesMatchingSearchList = new List<DtoResource>();
      dbResourceList.ForEach(x => oDatabaseOperationOutcome.ResourcesMatchingSearchList.Add(x.GetDto()));
      oDatabaseOperationOutcome.NumberOfRecordsPerPage = _NumberOfRecordsPerPage;
      oDatabaseOperationOutcome.PageRequested = PageRequired;
      oDatabaseOperationOutcome.ResourcesMatchingSearchCount = SearchResultCount;
      return oDatabaseOperationOutcome;
    }



    private ValueSetResource PopulateDbResourceEntity(int ResourceVersion, ValueSet FhirValueSet)
    {
      var ResourceIdentity = new Model.ResourceIdentity();
      ResourceIdentity.FhirResourceId = FhirValueSet.Id;

      var ResourceXml = new DataModel.Model.Resource();
      ResourceXml.Xml = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(FhirValueSet);
      ResourceXml.Received = (DateTimeOffset)FhirValueSet.Meta.LastUpdated;
      ResourceXml.Version = ResourceVersion;
      ResourceXml.IsCurrent = true;
      ResourceXml.IsDeleted = false;
      ResourceXml.ResourceType = DtoEnums.SupportedFhirResource.ValueSet;
      ResourceXml.ResourceIdentity = ResourceIdentity;

      var DbValueSetResource = new ValueSetResource();
      if (DbValueSetResource.Resource == null)
        DbValueSetResource.Resource = new List<Model.Resource>();
      DbValueSetResource.Resource.Add(ResourceXml);
      DbValueSetResource.ResourceIdentity = ResourceIdentity;
      if (FhirValueSet.Date != null)
        DbValueSetResource.Date = DateTime.Parse(FhirValueSet.Date);
      else
        DbValueSetResource.Date = null;
      DbValueSetResource.Description = FhirValueSet.Description;
      DbValueSetResource.Name = FhirValueSet.Name;
      DbValueSetResource.Publisher = FhirValueSet.Publisher;
      DbValueSetResource.Status = (ConformanceResourceStatus)FhirValueSet.Status;
      DbValueSetResource.Url = FhirValueSet.Url;
      DbValueSetResource.Version = FhirValueSet.Version;

      if (FhirValueSet.CodeSystem != null)
      {
        DbValueSetResource.CodeSystem = new Model.CodeSystem();
        DbValueSetResource.CodeSystem.System = FhirValueSet.CodeSystem.System;
        if (FhirValueSet.CodeSystem.Concept != null)
        {
          DbValueSetResource.CodeSystem.Concept = new List<Model.Concept>();
          foreach (var FhirConcept in FhirValueSet.CodeSystem.Concept)
          {
            //Method Recursively adds all the child concepts      
            RecursivelyResolveConcepts(DbValueSetResource.CodeSystem, FhirConcept);
          }
        }
      }

      if (FhirValueSet.Compose != null)
      {
        DbValueSetResource.Compose = new Model.Compose();
        if (FhirValueSet.Compose.Include != null)
        {
          DbValueSetResource.Compose.Include = new List<Model.Include>();
          foreach (var FhirInclude in FhirValueSet.Compose.Include)
          {
            var DbInclude = new Model.Include();
            DbInclude.System = FhirInclude.System;
            DbValueSetResource.Compose.Include.Add(DbInclude);
          }
        }
      }

      if (FhirValueSet.Expansion != null)
      {
        DbValueSetResource.Expansion = new Expansion();
        DbValueSetResource.Expansion.Identifier = FhirValueSet.Expansion.Identifier;
      }
      if (FhirValueSet.Identifier != null)
      {
        DbValueSetResource.Identifier = new Model.Identifier();
        DbValueSetResource.Identifier.System = FhirValueSet.Identifier.System;
        DbValueSetResource.Identifier.Value = FhirValueSet.Identifier.Value;
        DbValueSetResource.Identifier.Use = FhirValueSet.Identifier.Use;
        if (FhirValueSet.Identifier.Period != null)
        {
          DbValueSetResource.Identifier.Period = new Model.Period();
          if (FhirValueSet.Identifier.Period.Start != null && FhirDateTime.IsValidValue(FhirValueSet.Identifier.Period.Start))
            DbValueSetResource.Identifier.Period.Start = FhirValueSet.Identifier.Period.StartElement.ToDateTimeOffset();
          if (FhirValueSet.Identifier.Period.End != null && FhirDateTime.IsValidValue(FhirValueSet.Identifier.Period.End))
            DbValueSetResource.Identifier.Period.End = FhirValueSet.Identifier.Period.EndElement.ToDateTimeOffset();
        }
        if (FhirValueSet.Identifier.Type != null)
        {
          DbValueSetResource.Identifier.Type = new Model.CodeableConcept();
          DbValueSetResource.Identifier.Type.Text = FhirValueSet.Identifier.Type.Text;
          if (FhirValueSet.Identifier.Type.Coding != null)
          {
            DbValueSetResource.Identifier.Type.Coding = new List<Model.Coding>();
            foreach (var FhirCoding in FhirValueSet.Identifier.Type.Coding)
            {
              var DbCoding = new Model.Coding();
              DbCoding.Code = FhirCoding.Code;
              DbCoding.Display = FhirCoding.Display;
              DbCoding.System = FhirCoding.System;
              DbCoding.UserSelected = FhirCoding.UserSelected;
              DbCoding.Version = FhirCoding.Version;
              DbValueSetResource.Identifier.Type.Coding.Add(DbCoding);
            }
          }
        }
      }

      if (FhirValueSet.UseContext != null)
      {
        DbValueSetResource.UseContext = new List<Model.CodeableConcept>();
        foreach (var FhirUseContext in FhirValueSet.UseContext)
        {
          var DbUseContext = new Model.CodeableConcept();
          DbUseContext.Text = FhirUseContext.Text;
          if (FhirUseContext.Coding != null)
          {
            DbUseContext.Coding = new List<Model.Coding>();
            foreach (var FhirCoding in FhirUseContext.Coding)
            {
              var DbCoding = new Model.Coding();
              DbCoding.Code = FhirCoding.Code;
              DbCoding.Display = FhirCoding.Display;
              DbCoding.System = FhirCoding.System;
              DbCoding.UserSelected = FhirCoding.UserSelected;
              DbCoding.Version = FhirCoding.Version;
              DbUseContext.Coding.Add(DbCoding);
            }
          }
          DbValueSetResource.UseContext.Add(DbUseContext);
        }
      }

      return DbValueSetResource;
    }
    private void RemoveValueSetStructure(Model.Resource DbResource)
    {
      //Remove old structure
      if (DbResource.ValueSetResource.CodeSystem != null)
      {
        if (DbResource.ValueSetResource.CodeSystem.Concept != null)
        {
          //I had to do this here to improve performance. If I include the concepts in  the main
          //query then the performance is terrible. Doing this here is a lot faster.  
          var ConceptList = (from x in _Context.Concept
                             where x.CodeSystem.Id == DbResource.ValueSetResource.CodeSystem.Id
                             select x);
          _Context.Concept.RemoveRange(ConceptList);
        }
        _Context.CodeSystem.Remove(DbResource.ValueSetResource.CodeSystem);
      }

      if (DbResource.ValueSetResource.Compose != null)
      {
        if (DbResource.ValueSetResource.Compose.Include != null)
        {
          _Context.Include.RemoveRange(DbResource.ValueSetResource.Compose.Include);
        }
        _Context.Compose.Remove(DbResource.ValueSetResource.Compose);
      }

      if (DbResource.ValueSetResource.Expansion != null)
      {
        _Context.Expansion.Remove(DbResource.ValueSetResource.Expansion);
      }

      if (DbResource.ValueSetResource.Identifier != null)
      {
        if (DbResource.ValueSetResource.Identifier.Period != null)
        {
          _Context.Period.Remove(DbResource.ValueSetResource.Identifier.Period);
        }
        if (DbResource.ValueSetResource.Identifier.Type != null)
        {
          _Context.CodeableConcept.Remove(DbResource.ValueSetResource.Identifier.Type);
        }
        _Context.Identifier.Remove(DbResource.ValueSetResource.Identifier);
      }

      if (DbResource.ValueSetResource.UseContext != null)
      {
        foreach (var CodeableConcept in DbResource.ValueSetResource.UseContext)
        {
          var CodingList = (from x in _Context.Codeing
                            where x.CodeableConcept.Id == CodeableConcept.Id
                            select x);
          _Context.Codeing.RemoveRange(CodingList);

          //foreach (var Coding in CodeableConcept.Coding)
          //{
          //  _Context.Codeing.Remove(Coding);
          //}
          
        }
        _Context.CodeableConcept.RemoveRange(DbResource.ValueSetResource.UseContext);
        DbResource.ValueSetResource.UseContext = null;
       

        
      }

      _Context.ValueSetResource.Remove(DbResource.ValueSetResource);
    }

    /// <summary>
    /// Recursively add all the Concept children
    /// </summary>
    /// <param name="FhirConcept"></param>
    /// <returns></returns>
    private Model.Concept RecursivelyResolveConcepts(Model.CodeSystem DbCodeSystem, ValueSet.ConceptDefinitionComponent FhirConcept)
    {
      var DBConcept = new Model.Concept();
      DBConcept.Code = FhirConcept.Code;
      DbCodeSystem.Concept.Add(DBConcept);
      if (FhirConcept.Concept != null)
      {
        DBConcept.ConceptChild = new List<Model.Concept>();
        foreach (var FhirChildConcept in FhirConcept.Concept)
        {
          var Concept = RecursivelyResolveConcepts(DbCodeSystem, FhirChildConcept);
          DBConcept.ConceptChild.Add(Concept);
          DbCodeSystem.Concept.Add(Concept);
        }
      }

      return DBConcept;
    }

  }
}
