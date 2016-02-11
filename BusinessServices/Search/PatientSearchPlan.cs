using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.Engine.Support;
using Dip.Interfaces;
using BusinessEntities;
using BusinessEntities.Search;

namespace Blaze.Engine.Search
{
  public class PatientSearchPlan : SearchPlanBase, Interfaces.ISearchPlan
  {
    public IBlazeServiceOperationOutcome Search(DtoSearchParameters oSearchParameters, IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome, DtoEnums.SupportedFhirResource ResourceType)
    {
      //The search plan;
      if (oSearchParameters.SearchParametersList.Count == 1)
      {
        if (oSearchParameters.SearchParametersList.TrueForAll(x => x.Modifier == SearchModifierType.None && x.Prefix == SearchPrefixType.None))
        {
          if (!oSearchParameters.SearchParametersList.Any(x => x.HasLogicalOrProperties == true))
          {
            //_Id
            if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName._Id)
            {              
              DtoSearchParameterString _Id = oSearchParameters.SearchParametersList[0] as DtoSearchParameterString;
              oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFhirId(_Id.Values[0], null);
              return oBlazeServiceOperationOutcome;
            }
            //Family
            if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Family)
            {
              DtoSearchParameterString Family = oSearchParameters.SearchParametersList[0] as DtoSearchParameterString;
              oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], string.Empty, string.Empty, string.Empty, null, 1);              
              return oBlazeServiceOperationOutcome;
            }
            //Given
            if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Given)
            {
              DtoSearchParameterString Given = oSearchParameters.SearchParametersList[0] as DtoSearchParameterString;
              oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, Given.Values[0], string.Empty, string.Empty, null, 1);
              return oBlazeServiceOperationOutcome;
            }
            //Name
            if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Name)
            {              
              DtoSearchParameterString Name = oSearchParameters.SearchParametersList[0] as DtoSearchParameterString;
              oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, string.Empty, Name.Values[0], string.Empty, null, 1);
              return oBlazeServiceOperationOutcome;
            }
            //Phonetic
            if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Phonetic)
            {
              DtoSearchParameterString Phonetic = oSearchParameters.SearchParametersList[0] as DtoSearchParameterString;
              oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, string.Empty, string.Empty, Phonetic.Values[0], null, 1);
              return oBlazeServiceOperationOutcome;
            }
            //Identifier 
            if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Identifier)
            {
              
              DtoSearchParameterToken Identifier = oSearchParameters.SearchParametersList[0] as DtoSearchParameterToken;
              var IdentiferSystemAndCode = new Tuple<string, string>(Identifier.Values[0].System, Identifier.Values[0].Code);
              oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByIdentifier(IdentiferSystemAndCode, null, 1, RequestUri);
              return oBlazeServiceOperationOutcome;
            }
          }
        }
      }
      else if (oSearchParameters.SearchParametersList.Count == 2)
      {
        if (oSearchParameters.SearchParametersList.TrueForAll(x => x.Modifier == SearchModifierType.None && x.Prefix == SearchPrefixType.None))
        {
          if (!oSearchParameters.SearchParametersList.Any(x => x.HasLogicalOrProperties == true))
          {

            //Family, Given
            if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Family)
              && oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Given))
            {              
              DtoSearchParameterString Family = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Family) as DtoSearchParameterString;
              DtoSearchParameterString Given = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Given) as DtoSearchParameterString;
              oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], Given.Values[0], string.Empty, string.Empty, null, 1);
              return oBlazeServiceOperationOutcome;
            }

            //------ Active ---------
            if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Active))
            {
              DtoSearchParameterToken Active = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Active) as DtoSearchParameterToken;
              var ActiverSystemAndCode = new Tuple<string, string>(Active.Values[0].System, Active.Values[0].Code);

              //Active, _Id
              if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName._Id)
              {
                DtoSearchParameterString _Id = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName._Id) as DtoSearchParameterString;                
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFhirId(_Id.Values[0], ActiverSystemAndCode);
                return oBlazeServiceOperationOutcome;
              }

              //Active, Identifier 
              if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Identifier))
              {
                DtoSearchParameterToken Identifier = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Identifier) as DtoSearchParameterToken;                                
                var IdentiferSystemAndCode = new Tuple<string, string>(Identifier.Values[0].System, Identifier.Values[0].Code);
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByIdentifier(IdentiferSystemAndCode, ActiverSystemAndCode, 1, RequestUri);
                return oBlazeServiceOperationOutcome;
              }

              //Active, _Id
              if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName._Id)
              {
                //                DtoSearchParameterString _Id = oSearchTerms.SearchTermList[0] as DtoSearchParameterString;
                //                oBlazeServiceOperationOutcome.FhirBundle = _UnitOfWork.PatientRepository.SearchByFhirId(_Id.Values[0]);
                //                return oBlazeServiceOperationOutcome;
              }
              //Active, Family
              if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Family)
              {
                DtoSearchParameterString Family = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Family) as DtoSearchParameterString;                                
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], string.Empty, string.Empty, string.Empty, ActiverSystemAndCode, 1);
                return oBlazeServiceOperationOutcome;
              }
              //Active, Given
              if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Given)
              {
                DtoSearchParameterString Given = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Given) as DtoSearchParameterString;                                
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, Given.Values[0], string.Empty, string.Empty, ActiverSystemAndCode, 1);
                return oBlazeServiceOperationOutcome;
              }
              //Active, Name
              if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Name)
              {                
                DtoSearchParameterString Name = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Name) as DtoSearchParameterString;                                
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, string.Empty, Name.Values[0], string.Empty, ActiverSystemAndCode, 1);
                return oBlazeServiceOperationOutcome;
              }
              //Active, Phonetic
              if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Phonetic)
              {
                DtoSearchParameterString Phonetic = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Phonetic) as DtoSearchParameterString;                                                
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, string.Empty, string.Empty, Phonetic.Values[0], ActiverSystemAndCode, 1);
                return oBlazeServiceOperationOutcome;
              }
            }
            //------ Page ----------
            if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Page))
            {              
              DtoSearchParameterNumber Page = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Page) as DtoSearchParameterNumber;
              int Pagenumber = Convert.ToInt32(Page.Values[0]);
              //Page, Identifier
              if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Identifier))
              {
                DtoSearchParameterToken Identifier = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Identifier) as DtoSearchParameterToken;
                var IdentiferSystemAndCode = new Tuple<string, string>(Identifier.Values[0].System, Identifier.Values[0].Code);
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByIdentifier(IdentiferSystemAndCode, null, Pagenumber, RequestUri);
                return oBlazeServiceOperationOutcome;
              }
              //Page, Given
              if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Given))
              {
                DtoSearchParameterString Given = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Given) as DtoSearchParameterString;
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, Given.Values[0], string.Empty, string.Empty, null, Pagenumber);
                return oBlazeServiceOperationOutcome;
              }
              //Page, Family
              if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Family))
              {
                DtoSearchParameterString Family = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Family) as DtoSearchParameterString;
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], string.Empty, string.Empty, string.Empty, null, Pagenumber);
                return oBlazeServiceOperationOutcome;
              }
              //Page, Name
              if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Name))
              {
                DtoSearchParameterString Name = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Name) as DtoSearchParameterString;
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, string.Empty, Name.Values[0], string.Empty, null, Pagenumber);
                return oBlazeServiceOperationOutcome;
              }
              //Page, Phonetic
              if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Phonetic))
              {
                DtoSearchParameterString Phonetic = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Phonetic) as DtoSearchParameterString;                
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, string.Empty, string.Empty, Phonetic.Values[0], null, Pagenumber);
                return oBlazeServiceOperationOutcome;
              }

            }
          }
        }
      }
      else if (oSearchParameters.SearchParametersList.Count == 3)
      {
        if (oSearchParameters.SearchParametersList.TrueForAll(x => x.Modifier == SearchModifierType.None && x.Prefix == SearchPrefixType.None))
        {
          if (!oSearchParameters.SearchParametersList.Any(x => x.HasLogicalOrProperties == true))
          {
            //------ Active ------
            if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Active))
            {
              DtoSearchParameterToken Active = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Active) as DtoSearchParameterToken;
              var ActiverSystemAndCode = new Tuple<string, string>(Active.Values[0].System, Active.Values[0].Code);

              //Active, Family, Given
              if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Family) &&
                oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Given))
              {
                DtoSearchParameterString Family = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Family) as DtoSearchParameterString;
                DtoSearchParameterString Given = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Given) as DtoSearchParameterString;
                oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], Given.Values[0], string.Empty, string.Empty, ActiverSystemAndCode, 1);
                return oBlazeServiceOperationOutcome;
              }


              //------ Page ---------
              if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Page))
              {
                DtoSearchParameterNumber Page = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Page) as DtoSearchParameterNumber;
                int Pagenumber = Convert.ToInt32(Page.Values[0]);

                //Active, Page, Family
                if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Family))
                {
                  DtoSearchParameterString Family = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Family) as DtoSearchParameterString;
                  oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], null, string.Empty, string.Empty, ActiverSystemAndCode, Pagenumber);
                  return oBlazeServiceOperationOutcome;
                }
                //Active, Page, Given
                if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Given)
                {
                  DtoSearchParameterString Given = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Given) as DtoSearchParameterString;
                  oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, Given.Values[0], string.Empty, string.Empty, ActiverSystemAndCode, Pagenumber);
                  return oBlazeServiceOperationOutcome;
                }
                //Active, Page, Name
                if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Name)
                {
                  DtoSearchParameterString Name = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Name) as DtoSearchParameterString;                                  
                  oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, string.Empty, Name.Values[0], string.Empty, ActiverSystemAndCode, Pagenumber);
                  return oBlazeServiceOperationOutcome;
                }
                //Active, Page, Phonetic
                if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Phonetic)
                {
                  DtoSearchParameterString Phonetic = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Phonetic) as DtoSearchParameterString;                  
                  oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(string.Empty, string.Empty, string.Empty, Phonetic.Values[0], ActiverSystemAndCode, Pagenumber);
                  return oBlazeServiceOperationOutcome;
                }
                //Active, Page, Identifier
                if (oSearchParameters.SearchParametersList[0].Name == DtoEnums.Search.SearchParameterName.Identifier)
                {
                  DtoSearchParameterToken Identifier = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Phonetic) as DtoSearchParameterToken;                                    
                  var IdentiferSystemAndCode = new Tuple<string, string>(Identifier.Values[0].System, Identifier.Values[0].Code);
                  oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByIdentifier(IdentiferSystemAndCode, ActiverSystemAndCode, Pagenumber, RequestUri);
                  return oBlazeServiceOperationOutcome;
                }
              }
            }
          }
        }
      }
      else if (oSearchParameters.SearchParametersList.Count == 4)
      {
        if (oSearchParameters.SearchParametersList.TrueForAll(x => x.Modifier == SearchModifierType.None && x.Prefix == SearchPrefixType.None))
        {
          if (!oSearchParameters.SearchParametersList.Any(x => x.HasLogicalOrProperties == true))
          {
            //------ Active ------
            if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Active))
            {
              DtoSearchParameterToken Active = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Active) as DtoSearchParameterToken;
              var ActiverSystemAndCode = new Tuple<string, string>(Active.Values[0].System, Active.Values[0].Code);
            
              //------ Page ---------
              if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Page))
              {
                DtoSearchParameterNumber Page = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Page) as DtoSearchParameterNumber;
                int Pagenumber = Convert.ToInt32(Page.Values[0]);

                //Active, Page, Family, Given
                if (oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Family) &&
                  oSearchParameters.SearchParametersList.Exists(x => x.Name == DtoEnums.Search.SearchParameterName.Given))
                {
                  DtoSearchParameterString Family = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Family) as DtoSearchParameterString;
                  DtoSearchParameterString Given = oSearchParameters.SearchParametersList.FirstOrDefault(x => x.Name == DtoEnums.Search.SearchParameterName.Given) as DtoSearchParameterString;
                  oBlazeServiceOperationOutcome.DatabaseOperationOutcome = _UnitOfWork.PatientRepository.SearchByFamilyAndGiven(Family.Values[0], Given.Values[0], string.Empty, string.Empty, ActiverSystemAndCode, Pagenumber);
                  return oBlazeServiceOperationOutcome;
                }
                            
              }            
            }
          }
        }
      }

      //No Search Plan match was found so create OperationOutcome to inform sender
      var OpOutComeIssueComp = new OperationOutcome.IssueComponent();
      OpOutComeIssueComp.Severity = OperationOutcome.IssueSeverity.Error;
      OpOutComeIssueComp.Code = OperationOutcome.IssueType.Invalid;
      string ParameterListForErrorMessage = string.Empty;
      foreach (var item in oSearchParameters.SearchParametersList)
      {
        ParameterListForErrorMessage += item.RawValue + " & ";
      }
      ParameterListForErrorMessage = ParameterListForErrorMessage.Substring(0, ParameterListForErrorMessage.Length - 3);
      OpOutComeIssueComp.Details = new CodeableConcept("http://hl7.org/fhir/operation-outcome", "MSG_PARAM_UNKNOWN", String.Format("Parameter '{0}' not understood", ParameterListForErrorMessage));
      OpOutComeIssueComp.Details.Text = String.Format("This search parameter combination provided is not supported by the server. Parameters were: {0}", ParameterListForErrorMessage);            
      
      oBlazeServiceOperationOutcome.SearchPlanValidationOperationOutcome = new SearchPlanValidationOperationOutcome();
      oBlazeServiceOperationOutcome.SearchPlanValidationOperationOutcome.FhirOperationOutcome = new OperationOutcome();
      oBlazeServiceOperationOutcome.SearchPlanValidationOperationOutcome.FhirOperationOutcome.Issue.Add(OpOutComeIssueComp);
      oBlazeServiceOperationOutcome.SearchPlanValidationOperationOutcome.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
      
      return oBlazeServiceOperationOutcome;
    }
  }
}
