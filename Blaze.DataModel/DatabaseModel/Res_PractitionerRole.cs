using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_PractitionerRole : ResourceIndexBase
  {
    public int Res_PractitionerRoleID {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual Blaze_RootUrlStore organization_Url { get; set; }
    public int? organization_Url_Blaze_RootUrlStoreID { get; set; }
    public string practitioner_FhirId {get; set;}
    public string practitioner_Type {get; set;}
    public virtual Blaze_RootUrlStore practitioner_Url { get; set; }
    public int? practitioner_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_PractitionerRole_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_PractitionerRole_History> Res_PractitionerRole_History_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_email> email_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_location> location_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_phone> phone_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_role> role_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_specialty> specialty_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_telecom> telecom_List { get; set; }
   
    public Res_PractitionerRole()
    {
      this.email_List = new HashSet<Res_PractitionerRole_Index_email>();
      this.identifier_List = new HashSet<Res_PractitionerRole_Index_identifier>();
      this.location_List = new HashSet<Res_PractitionerRole_Index_location>();
      this.phone_List = new HashSet<Res_PractitionerRole_Index_phone>();
      this.role_List = new HashSet<Res_PractitionerRole_Index_role>();
      this.specialty_List = new HashSet<Res_PractitionerRole_Index_specialty>();
      this.telecom_List = new HashSet<Res_PractitionerRole_Index_telecom>();
      this.meta_tag_List = new HashSet<Res_PractitionerRole_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_PractitionerRole_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_PractitionerRole_Index_meta_profile>();
      this.Res_PractitionerRole_History_List = new HashSet<Res_PractitionerRole_History>();
    }
  }
}

