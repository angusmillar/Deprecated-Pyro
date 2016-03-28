using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerationSupport.FhirApiIntrospection
{
  /// <summary>
  /// Static class to parse the FHIR XPath string
  /// </summary>
  public static class FhirXPathFactory
  {
    private static char _ElementDelimiter = '/';
    private static char _NamespaceDilimeter = ':';
    private static char _ChoiceBracketOpen = '[';
    private static char _ChoiceBracketClosed = ']';    
    private static char _AttributeDelimiter = '@';
    private static char _EqualsDelimiter = '=';

    private static  string[] SplitElements(string Path)
    {
      var ElementInitalSplit = Path.Split(_ElementDelimiter);
      var FinalList = new List<string>();
      bool SkipNext = false;
      for (int i = 0; i < ElementInitalSplit.Length; i++)
      {
        if (!SkipNext)
        {
          if (ElementInitalSplit[i].Contains(_ChoiceBracketOpen) && !ElementInitalSplit[i].Contains(_ChoiceBracketClosed))
          {
            try
            {
              FinalList.Add(String.Format("{0}{1}{2}", ElementInitalSplit[i], _ElementDelimiter, ElementInitalSplit[i + 1]));
            }
            catch (IndexOutOfRangeException Exec)
            {
              throw new ApplicationException(String.Format("Do we have a Search path with an open {0} but not closed {1}?", _ChoiceBracketOpen, _ChoiceBracketClosed), Exec);
            }
            SkipNext = true;
          }
          else
          {
            FinalList.Add(ElementInitalSplit[i]);
          }
        }
      }
      return FinalList.ToArray();
    }
    private static  FhirXPathComponent ParseComponent(string ComponentString)
    {
      //XPath = "f:Patient/f:telecom[system/@value='email']"
      //XPath = "f:Patient/f:extension[@url='http://h l7.org/fhir/StructureDefinition/us-core-race'] | f:Patient/f:extension[@url='http://hl7.org/fhir/StructureDefinition/us-core-race']"
      //XPath = "f:Bundle/f:entry/f:resource[0]"
      var NewComponent = new FhirXPathComponent();
      var ElementsList = ComponentString.Split(_NamespaceDilimeter);
      if (ElementsList.Count() != 2)
        throw new FormatException(String.Format("Incorrectly formatted Fhir XPath, no namespace found for element: {0}", ComponentString));
      for (int i = 0; i < ElementsList.Length; i++)
      {
        if (i == 0)
        {
          NewComponent.NameSpace = ElementsList[i];
        }
        else if (i == 1)
        {
          if (ElementsList[i].Contains(_ChoiceBracketOpen) && ElementsList[i].Contains(_ChoiceBracketClosed))
          {
            NewComponent.Name = ElementsList[i].Substring(0, ElementsList[i].IndexOf(_ChoiceBracketOpen));
            string ChoiceSpecifierString = ElementsList[i].Substring(ElementsList[i].IndexOf(_ChoiceBracketOpen) + 1, ElementsList[i].IndexOf(_ChoiceBracketClosed) - ElementsList[i].IndexOf(_ChoiceBracketOpen) - 1);
            NewComponent.ChoiceSpecifier = ChoiceSpecifierParse(ChoiceSpecifierString);            
          }
          else
          {
            NewComponent.Name = ElementsList[i];
          }
        }
        else
        {
          throw new FormatException(String.Format("Incorrectly formatted FhirXPath, no namespace found repeating namespace to name delimiters in the element: {0}", ComponentString));
        }
      }
      return NewComponent;
    }
    private static ChoiceSpecifierDetails ChoiceSpecifierParse(string ChoiceString)
    {
      var oChoiceSpecifierDetails = new ChoiceSpecifierDetails();
      string tempAttribute = string.Empty;
      if (!ChoiceString.Contains(_ElementDelimiter) && !ChoiceString.Contains(_AttributeDelimiter))
      {
        oChoiceSpecifierDetails.Value = ChoiceString;
      }
      else if (ChoiceString.Contains(_ElementDelimiter))
      {
        if (ChoiceString.ToArray().Count(x => x == _ElementDelimiter) > 1)
          throw new FormatException(String.Format("Found more then one separator of type '{0}' within the Choice specifier of: {1}", _ElementDelimiter, ChoiceString));
        oChoiceSpecifierDetails.ElementName = ChoiceString.Split(_ElementDelimiter)[0];
        tempAttribute = ChoiceString.Split(_ElementDelimiter)[1];
        if (tempAttribute.StartsWith(_AttributeDelimiter.ToString()))
        {
          if (tempAttribute.Contains(_EqualsDelimiter))
          {
            oChoiceSpecifierDetails.AttributeName = tempAttribute.Split(_EqualsDelimiter)[0].Remove(tempAttribute.IndexOf(_AttributeDelimiter), 1);
            oChoiceSpecifierDetails.Value = tempAttribute.Split(_EqualsDelimiter)[1];
          }
          else
          {
            throw new FormatException(String.Format("Found choice specifier which has an attribute but no '{0}' delimiter character  to be equal to. Choice specifier was : {0}", _EqualsDelimiter, ChoiceString));
          }
        }
      }
      else if (tempAttribute.StartsWith(_AttributeDelimiter.ToString()))
      {
        if (tempAttribute.Contains(_EqualsDelimiter))
        {
          oChoiceSpecifierDetails.AttributeName = tempAttribute.Split(_EqualsDelimiter)[0];
          oChoiceSpecifierDetails.Value = tempAttribute.Split(_EqualsDelimiter)[1];
        }
        else
        {
          throw new FormatException(String.Format("Found choice specifier which has an attribute but no '{0}' delimiter character  to be equal to. Choice specifier was : {0}", _EqualsDelimiter, ChoiceString));
        }
      }
      if (oChoiceSpecifierDetails.Value.Count(x => x == '\'') == 2)
      {
        oChoiceSpecifierDetails.Value = oChoiceSpecifierDetails.Value.Replace("\'", "");
      }
      return oChoiceSpecifierDetails;
    }

    public static FhirXPath FhirXPathFactoryParse(string FhirXPathString) 
    {
      var oRoot = new FhirXPath();
      oRoot.FhirXPathComponentList = new List<FhirXPathComponent>();

      var ElementsList = SplitElements(FhirXPathString);
      for (int i = 0; i < ElementsList.Length; i++)
      {        
        FhirXPathComponent oComponent = ParseComponent(ElementsList[i]);
        oRoot.FhirXPathComponentList.Add(oComponent);
      }
      return oRoot;
    }
  }

  /// <summary>
  /// Simple Wrapper of a FhirXPathComponent List, the list is each Component of the path in order 
  /// </summary>
  public class FhirXPath
  {
    private List<FhirXPathComponent> _FhirXPathComponentList;
    public List<FhirXPathComponent> FhirXPathComponentList
    {
      get { return _FhirXPathComponentList; }
      set { _FhirXPathComponentList = value; }
    }
  }

  /// <summary>
  /// A single Component of the Fhir XPath, may contain a ChoiceSpecifier details
  /// </summary>
  public class FhirXPathComponent
  {
    public string NameSpace { get; set; }
    public string Name { get; set; }
    public bool HasChoiceSpecifier 
    { 
      get
      {
        return (this.ChoiceSpecifier != null);
      }
    }
    public ChoiceSpecifierDetails ChoiceSpecifier { get; set; }            
  }

  /// <summary>
  /// Choice Specifier Details, handles the brackets [ ] in paths such as this:
  /// "f:DataElement/f:element/f:mapping/f:extension[@url='http://hl7.org/fhir/StructureDefinition/11179-objectClass']
  /// </summary>
  public class ChoiceSpecifierDetails
  {
    public string ElementName { get; set; }
    public string AttributeName { get; set; }
    public string Value { get; set; }   
  }
}
