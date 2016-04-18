using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_Provenance
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? end_DateTimeOffset {get; set;}              
    public string location_FhirId {get; set;}     
    public string location_Type {get; set;}     
    public string location_Url {get; set;}     
    public DateTimeOffset? start_DateTimeOffset {get; set;}              

    public ICollection<Res_Provenance_Index_agent> agent_List { get; set; }   
    public ICollection<Res_Provenance_Index_entity> entity_List { get; set; }   
    public ICollection<Res_Provenance_Index_entitytype> entitytype_List { get; set; }   
    public ICollection<Res_Provenance_Index_patient> patient_List { get; set; }   
    public ICollection<Res_Provenance_Index_sigtype> sigtype_List { get; set; }   
    public ICollection<Res_Provenance_Index_target> target_List { get; set; }   
    public ICollection<Res_Provenance_Index_userid> userid_List { get; set; }   

    public Res_Provenance()
    {
      this.agent_List = new HashSet<Res_Provenance_Index_agent>();
      this.entity_List = new HashSet<Res_Provenance_Index_entity>();
      this.entitytype_List = new HashSet<Res_Provenance_Index_entitytype>();
      this.patient_List = new HashSet<Res_Provenance_Index_patient>();
      this.sigtype_List = new HashSet<Res_Provenance_Index_sigtype>();
      this.target_List = new HashSet<Res_Provenance_Index_target>();
      this.userid_List = new HashSet<Res_Provenance_Index_userid>();
    }
  }
}