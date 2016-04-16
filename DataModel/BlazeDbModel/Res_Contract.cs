using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Contract
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                

    public ICollection<Res_Contract_Index_actor> actor_List { get; set; }   
    public ICollection<Res_Contract_Index_patient> patient_List { get; set; }   
    public ICollection<Res_Contract_Index_signer> signer_List { get; set; }   
    public ICollection<Res_Contract_Index_subject> subject_List { get; set; }   

    public Res_Contract()
    {
      this.actor_List = new HashSet<Res_Contract_Index_actor>();
      this.patient_List = new HashSet<Res_Contract_Index_patient>();
      this.signer_List = new HashSet<Res_Contract_Index_signer>();
      this.subject_List = new HashSet<Res_Contract_Index_subject>();
    }
  }
}