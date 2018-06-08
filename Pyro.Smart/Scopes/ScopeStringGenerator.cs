using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Smart.Scopes
{
  public static class ScopeStringGenerator
  {

    // Public User & Patient
    public static string[] GetAllUserAndPatientScopes()
    {
      return GetUserAllAllScope()
       .Concat(GetUserAllReadScope())
       .Concat(GetUserAllWriteScope())
       .Concat(GetAllUserResourceListReadScopes())
       .Concat(GetAllUserResourceListWriteScopes())
       .Concat(GetPatientAllAllScope())
       .Concat(GetPatientAllReadScope())
       .Concat(GetPatientAllWriteScope())
       .Concat(GetAllPatientResourceListReadScopes())
       .Concat(GetAllPatientResourceListWriteScopes()).ToArray();
    }
    public static string[] GetAllUserAndPatientReadScopes()
    {
      return GetUserAllReadScope()
        .Concat(GetAllUserResourceListReadScopes())
        .Concat(GetPatientAllReadScope())
        .Concat(GetAllPatientResourceListReadScopes()).ToArray();
    }
    public static string[] GetAllUserAndPatientWriteScopes()
    {
      return GetUserAllWriteScope()
        .Concat(GetAllUserResourceListWriteScopes())
        .Concat(GetPatientAllWriteScope())
        .Concat(GetAllPatientResourceListWriteScopes()).ToArray();
    }
    
    // Public Patient Scopes
    public static string[] GetAllPatientScopes()
    {
      return GetPatientAllAllScope()
        .Concat(GetPatientAllReadScope())
        .Concat(GetPatientAllWriteScope())
        .Concat(GetAllPatientResourceListReadScopes())
        .Concat(GetAllPatientResourceListWriteScopes()).ToArray();
    }
    public static string[] GetAllPatientReadScopes()
    {
      return GetPatientAllReadScope().Concat(GetAllPatientResourceListReadScopes()).ToArray();      
    }
    public static string[] GetAllPatientWriteScopes()
    {
      return GetPatientAllWriteScope()
        .Concat(GetAllPatientResourceListWriteScopes())
        .ToArray();      
    }
    
    // Public User Scopes
    public static string[] GetUserPatientScopes()
    {      
      return GetUserAllAllScope().Concat(GetUserAllReadScope()).Concat(GetUserAllWriteScope()).Concat(GetAllUserResourceListReadScopes()).Concat(GetAllUserResourceListWriteScopes()).ToArray();      
    } 
    public static string[] GetAllUserReadScopes()
    {
      return GetUserAllReadScope()
        .Concat(GetAllUserResourceListReadScopes())
        .ToArray();      
    }
    public static string[] GetAllUserWriteScopes()
    {
      return GetUserAllWriteScope().Concat(GetAllUserResourceListWriteScopes()).ToArray();
    }

  
    //Private Patient Scopes
    private static string[] GetAllPatientResourceListReadScopes()
    {
      return GetAllResourcesScopeStringList(SmartEnum.Entity.Patient, SmartEnum.Action.Read);      
    }
    private static string[] GetAllPatientResourceListWriteScopes()
    {
      return GetAllResourcesScopeStringList(SmartEnum.Entity.Patient, SmartEnum.Action.Write);      
    }
    private static string[] GetPatientAllAllScope()
    {
      string[] ScopeList = new string[1];
      ScopeList[0] = GetScopeString(SmartEnum.Entity.Patient, KeyWord.All, SmartEnum.Action.All);
      return ScopeList;
    }
    private static string[] GetPatientAllReadScope()
    {
      string[] ScopeList = new string[1];
      ScopeList[0] = GetScopeString(SmartEnum.Entity.Patient, KeyWord.All, SmartEnum.Action.Read);
      return ScopeList;
    }
    private static string[] GetPatientAllWriteScope()
    {
      string[] ScopeList = new string[1];
      ScopeList[0] = GetScopeString(SmartEnum.Entity.Patient, KeyWord.All, SmartEnum.Action.Write);
      return ScopeList;
    }

    //Private User Scopes
    private static string[] GetAllUserResourceListReadScopes()
    {
      //user/Patient.read
      return GetAllResourcesScopeStringList(SmartEnum.Entity.User, SmartEnum.Action.Read);
    }
    private static string[] GetAllUserResourceListWriteScopes()
    {
      //user/Patient.write
      return GetAllResourcesScopeStringList(SmartEnum.Entity.User, SmartEnum.Action.Write);      
    }
    private static string[] GetUserAllAllScope()
    {
      //user/*.*
      string[] ScopeList = new string[1];
      ScopeList[0] = GetScopeString(SmartEnum.Entity.User, KeyWord.All, SmartEnum.Action.All);      
      return ScopeList;      
    }
    private static string[] GetUserAllReadScope()
    {
      //user/*.read
      string[] ScopeList = new string[1];      
      ScopeList[0] = GetScopeString(SmartEnum.Entity.User, KeyWord.All, SmartEnum.Action.Read);
      return ScopeList;
    }
    private static string[] GetUserAllWriteScope()
    {
      //user/*.write
      string[] ScopeList = new string[1];
      ScopeList[0] = GetScopeString(SmartEnum.Entity.User, KeyWord.All, SmartEnum.Action.Write);      
      return ScopeList;
    }

    //Support Methods
    private static string[] GetAllResourcesScopeStringList(SmartEnum.Entity Entity, SmartEnum.Action Action)
    {      
      string[] ScopeList = new string[ModelInfo.SupportedResources.Count];
      for (int i = 0; i < ModelInfo.SupportedResources.Count; i++)
      {
        ScopeList[i] = GetScopeString(Entity, ModelInfo.SupportedResources[i], Action);       
      }
      return ScopeList;
    }
    private static string GetScopeString(SmartEnum.Entity Entity, string Resource, SmartEnum.Action Action)
    {
      //user/*.write
      string ScopeString = string.Empty;
      if (Entity == SmartEnum.Entity.Patient)
      {
        ScopeString += KeyWord.Patient;        
      }
      else if (Entity == SmartEnum.Entity.User)
      {
        ScopeString += KeyWord.User;
      }
      else
      {
        throw new FormatException($"Unkown Smart Scope Entity of {Entity.ToString()}");
      }

      ScopeString += KeyWord.SlashDelimiter;

      if (!String.IsNullOrWhiteSpace(Resource))
      {
        ScopeString += Resource;
      }
      else
      {
        throw new FormatException($"Unkown Smart Scope Resource of {Resource}");
      }

      ScopeString += KeyWord.DotDelimiter;

      if (Action == SmartEnum.Action.Read)
      {
        ScopeString += KeyWord.Read;
      }
      else if (Action == SmartEnum.Action.Write)
      {
        ScopeString += KeyWord.Write;
      }
      else if (Action == SmartEnum.Action.All)
      {
        ScopeString += KeyWord.All;
      }
      else
      {
        throw new FormatException($"Unkown Smart Scope Action of {Action.ToString()}");
      }
      
      return ScopeString;
    }


  }
}
