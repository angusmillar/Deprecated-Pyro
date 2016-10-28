using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ProcessRequest : ResourceIndexBase
  {
    public int Res_ProcessRequestID {get; set;}
    public string action_Code {get; set;}
    public string action_System {get; set;}
    public string organization_identifier_Code {get; set;}
    public string organization_identifier_System {get; set;}
    public string organization_reference_VersionId {get; set;}
    public string organization_reference_FhirId {get; set;}
    public string organization_reference_Type {get; set;}
    public virtual ServiceRootURL_Store organization_reference_Url { get; set; }
    public int? organization_reference_ServiceRootURL_StoreID { get; set; }
    public string provider_identifier_Code {get; set;}
    public string provider_identifier_System {get; set;}
    public string provider_reference_VersionId {get; set;}
    public string provider_reference_FhirId {get; set;}
    public string provider_reference_Type {get; set;}
    public virtual ServiceRootURL_Store provider_reference_Url { get; set; }
    public int? provider_reference_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_ProcessRequest_History> Res_ProcessRequest_History_List { get; set; }
    public ICollection<Res_ProcessRequest_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_ProcessRequest_Index__profile> _profile_List { get; set; }
    public ICollection<Res_ProcessRequest_Index__security> _security_List { get; set; }
    public ICollection<Res_ProcessRequest_Index__tag> _tag_List { get; set; }
   
    public Res_ProcessRequest()
    {
      this.identifier_List = new HashSet<Res_ProcessRequest_Index_identifier>();
      this._profile_List = new HashSet<Res_ProcessRequest_Index__profile>();
      this._security_List = new HashSet<Res_ProcessRequest_Index__security>();
      this._tag_List = new HashSet<Res_ProcessRequest_Index__tag>();
      this.Res_ProcessRequest_History_List = new HashSet<Res_ProcessRequest_History>();
    }
  }
}

