using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_HealthcareService : ResourceIndexBase
  {
    public int Res_HealthcareServiceID {get; set;}
    public string name_String {get; set;}
    public string organization_VersionId {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual Blaze_RootUrlStore organization_Url { get; set; }
    public int? organization_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_HealthcareService_History> Res_HealthcareService_History_List { get; set; }
    public ICollection<Res_HealthcareService_Index_characteristic> characteristic_List { get; set; }
    public ICollection<Res_HealthcareService_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_HealthcareService_Index_location> location_List { get; set; }
    public ICollection<Res_HealthcareService_Index_programname> programname_List { get; set; }
    public ICollection<Res_HealthcareService_Index_servicecategory> servicecategory_List { get; set; }
    public ICollection<Res_HealthcareService_Index_servicetype> servicetype_List { get; set; }
    public ICollection<Res_HealthcareService_Index_profile> profile_List { get; set; }
    public ICollection<Res_HealthcareService_Index_security> security_List { get; set; }
    public ICollection<Res_HealthcareService_Index_tag> tag_List { get; set; }
   
    public Res_HealthcareService()
    {
      this.characteristic_List = new HashSet<Res_HealthcareService_Index_characteristic>();
      this.identifier_List = new HashSet<Res_HealthcareService_Index_identifier>();
      this.location_List = new HashSet<Res_HealthcareService_Index_location>();
      this.programname_List = new HashSet<Res_HealthcareService_Index_programname>();
      this.servicecategory_List = new HashSet<Res_HealthcareService_Index_servicecategory>();
      this.servicetype_List = new HashSet<Res_HealthcareService_Index_servicetype>();
      this.profile_List = new HashSet<Res_HealthcareService_Index_profile>();
      this.security_List = new HashSet<Res_HealthcareService_Index_security>();
      this.tag_List = new HashSet<Res_HealthcareService_Index_tag>();
      this.Res_HealthcareService_History_List = new HashSet<Res_HealthcareService_History>();
    }
  }
}

