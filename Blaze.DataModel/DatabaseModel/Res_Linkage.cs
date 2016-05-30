using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Linkage : ResourceIndexBase
  {
    public int Res_LinkageID {get; set;}
    public string author_VersionId {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual Blaze_RootUrlStore author_Url { get; set; }
    public int? author_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Linkage_History> Res_Linkage_History_List { get; set; }
    public ICollection<Res_Linkage_Index_item> item_List { get; set; }
    public ICollection<Res_Linkage_Index_source> source_List { get; set; }
    public ICollection<Res_Linkage_Index_profile> profile_List { get; set; }
    public ICollection<Res_Linkage_Index_security> security_List { get; set; }
    public ICollection<Res_Linkage_Index_tag> tag_List { get; set; }
   
    public Res_Linkage()
    {
      this.item_List = new HashSet<Res_Linkage_Index_item>();
      this.source_List = new HashSet<Res_Linkage_Index_source>();
      this.profile_List = new HashSet<Res_Linkage_Index_profile>();
      this.security_List = new HashSet<Res_Linkage_Index_security>();
      this.tag_List = new HashSet<Res_Linkage_Index_tag>();
      this.Res_Linkage_History_List = new HashSet<Res_Linkage_History>();
    }
  }
}

