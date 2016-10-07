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
    public string organization_VersionId {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual ServiceRootURL_Store organization_Url { get; set; }
    public int? organization_ServiceRootURL_StoreID { get; set; }
    public string practitioner_VersionId {get; set;}
    public string practitioner_FhirId {get; set;}
    public string practitioner_Type {get; set;}
    public virtual ServiceRootURL_Store practitioner_Url { get; set; }
    public int? practitioner_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_PractitionerRole_History> Res_PractitionerRole_History_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_email> email_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_location> location_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_phone> phone_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_role> role_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_specialty> specialty_List { get; set; }
    public ICollection<Res_PractitionerRole_Index_telecom> telecom_List { get; set; }
    public ICollection<Res_PractitionerRole_Index__profile> _profile_List { get; set; }
    public ICollection<Res_PractitionerRole_Index__security> _security_List { get; set; }
    public ICollection<Res_PractitionerRole_Index__tag> _tag_List { get; set; }
   
    public Res_PractitionerRole()
    {
      this.email_List = new HashSet<Res_PractitionerRole_Index_email>();
      this.identifier_List = new HashSet<Res_PractitionerRole_Index_identifier>();
      this.location_List = new HashSet<Res_PractitionerRole_Index_location>();
      this.phone_List = new HashSet<Res_PractitionerRole_Index_phone>();
      this.role_List = new HashSet<Res_PractitionerRole_Index_role>();
      this.specialty_List = new HashSet<Res_PractitionerRole_Index_specialty>();
      this.telecom_List = new HashSet<Res_PractitionerRole_Index_telecom>();
      this._profile_List = new HashSet<Res_PractitionerRole_Index__profile>();
      this._security_List = new HashSet<Res_PractitionerRole_Index__security>();
      this._tag_List = new HashSet<Res_PractitionerRole_Index__tag>();
      this.Res_PractitionerRole_History_List = new HashSet<Res_PractitionerRole_History>();
    }
  }
}

