using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Device
  {
    public int Res_DeviceID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
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
    public ICollection<Res_Device_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Device_Index_type> type_List { get; set; }
   
    public Res_Device()
    {
      this.identifier_List = new HashSet<Res_Device_Index_identifier>();
      this.type_List = new HashSet<Res_Device_Index_type>();
    }
  }
}

