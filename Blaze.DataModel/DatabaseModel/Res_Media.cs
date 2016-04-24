using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Media
  {
    public int Res_MediaID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string operator_FhirId {get; set;}
    public string operator_Type {get; set;}
    public virtual Aux_RootUrlStore operator_Aux_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Aux_RootUrlStore subject_Aux_RootUrlStoreID { get; set; }
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Media_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Media_Index_subtype> subtype_List { get; set; }
    public ICollection<Res_Media_Index_view> view_List { get; set; }
   
    public Res_Media()
    {
      this.identifier_List = new HashSet<Res_Media_Index_identifier>();
      this.subtype_List = new HashSet<Res_Media_Index_subtype>();
      this.view_List = new HashSet<Res_Media_Index_view>();
    }
  }
}

