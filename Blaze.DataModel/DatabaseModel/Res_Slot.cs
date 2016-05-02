using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Slot
  {
    public int Res_SlotID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string schedule_FhirId {get; set;}
    public string schedule_Type {get; set;}
    public virtual Blaze_RootUrlStore schedule_Url { get; set; }
    public int? schedule_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? start_DateTimeOffset {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Slot_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Slot_Index_slot_type> slot_type_List { get; set; }
   
    public Res_Slot()
    {
      this.identifier_List = new HashSet<Res_Slot_Index_identifier>();
      this.slot_type_List = new HashSet<Res_Slot_Index_slot_type>();
    }
  }
}

