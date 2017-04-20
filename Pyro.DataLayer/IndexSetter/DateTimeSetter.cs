using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataLayer.DbModel.EntityBase;
using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Model;
using Pyro.Common.BusinessEntities.Dto;

namespace Pyro.DataLayer.IndexSetter
{
  public static class DateTimeSetter
  {
    public static ResourceIndexType Set<ResourceIndexType>(IElementNavigator oElement, DtoServiceSearchParameterLight searchParameter)
      where ResourceIndexType : ResourceIndexBase, new()
    {
      var ResourceIndex = new ResourceIndexType();
      ResourceIndex.ServiceSearchParameterId = searchParameter.Id;
      if (oElement is Hl7.Fhir.FhirPath.PocoNavigator Poco && Poco.FhirValue != null)
      {
        if (Poco.FhirValue is Date Date)
        {
          if (Date.IsValidValue(Date.Value))
          {
            int? DateAsInteger = Pyro.Common.Tools.FhirTimeSupport.ConvertDateToInteger(Date);
            if (DateAsInteger.HasValue)
            {
              ResourceIndex.Date = DateAsInteger.Value;
              return ResourceIndex;
            }
            else
            {
              throw new FormatException(string.Format("Unable to convert the given date '{0}' to a valid date.", Date.Value));
            }
          }
          else
          {
            throw new FormatException(string.Format("The date given '{0}' is not a valid FHIR date format.", Date.Value));
          }
        }
        else if (Poco.FhirValue is Period Period)
        {
          if (Period.StartElement != null)
          {
            if (FhirDateTime.IsValidValue(Period.Start))
            {
              Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(Period.Start);
              if (oFhirDateTimeTool.IsValid)
              {
                ResourceIndex.DateTimeOffsetLow = oFhirDateTimeTool.Value.Value;
              }
              else
              {
                throw new FormatException($"The date & time given '{Period.Start}' could not be converted to a FHIR Date time.");
              }
            }
            else
            {
              throw new FormatException($"The date & time given '{Period.Start}' is not a valid FHIR date & time format.");
            }
          }
          else
          {
            ResourceIndex.DateTimeOffsetLow = null;
          }
          if (Period.EndElement != null)
          {
            if (FhirDateTime.IsValidValue(Period.End))
            {
              Common.Tools.FhirDateTimeSupport oFhirDateTimeTool = new Common.Tools.FhirDateTimeSupport(Period.End);
              if (oFhirDateTimeTool.IsValid)
              {
                ResourceIndex.DateTimeOffsetHigh = oFhirDateTimeTool.Value.Value;
              }
              else
              {
                throw new FormatException($"The date & time given '{Period.Start}' could not be converted to a FHIR Date time.");
              }
            }
            else
            {
              throw new FormatException($"The date & time given '{Period.End}' is not a valid FHIR date & time format.");
            }
          }
          else
          {
            ResourceIndex.DateTimeOffsetHigh = null;
          }
          if (ResourceIndex.DateTimeOffsetLow == null && ResourceIndex.DateTimeOffsetHigh == null)
          {
            return null;
          }
          else
          {
            return ResourceIndex;
          }
        }
        else
        {
          throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{searchParameter.Type}'");
        }
      }
      else if (oElement.Value is Hl7.FhirPath.ConstantValue ConstantValue)
      {
        ResourceIndex.String = ConstantValue.Type.ToString();
        return ResourceIndex;
      }
      else if (oElement.Value is bool Bool)
      {
        ResourceIndex.String = Bool.ToString();
        return ResourceIndex;
      }
      else
      {
        throw new FormatException($"Unkown FhirType: '{oElement.Type}' for SearchParameterType: '{searchParameter.Type}'");
      }
      return null;
    }

  }
}
