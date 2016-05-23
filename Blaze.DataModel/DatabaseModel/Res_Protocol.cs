using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Protocol : ResourceIndexBase
  {
    public int Res_ProtocolID {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Protocol_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_Protocol_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_Protocol_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_Protocol_History> Res_Protocol_History_List { get; set; }
    public ICollection<Res_Protocol_Index_identifier> identifier_List { get; set; }
   
    public Res_Protocol()
    {
      this.identifier_List = new HashSet<Res_Protocol_Index_identifier>();
      this.meta_tag_List = new HashSet<Res_Protocol_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_Protocol_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_Protocol_Index_meta_profile>();
      this.Res_Protocol_History_List = new HashSet<Res_Protocol_History>();
    }
  }
}

