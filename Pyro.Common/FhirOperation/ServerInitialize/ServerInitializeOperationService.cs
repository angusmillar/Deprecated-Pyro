using Pyro.Common.Interfaces.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.CompositionRoot;
using Pyro.Common.FhirOperation;
using Pyro.Common.RequestMetadata;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Repositories;
using Pyro.Common.Compartment;
using Pyro.Common.FhirOperation.BundleTransaction;
using Pyro.Common.Tools;
using Pyro.Common.Global;
using Pyro.Common.Service.ResourceService;


namespace Pyro.Common.FhirOperation.ServerInitialize
{
  public class ServerInitializeOperationService
  {
    private readonly IRepositorySwitcher IRepositorySwitcher;
    private readonly IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory;
    private readonly IResourceServices IResourceServices;
    private readonly IRequestMetaFactory IRequestMetaFactory;
    private readonly IBundleTransactionOperation IBundleTransactionOperation;
    private readonly IGlobalProperties IGlobalProperties;
    private readonly PyroHealthInformation.CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem;

    IResourceServiceOutcome ResourceServiceOutcome;

    public ServerInitializeOperationService(
      IRepositorySwitcher IRepositorySwitcher,
      IResourceServiceOutcomeFactory IResourceServiceOutcomeFactory,
      IResourceServices IResourceServices,
      IRequestMetaFactory IRequestMetaFactory,
      IGlobalProperties IGlobalProperties,
      IBundleTransactionOperation IBundleTransactionOperation,
      PyroHealthInformation.CodeSystems.IPyroFhirServer IPyroFhirServerCodeSystem)
    {
      this.IRepositorySwitcher = IRepositorySwitcher;
      this.IResourceServiceOutcomeFactory = IResourceServiceOutcomeFactory;
      this.IResourceServices = IResourceServices;
      this.IRequestMetaFactory = IRequestMetaFactory;
      this.IGlobalProperties = IGlobalProperties;
      this.IBundleTransactionOperation = IBundleTransactionOperation;
      this.IPyroFhirServerCodeSystem = IPyroFhirServerCodeSystem;
    }

    public IResourceServiceOutcome Initialize(OperationClass OperationClass, IRequestMeta RequestMeta, string FhirId)
    {
      if (OperationClass == null)
        throw new NullReferenceException("OperationClass cannot be null.");
      if (IResourceServices == null)
        throw new NullReferenceException("ResourceServices cannot be null.");
      if (RequestMeta == null)
        throw new NullReferenceException("RequestMeta cannot be null.");
      if (RequestMeta.PyroRequestUri == null)
        throw new NullReferenceException("RequestUri cannot be null.");
      if (RequestMeta.RequestHeader == null)
        throw new NullReferenceException("RequestHeaders cannot be null.");
      if (RequestMeta.SearchParameterGeneric == null)
        throw new NullReferenceException("SearchParameterGeneric cannot be null.");

      ResourceServiceOutcome = IResourceServiceOutcomeFactory.CreateResourceServiceOutcome();



      var ResourceRepository = IRepositorySwitcher.GetRepository(FHIRAllTypes.Patient);



      List<Resource> ResourceList = new List<Resource>();

      if (ResourceList.Count > 0)
      {
        Bundle TransactionBundle = GenerateTransactionBundle(ResourceList);
        var CurrentRequestMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.Bundle.GetLiteral()}/{TransactionBundle.Id}");
        IResourceServiceOutcome ResourceServiceOutcome = IBundleTransactionOperation.Transact(TransactionBundle, CurrentRequestMeta);
        return ResourceServiceOutcome;
      }


      //  var OutCome = IResourceServices.Put(Res.Id, Res, CurrentRequestMeta);

      //var ResourceRepository = IRepositorySwitcher.GetRepository(FHIRAllTypes.Patient);


      return ResourceServiceOutcome;
    }

    private List<Resource> GetResourceList()
    {
      List<Resource> ResourceList = new List<Resource>();
      ResourceList.AddRange(GetListAsOf20180507());
      return ResourceList;

    }

    private IEnumerable<Resource> GetListAsOf20180507()
    {
      List<Resource> ResourceList = new List<Resource>();
      string TaskId = "PyroServerInitialize20180507";
      var RequestTaskMeta = IRequestMetaFactory.CreateRequestMeta().Set($"{FHIRAllTypes.Task.GetLiteral()}/{TaskId}");
      var OutCome = IResourceServices.GetRead(TaskId, RequestTaskMeta);
      if (OutCome.ResourceResult == null )
      {
        var TaskRes = new Task();
        TaskRes.Id = TaskId;

        TaskRes.Meta = new Meta()
        {
          Tag = new List<Coding>()
           {
            IPyroFhirServerCodeSystem.GetCoding(PyroHealthInformation.CodeSystems.PyroFhirServer.Codes.Protected)
           }
        };

      }

      
      return ResourceList;

    }

    private Bundle GenerateTransactionBundle(List<Resource> ResourceList)
    {
      Bundle TranBundle = new Bundle();
      TranBundle.Id = "ServerInitialize";
      TranBundle.Type = Bundle.BundleType.Transaction;
      TranBundle.Entry = new List<Bundle.EntryComponent>();
      foreach(Resource Res in ResourceList)
      {
        var Entry = new Bundle.EntryComponent();
        Entry.Request = new Bundle.RequestComponent();
        Entry.FullUrl = $"{IGlobalProperties.ServiceBaseURL}/{Res.ResourceType.GetLiteral()}/{Res.Id}";
        Entry.Request.Method = Bundle.HTTPVerb.PUT;
        Entry.Request.Url = $"{Res.ResourceType.GetLiteral()}/{Res.Id}";
        Entry.Resource = Res;
      }
      return TranBundle;
    }
  }
}
