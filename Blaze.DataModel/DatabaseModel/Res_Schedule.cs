using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Schedule : ResourceIndexBase
  {
    public int Res_ScheduleID {get; set;}
    public string actor_FhirId {get; set;}
    public string actor_Type {get; set;}
    public virtual Blaze_RootUrlStore actor_Url { get; set; }
    public int? actor_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public ICollection<Res_Schedule_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_Schedule_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_Schedule_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_Schedule_History> Res_Schedule_History_List { get; set; }
    public ICollection<Res_Schedule_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Schedule_Index_type> type_List { get; set; }
   
    public Res_Schedule()
    {
      this.identifier_List = new HashSet<Res_Schedule_Index_identifier>();
      this.type_List = new HashSet<Res_Schedule_Index_type>();
      this.meta_tag_List = new HashSet<Res_Schedule_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_Schedule_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_Schedule_Index_meta_profile>();
      this.Res_Schedule_History_List = new HashSet<Res_Schedule_History>();
    }
  }
}

