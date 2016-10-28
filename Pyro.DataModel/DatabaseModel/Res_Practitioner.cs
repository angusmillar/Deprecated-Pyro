using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Practitioner : ResourceIndexBase
  {
    public int Res_PractitionerID {get; set;}
    public string active_Code {get; set;}
    public string active_System {get; set;}
    public string gender_Code {get; set;}
    public string gender_System {get; set;}
    public ICollection<Res_Practitioner_History> Res_Practitioner_History_List { get; set; }
    public ICollection<Res_Practitioner_Index_address> address_List { get; set; }
    public ICollection<Res_Practitioner_Index_address_city> address_city_List { get; set; }
    public ICollection<Res_Practitioner_Index_address_country> address_country_List { get; set; }
    public ICollection<Res_Practitioner_Index_address_postalcode> address_postalcode_List { get; set; }
    public ICollection<Res_Practitioner_Index_address_state> address_state_List { get; set; }
    public ICollection<Res_Practitioner_Index_address_use> address_use_List { get; set; }
    public ICollection<Res_Practitioner_Index_communication> communication_List { get; set; }
    public ICollection<Res_Practitioner_Index_email> email_List { get; set; }
    public ICollection<Res_Practitioner_Index_family> family_List { get; set; }
    public ICollection<Res_Practitioner_Index_given> given_List { get; set; }
    public ICollection<Res_Practitioner_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Practitioner_Index_location> location_List { get; set; }
    public ICollection<Res_Practitioner_Index_name> name_List { get; set; }
    public ICollection<Res_Practitioner_Index_organization> organization_List { get; set; }
    public ICollection<Res_Practitioner_Index_phone> phone_List { get; set; }
    public ICollection<Res_Practitioner_Index_phonetic> phonetic_List { get; set; }
    public ICollection<Res_Practitioner_Index_role> role_List { get; set; }
    public ICollection<Res_Practitioner_Index_specialty> specialty_List { get; set; }
    public ICollection<Res_Practitioner_Index_telecom> telecom_List { get; set; }
    public ICollection<Res_Practitioner_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Practitioner_Index__security> _security_List { get; set; }
    public ICollection<Res_Practitioner_Index__tag> _tag_List { get; set; }
   
    public Res_Practitioner()
    {
      this.address_List = new HashSet<Res_Practitioner_Index_address>();
      this.address_city_List = new HashSet<Res_Practitioner_Index_address_city>();
      this.address_country_List = new HashSet<Res_Practitioner_Index_address_country>();
      this.address_postalcode_List = new HashSet<Res_Practitioner_Index_address_postalcode>();
      this.address_state_List = new HashSet<Res_Practitioner_Index_address_state>();
      this.address_use_List = new HashSet<Res_Practitioner_Index_address_use>();
      this.communication_List = new HashSet<Res_Practitioner_Index_communication>();
      this.email_List = new HashSet<Res_Practitioner_Index_email>();
      this.family_List = new HashSet<Res_Practitioner_Index_family>();
      this.given_List = new HashSet<Res_Practitioner_Index_given>();
      this.identifier_List = new HashSet<Res_Practitioner_Index_identifier>();
      this.location_List = new HashSet<Res_Practitioner_Index_location>();
      this.name_List = new HashSet<Res_Practitioner_Index_name>();
      this.organization_List = new HashSet<Res_Practitioner_Index_organization>();
      this.phone_List = new HashSet<Res_Practitioner_Index_phone>();
      this.phonetic_List = new HashSet<Res_Practitioner_Index_phonetic>();
      this.role_List = new HashSet<Res_Practitioner_Index_role>();
      this.specialty_List = new HashSet<Res_Practitioner_Index_specialty>();
      this.telecom_List = new HashSet<Res_Practitioner_Index_telecom>();
      this._profile_List = new HashSet<Res_Practitioner_Index__profile>();
      this._security_List = new HashSet<Res_Practitioner_Index__security>();
      this._tag_List = new HashSet<Res_Practitioner_Index__tag>();
      this.Res_Practitioner_History_List = new HashSet<Res_Practitioner_History>();
    }
  }
}

