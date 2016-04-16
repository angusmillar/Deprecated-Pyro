using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Specimen
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string accession_Code {get; set;}                  
    public string accession_System {get; set;}                
    public DateTimeOffset? collected_DateTimeOffset {get; set;}              
    public string collector_FhirId {get; set;}     
    public string collector_Type {get; set;}     
    public string collector_Url {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public string subject_FhirId {get; set;}     
    public string subject_Type {get; set;}     
    public string subject_Url {get; set;}     

    public ICollection<Res_Specimen_Index_bodysite> bodysite_List { get; set; }   
    public ICollection<Res_Specimen_Index_container> container_List { get; set; }   
    public ICollection<Res_Specimen_Index_container_id> container_id_List { get; set; }   
    public ICollection<Res_Specimen_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_Specimen_Index_parent> parent_List { get; set; }   
    public ICollection<Res_Specimen_Index_type> type_List { get; set; }   

    public Res_Specimen()
    {
      this.bodysite_List = new HashSet<Res_Specimen_Index_bodysite>();
      this.container_List = new HashSet<Res_Specimen_Index_container>();
      this.container_id_List = new HashSet<Res_Specimen_Index_container_id>();
      this.identifier_List = new HashSet<Res_Specimen_Index_identifier>();
      this.parent_List = new HashSet<Res_Specimen_Index_parent>();
      this.type_List = new HashSet<Res_Specimen_Index_type>();
    }
  }
}