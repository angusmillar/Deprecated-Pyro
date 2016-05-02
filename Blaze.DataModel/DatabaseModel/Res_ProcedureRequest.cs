using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ProcedureRequest
  {
    public int Res_ProcedureRequestID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Blaze_RootUrlStore encounter_Url { get; set; }
    public int? encounter_Url_Blaze_RootUrlStoreID { get; set; }
    public string orderer_FhirId {get; set;}
    public string orderer_Type {get; set;}
    public virtual Blaze_RootUrlStore orderer_Url { get; set; }
    public int? orderer_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string performer_FhirId {get; set;}
    public string performer_Type {get; set;}
    public virtual Blaze_RootUrlStore performer_Url { get; set; }
    public int? performer_Url_Blaze_RootUrlStoreID { get; set; }
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_ProcedureRequest_Index_identifier> identifier_List { get; set; }
   
    public Res_ProcedureRequest()
    {
      this.identifier_List = new HashSet<Res_ProcedureRequest_Index_identifier>();
    }
  }
}

