using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Pyro.Smart.Scopes
{
  public class ScopeParse : IScopeParse
  {
    public bool Parse(string item, out ISmartScope scope)
    {      
      SmartScope SmartScope = new SmartScope();
      scope = SmartScope;
      string[] SlashSplit = item.Split(KeyWord.SlashDelimiter);

      if (SlashSplit.Count() == 2)
      {
        //Parse the entity
        switch (SlashSplit[0])
        {
          case KeyWord.Patient:
            SmartScope.Entity = SmartEnum.Entity.Patient;
            break;
          case KeyWord.User:
            SmartScope.Entity = SmartEnum.Entity.User;
            break;
          default:
            return false;
        }

        string[] DotSplit = SlashSplit[1].Split(KeyWord.DotDelimiter);
        if (DotSplit.Count() == 2)
        {
          //Parse the resource
          string ResourceName = DotSplit[0].Trim();
          if (ResourceName == KeyWord.ReadWrite)
          {
            SmartScope.Resource = FHIRAllTypes.Resource;
          }
          else
          {
            Type ResourceType = ModelInfo.GetTypeForFhirType(ResourceName);
            if (ResourceType != null && ModelInfo.IsKnownResource(ResourceType))
            {
              SmartScope.Resource = (FHIRAllTypes)ModelInfo.FhirTypeNameToFhirType(ResourceName);
            }
            else
            {
              return false;
            }
          }

          switch (DotSplit[1].Trim())
          {
            //Parse the action
            case KeyWord.Read:
              SmartScope.Action = SmartEnum.Action.Read;
              break;
            case KeyWord.Write:
              SmartScope.Action = SmartEnum.Action.Write;
              break;
            case KeyWord.ReadWrite:
              SmartScope.Action = SmartEnum.Action.ReadWrite;
              break;
            default:
              return false;
          }          
        }
        else
        {
          return false;
        }
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
