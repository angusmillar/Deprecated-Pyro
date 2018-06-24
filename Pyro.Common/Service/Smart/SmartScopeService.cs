using Hl7.Fhir.Model;
using Hl7.Fhir.Utility;
using Pyro.Common.Global;
using Pyro.Common.Search;
using Pyro.Common.Search.SearchParameterEntity;
using Pyro.Smart.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.Service.Smart
{
  public class SmartScopeService : ISmartScopeService
  {
    private readonly IGlobalProperties IGlobalProperties;
    private readonly string ClientIdName = "client_id";
    private readonly string ScopeName = "scope";
    public SmartScopeService(IGlobalProperties IGlobalProperties)
    {
      this.IGlobalProperties = IGlobalProperties;
    }

     
    public ISmartScopeOutcome ProcessScopes(PyroSearchParameters PyroSearchParameters, FHIRAllTypes ServiceResourceType, bool Read, bool Write)
    {
      ISmartScopeOutcome SmartScopeOutcome = new SmartScopeOutcome() { ScopesOK = false };
      // If FHIRApiAuthentication = false then no need to check and scopes, ScopesOK!
      if (!IGlobalProperties.FHIRApiAuthentication)
      {
        SmartScopeOutcome.ScopesOK = true;
        return SmartScopeOutcome;
      }
        
      SmartEnum.Action SmartAction = GetActionEnum(Read, Write);
      
      if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal is ClaimsPrincipal Principal)
      {
        //Get Client Id, we need to log this somewere, maybe FHIR AuditEventy?
        System.Security.Claims.Claim ClientClaim = Principal.Claims.SingleOrDefault(x => x.Type == ClientIdName);

        //Get tye scopes
        List<System.Security.Claims.Claim> ScopeClaim = Principal.Claims.Where(x => x.Type == ScopeName).ToList();

        //This should be injected
        ScopeParse ScopeParse = new ScopeParse();
        List<ISmartScope> ScopeList = new List<ISmartScope>();
        foreach (var ScopeString in ScopeClaim)
        {
          ISmartScope SmartScope = new SmartScope();
          if (ScopeParse.Parse(ScopeString.Value, out SmartScope))
          {
            ScopeList.Add(SmartScope);
          }
          else
          {
            string Message = $"Unable to parse the SMART on FHIR scope given. Scope was {ScopeString.Value}";
            var OpOut = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Message);
            throw new Common.Exceptions.PyroException(System.Net.HttpStatusCode.InternalServerError, OpOut, Message);
          }
        }

        IEnumerable<ISmartScope> FoundScopesList = ScopeList.Where(x => x.Resource == ServiceResourceType && (x.Action == SmartAction || x.Action == SmartEnum.Action.All));
        if (FoundScopesList.Count() > 0)
        {
          if (PyroSearchParameters.IncludeList != null && PyroSearchParameters.IncludeList.Count > 0)
          {
            foreach (var Include in PyroSearchParameters.IncludeList)
            {
              FoundScopesList = ScopeList.Where(x => x.Resource == Include.SourceResourceType && (x.Action == SmartAction || x.Action == SmartEnum.Action.All));
              if (FoundScopesList.Count() == 0)
              {
                //Reject
                string Message = $"You do not have permission to access the {Include.SourceResourceType.GetLiteral()} Resource type found within your include or revinclude search parameters.";
                var OpOut = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Forbidden, Message);
                SmartScopeOutcome.OperationOutcome = OpOut;
                SmartScopeOutcome.ScopesOK = false;
                return SmartScopeOutcome;
              }
            }
          }

          var SearchParametersThatHaveChainParametersList = PyroSearchParameters.SearchParametersList.Where(x => x.ChainedSearchParameterList.Count() != 0);
          if (SearchParametersThatHaveChainParametersList != null && SearchParametersThatHaveChainParametersList.Count() > 0)
          {

            foreach (ISearchParameterBase Chain in SearchParametersThatHaveChainParametersList)
            {
              if (!RecursiveChainScoped(Chain, ScopeList, SmartAction))
              {
                //Reject
                string Message = $"You do not have permission to access one of the Resources found within your chained search parameters.";
                var OpOut = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Forbidden, Message);
                SmartScopeOutcome.OperationOutcome = OpOut;
                SmartScopeOutcome.ScopesOK = false;
                return SmartScopeOutcome;
                
              }
            }
          }

          //ALL GOOD! We have a scope for the resource and action. all ok.
          SmartScopeOutcome.ScopesOK = true;
          return SmartScopeOutcome;
        }
        else
        {
          string Message = string.Empty;
          if (SmartAction == SmartEnum.Action.All)
          {
            Message = $"You do not have permission to access Resources {ServiceResourceType.GetLiteral()} types for Read or Write.";
          }
          else if (SmartAction == SmartEnum.Action.Read)
          {
            Message = $"You do not have permission to access Resources {ServiceResourceType.GetLiteral()} types for Read.";
          }
          else if (SmartAction == SmartEnum.Action.Read)
          {
            Message = $"You do not have permission to access Resources {ServiceResourceType.GetLiteral()} types for Write.";
          }
          var OpOut = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Forbidden, Message);
          SmartScopeOutcome.OperationOutcome = OpOut;
          SmartScopeOutcome.ScopesOK = false;
          return SmartScopeOutcome;
        }
      }
      else
      {
        //System.Threading.Thread.CurrentPrincipal was null
        string Message = "Internal Server Error: System.Threading.Thread.CurrentPrincipal was null";
        var OpOut = Common.Tools.FhirOperationOutcomeSupport.Create(OperationOutcome.IssueSeverity.Error, OperationOutcome.IssueType.Exception, Message);
        throw new Common.Exceptions.PyroException(System.Net.HttpStatusCode.InternalServerError, OpOut, Message);
      }
    }
    
    private bool RecursiveChainScoped(ISearchParameterBase ParentChain, List<ISmartScope> ScopeList, SmartEnum.Action SmartAction)
    {
      IEnumerable<ISmartScope> FoundScopesList = ScopeList.Where(x => x.Resource.GetLiteral() == ParentChain.Resource && (x.Action == SmartAction || x.Action == SmartEnum.Action.All));
      if (FoundScopesList.Count() > 0)
      {
        foreach (ISearchParameterBase ChildChain in ParentChain.ChainedSearchParameterList)
        {
          return RecursiveChainScoped(ChildChain, ScopeList, SmartAction);
        }
        //We have reached the end of the list and all had valid scopes
        return true;
      }
      else
      {
        //We have found a chain that does not have a scope, reject call
        return false;
      }
    }

    private SmartEnum.Action GetActionEnum(bool Read, bool Write)
    {
      if (Read && Write)
        return SmartEnum.Action.All;
      if (Read)
        return SmartEnum.Action.Read;
      if (Write)
        return SmartEnum.Action.Write;
      else
        throw new Exception($"Internal Server error: SMARTonFHIR SmartEnum.Action could not be resolved from Read {Read.ToString()} and Write {Write.ToString()}.");
    }
  }
}
