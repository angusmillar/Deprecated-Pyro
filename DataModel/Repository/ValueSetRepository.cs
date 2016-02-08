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

    public void Search()
    {
      
      List<Filter> oFilterList = new List<Filter>();
      oFilterList.Add(new Filter() { Property = DbInfo.Resource.IsCurrent, Operation = Op.Equals, Value = true });
      oFilterList.Add(new Filter() { Property = DbInfo.Resource.Version, Operation = Op.Equals, Value = 6 });
      var deleg = ExpressionBuilder.GetExpression<Model.Resource>(oFilterList).Compile();

      Model.Resource oResource = new Model.Resource();
      var testsearch2 = _Context.Resource.Where(deleg).ToList();
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
      //ToDo: Validate the Date in the validator
      if (FhirValueSet.Date != null)
        DbValueSetResource.Date = DateTime.Parse(FhirValueSet.Date);
      else
        DbValueSetResource.Date = null;
      DbValueSetResource.Description = FhirValueSet.Description;
      DbValueSetResource.Name = FhirValueSet.Name;
      DbValueSetResource.Publisher = FhirValueSet.Publisher;
      //ToDo: Validate the status is not null, FHIR standard says it is 1..1 for ValueSet Resource
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
            //ToDo: Concept look as if they can have child Concepts, need to add this feature
            var DbConcept = new Concept();
            DbConcept.Code = FhirConcept.Code;
            DbValueSetResource.CodeSystem.Concept.Add(DbConcept);
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
            foreach(var FhirCoding in FhirValueSet.Identifier.Type.Coding)
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
        foreach(var FhirUseContext in FhirValueSet.UseContext)
        {
          var DbUseContext = new Model.CodeableConcept();
          DbUseContext.Text = FhirUseContext.Text;
          if (FhirUseContext.Coding != null)
          {
            DbUseContext.Coding = new List<Model.Coding>();
            foreach(var FhirCoding in FhirUseContext.Coding)
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
        _Context.CodeableConcept.RemoveRange(DbResource.ValueSetResource.UseContext);
      }

      _Context.ValueSetResource.Remove(DbResource.ValueSetResource);
    }

  }
}
