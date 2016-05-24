using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Slot : ResourceIndexBase
  {
    public int Res_SlotID {get; set;}
    public string schedule_FhirId {get; set;}
    public string schedule_Type {get; set;}
    public virtual Blaze_RootUrlStore schedule_Url { get; set; }
    public int? schedule_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? start_DateTimeOffset {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Slot_History> Res_Slot_History_List { get; set; }
    public ICollection<Res_Slot_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Slot_Index_slot_type> slot_type_List { get; set; }
    public ICollection<Res_Slot_Index_profile> profile_List { get; set; }
    public ICollection<Res_Slot_Index_security> security_List { get; set; }
    public ICollection<Res_Slot_Index_tag> tag_List { get; set; }
   
    public Res_Slot()
    {
      this.identifier_List = new HashSet<Res_Slot_Index_identifier>();
      this.slot_type_List = new HashSet<Res_Slot_Index_slot_type>();
      this.profile_List = new HashSet<Res_Slot_Index_profile>();
      this.security_List = new HashSet<Res_Slot_Index_security>();
      this.tag_List = new HashSet<Res_Slot_Index_tag>();
      this.Res_Slot_History_List = new HashSet<Res_Slot_History>();
    }
  }
}

