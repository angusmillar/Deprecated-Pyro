using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ValueSet
  {
    public int Res_ValueSetID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string description_String {get; set;}
    public string expansion_Uri {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string system_Uri {get; set;}
    public string url_Uri {get; set;}
    public string version_Code {get; set;}
    public string version_System {get; set;}
    public ICollection<Res_ValueSet_Index_code> code_List { get; set; }
    public ICollection<Res_ValueSet_Index_context> context_List { get; set; }
    public ICollection<Res_ValueSet_Index_reference> reference_List { get; set; }
   
    public Res_ValueSet()
    {
      this.code_List = new HashSet<Res_ValueSet_Index_code>();
      this.context_List = new HashSet<Res_ValueSet_Index_context>();
      this.reference_List = new HashSet<Res_ValueSet_Index_reference>();
    }
  }
}

