using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Utility;

namespace Pyro.Common.BusinessEntities.Search
{
  public class DtoSearchParameters
  {
    public FHIRAllTypes? ResourceTarget { get; set; }
    public Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
    public List<DtoSearchParameterBase> SearchParametersList { get; set; }
    public List<DtoUnspportedSearchParameter> UnspportedSearchParameterList { get; set; }
    public List<Sort> SortList { get; set; }
    public int RequiredPageNumber { get; set; }
    public int? CountOfRecordsRequested { get; set; }
    public string Format { get; set; }
    public SummaryType? SummaryType { get; set; }
    public Uri SupportedSearchUrl()
    {
      string UrlString = PrimaryRootUrlStore.Url;
      if (ResourceTarget.HasValue)
        UrlString = $"{UrlString}/{ResourceTarget.GetLiteral()}";
      for (int i = 0; i < SearchParametersList.Count; i++)
      {
        if (i == 0)
          UrlString += $"/?{SearchParametersList[i].RawValue}";
        else
          UrlString += $"&{UrlString}{SearchParametersList[i].RawValue}";
      }
      try
      {
        var Uri = new Uri(UrlString, UriKind.Absolute);
        return Uri;
      }
      catch (UriFormatException)
      {
        return null;
      }
    }
    public DtoSearchParameters()
    {
      this.SummaryType = null;
    }

    public class Sort
    {
      public DtoServiceSearchParameterLight Value { get; set; }
      public Hl7.Fhir.Rest.SortOrder SortOrderType { get; set; }
    }
  }
}
