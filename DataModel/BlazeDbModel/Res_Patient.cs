using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Patient
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string active_Code {get; set;}                  
    public string active_System {get; set;}                
    public DateTimeOffset? birthdate_DateTimeOffset {get; set;}              
    public DateTimeOffset? deathdate_DateTimeOffset {get; set;}              
    public string deceased_Code {get; set;}                  
    public string deceased_System {get; set;}                
    public string gender_Code {get; set;}                  
    public string gender_System {get; set;}                
    public string organization_FhirId {get; set;}     
    public string organization_Type {get; set;}     
    public string organization_Url {get; set;}     

    public ICollection<Res_Patient_Index_address> address_List { get; set; }   
    public ICollection<Res_Patient_Index_address_city> address_city_List { get; set; }   
    public ICollection<Res_Patient_Index_address_country> address_country_List { get; set; }   
    public ICollection<Res_Patient_Index_address_postalcode> address_postalcode_List { get; set; }   
    public ICollection<Res_Patient_Index_address_state> address_state_List { get; set; }   
    public ICollection<Res_Patient_Index_address_use> address_use_List { get; set; }   
    public ICollection<Res_Patient_Index_animal_breed> animal_breed_List { get; set; }   
    public ICollection<Res_Patient_Index_animal_species> animal_species_List { get; set; }   
    public ICollection<Res_Patient_Index_careprovider> careprovider_List { get; set; }   
    public ICollection<Res_Patient_Index_email> email_List { get; set; }   
    public ICollection<Res_Patient_Index_family> family_List { get; set; }   
    public ICollection<Res_Patient_Index_given> given_List { get; set; }   
    public ICollection<Res_Patient_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_Patient_Index_language> language_List { get; set; }   
    public ICollection<Res_Patient_Index_link> link_List { get; set; }   
    public ICollection<Res_Patient_Index_name> name_List { get; set; }   
    public ICollection<Res_Patient_Index_phone> phone_List { get; set; }   
    public ICollection<Res_Patient_Index_phonetic> phonetic_List { get; set; }   
    public ICollection<Res_Patient_Index_telecom> telecom_List { get; set; }   
    public ICollection<Res_Patient_Index_race> race_List { get; set; }   
    public ICollection<Res_Patient_Index_ethnicity> ethnicity_List { get; set; }   

    public Res_Patient()
    {
      this.address_List = new HashSet<Res_Patient_Index_address>();
      this.address_city_List = new HashSet<Res_Patient_Index_address_city>();
      this.address_country_List = new HashSet<Res_Patient_Index_address_country>();
      this.address_postalcode_List = new HashSet<Res_Patient_Index_address_postalcode>();
      this.address_state_List = new HashSet<Res_Patient_Index_address_state>();
      this.address_use_List = new HashSet<Res_Patient_Index_address_use>();
      this.animal_breed_List = new HashSet<Res_Patient_Index_animal_breed>();
      this.animal_species_List = new HashSet<Res_Patient_Index_animal_species>();
      this.careprovider_List = new HashSet<Res_Patient_Index_careprovider>();
      this.email_List = new HashSet<Res_Patient_Index_email>();
      this.family_List = new HashSet<Res_Patient_Index_family>();
      this.given_List = new HashSet<Res_Patient_Index_given>();
      this.identifier_List = new HashSet<Res_Patient_Index_identifier>();
      this.language_List = new HashSet<Res_Patient_Index_language>();
      this.link_List = new HashSet<Res_Patient_Index_link>();
      this.name_List = new HashSet<Res_Patient_Index_name>();
      this.phone_List = new HashSet<Res_Patient_Index_phone>();
      this.phonetic_List = new HashSet<Res_Patient_Index_phonetic>();
      this.telecom_List = new HashSet<Res_Patient_Index_telecom>();
      this.race_List = new HashSet<Res_Patient_Index_race>();
      this.ethnicity_List = new HashSet<Res_Patient_Index_ethnicity>();
    }
  }
}