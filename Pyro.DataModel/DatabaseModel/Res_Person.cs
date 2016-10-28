using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Person : ResourceIndexBase
  {
    public int Res_PersonID {get; set;}
    public int? birthdate_Date {get; set;}
    public string gender_Code {get; set;}
    public string gender_System {get; set;}
    public string organization_VersionId {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual ServiceRootURL_Store organization_Url { get; set; }
    public int? organization_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_Person_History> Res_Person_History_List { get; set; }
    public ICollection<Res_Person_Index_address> address_List { get; set; }
    public ICollection<Res_Person_Index_address_city> address_city_List { get; set; }
    public ICollection<Res_Person_Index_address_country> address_country_List { get; set; }
    public ICollection<Res_Person_Index_address_postalcode> address_postalcode_List { get; set; }
    public ICollection<Res_Person_Index_address_state> address_state_List { get; set; }
    public ICollection<Res_Person_Index_address_use> address_use_List { get; set; }
    public ICollection<Res_Person_Index_email> email_List { get; set; }
    public ICollection<Res_Person_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Person_Index_link> link_List { get; set; }
    public ICollection<Res_Person_Index_name> name_List { get; set; }
    public ICollection<Res_Person_Index_patient> patient_List { get; set; }
    public ICollection<Res_Person_Index_phone> phone_List { get; set; }
    public ICollection<Res_Person_Index_phonetic> phonetic_List { get; set; }
    public ICollection<Res_Person_Index_practitioner> practitioner_List { get; set; }
    public ICollection<Res_Person_Index_relatedperson> relatedperson_List { get; set; }
    public ICollection<Res_Person_Index_telecom> telecom_List { get; set; }
    public ICollection<Res_Person_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Person_Index__security> _security_List { get; set; }
    public ICollection<Res_Person_Index__tag> _tag_List { get; set; }
   
    public Res_Person()
    {
      this.address_List = new HashSet<Res_Person_Index_address>();
      this.address_city_List = new HashSet<Res_Person_Index_address_city>();
      this.address_country_List = new HashSet<Res_Person_Index_address_country>();
      this.address_postalcode_List = new HashSet<Res_Person_Index_address_postalcode>();
      this.address_state_List = new HashSet<Res_Person_Index_address_state>();
      this.address_use_List = new HashSet<Res_Person_Index_address_use>();
      this.email_List = new HashSet<Res_Person_Index_email>();
      this.identifier_List = new HashSet<Res_Person_Index_identifier>();
      this.link_List = new HashSet<Res_Person_Index_link>();
      this.name_List = new HashSet<Res_Person_Index_name>();
      this.patient_List = new HashSet<Res_Person_Index_patient>();
      this.phone_List = new HashSet<Res_Person_Index_phone>();
      this.phonetic_List = new HashSet<Res_Person_Index_phonetic>();
      this.practitioner_List = new HashSet<Res_Person_Index_practitioner>();
      this.relatedperson_List = new HashSet<Res_Person_Index_relatedperson>();
      this.telecom_List = new HashSet<Res_Person_Index_telecom>();
      this._profile_List = new HashSet<Res_Person_Index__profile>();
      this._security_List = new HashSet<Res_Person_Index__security>();
      this._tag_List = new HashSet<Res_Person_Index__tag>();
      this.Res_Person_History_List = new HashSet<Res_Person_History>();
    }
  }
}

