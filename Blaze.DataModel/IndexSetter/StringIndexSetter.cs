using System;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Blaze.DataModel.Repository;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.DataModel.Repository.Interfaces;

namespace Blaze.DataModel.IndexSetter
{
  public class StringIndexSetter : IStringIndexSetter
  {
    private string ItemDelimeter = " ";
    public ModelBase Set(Element FhirElement, ModelBase ModelBase, IDtoFhirRequestUri FhirRequestUri = null, ICommonRepository CommonRepository = null)
    {
      if (ModelBase == null)
        throw new ArgumentNullException("ModelBase cannot be null for method.");

      if (FhirElement == null)
        throw new ArgumentNullException("FhirElement cannot be null for method.");


      if (ModelBase is StringIndex)
      {
        var StringIndex = ModelBase as StringIndex;
        if (FhirElement is Address)
        {
          return SetAddress(FhirElement as Address, StringIndex);
        }
        else if (FhirElement is Annotation)
        {
          return SetAnnotation(FhirElement as Annotation, StringIndex);
        }
        else if (FhirElement is FhirString)
        {
          return SetFhirString(FhirElement as FhirString, StringIndex);
        }
        else if (FhirElement is HumanName)
        {
          return SetHumanName(FhirElement as HumanName, StringIndex);
        }
        else if (FhirElement is Markdown)
        {
          return SetMarkdown(FhirElement as Markdown, StringIndex);
        }
        else
        {
          throw new Exception(string.Format("FhirElement was unexpected type for StringIndex, type was {0}", FhirElement.ToString()));
        }
      }
      else
      {
        throw new InvalidCastException(string.Format("StringIndex expected typeof {0} yet was passed typeof {1}", typeof(StringIndex).Name, ModelBase.GetType().Name));
      }
    }

    public StringIndex SetAddress(Address Address, StringIndex StringIndex)
    {
      if (Address == null)
        throw new ArgumentNullException("Address cannot be null for method.");

      if (StringIndex == null)
        throw new ArgumentNullException("StringIndex cannot be null for method.");
      string FullAdddress = string.Empty;
      foreach (var Line in Address.Line)
      {
        FullAdddress += Line + ItemDelimeter;
      }
      if (!string.IsNullOrWhiteSpace(Address.City))
      {
        FullAdddress += Address.City + ItemDelimeter;
      }
      if (!string.IsNullOrWhiteSpace(Address.PostalCode))
      {
        FullAdddress += Address.PostalCode + ItemDelimeter;
      }
      if (!string.IsNullOrWhiteSpace(Address.PostalCode))
      {
        FullAdddress += Address.PostalCode + ItemDelimeter;
      }
      if (!string.IsNullOrWhiteSpace(Address.State))
      {
        FullAdddress += Address.State + ItemDelimeter;
      }
      if (!string.IsNullOrWhiteSpace(Address.Country))
      {
        FullAdddress += Address.Country + ItemDelimeter;
      }
      if (FullAdddress != string.Empty)
      {
        StringIndex.String = FullAdddress.Trim();
        return StringIndex;
      }
      else
      {
        return null;
      }
    }

    public StringIndex SetAnnotation(Annotation Annotation, StringIndex StringIndex)
    {
      if (Annotation == null)
        throw new ArgumentNullException("Annotation cannot be null for method.");

      if (StringIndex == null)
        throw new ArgumentNullException("StringIndex cannot be null for method.");

      if (!string.IsNullOrWhiteSpace(Annotation.Text))
      {
        StringIndex.String = Annotation.Text;
        return StringIndex;
      }
      else
      {
        return null;
      }
    }

    public StringIndex SetFhirString(FhirString FhirString, StringIndex StringIndex)
    {
      if (FhirString == null)
        throw new ArgumentNullException("FhirString cannot be null for method.");

      if (StringIndex == null)
        throw new ArgumentNullException("StringIndex cannot be null for method.");

      if (!string.IsNullOrWhiteSpace(FhirString.Value))
      {
        StringIndex.String = FhirString.Value;
        return StringIndex;
      }
      else
      {
        return null;
      }
    }

    public StringIndex SetHumanName(HumanName HumanName, StringIndex StringIndex)
    {
      if (HumanName == null)
        throw new ArgumentNullException("HumanName cannot be null for method.");

      if (StringIndex == null)
        throw new ArgumentNullException("StringIndex cannot be null for method.");
      string FullName = string.Empty;
      foreach (var Given in HumanName.Given)
      {
        FullName += Given + ItemDelimeter;
      }

      foreach (var Family in HumanName.Family)
      {
        FullName += Family + ItemDelimeter;
      }

      if (FullName != string.Empty)
      {
        StringIndex.String = FullName.Trim();
        return StringIndex;
      }
      else
      {
        return null;
      }

    }

    public StringIndex SetMarkdown(Markdown Markdown, StringIndex StringIndex)
    {
      if (Markdown == null)
        throw new ArgumentNullException("Markdown cannot be null for method.");

      if (StringIndex == null)
        throw new ArgumentNullException("StringIndex cannot be null for method.");

      if (!string.IsNullOrWhiteSpace(Markdown.Value))
      {
        StringIndex.String = Markdown.Value;
        return StringIndex;
      }
      else
      {
        return null;
      }
    }
  }
}
