using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_RelatedPerson
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public DateTimeOffset? birthdate_DateTimeOffset {get; set;}              
    public string gender_Code {get; set;}                  
    public string gender_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     

    public ICollection<Res_RelatedPerson_Index_address> address_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_address_city> address_city_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_address_country> address_country_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_address_postalcode> address_postalcode_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_address_state> address_state_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_address_use> address_use_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_email> email_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_name> name_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_phone> phone_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_phonetic> phonetic_List { get; set; }   
    public ICollection<Res_RelatedPerson_Index_telecom> telecom_List { get; set; }   

    public Res_RelatedPerson()
    {
      this.address_List = new HashSet<Res_RelatedPerson_Index_address>();
      this.address_city_List = new HashSet<Res_RelatedPerson_Index_address_city>();
      this.address_country_List = new HashSet<Res_RelatedPerson_Index_address_country>();
      this.address_postalcode_List = new HashSet<Res_RelatedPerson_Index_address_postalcode>();
      this.address_state_List = new HashSet<Res_RelatedPerson_Index_address_state>();
      this.address_use_List = new HashSet<Res_RelatedPerson_Index_address_use>();
      this.email_List = new HashSet<Res_RelatedPerson_Index_email>();
      this.identifier_List = new HashSet<Res_RelatedPerson_Index_identifier>();
      this.name_List = new HashSet<Res_RelatedPerson_Index_name>();
      this.phone_List = new HashSet<Res_RelatedPerson_Index_phone>();
      this.phonetic_List = new HashSet<Res_RelatedPerson_Index_phonetic>();
      this.telecom_List = new HashSet<Res_RelatedPerson_Index_telecom>();
    }
  }
}