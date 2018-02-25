using Pyro.Common.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Search;
using Pyro.Common.FhirOperation;
using Pyro.Common.Tools.Headers;
using Pyro.Common.ADHA.Api;


namespace Pyro.Common.Service
{
  public class IHISearchOrValidateOperationService : IIHISearchOrValidateOperationService
  {
    enum ResourceValidationModeType { None, Create, Update, Delete };
    List<OperationOutcome.IssueComponent> IssueList = null;
    string FormatMimeType = string.Empty;
    IResourceServiceOutcome ResourceServiceOutcome;

    private readonly Pyro.ADHA.Api.IHiServiceApi HiServiceApi;
    private readonly ICommonFactory ICommonFactory;
    private readonly ISearchParameterServiceFactory ISearchParameterServiceFactory;
    private readonly IPyroFhirUriFactory IPyroFhirUriFactory;
    private readonly IResourceServices IResourceServices;    

    public IHISearchOrValidateOperationService(
      ICommonFactory ICommonFactory,
      IPyroFhirUriFactory IPyroFhirUriFactory,
      ISearchParameterServiceFactory ISearchParameterServiceFactory,
      IResourceServices IResourceServices,
      Pyro.ADHA.Api.IHiServiceApi HiServiceApi)
    {
      this.ICommonFactory = ICommonFactory;
      this.IPyroFhirUriFactory = IPyroFhirUriFactory;
      this.ISearchParameterServiceFactory = ISearchParameterServiceFactory;
      this.IResourceServices = IResourceServices;      
      this.HiServiceApi = HiServiceApi;
    }

    public IResourceServiceOutcome IHISearchOrValidate(
      OperationClass OperationClass,
      Resource Resource,
      IPyroRequestUri RequestUri,
      ISearchParameterGeneric SearchParameterGeneric,
      IRequestHeader RequestHeaders)
    {
      if (OperationClass == null)
        throw new NullReferenceException("OperationClass cannot be null.");
      if (Resource == null)
        throw new NullReferenceException("Resource cannot be null.");
      if (RequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (RequestHeaders == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");
      if (SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");
      if (HiServiceApi == null)
        throw new NullReferenceException("HiServiceApi cannot be null.");

     
      if (typeof(Patient) != ModelInfo.GetTypeForFhirType(RequestUri.FhirRequestUri.ResourseName))
      {
        //return operation outcome that x-IHISearchOrValidate only supported for the Patient endpoint.
      }
      //Parse the parameter resource and populate the IhiRequestData object or error and return OperationOutcome
      //Make the call to HI Service, return any error as operation outcome or return the parameter resource wiht the results
      //Note: Need to create the Web.config properties for the HI Service Config as they as statis set at present

      IhiRequestData IhiRequestData = new IhiRequestData();
      //The User Id , does not need to be registered with Medicare
      IhiRequestData.UserId = "BobSmith";
      //The User Id Qualifier, does not need to be registered with Medicare
      IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      //If True the Soap Request and Response XML data will be returned for each call
      //A conformant Hi Service system must keep an audit trail of this data for 7 years
      IhiRequestData.ReturnSoapRequestAndResponseData = true;

      IhiRequestData.Dob = new DateTime(1982, 01, 24);
      //IhiRequestDemographics.DVANumber = "";
      IhiRequestData.Family = "MARCELLE";
      IhiRequestData.Given = "JUANITA";
      //IhiRequestDemographics.IHINumber = "1234567890123456";
      //IhiRequestDemographics.MedicareIRN = "1";
      IhiRequestData.MedicareNumber = "2950156481";
      IhiRequestData.SexChar = 'F';


      var HiServiceOutCome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);

      
      IssueList = new List<OperationOutcome.IssueComponent>();

      ResourceServiceOutcome = ICommonFactory.CreateResourceServiceOutcome();




      return ResourceServiceOutcome;
    }
      
    
  }
}
