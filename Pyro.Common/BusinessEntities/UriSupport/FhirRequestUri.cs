using Hl7.Fhir.Model;
using Pyro.Common.Enum;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.ServiceRoot;
using Pyro.Common.Tools;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pyro.Common.BusinessEntities.UriSupport
{
  public enum UrnType { uuid, oid };

  public class FhirRequestUri : IFhirRequestUri
  {
    private readonly IPrimaryServiceRootCache IPrimaryServiceRootCache;
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="PrimaryServiceRoot">Should take the form http://SomeServer.net/bla/bla/bla/fhir </param>
    public FhirRequestUri(IPrimaryServiceRootCache IPrimaryServiceRootCache)
    {
      this.IPrimaryServiceRootCache = IPrimaryServiceRootCache;
      Uri TempUri = null;
      if (Uri.TryCreate(this.IPrimaryServiceRootCache.GetPrimaryRootUrlFromWebConfig(), UriKind.RelativeOrAbsolute, out TempUri))
      {
        this.PrimaryServiceRootServers = TempUri;
      }
      else
      {
        ErrorInParseing = true;
        ParseErrorMessage = $"The Primary Service root Uri was not able to be parsed: {this.IPrimaryServiceRootCache.GetPrimaryRootUrlFromWebConfig()}";
      }
    }

    private const string _MetadataName = "metadata";
    private const string _HistoryName = "_history";
    private const string _SearchFormDataName = "_search";
    private const string _UrnName = "urn";
    private const string _OidName = "oid";
    private const string _uuidName = "uuid";
    private const string _HttpName = "http";
    private const string _HttpsName = "https";

    public string ParseErrorMessage { get; set; }
    public bool ErrorInParseing { get; set; }
    public string ResourseName { get; set; }
    public string ResourceId { get; set; }
    public string VersionId { get; set; }
    public string OperationName { get; set; }
    public string Query { get; set; }
    public string OriginalString { get; set; }
    public bool IsUrn { get; set; }
    public string Urn { get; set; }
    public UrnType? UrnType { get; private set; }
    public bool IsFormDataSearch { get; set; }
    public bool IsRelativeToServer { get; set; }
    public bool IsOperation
    {
      get
      {
        return (this.OperationType.HasValue);
      }
    }
    public FhirOperationEnum.OperationScope? OperationType { get; private set; }
    public bool IsContained { get; set; }
    public bool IsMetaData { get; set; }
    public bool IsHistoryReferance { get; set; }
    public Uri UriPrimaryServiceRoot
    {
      get
      {
        if (this.IsRelativeToServer)
          return this.PrimaryServiceRootServers;
        else
          return this.PrimaryServiceRootRemote;
      }
    }
    public Uri PrimaryServiceRootRemote { get; set; }
    public Uri PrimaryServiceRootServers { get; set; }
    public bool Parse(string RequestUri)
    {
      ParseErrorMessage = string.Empty;
      ErrorInParseing = false;
      return ProcessRequestUri(System.Net.WebUtility.UrlDecode(RequestUri));
    }
    private bool ProcessRequestUri(string RequestUri)
    {
      this.OriginalString = RequestUri;
      string ChainResult = string.Empty;
      ChainResult = ResolveQueryUriPart(RequestUri);

      if (ErrorInParseing)
      {
        return false;
      }
      ChainResult = ResolvePrimaryServiceRoot(ChainResult);

      if (ErrorInParseing)
      {
        return false;
      }
      ChainResult = ResolveRelativeUriPart(ChainResult);

      if (ErrorInParseing)
      {
        return false;
      }
      ChainResult = ResolveResourceIdPart(ChainResult);

      if (ChainResult != string.Empty)
      {
        ParseErrorMessage = $"The URI has extra unknown content near the end of : '{ChainResult}'. The full URI was: '{RequestUri}'";
        ErrorInParseing = true;
        return false;
      }
      else
      {
        return true;
      }
    }

    private string ResolveQueryUriPart(string value)
    {
      if (value.Contains('?'))
      {
        var Split = value.Split('?');
        this.Query = Split[1];
        return Split[0];
      }
      else
      {
        return value;
      }
    }
    private string ResolvePrimaryServiceRoot(string RequestUri)
    {
      string RequestRelativePath;
      if (RequestUri.StripHttp().ToLower().StartsWith(this.PrimaryServiceRootServers.OriginalString.StripHttp()))
      //if (RequestUri.ToLower().StartsWith(this.PrimaryServiceRootServers.OriginalString))
      {
        //If the request URL starts with our known servers root then cut it off and return relative part , job done.
        this.IsRelativeToServer = true;
        RequestUri = RequestUri.StripHttp();
        string PrimaryServiceRootServers = this.PrimaryServiceRootServers.OriginalString.StripHttp();
        RequestRelativePath = RequestUri.Substring(PrimaryServiceRootServers.Count(), RequestUri.Count() - PrimaryServiceRootServers.Count());
        if (RequestRelativePath.StartsWith("/"))
          RequestRelativePath = RequestRelativePath.TrimStart('/');
        return RequestRelativePath;
      }
      else if (RequestUri.ToLower().StartsWith(_HttpName) || RequestUri.ToLower().StartsWith(_HttpsName))
      {
        //If not and the URL starts with 'http' or 'https' then loop through each segment of the URL looking for 
        //a segment that matches to the FHIR Resource name. Once found we can determine the remote root and return the 
        // relative part.
        this.IsRelativeToServer = false;
        string FhirResourceRegexPattern = string.Empty;
        string RegexResourceDilimeter = "|";
        FhirResourceRegexPattern += String.Join(RegexResourceDilimeter, ModelInfo.SupportedResources);
        string RemotePrimaryServiceRoot = string.Empty;
        var PathSplit = RequestUri.Split('#')[0].Split('/');
        foreach (string Segment in PathSplit)
        {
          if (Regex.IsMatch(Segment, FhirResourceRegexPattern))
          {
            //Resource segment found 
            break;
          }
          else if (Segment.StartsWith("$"))
          {
            //Operation segment found
            break;
          }
          else if (Segment.ToLower() == _MetadataName)
          {
            //metadate segment found
            break;
          }
          RemotePrimaryServiceRoot = String.Join("/", RemotePrimaryServiceRoot, Segment);
        }
        RemotePrimaryServiceRoot = RemotePrimaryServiceRoot.TrimStart('/');
        //strip off and set the primary root
        this.PrimaryServiceRootRemote = new Uri(RemotePrimaryServiceRoot);
        RequestRelativePath = RequestUri.Substring(RemotePrimaryServiceRoot.Count(), RequestUri.Count() - RemotePrimaryServiceRoot.Count());
        if (RequestRelativePath.StartsWith("/"))
          RequestRelativePath = RequestRelativePath.TrimStart('/');
        return RequestRelativePath;
      }
      else if (RequestUri.ToLower().StartsWith($"{_UrnName}:{_uuidName}:") || RequestUri.ToLower().StartsWith($"{_UrnName}:{_OidName}:"))
      {
        this.IsRelativeToServer = false;
        this.IsUrn = true;
        if (RequestUri.ToLower().StartsWith($"{_UrnName}:{_uuidName}:"))
        {
          this.UrnType = UriSupport.UrnType.uuid;
          this.Urn = RequestUri;
          if (!Uuid.IsValidValue(this.Urn))
          {
            ParseErrorMessage = $"The {_UrnName}:{_uuidName} value given is not valid: {this.Urn}";
            ErrorInParseing = true;
            return string.Empty;
          }
        }
        if (RequestUri.ToLower().StartsWith($"{_UrnName}:{_OidName}:"))
        {
          this.UrnType = UriSupport.UrnType.oid;
          this.Urn = RequestUri;
          if (!Oid.IsValidValue(this.Urn))
          {
            ParseErrorMessage = $"The {_UrnName}:{_OidName} value given is not valid: {this.Urn}";
            ErrorInParseing = true;
            return string.Empty;
          }
        }
        RequestRelativePath = RequestUri.Substring(this.Urn.Count(), RequestUri.Count() - this.Urn.Count());
        return RequestRelativePath;
      }
      else
      {
        //The path has not Primary root and is a relative URI
        this.IsRelativeToServer = true;
        RequestRelativePath = RequestUri;
        return RequestRelativePath;
      }
    }
    private string ResolveRelativeUriPart(string RequestRelativePath)
    {
      if (RequestRelativePath == string.Empty)
        return string.Empty;

      string Remainder = string.Empty;
      var SplitParts = RequestRelativePath.Split('?')[0].Split('/');
      foreach (string Segment in SplitParts)
      {
        if (Segment.StartsWith("$"))
        {
          //It is a base operation          
          this.OperationType = FhirOperationEnum.OperationScope.Base;
          this.OperationName = Segment.TrimStart('$');
          return RequestRelativePath.Substring(this.OperationName.Count() + 1, RequestRelativePath.Count() - (this.OperationName.Count() + 1));
        }
        else if (Segment.StartsWith("#"))
        {
          //It is a contained referance with out a resource name e.g (#123456) and not (Patient/#123456)
          this.IsContained = true;
          this.IsRelativeToServer = false;
          this.ResourceId = Segment.TrimStart('#');
          return RequestRelativePath.Substring(this.ResourceId.Count() + 1, RequestRelativePath.Count() - (this.ResourceId.Count() + 1));
        }
        else if (Segment.ToLower() == _MetadataName)
        {
          //This is a metadata request
          this.IsMetaData = true;
          Remainder = RequestRelativePath.Substring(_MetadataName.Count(), RequestRelativePath.Count() - _MetadataName.Count());
          return RemoveStartsWithSlash(Remainder);
        }
        else
        {
          //This is a Resource referance
          string FhirResourceRegexPattern = string.Empty;
          string RegexResourceDilimeter = "|";
          FhirResourceRegexPattern += String.Join(RegexResourceDilimeter, ModelInfo.SupportedResources);
          if (Regex.IsMatch(Segment, FhirResourceRegexPattern))
          {
            this.ResourseName = Segment;
            Remainder = RequestRelativePath.Substring(this.ResourseName.Count(), RequestRelativePath.Count() - this.ResourseName.Count());
            return RemoveStartsWithSlash(Remainder);
          }
          else
          {
            ParseErrorMessage = $"The URI has no Resource or metadata or $Operation or #Contained segment or does not begin with http:// or https://. Found invalid segment: {Segment} in URL: {this.OriginalString}";
            ErrorInParseing = true;
            return string.Empty;
          }
        }
      }
      ParseErrorMessage = $"The URI has no Resource or metadata or $Operation or #Contained segment. Found invalid segment: {RequestRelativePath} in URL {this.OriginalString}";
      ErrorInParseing = true;
      return string.Empty;
    }
    private string ResolveResourceIdPart(string value)
    {
      string Remainder = value;
      if (value == string.Empty)
      {
        return value;
      }
      else
      {
        var Split = value.Split('/');
        foreach (string Segment in Split)
        {
          if (this.ResourceId == null)
          {
            //Resource Id
            if (Segment.StartsWith("#"))
            {
              //Contained Resource #Id
              this.IsContained = true;
              this.IsRelativeToServer = false;
              this.ResourceId = Segment.TrimStart('#');
              Remainder = RemoveStartsWithSlash(Remainder.Substring(this.ResourceId.Count() + 1, Remainder.Count() - (this.ResourceId.Count() + 1)));
            }
            else if (Segment.ToLower() == _SearchFormDataName)
            {
              //Search Form Data 
              this.IsFormDataSearch = true;
              Remainder = RemoveStartsWithSlash(Remainder.Substring(_SearchFormDataName.Count(), Remainder.Count() - _SearchFormDataName.Count()));
              //Must not be anything after _search, the search parameters are in the body.
              break;
            }
            else if (!this.IsOperation && Segment.StartsWith("$"))
            {
              //A Resource $operation e.g (base/Patient/$operation)              
              this.OperationType = FhirOperationEnum.OperationScope.Resource;
              this.OperationName = Segment.TrimStart('$');
              Remainder = RemoveStartsWithSlash(Remainder.Substring(this.OperationName.Count() + 1, Remainder.Count() - (this.OperationName.Count() + 1)));
              return Remainder;
            }
            else
            {
              //Normal Resource Id
              this.ResourceId = Segment;
              Remainder = RemoveStartsWithSlash(Remainder.Substring(this.ResourceId.Count(), Remainder.Count() - this.ResourceId.Count()));
            }
          }
          else
          {
            if (!this.IsOperation && this.ResourceId != null && Segment.StartsWith("$"))
            {
              //A Resource Instance $operation e.g (base/Patient/10/$operation)              
              this.OperationType = FhirOperationEnum.OperationScope.Instance;
              this.OperationName = Segment.TrimStart('$');
              Remainder = RemoveStartsWithSlash(Remainder.Substring(this.OperationName.Count() + 1, Remainder.Count() - (this.OperationName.Count() + 1)));
              return Remainder;
            }
            else if (Segment.ToLower() == _HistoryName)
            {
              //History segment e.g (_history)
              //Is this case iterate over loop again to see is we have a Resource VersionId
              this.IsHistoryReferance = true;
              Remainder = RemoveStartsWithSlash(Remainder.Substring(_HistoryName.Count(), Remainder.Count() - _HistoryName.Count()));
            }
            else if (this.IsHistoryReferance)
            {
              //History version id
              this.VersionId = Segment;
              Remainder = RemoveStartsWithSlash(Remainder.Substring(this.VersionId.Count(), Remainder.Count() - this.VersionId.Count()));
              return Remainder;
            }
          }
        }
        return Remainder;
      }
    }
    private static string RemoveStartsWithSlash(string value)
    {
      if (value.StartsWith("/"))
        value = value.TrimStart('/');
      return value;
    }

    //public static bool TryParse(string PrimaryServiceRoot, string RequestUri, out IFhirRequestUri Value, out string ErrorMessage)
    //{
    //  var item = new FhirRequestUri(PrimaryServiceRoot, RequestUri);
    //  if (item._ErrorInParseing)
    //  {
    //    Value = null;
    //    ErrorMessage = item._ParseErrorMessage;
    //    return false;
    //  }
    //  else
    //  {
    //    Value = item;
    //    ErrorMessage = null;
    //    return true;
    //  }
    //}
  }
}
