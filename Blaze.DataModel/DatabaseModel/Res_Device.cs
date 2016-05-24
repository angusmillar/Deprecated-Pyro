using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Device : ResourceIndexBase
  {
    public int Res_DeviceID {get; set;}
    public string location_FhirId {get; set;}
    public string location_Type {get; set;}
    public virtual Blaze_RootUrlStore location_Url { get; set; }
    public int? location_Url_Blaze_RootUrlStoreID { get; set; }
    public string manufacturer_String {get; set;}
    public string model_String {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual Blaze_RootUrlStore organization_Url { get; set; }
    public int? organization_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string udicarrier_Code {get; set;}
    public string udicarrier_System {get; set;}
    public string url_Uri {get; set;}
    public ICollection<Res_Device_History> Res_Device_History_List { get; set; }
    public ICollection<Res_Device_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Device_Index_type> type_List { get; set; }
    public ICollection<Res_Device_Index_profile> profile_List { get; set; }
    public ICollection<Res_Device_Index_security> security_List { get; set; }
    public ICollection<Res_Device_Index_tag> tag_List { get; set; }
   
    public Res_Device()
    {
      this.identifier_List = new HashSet<Res_Device_Index_identifier>();
      this.type_List = new HashSet<Res_Device_Index_type>();
      this.profile_List = new HashSet<Res_Device_Index_profile>();
      this.security_List = new HashSet<Res_Device_Index_security>();
      this.tag_List = new HashSet<Res_Device_Index_tag>();
      this.Res_Device_History_List = new HashSet<Res_Device_History>();
    }
  }
}

