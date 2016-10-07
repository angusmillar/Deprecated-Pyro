using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MessageHeader : ResourceIndexBase
  {
    public int Res_MessageHeaderID {get; set;}
    public string author_VersionId {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual ServiceRootURL_Store author_Url { get; set; }
    public int? author_ServiceRootURL_StoreID { get; set; }
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public string enterer_VersionId {get; set;}
    public string enterer_FhirId {get; set;}
    public string enterer_Type {get; set;}
    public virtual ServiceRootURL_Store enterer_Url { get; set; }
    public int? enterer_ServiceRootURL_StoreID { get; set; }
    public string event_Code {get; set;}
    public string event_System {get; set;}
    public string receiver_VersionId {get; set;}
    public string receiver_FhirId {get; set;}
    public string receiver_Type {get; set;}
    public virtual ServiceRootURL_Store receiver_Url { get; set; }
    public int? receiver_ServiceRootURL_StoreID { get; set; }
    public string response_id_Code {get; set;}
    public string response_id_System {get; set;}
    public string responsible_VersionId {get; set;}
    public string responsible_FhirId {get; set;}
    public string responsible_Type {get; set;}
    public virtual ServiceRootURL_Store responsible_Url { get; set; }
    public int? responsible_ServiceRootURL_StoreID { get; set; }
    public string source_String {get; set;}
    public string source_uri_Uri {get; set;}
    public DateTimeOffset? timestamp_DateTimeOffset {get; set;}
    public ICollection<Res_MessageHeader_History> Res_MessageHeader_History_List { get; set; }
    public ICollection<Res_MessageHeader_Index_data> data_List { get; set; }
    public ICollection<Res_MessageHeader_Index_destination> destination_List { get; set; }
    public ICollection<Res_MessageHeader_Index_destination_uri> destination_uri_List { get; set; }
    public ICollection<Res_MessageHeader_Index_target> target_List { get; set; }
    public ICollection<Res_MessageHeader_Index__profile> _profile_List { get; set; }
    public ICollection<Res_MessageHeader_Index__security> _security_List { get; set; }
    public ICollection<Res_MessageHeader_Index__tag> _tag_List { get; set; }
   
    public Res_MessageHeader()
    {
      this.data_List = new HashSet<Res_MessageHeader_Index_data>();
      this.destination_List = new HashSet<Res_MessageHeader_Index_destination>();
      this.destination_uri_List = new HashSet<Res_MessageHeader_Index_destination_uri>();
      this.target_List = new HashSet<Res_MessageHeader_Index_target>();
      this._profile_List = new HashSet<Res_MessageHeader_Index__profile>();
      this._security_List = new HashSet<Res_MessageHeader_Index__security>();
      this._tag_List = new HashSet<Res_MessageHeader_Index__tag>();
      this.Res_MessageHeader_History_List = new HashSet<Res_MessageHeader_History>();
    }
  }
}

