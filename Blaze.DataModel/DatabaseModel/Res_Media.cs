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
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string operator_FhirId {get; set;}
    public string operator_Type {get; set;}
    public virtual Blaze_RootUrlStore operator_Url { get; set; }
    public int? operator_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
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

