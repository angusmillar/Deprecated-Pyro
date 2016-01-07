using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Engine.Search.SearchTermTypes;

namespace Blaze.Engine.Search
{
  public class PatientSearchPlan : Interfaces.ISearchPlan
  {
    private DataModel.UnitOfWork _UnitOfWork;
    public DataModel.UnitOfWork UnitOfWork 
    { 
      set
      {
        _UnitOfWork = value;
      }
    }
    
    public SearchResult Search(SearchTerms oSearchTerms)
    {
      //Check that the SearchTerms have not already thrown an error 
      var oSearchResult = new SearchResult();
      if (oSearchTerms.HasError)
      {
        oSearchResult.ErrorMessageList = oSearchTerms.ErrorMessageList;
        return oSearchResult;
      }

      //The search plan;
      if (oSearchTerms.SearchTermList.Count == 1)
      {
        if (oSearchTerms.SearchTermList.TrueForAll(x => x.Modifier == SearchModifierType.None && x.Prefix == SearchPrefixType.None))
        {
          if (!oSearchTerms.SearchTermList.Any(x => x.HasLogicalOrProperties == true))
          {
            if (oSearchTerms.SearchTermList[0].Name == Support.EnumSupport.SearchTermName.Family)
            {
              Search.SearchTermTypes.SearchTermString Family = oSearchTerms.SearchTermList[0] as Search.SearchTermTypes.SearchTermString;
              oSearchResult.FhirBundle = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], string.Empty, 1);
              return oSearchResult;
            }
            else if (oSearchTerms.SearchTermList[0].Name == Support.EnumSupport.SearchTermName.Given)
            {
              Search.SearchTermTypes.SearchTermString Given = oSearchTerms.SearchTermList[0] as Search.SearchTermTypes.SearchTermString;
              oSearchResult.FhirBundle = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, Given.Values[0], 1);
              return oSearchResult;
            }
          }
        }
      }
      else if (oSearchTerms.SearchTermList.Count == 2)
      {
        if (oSearchTerms.SearchTermList.TrueForAll(x => x.Modifier == SearchModifierType.None && x.Prefix == SearchPrefixType.None))
        {
          if (!oSearchTerms.SearchTermList.Any(x => x.HasLogicalOrProperties == true))
          {
            if (oSearchTerms.SearchTermList.Exists(x => x.Name == Support.EnumSupport.SearchTermName.Given)
              && oSearchTerms.SearchTermList.Exists(x => x.Name == Support.EnumSupport.SearchTermName.Family))
            {
              Search.SearchTermTypes.SearchTermString Given = oSearchTerms.SearchTermList.FirstOrDefault(x => x.Name == Support.EnumSupport.SearchTermName.Given) as Search.SearchTermTypes.SearchTermString;
              Search.SearchTermTypes.SearchTermString Family = oSearchTerms.SearchTermList.FirstOrDefault(x => x.Name == Support.EnumSupport.SearchTermName.Family) as Search.SearchTermTypes.SearchTermString;
              oSearchResult.FhirBundle = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], Given.Values[0], 1);
              return oSearchResult;
            }

            if (oSearchTerms.SearchTermList.Exists(x => x.Name == Support.EnumSupport.SearchTermName.Given)
              && oSearchTerms.SearchTermList.Exists(x => x.Name == Support.EnumSupport.SearchTermName.Page))
            {
              Search.SearchTermTypes.SearchTermString Given = oSearchTerms.SearchTermList.FirstOrDefault(x => x.Name == Support.EnumSupport.SearchTermName.Given) as Search.SearchTermTypes.SearchTermString;
              Search.SearchTermTypes.SearchTermNumber Page = oSearchTerms.SearchTermList.FirstOrDefault(x => x.Name == Support.EnumSupport.SearchTermName.Page) as Search.SearchTermTypes.SearchTermNumber;
              int Pagenumber = Convert.ToInt32(Page.Values[0]);
              oSearchResult.FhirBundle = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, Given.Values[0], Pagenumber);
              return oSearchResult;
            }

            if (oSearchTerms.SearchTermList.Exists(x => x.Name == Support.EnumSupport.SearchTermName.Family)
              && oSearchTerms.SearchTermList.Exists(x => x.Name == Support.EnumSupport.SearchTermName.Page))
            {
              Search.SearchTermTypes.SearchTermString Family = oSearchTerms.SearchTermList.FirstOrDefault(x => x.Name == Support.EnumSupport.SearchTermName.Family) as Search.SearchTermTypes.SearchTermString;
              Search.SearchTermTypes.SearchTermNumber Page = oSearchTerms.SearchTermList.FirstOrDefault(x => x.Name == Support.EnumSupport.SearchTermName.Page) as Search.SearchTermTypes.SearchTermNumber;
              int Pagenumber = Convert.ToInt32(Page.Values[0]);
              oSearchResult.FhirBundle = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], string.Empty, Pagenumber);
              return oSearchResult;
            }
          }
        }
      }
      else if (oSearchTerms.SearchTermList.Count == 3)
      {
        if (oSearchTerms.SearchTermList.TrueForAll(x => x.Modifier == SearchModifierType.None && x.Prefix == SearchPrefixType.None))
        {
          if (!oSearchTerms.SearchTermList.Any(x => x.HasLogicalOrProperties == true))
          {
            if (oSearchTerms.SearchTermList.Exists(x => x.Name == Support.EnumSupport.SearchTermName.Given)
              && oSearchTerms.SearchTermList.Exists(x => x.Name == Support.EnumSupport.SearchTermName.Family)
              && oSearchTerms.SearchTermList.Exists(x => x.Name == Support.EnumSupport.SearchTermName.Page))
            {
              Search.SearchTermTypes.SearchTermString Given = oSearchTerms.SearchTermList.FirstOrDefault(x => x.Name == Support.EnumSupport.SearchTermName.Given) as Search.SearchTermTypes.SearchTermString;
              Search.SearchTermTypes.SearchTermString Family = oSearchTerms.SearchTermList.FirstOrDefault(x => x.Name == Support.EnumSupport.SearchTermName.Family) as Search.SearchTermTypes.SearchTermString;
              Search.SearchTermTypes.SearchTermNumber Page = oSearchTerms.SearchTermList.FirstOrDefault(x => x.Name == Support.EnumSupport.SearchTermName.Page) as Search.SearchTermTypes.SearchTermNumber;
              int Pagenumber = Convert.ToInt32(Page.Values[0]);
              oSearchResult.FhirBundle = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], Given.Values[0], Pagenumber);
              return oSearchResult;
            }
          }
        }
      }
      oSearchResult.ErrorMessageList.Add(String.Format("This search parameter combination provided is not supported by the server."));
      return oSearchResult;
    }
  }
}
