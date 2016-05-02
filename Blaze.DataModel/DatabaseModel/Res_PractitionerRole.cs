using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_PractitionerRole
  {
    public int Res_PractitionerRoleID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual Blaze_RootUrlStore organization_Url { get; set; }
    public int? organization_Url_Blaze_RootUrlStoreID { get; set; }
    public string practitioner_FhirId {get; set;}
    public string practitioner_Type {get; set;}
    public virtual Blaze_RootUrlStore practitioner_Url { get; set; }
    public int? practitioner_Url_Blaze_RootUrlStoreID { get; set; }
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
    }
  }
}

