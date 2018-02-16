using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.CompositionRoot;
using Pyro.Common.Tools.UriSupport;
using Pyro.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Data.Entity;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Pyro.Common.Interfaces.Tools.HtmlSupport;
using Pyro.Common.Service;
using Pyro.Common.Logging;
using Pyro.Common.Global;

namespace Pyro.WebApi.Attributes
{
  public class ActionLogAttribute : ActionFilterAttribute
  {
    private string DateTimeKey = "ActionStartDateTime";
    private string StopwatchKey = "ActionStopwatch";
    static public string ResourceIdentityKey = "ResourceIdentity";

    public override void OnActionExecuting(HttpActionContext actionContext)
    {
      actionContext.Request.Properties[DateTimeKey] = DateTime.Now;
      actionContext.Request.Properties[StopwatchKey] = System.Diagnostics.Stopwatch.StartNew();
      base.OnActionExecuting(actionContext);
    }

    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
      var _FhirServiceNegotiator = actionExecutedContext.ActionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(IServiceNegotiator)) as IServiceNegotiator;
      var ResourceServices = _FhirServiceNegotiator.Create<IResourceServices>();
      var ICommonFactory = actionExecutedContext.ActionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(ICommonFactory)) as ICommonFactory;
      var IGlobalProperties = actionExecutedContext.ActionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(IGlobalProperties)) as IGlobalProperties;
      //var ILog = actionExecutedContext.ActionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(ILog)) as ILog;

      using (DbContextTransaction Transaction = ResourceServices.BeginTransaction())
      {
        try
        {

          DateTime dtStart = (DateTime)actionExecutedContext.Request.Properties[DateTimeKey];
          System.Diagnostics.Stopwatch stopwatch = (System.Diagnostics.Stopwatch)actionExecutedContext.Request.Properties[StopwatchKey];
          stopwatch.Stop();
          TimeSpan duration = stopwatch.Elapsed;

          ResourceServices.SetCurrentResourceType(FHIRAllTypes.AuditEvent);
          IPyroRequestUri DtoRequestUri = ICommonFactory.CreateDtoRequestUri(actionExecutedContext.Request.RequestUri.OriginalString);

          // use owin context so we can self host (i.e. avoid System.Web.HttpContext.Current)
          var owinContext = actionExecutedContext.Request.GetOwinContext();

          string machineName = System.Environment.MachineName;
          string httpVerb = actionExecutedContext.Request.Method.ToString();
          string ipAddress = owinContext.Request.RemoteIpAddress;
          string controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
          string actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
          bool successfulRequest = (actionExecutedContext.Exception == null);
          System.Web.Http.Routing.IHttpRouteData route = actionExecutedContext.ActionContext.ControllerContext.RouteData;

          // Get the resource base
          string baseUri = DtoRequestUri.FhirRequestUri.UriPrimaryServiceRoot.OriginalString;

          // Create the Security Event Object
          AuditEvent Audit = new AuditEvent();
          if (actionExecutedContext.Request.Method == HttpMethod.Put)
            Audit.Action = AuditEvent.AuditEventAction.U;
          else if (actionExecutedContext.Request.Method == HttpMethod.Post)
            Audit.Action = AuditEvent.AuditEventAction.C;
          else if (actionExecutedContext.Request.Method == HttpMethod.Delete)
            Audit.Action = AuditEvent.AuditEventAction.D;
          else
            Audit.Action = AuditEvent.AuditEventAction.R;

          Audit.Recorded = DateTimeOffset.Now;

          Audit.Outcome = AuditEvent.AuditEventOutcome.N0;
          if (!successfulRequest)
          {
            // log error
            if (actionExecutedContext.Exception is PyroException)
            {
              var fse = actionExecutedContext.Exception as PyroException;
              if ((int)fse.HttpStatusCode >= 500)
                Audit.Outcome = AuditEvent.AuditEventOutcome.N8;
              else if ((int)fse.HttpStatusCode >= 400)
                Audit.Outcome = AuditEvent.AuditEventOutcome.N4;
            }
            else
            {
              Audit.Outcome = AuditEvent.AuditEventOutcome.N8;
            }
          }

          Audit.Type = new Coding() { System = "http://hl7.org/fhir/security-event-type", Code = "rest", Display = "Restful Operation" };
          Audit.Subtype = new List<Coding>();

          if (actionExecutedContext.Request.Method == HttpMethod.Put)
            Audit.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "update", Display = "update" });
          else if (actionExecutedContext.Request.Method == HttpMethod.Post)
            Audit.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "create", Display = "create" });
          else if (actionExecutedContext.Request.Method == HttpMethod.Delete)
            Audit.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "delete", Display = "delete" });
          else if (actionExecutedContext.Request.Method == HttpMethod.Options)
            Audit.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "read", Display = "read" });
          else if (route.Values.ContainsKey("ResourceName") && route.Values.ContainsKey("id") && route.Values.ContainsKey("vid"))
            Audit.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "vread", Display = "vread" });
          else if (route.Values.ContainsKey("ResourceName") && route.Values.ContainsKey("id"))
          {
            if (owinContext.Request.Uri.OriginalString.Contains("_history"))
              Audit.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "history-instance", Display = "history-instance" });
            else
              Audit.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "read", Display = "read" });
          }
          else if (route.Values.ContainsKey("ResourceName"))
          {
            if (owinContext.Request.Uri.OriginalString.Contains("_history"))
              Audit.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "history-type", Display = "history-type" });
            else
              Audit.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "search-type", Display = "search-type" });
          }

          Audit.Agent.Add(new AuditEvent.AgentComponent());
          // se.Participant[0].UserId = "";
          // se.Participant[0].AltId = owinContext.Authentication.;
          if (owinContext.Authentication.User != null && owinContext.Authentication.User.Identity.IsAuthenticated)
          {
            Audit.Agent[0].Name = owinContext.Authentication.User.Identity.Name;

            // read additional details from the identity claims
            if (owinContext.Authentication.User.Identity is System.Security.Claims.ClaimsIdentity ci)
            {
              var claim = ci.Claims.Where(c => c.Type == "name").FirstOrDefault();
              if (claim != null)
                Audit.Agent[0].Name = claim.Value;
              claim = ci.Claims.Where(c => c.Type == "sub").FirstOrDefault();
              if (claim != null)
                Audit.Agent[0].AltId = claim.Value;
              if (ci.Claims.Any(c => c.Type == "author_only_access" && c.Value == "true"))
              {
                Audit.Agent[0].Role = new List<CodeableConcept>
                {
                  new CodeableConcept(null, "author_only_access")
                };
              }
            }
          }
          Audit.Agent[0].Requestor = true;
          Audit.Agent[0].Network = new AuditEvent.NetworkComponent()
          {
            Address = ipAddress,
            Type = AuditEvent.AuditEventAgentNetworkType.N2
          };

          Audit.Source = new AuditEvent.SourceComponent
          {
            Site = "Cloud",
            Identifier = new Identifier(null, actionExecutedContext.Request.RequestUri.GetLeftPart(UriPartial.Authority))
          };
          Audit.Source.Type.Add(new Coding() { System = "http://hl7.org/fhir/ValueSet/audit-source-type", Code = "3", Display = "Web Server" });

          if (route.Values.ContainsKey("ResourceName") && route.Values.ContainsKey("id"))
          {
            string relativeUri = String.Format("{0}/{1}", route.Values["ResourceName"] as string, route.Values["id"] as string);
            if (route.Values.ContainsKey("vid"))
              relativeUri += "/_history/" + route.Values["vid"] as string;
            Audit.Entity = new List<AuditEvent.EntityComponent>
            {
              new AuditEvent.EntityComponent()
              {
                Name = actionExecutedContext.Request.RequestUri.ToString(),
                Reference = new ResourceReference() { Url = new Uri(relativeUri, UriKind.Relative) },
                Type = new Coding() { System = "http://hl7.org/fhir/object-type", Code = "1", Display = "Person" }
              }
            };
            if (actionExecutedContext.Request.Properties.ContainsKey(Attributes.ActionLogAttribute.ResourceIdentityKey))
            {
              string reference = actionExecutedContext.Request.Properties[Attributes.ActionLogAttribute.ResourceIdentityKey] as string;
              if (!string.IsNullOrEmpty(reference))
                Audit.Entity[0].Reference.Reference = reference;
            }
          }
          else
          {
            Audit.Entity = new List<AuditEvent.EntityComponent>
            {
              new AuditEvent.EntityComponent()
              {
                Name = actionExecutedContext.Request.RequestUri.ToString(),
                Description = baseUri == null ?
                                owinContext.Request.Uri.OriginalString
                                : owinContext.Request.Uri.OriginalString.Replace(baseUri, ""),
                Type = new Coding() { System = "http://hl7.org/fhir/object-type", Code = "1", Display = "Person" }
              }
            };

            if (actionExecutedContext.Request.Properties.ContainsKey(Attributes.ActionLogAttribute.ResourceIdentityKey))
            {
              string reference = actionExecutedContext.Request.Properties[Attributes.ActionLogAttribute.ResourceIdentityKey] as string;
              if (!string.IsNullOrEmpty(reference))
                Audit.Entity[0].Reference = new ResourceReference() { Reference = reference };
            }
          }


          IHtmlGenerationSupport Narative = ICommonFactory.CreateFhirNarativeGenerationSupport();
          Narative.NewValuePairList("Time", string.Format("{0} ({1:f3} sec)", dtStart, duration.TotalSeconds));
          Narative.AppendValuePairList(actionExecutedContext.Request.Method.ToString(), string.Format("{0}", HttpUtility.HtmlEncode(baseUri == null ?
                                  owinContext.Request.Uri.OriginalString
                                  : owinContext.Request.Uri.OriginalString.Replace(baseUri, ""))));
          Narative.AppendValuePairList("BaseUri", baseUri);
          Narative.AppendValuePairList("From", ipAddress);
          if (owinContext.Authentication.User != null && owinContext.Authentication.User.Identity.IsAuthenticated)
            Narative.AppendValuePairList("User", owinContext.Authentication.User.ToString());
          else
            Narative.AppendValuePairList("User", "(anonymous)");

          if (Audit.Outcome != AuditEvent.AuditEventOutcome.N0)
          {
            Audit.OutcomeDesc = actionExecutedContext.Exception.Message;
            Narative.AppendValuePairList("Error", actionExecutedContext.Exception.Message);
          }
          Audit.Text = new Narrative
          {
            Div = Narative.Generate()
          };

          // Add custom PyroHealth event data
          Audit.AddExtension("http://pyrohealth.net/extention/AuditEvent/TimeTaken", new FhirDecimal((decimal)duration.TotalMilliseconds));

          if (IGlobalProperties.FhirAuditEventLogRequestData)
          {
            var requestDataObj = new AuditEvent.EntityComponent
            {
              Identifier = new Identifier(null, "RequestData"),
              Name = actionExecutedContext.Request.RequestUri.ToString(),
              Description = "Orginial Request Data",
              Type = new Coding() { System = "http://hl7.org/fhir/object-type", Code = "4", Display = "RequestData" },
              Detail = new List<AuditEvent.DetailComponent>()
            };
            var DetailComponent = new AuditEvent.DetailComponent();
            requestDataObj.Detail.Add(DetailComponent);
            string RequestData = GetRequestData(actionExecutedContext);
            if (!string.IsNullOrWhiteSpace(RequestData))
            {
              DetailComponent.Value = Encoding.UTF8.GetBytes(RequestData);
              Audit.Entity.Add(requestDataObj);
            }
          }
          
          if (IGlobalProperties.FhirAuditEventLogResponseData)
          {
            var responseDataObj = new AuditEvent.EntityComponent
            {
              Identifier = new Identifier(null, "ResponseData"),
              Name = actionExecutedContext.Request.RequestUri.ToString(),
              Description = "Orginial Response Data",
              Type = new Coding() { System = "http://hl7.org/fhir/object-type", Code = "4", Display = "ResponseData" },
              Detail = new List<AuditEvent.DetailComponent>()
            };
            var DetailComponent = new AuditEvent.DetailComponent();
            responseDataObj.Detail.Add(DetailComponent);
            string ResponseData = GetResponseData(actionExecutedContext);
            if (!string.IsNullOrWhiteSpace(ResponseData))
            {
              DetailComponent.Value = Encoding.UTF8.GetBytes(ResponseData);
              Audit.Entity.Add(responseDataObj);
            }
          }

          //Will only log if Debug logging is enabled. 
          DebugLogRequestResource(actionExecutedContext);


          //Commit to Database          
          IResourceServiceOutcome ResourceServiceOutcome = (ResourceServices as IResourceServicesBase).SetResource(Audit, DtoRequestUri, RestEnum.CrudOperationType.Create);
          Transaction.Commit();
        }
        catch (Exception Exec)
        {
          Logger.Log.Error(Exec, "ActionLogAttribute");
          Transaction.Rollback();
        }

        base.OnActionExecuted(actionExecutedContext);
      }
    }

    private void DebugLogRequestResource(HttpActionExecutedContext context)
    {
      if (Logger.Log.IsDebugEnabled)
      {
        if (context.ActionContext.ActionArguments.Keys.Count > 0)
        {
          if (context.ActionContext.ActionArguments.ContainsKey("resource"))
          {
            if (context.ActionContext.ActionArguments["resource"] is Resource FhirResource)
            {
              string XmlFHIRResource = Common.Tools.FhirResourceSerializationSupport.SerializeToXml(FhirResource);
              Logger.Log.Debug($"{System.Environment.NewLine}{XmlFHIRResource}{System.Environment.NewLine}");
            }
          }
        }
      }
    }

    private string GetRequestData(HttpActionExecutedContext context)
    {
      string result = null;

      if (context.ActionContext.ActionArguments.Keys.Count > 0)
      {        
        result = Newtonsoft.Json.JsonConvert.SerializeObject(context.ActionContext.ActionArguments);
      }
      return result;
    }

    private string GetResponseData(HttpActionExecutedContext actionExecutedContext)
    {
      string json = null;

      // GET is not supported, Response not populated when an error occurrs
      if (actionExecutedContext.Response != null)
      {
        var ms = (actionExecutedContext.ActionContext.ControllerContext.Controller as System.Web.Http.ApiController).ModelState;
        object jsonObj = null;
        if (ms != null && ms.Count > 0 && ms.Values != null && ms.Values.Count > 0)
        {
          jsonObj = new
          {
            ModelState = ms.Values,
            ResponseCode = actionExecutedContext.Response.StatusCode
          };
        }
        else
        {
          jsonObj = new { ResponseCode = actionExecutedContext.Response.StatusCode };
        }

        if (jsonObj != null)
        {
          json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
        }
      }

      return json + string.Empty;
    }

    private int GetEntityId(Microsoft.Owin.IOwinContext owinContext, HttpActionExecutedContext actionExecutedContext)
    {

      var split = owinContext.Request.Uri.AbsolutePath.Split('/').ToList();

      string x = !String.IsNullOrEmpty(split.Last()) ? split.Last() : split[split.Count - 2];
      Int32.TryParse(x, out int id);

      if (id == 0)
      {
        // if the id isn't part of the URL, then it's probably in the form data
        var model = actionExecutedContext.ActionContext.ActionArguments.Select(s => s.Value).FirstOrDefault();
        if (model != null)
        {
          // the first arg could be the actual id or it could be the entity
          if (model is Int32)
          {
            return (int)model;
          }
          else
          {
            // this would be easier if the id was in our base class,
            // but it's not due to automatic documentation so just doing
            // some basic string manipulation on the json object to find the id
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);
            string xx = json.Substring(json.IndexOf("\"Id\":"), 50);

            string idString = xx.Replace("\"Id\":", "");
            idString = idString.Substring(0, idString.IndexOf("\"") - 1).Trim();

            Int32.TryParse(idString, out id);
          }
        }
      }

      return id;
    }
  }
}