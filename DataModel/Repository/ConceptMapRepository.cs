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
    public class ConceptMapRepository : BaseRepository, IConceptMapRepository
    {
        public ConceptMapRepository(BlazeDbContext Context)
        {
            _Context = Context;
        }

        public string AddResource(ConceptMap ConceptMap)
        {
            var NewConceptMapResource = this.PopulateDbResourceEntity(1, ConceptMap);
            using (var scope = new TransactionScope())
            {
                _Context.ConceptMapResource.Add(NewConceptMapResource);
                this.Save();
                scope.Complete();
            }
            return ConceptMap.Id;
        }

        public string UpdateResource(int ResourceVersion, ConceptMap ConceptMap)
        {
            var NewConceptMapResource = this.PopulateDbResourceEntity(ResourceVersion, ConceptMap);

            Model.Resource DbResource = (from x in _Context.Resource
                                .Include(y => y.ResourceIdentity)
                                         where x.IsCurrent == true && x.ResourceIdentity.FhirResourceId == ConceptMap.Id
                                         select x).SingleOrDefault();

            //The last update to the resource was a delete so no ConceptMapResource to be found need to add one
            if (DbResource.IsDeleted == true)
            {
                using (var scope = new TransactionScope())
                {
                    //== Add the ConceptMap Structure as required =============================================          
                    NewConceptMapResource.ResourceIdentity = DbResource.ResourceIdentity;
                    DbResource.IsCurrent = false;

                    //==========================================================================================

                    //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
                    //It is also set to current as the instance is populated.
                    var InboundResource = NewConceptMapResource.Resource.SingleOrDefault(x => x.IsCurrent == true);
                    InboundResource.Version = ResourceVersion;
                    InboundResource.Received = (DateTimeOffset)ConceptMap.Meta.LastUpdated;
                    InboundResource.IsCurrent = true;
                    InboundResource.ResourceIdentity = DbResource.ResourceIdentity;
                    InboundResource.ConceptMapResource = NewConceptMapResource;
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
                    //== Update the ConceptMap Structure as required =============================================

                    RemoveConceptMapStructure(DbResource);

                    //==========================================================================================

                    //Get the new Resource from the list, it will be the only one as this instance is the single inbound instance
                    //It is also set to current as the instance is populated.
                    var InboundResource = NewConceptMapResource.Resource.SingleOrDefault(x => x.IsCurrent == true);
                    InboundResource.Version = ResourceVersion;
                    InboundResource.Received = (DateTimeOffset)ConceptMap.Meta.LastUpdated;
                    InboundResource.IsCurrent = true;
                    InboundResource.ResourceIdentity = DbResource.ResourceIdentity;
                    NewConceptMapResource.ResourceIdentity = DbResource.ResourceIdentity;
                    InboundResource.ConceptMapResource = NewConceptMapResource;
                    _Context.Resource.Add(InboundResource);

                    //Set the past Current Resource to not current
                    DbResource.IsCurrent = false;
                    DbResource.ConceptMapResource_Id = null;
                    DbResource.ConceptMapResource = null;

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
                                .Include(y => y.ConceptMapResource)
                              where r.ResourceIdentity.FhirResourceId == FhirResourceId && r.IsCurrent == true
                              select r).FirstOrDefault();

            using (var scope = new TransactionScope())
            {

                //=== Clean Up ==========================================================
                RemoveConceptMapStructure(DbResource);
                DbResource.IsCurrent = false;
                DbResource.ConceptMapResource = null;
                //_Context.ConceptMapResource.Remove(DbResource.ConceptMapResource);

                //=== Add Delete Record =================================================        
                var NewResource = new DataModel.Model.Resource();
                NewResource.ResourceType = DtoEnums.SupportedFhirResource.ConceptMap;
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

        private ConceptMapResource PopulateDbResourceEntity(int ResourceVersion, ConceptMap FhirConceptMap)
        {
            var ResourceIdentity = new Model.ResourceIdentity();
            ResourceIdentity.FhirResourceId = FhirConceptMap.Id;

            var ResourceXml = new DataModel.Model.Resource();
            ResourceXml.Xml = Hl7.Fhir.Serialization.FhirSerializer.SerializeResourceToXml(FhirConceptMap);
            ResourceXml.Received = (DateTimeOffset)FhirConceptMap.Meta.LastUpdated;
            ResourceXml.Version = ResourceVersion;
            ResourceXml.IsCurrent = true;
            ResourceXml.IsDeleted = false;
            ResourceXml.ResourceType = DtoEnums.SupportedFhirResource.ConceptMap;
            ResourceXml.ResourceIdentity = ResourceIdentity;

            var DbConceptMapResource = new ConceptMapResource();
            if (DbConceptMapResource.Resource == null)
                DbConceptMapResource.Resource = new List<Model.Resource>();
            DbConceptMapResource.Resource.Add(ResourceXml);
            DbConceptMapResource.ResourceIdentity = ResourceIdentity;
            if (FhirConceptMap.Date != null)
                DbConceptMapResource.Date = DateTime.Parse(FhirConceptMap.Date);
            else
                DbConceptMapResource.Date = null;
            DbConceptMapResource.Description = FhirConceptMap.Description;
            DbConceptMapResource.Name = FhirConceptMap.Name;
            DbConceptMapResource.Publisher = FhirConceptMap.Publisher;
            DbConceptMapResource.Status = (ConformanceResourceStatus)FhirConceptMap.Status;
            DbConceptMapResource.Url = FhirConceptMap.Url;
            DbConceptMapResource.Version = FhirConceptMap.Version;


            if (FhirConceptMap.Identifier != null)
            {
                DbConceptMapResource.Identifier = new Model.Identifier();
                DbConceptMapResource.Identifier.System = FhirConceptMap.Identifier.System;
                DbConceptMapResource.Identifier.Value = FhirConceptMap.Identifier.Value;
                DbConceptMapResource.Identifier.Use = FhirConceptMap.Identifier.Use;
                if (FhirConceptMap.Identifier.Period != null)
                {
                    DbConceptMapResource.Identifier.Period = new Model.Period();
                    if (FhirConceptMap.Identifier.Period.Start != null && FhirDateTime.IsValidValue(FhirConceptMap.Identifier.Period.Start))
                        DbConceptMapResource.Identifier.Period.Start = FhirConceptMap.Identifier.Period.StartElement.ToDateTimeOffset();
                    if (FhirConceptMap.Identifier.Period.End != null && FhirDateTime.IsValidValue(FhirConceptMap.Identifier.Period.End))
                        DbConceptMapResource.Identifier.Period.End = FhirConceptMap.Identifier.Period.EndElement.ToDateTimeOffset();
                }
                if (FhirConceptMap.Identifier.Type != null)
                {
                    DbConceptMapResource.Identifier.Type = new Model.CodeableConcept();
                    DbConceptMapResource.Identifier.Type.Text = FhirConceptMap.Identifier.Type.Text;
                    if (FhirConceptMap.Identifier.Type.Coding != null)
                    {
                        DbConceptMapResource.Identifier.Type.Coding = new List<Model.Coding>();
                        foreach (var FhirCoding in FhirConceptMap.Identifier.Type.Coding)
                        {
                            var DbCoding = new Model.Coding();
                            DbCoding.Code = FhirCoding.Code;
                            DbCoding.Display = FhirCoding.Display;
                            DbCoding.System = FhirCoding.System;
                            DbCoding.UserSelected = FhirCoding.UserSelected;
                            DbCoding.Version = FhirCoding.Version;
                            DbConceptMapResource.Identifier.Type.Coding.Add(DbCoding);
                        }
                    }
                }
            }

            if (FhirConceptMap.UseContext != null)
            {
                DbConceptMapResource.UseContext = new List<Model.CodeableConcept>();
                foreach (var FhirUseContext in FhirConceptMap.UseContext)
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
                    DbConceptMapResource.UseContext.Add(DbUseContext);
                }
            }

            return DbConceptMapResource;
        }
        private void RemoveConceptMapStructure(Model.Resource DbResource)
        {
            //Remove old structure

            if (DbResource.ConceptMapResource.Identifier != null)
            {
                if (DbResource.ConceptMapResource.Identifier.Period != null)
                {
                    _Context.Period.Remove(DbResource.ConceptMapResource.Identifier.Period);
                }
                if (DbResource.ConceptMapResource.Identifier.Type != null)
                {
                    _Context.CodeableConcept.Remove(DbResource.ConceptMapResource.Identifier.Type);
                }
                _Context.Identifier.Remove(DbResource.ConceptMapResource.Identifier);
            }

            if (DbResource.ConceptMapResource.UseContext != null)
            {
                _Context.CodeableConcept.RemoveRange(DbResource.ConceptMapResource.UseContext);
            }

            _Context.ConceptMapResource.Remove(DbResource.ConceptMapResource);
        }

    }
}
