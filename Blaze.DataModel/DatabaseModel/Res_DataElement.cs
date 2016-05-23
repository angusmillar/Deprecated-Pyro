using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DataElement : ResourceIndexBase
  {
    public int Res_DataElementID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string stringency_Code {get; set;}
    public string stringency_System {get; set;}
    public string url_Uri {get; set;}
    public string version_String {get; set;}
    public ICollection<Res_DataElement_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_DataElement_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_DataElement_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_DataElement_History> Res_DataElement_History_List { get; set; }
    public ICollection<Res_DataElement_Index_code> code_List { get; set; }
    public ICollection<Res_DataElement_Index_context> context_List { get; set; }
    public ICollection<Res_DataElement_Index_description> description_List { get; set; }
    public ICollection<Res_DataElement_Index_identifier> identifier_List { get; set; }
   
    public Res_DataElement()
    {
      this.code_List = new HashSet<Res_DataElement_Index_code>();
      this.context_List = new HashSet<Res_DataElement_Index_context>();
      this.description_List = new HashSet<Res_DataElement_Index_description>();
      this.identifier_List = new HashSet<Res_DataElement_Index_identifier>();
      this.meta_tag_List = new HashSet<Res_DataElement_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_DataElement_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_DataElement_Index_meta_profile>();
      this.Res_DataElement_History_List = new HashSet<Res_DataElement_History>();
    }
  }
}

