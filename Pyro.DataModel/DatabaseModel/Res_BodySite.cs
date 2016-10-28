using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_BodySite : ResourceIndexBase
  {
    public int Res_BodySiteID {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_BodySite_History> Res_BodySite_History_List { get; set; }
    public ICollection<Res_BodySite_Index_code> code_List { get; set; }
    public ICollection<Res_BodySite_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_BodySite_Index__profile> _profile_List { get; set; }
    public ICollection<Res_BodySite_Index__security> _security_List { get; set; }
    public ICollection<Res_BodySite_Index__tag> _tag_List { get; set; }
   
    public Res_BodySite()
    {
      this.code_List = new HashSet<Res_BodySite_Index_code>();
      this.identifier_List = new HashSet<Res_BodySite_Index_identifier>();
      this._profile_List = new HashSet<Res_BodySite_Index__profile>();
      this._security_List = new HashSet<Res_BodySite_Index__security>();
      this._tag_List = new HashSet<Res_BodySite_Index__tag>();
      this.Res_BodySite_History_List = new HashSet<Res_BodySite_History>();
    }
  }
}

