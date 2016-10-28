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
    public virtual ServiceRootURL_Store author_Url { get; set; }
    public int? author_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_Linkage_History> Res_Linkage_History_List { get; set; }
    public ICollection<Res_Linkage_Index_item> item_List { get; set; }
    public ICollection<Res_Linkage_Index_source> source_List { get; set; }
    public ICollection<Res_Linkage_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Linkage_Index__security> _security_List { get; set; }
    public ICollection<Res_Linkage_Index__tag> _tag_List { get; set; }
   
    public Res_Linkage()
    {
      this.item_List = new HashSet<Res_Linkage_Index_item>();
      this.source_List = new HashSet<Res_Linkage_Index_source>();
      this._profile_List = new HashSet<Res_Linkage_Index__profile>();
      this._security_List = new HashSet<Res_Linkage_Index__security>();
      this._tag_List = new HashSet<Res_Linkage_Index__tag>();
      this.Res_Linkage_History_List = new HashSet<Res_Linkage_History>();
    }
  }
}

