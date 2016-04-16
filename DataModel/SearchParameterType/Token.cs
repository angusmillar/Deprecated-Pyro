using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace DataModel.SearchParameterType
{
  /// <summary>
  /// Search Parameter Type 'Token' 
  /// Constructor implements mappings between FHIR data type and Token Parameter Types 
  /// </summary>
  public class Token
  {
    public string Code { get; set; }
    public string CodeSystem { get; set; }

    public Token(Coding Coding)
    {
      if (Coding.Code != string.Empty)      
        this.Code = Coding.Code;
      
      if (Coding.System != string.Empty)      
        this.Code = Coding.System;      
    }
    public Token(Identifier Identifier)
    {
      if (Identifier.Value != string.Empty)
        this.Code = Identifier.Value;
      if (Identifier.System != string.Empty)
        this.CodeSystem = Identifier.System;
    }
    public Token(ContactPoint ContactPoint)
    {
      if (ContactPoint.Value != string.Empty)
        this.Code = ContactPoint.Value;
      if (ContactPoint.Use != null)
        this.CodeSystem = ContactPoint.Use.ToString();
    }
    public Token(Code Code)
    {
      if (Code.Value != string.Empty)
        this.Code = Code.Value;
      
      this.CodeSystem = null;
    }
    public Token(FhirBoolean FhirBoolean)
    {
      if (FhirBoolean.Value != null)
      {
        if ((Boolean)FhirBoolean.Value)
        {
          this.Code = "True";
        }
        else
        {
          this.Code = "False";
        }
      }        
      this.CodeSystem = null;
    }
    public Token(FhirString FhirString)
    {
      if (FhirString.Value != string.Empty)
        this.Code = FhirString.Value;
      this.CodeSystem = null;
    }
  } 
}
