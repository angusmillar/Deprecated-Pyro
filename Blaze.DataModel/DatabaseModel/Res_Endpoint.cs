using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Endpoint : ResourceIndexBase
  {
    public int Res_EndpointID {get; set;}
    public string name_String {get; set;}
    public string organization_VersionId {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual ServiceRootURL_Store organization_Url { get; set; }
    public int? organization_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Endpoint_History> Res_Endpoint_History_List { get; set; }
    public ICollection<Res_Endpoint_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Endpoint_Index_payload_type> payload_type_List { get; set; }
    public ICollection<Res_Endpoint_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Endpoint_Index__security> _security_List { get; set; }
    public ICollection<Res_Endpoint_Index__tag> _tag_List { get; set; }
   
    public Res_Endpoint()
    {
      this.identifier_List = new HashSet<Res_Endpoint_Index_identifier>();
      this.payload_type_List = new HashSet<Res_Endpoint_Index_payload_type>();
      this._profile_List = new HashSet<Res_Endpoint_Index__profile>();
      this._security_List = new HashSet<Res_Endpoint_Index__security>();
      this._tag_List = new HashSet<Res_Endpoint_Index__tag>();
      this.Res_Endpoint_History_List = new HashSet<Res_Endpoint_History>();
    }
  }
}

