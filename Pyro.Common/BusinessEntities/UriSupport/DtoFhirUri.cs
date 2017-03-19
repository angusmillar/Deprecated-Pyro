using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Model;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.Common.BusinessEntities.UriSupport
{
  public class DtoFhirUri : IFhirUri
  {
    //Info
    //Absolute
    //value="http://angusmilllar.com.au/someApi/Organization/f001"

    //Absolute with _history
    //value="http://angusmilllar.com.au/someApi/Organization/f001/_history/2"   

    //Relative
    //value="Organization/f001"

    //Contained, this object does not need to parse these
    //value="#org1"

    private readonly char UriDelimieter = '/';
    private readonly string HistorySegmentName = "_history";
    private readonly string FormDataSearchSegmentName = "_search";
    private readonly string RegexResourceDilimeter = "|";
    private readonly char OperationPrefix = '$';
    private readonly string UrnSchemaCode = "urn";
    private readonly string UuidNameCode = "uuid";
    private readonly string OidNameCode = "oid";
    protected bool IsValidFhirUri = false;

    internal DtoFhirUri()
    {
      SetDefaults();
    }
    internal DtoFhirUri(Uri Uri)
    {
      SetDefaults();
      if (ParseUri(Uri))
      {
        this.IsValidFhirUri = true;
      }
      else
      {
        this.IsValidFhirUri = false;
      }
    }
    internal DtoFhirUri(string UriString)
    {
      SetDefaults();
      if (Uri.IsWellFormedUriString(UriString, UriKind.Absolute))
      {
        var Uri = new Uri(UriString);
        if (this.ParseUri(Uri))
        {
          this.IsValidFhirUri = true;
        }
        else
        {
          this.IsValidFhirUri = false;
        }
      }
      else
      {
        if (HttpUtil.IsRestResourceIdentity(UriString))
        {
          this.IsAbsoluteUri = false;
          if (ParseOutResourceIdentity(UriString))
          {
            this.IsValidFhirUri = true;
          }
          else
          {
            this.IsValidFhirUri = false;
          }
        }
        else
        {
          this.IsValidFhirUri = false;
        }
      }
    }

    private void SetDefaults()
    {
      this.IsFormDataSearch = false;
    }
    public bool IsAbsoluteUri { get; private set; }
    public bool IsRelativeUri { get { return !this.IsAbsoluteUri; } }

    /// <summary>
    /// The Raw Uri as it was passed in to DtoFhirUri
    /// </summary>
    public Uri Uri { get; private set; }
    /// <summary>
    /// example: 'Http' or 'Https'
    /// </summary>
    public string Schema { get; private set; }
    /// <summary>
    /// '://'
    /// </summary>
    public string SchemaDelimiter { get; private set; }
    /// <summary>
    /// example: 'www.somewhere.com'
    /// </summary>
    public string Authority { get; private set; }
    /// <summary>
    /// example: 'fhirapi/open' or 'fhirapi/open' or 'fhirapi'
    /// </summary>
    public string[] ApiSegments { get; private set; }
    /// <summary>
    /// example: 'Patient' or 'DiagnosticReport'
    /// </summary>
    public string ResourseType { get; private set; }
    /// <summary>
    /// example: '123456789'
    /// </summary>
    public string Id { get; private set; }
    /// <summary>
    /// Resource Operation: '$lookup'
    /// </summary>
    public string ResourceOperation { get; private set; }
    /// <summary>
    /// example: '_search'
    /// </summary>
    public bool IsFormDataSearch { get; private set; }
    /// <summary>
    /// example: True if the identity points to a history resource
    /// </summary>
    public bool IsHistory { get; private set; }
    /// <summary>
    /// The Version Id of the identity, null unless IsHistory is true 
    /// </summary>
    public string VersionId { get; private set; }
    /// <summary>
    /// Returns the full Service Root part as a Uri DataType
    /// </summary>
    public Uri ServiceRootUrl
    {
      get
      {
        if (this.IsAbsoluteUri)
        {
          if (this.Schema == UrnSchemaCode)
          {
            return null;
          }
          string NewUriString = string.Empty;
          if (this.ApiSegments.Length == 0)
            NewUriString = String.Format("{0}{1}{2}", Schema, SchemaDelimiter, Authority);
          else
            NewUriString = String.Format("{0}{1}{2}{3}{4}", Schema, SchemaDelimiter, Authority, UriDelimieter, ApiSegmentsToPath());
          return new Uri(NewUriString);
        }
        else
        {
          return null;
        }
      }
    }
    /// <summary>
    /// The Service Root without the Schema 'Http or Https' or Schema delimiter '://'
    /// and all lower case.
    /// This can be used to compare to URL's ServiceRoot for equality.  
    /// </summary>
    public string ServiceRootUrlForComparison
    {
      get
      {
        if (this.Schema == UrnSchemaCode)
        {
          return string.Empty;
        }
        if (this.ApiSegments.Length == 0)
          return String.Format("{0}", Authority).ToLower();
        else
          return String.Format("{0}{1}{2}", Authority, UriDelimieter, ApiSegmentsToPath()).ToLower();
      }
    }
    /// <summary>
    /// Retuns the full Resource identity with out the resource type (e.g /10/_history/2
    /// </summary>
    public string FullResourceIdentity
    {
      get
      {
        if (this.IsHistory)
          return String.Format("{1}{0}{2}{0}{3}", UriDelimieter.ToString(), this.Id, this.HistorySegmentName, this.VersionId);
        else
          return this.Id;
      }
    }
    /// <summary>
    /// The Query part of the request uri (e.g ?family=millar&given=angus)
    /// </summary>
    public string Query { get; private set; }
    public bool IsUuid
    {
      get
      {
        if (this.Schema == UrnSchemaCode)
        {
          if (this.Id.Contains(":" + UuidNameCode + ":"))
          {
            return true;
          }
        }
        return false;
      }
    }
    public bool IsUuidValid
    {
      get
      {
        if (this.Schema == UrnSchemaCode)
        {
          if (this.Id.Contains(":" + UuidNameCode + ":"))
          {
            return Uuid.IsValidValue(this.Id);            
          }
        }
        return false;
      }
     }
    public bool IsOid
    {
      get
      {
        if (this.Schema == UrnSchemaCode)
        {
          if (this.Id.Contains(":" + OidNameCode + ":"))
          {
            return true;
          }
        }
        return false;
      }
    }
    public bool IsOidValid
    {
      get
      {
        if (this.Schema == UrnSchemaCode)
        {
          if (this.Id.Contains(":" + OidNameCode + ":"))
          {
            return Oid.IsValidValue(this.Id);
          }
        }
        return false;
      }
    }


    public static bool TryParse(Uri Uri, out IFhirUri FhirUri)
    {
      FhirUri = Common.CommonFactory.GetFhirUri(Uri);
      var DtoFhirUri = FhirUri as DtoFhirUri;
      if (DtoFhirUri.IsValidFhirUri)
      {
        return true;
      }
      else
      {
        FhirUri = null;
        return false;
      }
    }

    public static bool TryParse(string Uri, out IFhirUri FhirUri)
    {
      FhirUri = Common.CommonFactory.GetFhirUri(Uri);
      var DtoFhirUri = FhirUri as DtoFhirUri;
      if (DtoFhirUri.IsValidFhirUri)
      {
        return true;
      }
      else
      {
        FhirUri = null;
        return false;
      }
    }

    private bool ParseUri(Uri Uri)
    {
      
      this.Uri = Uri;
      string UriPartToParse = string.Empty;
      if (Uri.IsAbsoluteUri)
      {
        this.IsAbsoluteUri = true;
        this.Schema = Uri.Scheme;
        if (this.Schema != UrnSchemaCode)
        {
          this.SchemaDelimiter = Uri.SchemeDelimiter;
        }
        else
        {
          this.SchemaDelimiter = string.Empty;
        }
        this.Authority = Uri.Authority;
        UriPartToParse = Uri.AbsolutePath;
        if (!string.IsNullOrWhiteSpace(Uri.Query))
        {
          this.Query = Uri.Query;          
        }
      }
      else
      {
        this.SchemaDelimiter = string.Empty;
        this.IsAbsoluteUri = false;
        UriPartToParse = Uri.OriginalString;
      }

      if (!ParseOutResourceIdentity(UriPartToParse))
      {
        return false;
      }
      if (this.IsUuid)
      {
        return IsUuidValid;
      }
      if (this.IsOid)
      {
        return IsOidValid;
      }
      if (this.ResourseType == null)
      {
        return false;
      }
      if (this.Id != null)
      {
        if (!HttpUtil.IsRestResourceIdentity(Uri))
        {
          return false;
        }
      }
      return true;
    }

    private bool ParseOutResourceIdentity(string UrlPart)
    {
      if (this.Schema == UrnSchemaCode || this.Schema == OidNameCode)
      {
        this.Id = this.Uri.OriginalString;        
        return true;
      }
      var ApiSegmentList = new List<string>();
      string FhirResourceRegexPattern = string.Empty;
      FhirResourceRegexPattern += String.Join(RegexResourceDilimeter, ModelInfo.SupportedResources);

      string[] AbsolutePathArray = null;
      UrlPart = System.Net.WebUtility.UrlDecode(UrlPart);
      AbsolutePathArray = UrlPart.Split(UriDelimieter);
      for (int i = 0; i < AbsolutePathArray.Length; i++)
      {
        if (this.ResourseType == null)
        {
          if (Regex.IsMatch(AbsolutePathArray[i], FhirResourceRegexPattern))
          {
            this.ResourseType = AbsolutePathArray[i];
          }
          else
          {
            if (i > 0)
            {
              ApiSegmentList.Add(AbsolutePathArray[i]);
            }
          }
        }
        else
        {
          if (this.Id == null && !this.IsFormDataSearch && AbsolutePathArray[i] == FormDataSearchSegmentName)
          {
            this.IsFormDataSearch = true;
          }
          else if (this.Id == null && string.IsNullOrWhiteSpace(this.ResourceOperation) && AbsolutePathArray[i].StartsWith(OperationPrefix.ToString()))
          {
            this.ResourceOperation = AbsolutePathArray[i].TrimStart(OperationPrefix);
          }
          else if (this.Id == null)
          {
            this.Id = AbsolutePathArray[i];
          }
          else
          {
            if (this.IsHistory)
            {
              this.VersionId = AbsolutePathArray[i];
            }
            else
            {
              if (Regex.IsMatch(AbsolutePathArray[i], HistorySegmentName, RegexOptions.IgnoreCase))
              {
                this.IsHistory = true;
              }
              else
              {
                return false;
              }
            }
          }
        }
      }
      this.ApiSegments = ApiSegmentList.ToArray();
      return true;
    }

    private string ApiSegmentsToPath()
    {
      var ReturnString = string.Empty;
      ReturnString += String.Join(UriDelimieter.ToString(), this.ApiSegments);
      return ReturnString;
    }
  }
}
