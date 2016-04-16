using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Slot
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string fb_type_Code {get; set;}                  
    public string fb_type_System {get; set;}                
    public string schedule_FhirId {get; set;}     
    public string schedule_Type {get; set;}     
    public string schedule_Url {get; set;}     
    public DateTimeOffset? start_DateTimeOffset {get; set;}              

    public ICollection<Res_Slot_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_Slot_Index_slot_type> slot_type_List { get; set; }   

    public Res_Slot()
    {
      this.identifier_List = new HashSet<Res_Slot_Index_identifier>();
      this.slot_type_List = new HashSet<Res_Slot_Index_slot_type>();
    }
  }
}