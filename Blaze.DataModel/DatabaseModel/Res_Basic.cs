using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Basic : ResourceIndexBase
  {
    public int Res_BasicID {get; set;}
    public string author_VersionId {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual ServiceRootURL_Store author_Url { get; set; }
    public int? author_ServiceRootURL_StoreID { get; set; }
    public int? created_Date {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_Basic_History> Res_Basic_History_List { get; set; }
    public ICollection<Res_Basic_Index_code> code_List { get; set; }
    public ICollection<Res_Basic_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Basic_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Basic_Index__security> _security_List { get; set; }
    public ICollection<Res_Basic_Index__tag> _tag_List { get; set; }
   
    public Res_Basic()
    {
      this.code_List = new HashSet<Res_Basic_Index_code>();
      this.identifier_List = new HashSet<Res_Basic_Index_identifier>();
      this._profile_List = new HashSet<Res_Basic_Index__profile>();
      this._security_List = new HashSet<Res_Basic_Index__security>();
      this._tag_List = new HashSet<Res_Basic_Index__tag>();
      this.Res_Basic_History_List = new HashSet<Res_Basic_History>();
    }
  }
}

