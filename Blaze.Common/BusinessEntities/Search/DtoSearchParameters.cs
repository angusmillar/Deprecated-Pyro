using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.Common.BusinessEntities.Dto;
using Hl7.Fhir.Model;

namespace Blaze.Common.BusinessEntities.Search
{
  public class DtoSearchParameters
  {
    public FHIRDefinedType ResourceTarget { get; set; }
    public Common.Interfaces.Dto.IDtoRootUrlStore PrimaryRootUrlStore { get; set; }
    public List<DtoSearchParameterBase> SearchParametersList { get; set; }
    public List<DtoUnspportedSearchParameter> DtoUnspportedSearchParameterList { get; set; }
    public List<Sort> SortList { get; set; }
    /// <summary>
    /// Gets the Search parameter value for 'page', will iterate and return the last instance is many found
    /// //Will return zero if none found.
    /// </summary>
    public int RequiredPageNumber
    {
      get
      {
        int PageNumber = 0;
        DtoSearchParameterBase[] PageParameterList = this.SearchParametersList.Where(x => x.Name == Enum.FhirSearchEnum.SearchParameterNameType.page).ToArray();
        foreach (DtoSearchParameterBase Page in PageParameterList)
        {
          if (Page is DtoSearchParameterNumber)
          {
            var DtoSearchParameterNumber = Page as DtoSearchParameterNumber;
            foreach (DtoSearchParameterNumberValue NumberValue in DtoSearchParameterNumber.ValueList)
            {
              PageNumber = (Int32)NumberValue.Value;
            }
          }
        }
        return PageNumber;
      }
    }

    public class Sort
    {
      public DtoSupportedSearchParameters Value { get; set; }
      public Hl7.Fhir.Rest.SortOrder SortOrderType { get; set; }
    }
  }
}
