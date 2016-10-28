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
    public string active_Code {get; set;}
    public string active_System {get; set;}
    public string name_String {get; set;}
    public string organization_VersionId {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual ServiceRootURL_Store organization_Url { get; set; }
    public int? organization_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_HealthcareService_History> Res_HealthcareService_History_List { get; set; }
    public ICollection<Res_HealthcareService_Index_characteristic> characteristic_List { get; set; }
    public ICollection<Res_HealthcareService_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_HealthcareService_Index_location> location_List { get; set; }
    public ICollection<Res_HealthcareService_Index_programname> programname_List { get; set; }
    public ICollection<Res_HealthcareService_Index_servicecategory> servicecategory_List { get; set; }
    public ICollection<Res_HealthcareService_Index_servicetype> servicetype_List { get; set; }
    public ICollection<Res_HealthcareService_Index__profile> _profile_List { get; set; }
    public ICollection<Res_HealthcareService_Index__security> _security_List { get; set; }
    public ICollection<Res_HealthcareService_Index__tag> _tag_List { get; set; }
   
    public Res_HealthcareService()
    {
      this.characteristic_List = new HashSet<Res_HealthcareService_Index_characteristic>();
      this.identifier_List = new HashSet<Res_HealthcareService_Index_identifier>();
      this.location_List = new HashSet<Res_HealthcareService_Index_location>();
      this.programname_List = new HashSet<Res_HealthcareService_Index_programname>();
      this.servicecategory_List = new HashSet<Res_HealthcareService_Index_servicecategory>();
      this.servicetype_List = new HashSet<Res_HealthcareService_Index_servicetype>();
      this._profile_List = new HashSet<Res_HealthcareService_Index__profile>();
      this._security_List = new HashSet<Res_HealthcareService_Index__security>();
      this._tag_List = new HashSet<Res_HealthcareService_Index__tag>();
      this.Res_HealthcareService_History_List = new HashSet<Res_HealthcareService_History>();
    }
  }
}

