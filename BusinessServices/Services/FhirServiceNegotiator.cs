using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir = Hl7.Fhir;
using System.Net;
using System.Net.Http;
using Blaze.Engine.Response;
using Blaze.Engine.CustomException;

namespace Blaze.Engine.Services
{
  public class FhirServiceNegotiator : Interfaces.IFhirServiceNegotiator
  {
    private Interfaces.IResourceServices FhirService = null;

    private Interfaces.IResourceServices GetResourceService(string type)
    {      
      if (Fhir.Model.ModelInfo.IsKnownResource(type))
      {
        var ResourceType = Fhir.Model.ModelInfo.GetTypeForResourceName(type);
        if (BlazeImplementation.SupportedFhirResourceTypeDictionary.ContainsKey(ResourceType))
        {
          BlazeImplementation.SupportedFhirResource SupportedResource = BlazeImplementation.SupportedFhirResourceTypeDictionary[ResourceType];
          switch (SupportedResource)
          {
            case BlazeImplementation.SupportedFhirResource.Patient:
              return new PatientResourceServices();
            default:
              //throw new ApplicationException(String.Format("Internal error, BlazeImplementation.SupportedFhirResource indicates this Resource is supported yet not Service was found for the Resource type.", type));
              throw new BlazeException(HttpStatusCode.BadRequest, String.Format("Internal error, BlazeImplementation.SupportedFhirResource indicates this Resource is supported yet not Service was found for the Resource type.", type));    
          }          
        }
        else
        {          
          throw new BlazeException(HttpStatusCode.BadRequest, String.Format("The Fhir Resource is not currently supported by the Blaze server. Resource type was: {0}", type));
        }
      }
      throw new BlazeException(HttpStatusCode.BadRequest, String.Format("The Resource name given is not a Resource supported by DSTU2."));
    }
   
    public FhirRestResponse Get(string type, string FhirResourceId)
    {
      FhirService = this.GetResourceService(type);  
      return FhirService.Get(FhirResourceId);
    }

    public FhirRestResponse Get(string type, Uri uri, Fhir.Rest.SearchParams searchParams)
    {     
      FhirService = this.GetResourceService(type); 
      return FhirService.Get(uri, searchParams);
    }

    public FhirRestResponse Post(string type, Fhir.Model.Resource FhirResource)
    {
      FhirService = this.GetResourceService(type);
      return FhirService.Post(FhirResource);
    }

    public FhirRestResponse Put(string type, string FhirResourceId, Fhir.Model.Resource FhirResource)
    {     
      FhirService = this.GetResourceService(type);
      return FhirService.Put(FhirResourceId, FhirResource);
    }

    public FhirRestResponse Delete(string type, string FhirResourceId)
    {
      FhirService = this.GetResourceService(type);
      return FhirService.Delete(FhirResourceId);
    }

  }
}
