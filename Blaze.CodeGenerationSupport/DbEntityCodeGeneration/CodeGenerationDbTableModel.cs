using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.CodeGenerationSupport.DbEntityCodeGeneration
{
  public class CodeGenerationDbTableModel
  {
    public string TableName { get; set; }
    public string TableCreateSyntax { get; set; }
    public string TableConfiguratonSyntax { get; set; }
    public CodeGenerationDbTableConfigurationClassModel TableConfigurationClassModel { get; set; }
    public CodeGenerationDbTableClassModel TableClassModel { get; set; }

    public CodeGenerationDbTableModel()
    {      
      
    }
  }

  public class CodeGenerationDbTableConfigurationClassModel
  {
    public string ClassName { get; set; }
    public List<string> FluentPropertyConfigurationList;

    public CodeGenerationDbTableConfigurationClassModel()
    {
      this.FluentPropertyConfigurationList = new List<string>();
    }
  }

  public class CodeGenerationDbTableClassModel
  {
    public string ClassName { get; set; }

    public List<string> ClassInheritanceList { get; set; }
    public List<string> PropertyList;
    public List<string> PropertyConstructorInstantiationList;

    public CodeGenerationDbTableClassModel(bool InheritFromBaseClass = true)
    {
      this.PropertyList = new List<string>();
      this.PropertyConstructorInstantiationList = new List<string>();      
      this.ClassInheritanceList = new List<string>();
      if (InheritFromBaseClass)      
        this.ClassInheritanceList.Add(DatabaseModelInfo.DatabaseModelBaseClassName);
    }

    /// <summary>
    /// ConstructClassTypeStatment: "MyClassName : Inheritance, Inheritance"
    /// </summary>
    public string ConstructClassTypeStatment()
    {
      string Result = string.Empty;
      Result = this.ClassName + " : ";
      foreach (var item in this.ClassInheritanceList)
      {
        Result += item + ", ";
      }
      Result = Result.Substring(0, Result.Length - 2);
      return Result;
    }
  }
}
