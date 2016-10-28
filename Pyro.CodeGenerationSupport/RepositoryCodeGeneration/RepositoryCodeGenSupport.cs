using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;

namespace Blaze.CodeGenerationSupport.RepositoryCodeGeneration
{
  public static class RepositoryCodeGenSupport
  {    
    public static void ResolvePropertyNameChainList(int i, FhirSearchParameterSearchPathElement CurrentItem, List<string> PropertyNameChainList)
    {
      if (i > 1)
      {        
        PropertyNameChainList.Add(RepositoryCodeGenSupport.UppercaseFirst(CurrentItem.PropertyName));
      }
      else
      {       
        PropertyNameChainList.Add(RepositoryCodeGenSupport.UppercaseFirst(CurrentItem.PropertyName));
      }
    }

    public static string UppercaseFirst(string s)
    {
      // Check for empty string.
      if (string.IsNullOrEmpty(s))
      {
        return string.Empty;
      }
      // Return char and concat substring.
      return char.ToUpper(s[0]) + s.Substring(1);
    }

    public static string DepthSpace(int DepthCounter, int BracketIndentDefault = 0)
    {
      string Result = string.Empty;
      Result = Result.PadLeft(BracketIndentDefault);
      for (int i = 0; i < DepthCounter; i++)
      {
        Result = Result + "  ";
      }      
      return Result;
    }

    public static void CloseBrackets(StringBuilder Sb, int BracketDepthCounter, int BracketIndentDefault = 0)
    {
      int CountDown = BracketDepthCounter;
      for (int j = 0; j < BracketDepthCounter; j++)
      {
        CountDown--;
        Sb.AppendLine(String.Format("{0}}}", DepthSpace(CountDown, BracketIndentDefault)));
      }
    }
  }
}
