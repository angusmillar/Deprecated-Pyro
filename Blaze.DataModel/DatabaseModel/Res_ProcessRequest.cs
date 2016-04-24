using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ProcessRequest
  {
    public int Res_ProcessRequestID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public string action_Code {get; set;}
    public string action_System {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual Aux_RootUrlStore organization_Aux_RootUrlStoreID { get; set; }
    public string provider_FhirId {get; set;}
    public string provider_Type {get; set;}
    public virtual Aux_RootUrlStore provider_Aux_RootUrlStoreID { get; set; }
    public ICollection<Res_ProcessRequest_Index_identifier> identifier_List { get; set; }
   
    public Res_ProcessRequest()
    {
      this.identifier_List = new HashSet<Res_ProcessRequest_Index_identifier>();
    }
  }
}

