using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_MessageHeader
  {
    public int Res_MessageHeaderID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual Aux_RootUrlStore author_Aux_RootUrlStoreID { get; set; }
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public string enterer_FhirId {get; set;}
    public string enterer_Type {get; set;}
    public virtual Aux_RootUrlStore enterer_Aux_RootUrlStoreID { get; set; }
    public string event_Code {get; set;}
    public string event_System {get; set;}
    public string receiver_FhirId {get; set;}
    public string receiver_Type {get; set;}
    public virtual Aux_RootUrlStore receiver_Aux_RootUrlStoreID { get; set; }
    public string response_id_Code {get; set;}
    public string response_id_System {get; set;}
    public string responsible_FhirId {get; set;}
    public string responsible_Type {get; set;}
    public virtual Aux_RootUrlStore responsible_Aux_RootUrlStoreID { get; set; }
    public string source_String {get; set;}
    public string source_uri_Uri {get; set;}
    public DateTimeOffset? timestamp_DateTimeOffset {get; set;}
    public ICollection<Res_MessageHeader_Index_data> data_List { get; set; }
    public ICollection<Res_MessageHeader_Index_destination> destination_List { get; set; }
    public ICollection<Res_MessageHeader_Index_destination_uri> destination_uri_List { get; set; }
    public ICollection<Res_MessageHeader_Index_target> target_List { get; set; }
   
    public Res_MessageHeader()
    {
      this.data_List = new HashSet<Res_MessageHeader_Index_data>();
      this.destination_List = new HashSet<Res_MessageHeader_Index_destination>();
      this.destination_uri_List = new HashSet<Res_MessageHeader_Index_destination_uri>();
      this.target_List = new HashSet<Res_MessageHeader_Index_target>();
    }
  }
}

