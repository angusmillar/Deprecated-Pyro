using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Composition
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string confidentiality_Code {get; set;}                  
    public string confidentiality_System {get; set;}                
    public DateTimeOffset? date_DateTimeOffset {get; set;}              
    public string encounter_FhirId {get; set;}     
    public string encounter_Type {get; set;}     
    public string encounter_Url {get; set;}     
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     
    public string title_String {get; set;}                  

    public ICollection<Res_Composition_Index_attester> attester_List { get; set; }   
    public ICollection<Res_Composition_Index_author> author_List { get; set; }   
    public ICollection<Res_Composition_Index_class> class_List { get; set; }   
    public ICollection<Res_Composition_Index_context> context_List { get; set; }   
    public ICollection<Res_Composition_Index_entry> entry_List { get; set; }   
    public ICollection<Res_Composition_Index_period> period_List { get; set; }   
    public ICollection<Res_Composition_Index_section> section_List { get; set; }   
    public ICollection<Res_Composition_Index_type> type_List { get; set; }   

    public Res_Composition()
    {
      this.attester_List = new HashSet<Res_Composition_Index_attester>();
      this.author_List = new HashSet<Res_Composition_Index_author>();
      this.class_List = new HashSet<Res_Composition_Index_class>();
      this.context_List = new HashSet<Res_Composition_Index_context>();
      this.entry_List = new HashSet<Res_Composition_Index_entry>();
      this.period_List = new HashSet<Res_Composition_Index_period>();
      this.section_List = new HashSet<Res_Composition_Index_section>();
      this.type_List = new HashSet<Res_Composition_Index_type>();
    }
  }
}