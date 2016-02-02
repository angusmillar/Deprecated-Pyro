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
using SqlForge.Query;
using SqlForge.Support;
using DataModel.ModelExtend;

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
      //##issues## Check  if (entry.State != EntityState.Modified) here to see if not change results in modified
      var NewValueSetResource = this.PopulateDbResourceEntity(ResourceVersion, ValueSet);

      var DbResource = (from x in _Context.Resource
                          .Include(y => y.ResourceIdentity)
                          .Include(y => y.ValueSetResource)
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
          //Value Set has nothing at present

          //==========================================================================================

          //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
          //It is also set to current as the instance is populated.
          var InboundResource = NewValueSetResource.Resources.SingleOrDefault(x => x.IsCurrent == true);
          InboundResource.Version = ResourceVersion;
          InboundResource.Received = (DateTimeOffset)ValueSet.Meta.LastUpdated;
          InboundResource.IsCurrent = true;
          InboundResource.ResourceIdentity = DbResource.ResourceIdentity;
          InboundResource.ValueSetResource = NewValueSetResource;
          _Context.Resource.Add(InboundResource);
          //DbValueSetResource.Resources.Add(InboundResource);

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
          
          //Value Set has nothing at present

          //==========================================================================================

          //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
          //It is also set to current as the instance is populated.
          var InboundResource = NewValueSetResource.Resources.SingleOrDefault(x => x.IsCurrent == true);
          InboundResource.Version = ResourceVersion;
          InboundResource.Received = (DateTimeOffset)ValueSet.Meta.LastUpdated;
          InboundResource.IsCurrent = true;
          InboundResource.ResourceIdentity = DbResource.ResourceIdentity;
          InboundResource.ValueSetResource = DbResource.ValueSetResource;
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
                                .Include(x => x.ResourceIdentity)
                        where r.ResourceIdentity.FhirResourceId == FhirResourceId && r.IsCurrent == true
                        select r).FirstOrDefault();

      using (var scope = new TransactionScope())
      {
        
        //=== Clean Up ==========================================================
        DbResource.IsCurrent = false;
        DbResource.ValueSetResource = null;
        _Context.ValueSetResource.Remove(DbResource.ValueSetResource);
        
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
      if (DbValueSetResource.Resources == null)
        DbValueSetResource.Resources = new List<Model.Resource>(); 
      DbValueSetResource.Resources.Add(ResourceXml);
      DbValueSetResource.ResourceIdentity = ResourceIdentity;

      return DbValueSetResource;
    }
  }
}
