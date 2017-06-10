//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Pyro.Common.Interfaces.Service;
//using Pyro.Common.Interfaces.Repositories;
//using Pyro.Common.Interfaces;
//using Hl7.Fhir.Model;
//using Pyro.Common.BusinessEntities.Dto;
//using System.Net;
//using Hl7.Fhir.Utility;

//namespace Pyro.Engine.Services
//{
//  public class DefaultResourceServices : ResourceServices, IDefaultResourceServices, IResourceServices, ICommonServices
//  {
//    //Constructor for dependency injection
//    public DefaultResourceServices(IUnitOfWork IUnitOfWork)
//      : base(IUnitOfWork){}
    
//    public void SetCurrentResourceType(FHIRAllTypes ResourceType)
//    {      
//      _CurrentResourceType = ResourceType;
//      _ResourceRepository = new Pyro.Common.Tools.RepositorySwitcher().GetRepository(_CurrentResourceType, _UnitOfWork);
//    }

//    public void SetCurrentResourceType(ResourceType ResourceType)
//    {      
//      SetCurrentResourceType(ResourceType.SearchParameter.GetLiteral());
//    }
    
//    public void SetCurrentResourceType(string ResourceName)
//    {
//      Type ResourceType = ModelInfo.GetTypeForFhirType(ResourceName);
//      if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
//      {
//        this.SetCurrentResourceType((FHIRAllTypes)ModelInfo.FhirTypeNameToFhirType(ResourceName));        
//      }
//      else
//      {
//        string ErrorMessage = $"The Resource name given '{ResourceName}' is not a Resource supported by the .net FHIR API Version: {ModelInfo.Version}.";
//        var OpOutCome = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Fatal, OperationOutcome.IssueType.Invalid, ErrorMessage);
//        OpOutCome.Issue[0].Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_UNKNOWN_TYPE", String.Format("Resource Type '{0}' not recognised", ResourceName));
//        throw new DtoPyroException(HttpStatusCode.BadRequest, OpOutCome, ErrorMessage);
//      }      
//    }


    

//    //public new FHIRAllTypes SetCurrentResourceType
//    //{
//    //  set
//    //  {        
//    //    _CurrentResourceType = value;
//    //    _ResourceRepository = new Pyro.Common.Tools.RepositorySwitcher().GetRepository(_CurrentResourceType, _UnitOfWork);        
//    //  }
//    //}
//  }
//}
