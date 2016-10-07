using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Protocol : ResourceIndexBase
  {
    public int Res_ProtocolID {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_Protocol_History> Res_Protocol_History_List { get; set; }
    public ICollection<Res_Protocol_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Protocol_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Protocol_Index__security> _security_List { get; set; }
    public ICollection<Res_Protocol_Index__tag> _tag_List { get; set; }
   
    public Res_Protocol()
    {
      this.identifier_List = new HashSet<Res_Protocol_Index_identifier>();
      this._profile_List = new HashSet<Res_Protocol_Index__profile>();
      this._security_List = new HashSet<Res_Protocol_Index__security>();
      this._tag_List = new HashSet<Res_Protocol_Index__tag>();
      this.Res_Protocol_History_List = new HashSet<Res_Protocol_History>();
    }
  }
}

