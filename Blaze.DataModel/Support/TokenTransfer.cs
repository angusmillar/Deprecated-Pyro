using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace Blaze.DataModel.Support
{
  /// <summary>
  /// Search Parameter Type 'Token' 
  /// Constructor implements mappings between FHIR data type and Token Parameter Types 
  /// </summary>
  public class TokenTransfer
  {
    public string Code { get; set; }
    public string CodeSystem { get; set; }

    public TokenTransfer(Coding Coding)
    {
      if (Coding.Code != string.Empty)      
        this.Code = Coding.Code;
      
      if (Coding.System != string.Empty)      
        this.CodeSystem= Coding.System;      
    }
    public TokenTransfer(Identifier Identifier)
    {
      if (Identifier.Value != string.Empty)
        this.Code = Identifier.Value;
      if (Identifier.System != string.Empty)
        this.CodeSystem = Identifier.System;
    }
    public TokenTransfer(ContactPoint ContactPoint)
    {
      if (ContactPoint.Value != string.Empty)
        this.Code = ContactPoint.Value;
      if (ContactPoint.Use != null)
        this.CodeSystem = ContactPoint.Use.ToString();
    }
    public TokenTransfer(Code Code)
    {
      if (Code.Value != string.Empty)
        this.Code = Code.Value;
      
      this.CodeSystem = null;
    }
    public TokenTransfer(FhirBoolean FhirBoolean)
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
    public TokenTransfer(FhirString FhirString)
    {
      if (FhirString.Value != string.Empty)
        this.Code = FhirString.Value;
      this.CodeSystem = null;
    }
  } 
}
