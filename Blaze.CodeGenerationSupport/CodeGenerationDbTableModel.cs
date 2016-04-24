using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blaze.CodeGenerationSupport
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
    public List<string> PropertyList;    
    public List<string> PropertyConstructorInstantiationList;

    public CodeGenerationDbTableClassModel()
    {
      this.PropertyList = new List<string>();
      this.PropertyConstructorInstantiationList = new List<string>();
    }
  }


}
