using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using Hl7.Fhir.Model;

using Pyro.Web.Response;
using Pyro.Common.Interfaces.Service;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.Interfaces;
using Pyro.Common.Interfaces.Dto;
using Pyro.Common.Interfaces.Dto.Headers;
using Pyro.Common.Enum;
using Pyro.Web.Extensions;

//using Hl7.Fhir.Server;
//using HealthConnex.Fhir.Models;
using System.Text;

namespace Pyro.Web.Attributes
{
  public class ActionLogAttribute : ActionFilterAttribute
  {
    private IServiceNegotiator _FhirServiceNegotiator;
    private string DateTimeKey = "ActionStartDateTime";
    private string StopwatchKey = "ActionStopwatch";
    static public string ResourceIdentityKey = "ResourceIdentity";
    
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
      _FhirServiceNegotiator = actionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(IServiceNegotiator)) as IServiceNegotiator;

      actionContext.Request.Properties[DateTimeKey] = DateTime.Now;
      actionContext.Request.Properties[StopwatchKey] = System.Diagnostics.Stopwatch.StartNew();

      base.OnActionExecuting(actionContext);
    }

    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
      try
      {
        DateTime dtStart = (DateTime)actionExecutedContext.Request.Properties[DateTimeKey];
        // TimeSpan duration = (DateTime.Now - dtStart);
        System.Diagnostics.Stopwatch stopwatch = (System.Diagnostics.Stopwatch)actionExecutedContext.Request.Properties[StopwatchKey];
        stopwatch.Stop();
        TimeSpan duration = stopwatch.Elapsed;

        // use owin context so we can self host (i.e. avoid System.Web.HttpContext.Current)
        var owinContext = actionExecutedContext.Request.GetOwinContext();

        string machineName = System.Environment.MachineName;
        string httpVerb = actionExecutedContext.Request.Method.ToString();
        string ipAddress = owinContext.Request.RemoteIpAddress;
        //string jsonRequestData = GetRequestData(actionExecutedContext);
        string controllerName = actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName;
        string actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
        bool successfulRequest = (actionExecutedContext.Exception == null);
        System.Web.Http.Routing.IHttpRouteData route = actionExecutedContext.ActionContext.ControllerContext.RouteData;

        // Get the resource base
        string baseUri = null;
        if (route.Values.ContainsKey("ResourceName"))
        {
          //baseUri = Utility.CalculateBaseURI(actionExecutedContext.ActionContext.ControllerContext.Controller as System.Web.Http.ApiController, route.Values["ResourceName"] as string);
        }
        else if (route.Route.RouteTemplate == "fhir/metadata" || route.Route.RouteTemplate == "fhir")
        {
          //         baseUri = Utility.CalculateBaseURI(actionExecutedContext.ActionContext.ControllerContext.Controller as System.Web.Http.ApiController, "metadata");
        }
        else if (route.Route.RouteTemplate == "fhir/${operation}")
        {
          //         baseUri = Utility.CalculateBaseURI(actionExecutedContext.ActionContext.ControllerContext.Controller as System.Web.Http.ApiController, "${operation}");
        }

        // Create the Security Event Object
        AuditEvent se = new AuditEvent();
        //se.UserData.Add("system", true);
        //se.Event = new AuditEvent.EventComponent();
        if (actionExecutedContext.Request.Method == HttpMethod.Put)
          se.Action = AuditEvent.AuditEventAction.U;
        else if (actionExecutedContext.Request.Method == HttpMethod.Post)
          se.Action = AuditEvent.AuditEventAction.C;
        else if (actionExecutedContext.Request.Method == HttpMethod.Delete)
          se.Action = AuditEvent.AuditEventAction.D;
        else
          se.Action = AuditEvent.AuditEventAction.R;

        se.Recorded = DateTimeOffset.Now;

        se.Outcome = AuditEvent.AuditEventOutcome.N0;
        if (!successfulRequest)
        {
          // log error
          if (actionExecutedContext.Exception is Pyro.Common.BusinessEntities.Dto.DtoPyroException)
          {
            var fse = actionExecutedContext.Exception as Pyro.Common.BusinessEntities.Dto.DtoPyroException;
            if ((int)fse.HttpStatusCode >= 500)
              se.Outcome = AuditEvent.AuditEventOutcome.N8;
            else if ((int)fse.HttpStatusCode >= 400)
              se.Outcome = AuditEvent.AuditEventOutcome.N4;
          }
          else
          {
            se.Outcome = AuditEvent.AuditEventOutcome.N8;
          }
        }

        se.Type = new Coding() { System = "http://hl7.org/fhir/security-event-type", Code = "rest", Display = "Restful Operation" };
        se.Subtype = new List<Coding>();

        if (actionExecutedContext.Request.Method == HttpMethod.Put)
          se.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "update", Display = "update" });
        else if (actionExecutedContext.Request.Method == HttpMethod.Post)
          se.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "create", Display = "create" });
        else if (actionExecutedContext.Request.Method == HttpMethod.Delete)
          se.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "delete", Display = "delete" });
        else if (actionExecutedContext.Request.Method == HttpMethod.Options)
          se.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "read", Display = "read" });
        else if (route.Values.ContainsKey("ResourceName") && route.Values.ContainsKey("id") && route.Values.ContainsKey("vid"))
          se.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "vread", Display = "vread" });
        else if (route.Values.ContainsKey("ResourceName") && route.Values.ContainsKey("id"))
        {
          if (owinContext.Request.Uri.OriginalString.Contains("_history"))
            se.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "history-instance", Display = "history-instance" });
          else
            se.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "read", Display = "read" });
        }
        else if (route.Values.ContainsKey("ResourceName"))
        {
          if (owinContext.Request.Uri.OriginalString.Contains("_history"))
            se.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "history-type", Display = "history-type" });
          else
            se.Subtype.Add(new Coding() { System = "http://hl7.org/fhir/restful-interaction", Code = "search-type", Display = "search-type" });
        }

        se.Agent.Add(new AuditEvent.AgentComponent());
        // se.Participant[0].UserId = "";
        // se.Participant[0].AltId = owinContext.Authentication.;
        if (owinContext.Authentication.User != null && owinContext.Authentication.User.Identity.IsAuthenticated)
        {
          se.Agent[0].Name = owinContext.Authentication.User.Identity.Name;

          // read additional details from the identity claims
          var ci = owinContext.Authentication.User.Identity as System.Security.Claims.ClaimsIdentity;
          if (ci != null)
          {
            var claim = ci.Claims.Where(c => c.Type == "name").FirstOrDefault();
            if (claim != null)
              se.Agent[0].Name = claim.Value;
            claim = ci.Claims.Where(c => c.Type == "sub").FirstOrDefault();
            if (claim != null)
              se.Agent[0].AltId = claim.Value;
            if (ci.Claims.Any(c => c.Type == "author_only_access" && c.Value == "true"))
            {
              se.Agent[0].Role = new List<CodeableConcept>();
              se.Agent[0].Role.Add(new CodeableConcept(null, "author_only_access"));
            }
          }
        }
        se.Agent[0].Requestor = true;
        se.Agent[0].Network = new AuditEvent.NetworkComponent()
        {
          Address = ipAddress,
          Type = AuditEvent.AuditEventAgentNetworkType.N2
        };

        se.Source = new AuditEvent.SourceComponent();
        se.Source.Site = "Cloud";
        se.Source.Identifier = new Identifier(null, actionExecutedContext.Request.RequestUri.GetLeftPart(UriPartial.Authority));
        se.Source.Type.Add(new Coding() { System = "http://hl7.org/fhir/ValueSet/audit-source-type", Code = "3", Display = "Web Server" });

        if (route.Values.ContainsKey("ResourceName") && route.Values.ContainsKey("id"))
        {
          string relativeUri = String.Format("{0}/{1}", route.Values["ResourceName"] as string, route.Values["id"] as string);
          if (route.Values.ContainsKey("vid"))
            relativeUri += "/_history/" + route.Values["vid"] as string;
          se.Entity = new List<AuditEvent.EntityComponent>();
          se.Entity.Add(new AuditEvent.EntityComponent()
          {
            Name = actionExecutedContext.Request.RequestUri.ToString(),
            Reference = new ResourceReference() { Url = new Uri(relativeUri, UriKind.Relative) },
            Type = new Coding() { System = "http://hl7.org/fhir/object-type", Code = "1", Display = "Person" }
          });
          if (actionExecutedContext.Request.Properties.ContainsKey(Attributes.ActionLogAttribute.ResourceIdentityKey))
          {
            string reference = actionExecutedContext.Request.Properties[Attributes.ActionLogAttribute.ResourceIdentityKey] as string;
            if (!string.IsNullOrEmpty(reference))
              se.Entity[0].Reference.Reference = reference;
          }
        }
        else
        {
          se.Entity = new List<AuditEvent.EntityComponent>();
          se.Entity.Add(new AuditEvent.EntityComponent()
          {
            Name = actionExecutedContext.Request.RequestUri.ToString(),
            Description = baseUri == null ?
                              owinContext.Request.Uri.OriginalString
                              : owinContext.Request.Uri.OriginalString.Replace(baseUri, ""),
            Type = new Coding() { System = "http://hl7.org/fhir/object-type", Code = "1", Display = "Person" }
            // Type = AuditEvent.AuditEventObjectType.N1
          });
          if (actionExecutedContext.Request.Properties.ContainsKey(Attributes.ActionLogAttribute.ResourceIdentityKey))
          {
            string reference = actionExecutedContext.Request.Properties[Attributes.ActionLogAttribute.ResourceIdentityKey] as string;
            if (!string.IsNullOrEmpty(reference))
              se.Entity[0].Reference = new ResourceReference() { Reference = reference };
          }
        }

        StringBuilder sb = new StringBuilder();
        sb.Append(string.Format("Time", "{0} ({1:f3} sec)", dtStart, duration.TotalSeconds));
        // sb.AppendFormatFHIRFields("Method", "{0}", actionExecutedContext.Request.Method);

        sb.Append(string.Format(actionExecutedContext.Request.Method.ToString(), "{0}", HttpUtility.HtmlEncode(baseUri == null ?
                                owinContext.Request.Uri.OriginalString
                                : owinContext.Request.Uri.OriginalString.Replace(baseUri, ""))));
        sb.Append(string.Format("		<{0}{1}>{2}</{0}><br/>", "Utility.TextDivFieldType", "Utility.TextDivFieldStyle", baseUri));

        sb.Append(string.Format("From", "{0}", ipAddress));
        if (owinContext.Authentication.User != null && owinContext.Authentication.User.Identity.IsAuthenticated)
          sb.Append(string.Format("User", "{0}", HttpUtility.HtmlEncode("owinContext.Authentication.User.GetUserName()")));
        else
          sb.Append(string.Format("User", "(anonymous)"));

        //if (route.Values.ContainsKey("ResourceName"))
        //    sb.AppendFormatFHIRFields("Resource", route.Values["ResourceName"] as string);
        //if (route.Values.ContainsKey("id"))
        //    sb.AppendFormatFHIRFields("id", HttpUtility.HtmlEncode(route.Values["id"] as string));
        //if (route.Values.ContainsKey("vid"))
        //    sb.AppendFormatFHIRFields("vid", HttpUtility.HtmlEncode(route.Values["vid"] as string));
        if (se.Outcome != AuditEvent.AuditEventOutcome.N0)
        {
          se.OutcomeDesc = actionExecutedContext.Exception.Message;
          sb.Append(string.Format("<span style='color:red'>error</span>", "{0}", HttpUtility.HtmlEncode(actionExecutedContext.Exception.Message)));
        }
        //se.Text = new Narrative();
        //se.Text.Div = sb.ToString();
        //se.Text = Hl7.Fhir.Server.Utility.CreateNarative(sb.ToString());


        // Add custom SQL-on-FHIR event data
        se.AddExtension("http://healthconnex.com.au/sof/AuditEvent/TimeTaken", new FhirDecimal((decimal)duration.TotalMilliseconds));

        if (true)
        //if (FhirAppSettings.LogRequestData)
        {
          var requestDataObj = new AuditEvent.EntityComponent()
          {
            Identifier = new Identifier(null, "RequestData"),
            Name = actionExecutedContext.Request.RequestUri.ToString(),
            Description = "Orginial Request Data",
            Type = new Coding() { System = "http://hl7.org/fhir/object-type", Code = "4", Display = "RequestData" },
            Detail = new List<AuditEvent.DetailComponent>()
                        {
                            new AuditEvent.DetailComponent
                            {
                                Value = Encoding.UTF8.GetBytes(GetRequestData(actionExecutedContext))
                            }
                        }
          };
          se.Entity.Add(requestDataObj);
        }

        if (true)
        //if (FhirAppSettings.LogResponseData)
        {
          var responseDataObj = new AuditEvent.EntityComponent()
          {
            Identifier = new Identifier(null, "ResponseData"),
            Name = actionExecutedContext.Request.RequestUri.ToString(),
            Description = "Orginial Response Data",
            Type = new Coding() { System = "http://hl7.org/fhir/object-type", Code = "4", Display = "ResponseData" },
            Detail = new List<AuditEvent.DetailComponent>()
                        {
                            new AuditEvent.DetailComponent
                            {
                                Value = Encoding.UTF8.GetBytes(GetResponseData(actionExecutedContext))
                            }
                        }
          };
          se.Entity.Add(responseDataObj);
        }


        IBaseResourceServices oService = _FhirServiceNegotiator.GetService(ResourceType.AuditEvent.ToString());
        IDtoFhirRequestUri DtoFhirRequestUri = Services.PrimaryServiceRootFactory.Create(oService as ICommonServices, actionExecutedContext.Request.RequestUri);
        //Check the search parameters here don't conflict with what we are doing as there are the actually request parameters not specific to this post
        IDtoSearchParameterGeneric SearchParameterGeneric = Common.CommonFactory.GetDtoSearchParameterGeneric(actionExecutedContext.Request.GetSearchParams());
        IResourceServiceRequest ResourceServiceRequest = Common.CommonFactory.GetResourceServiceRequest(ServiceEnums.ServiceRequestType.Create, se, DtoFhirRequestUri, SearchParameterGeneric);

        IResourceServiceOutcome ResourceServiceOutcome = oService.Post(ResourceServiceRequest);





        //var model = ModelFactory.GetModel(ResourceType.AuditEvent.ToString(),
        //    Controllers.StandardResourceController.GetInputs(actionExecutedContext.Request,
        //    actionExecutedContext.ActionContext.ControllerContext.RequestContext.Principal,
        //    !string.IsNullOrWhiteSpace(baseUri) ? new Uri(baseUri) : null)
        //) as AuditEventModel;

        //if (actionExecutedContext.Exception != null)
        //{
        //  var error = new HealthConnex.Fhir.Store.ErrorLog()
        //  {
        //    ErrorMessage = actionExecutedContext.Exception.Message,
        //    SerialisedException = Newtonsoft.Json.JsonConvert.SerializeObject(actionExecutedContext.Exception, Newtonsoft.Json.Formatting.Indented)
        //  };
        //  se.UserData["ErrorLog"] = error;
        //}

        //model.Create(se, null, null, null);
      }
      catch (Exception ex)
      {
        // TODO: This exception should be stored somewhere, registry?
        System.Diagnostics.Trace.WriteLine(ex.Message);
      }

      base.OnActionExecuted(actionExecutedContext);
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
      int id = 0;

      var split = owinContext.Request.Uri.AbsolutePath.Split('/').ToList();

      string x = !String.IsNullOrEmpty(split.Last()) ? split.Last() : split[split.Count - 2];
      Int32.TryParse(x, out id);

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