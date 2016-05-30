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
    public string organizationidentifier_Code {get; set;}
    public string organizationidentifier_System {get; set;}
    public string organizationreference_VersionId {get; set;}
    public string organizationreference_FhirId {get; set;}
    public string organizationreference_Type {get; set;}
    public virtual Blaze_RootUrlStore organizationreference_Url { get; set; }
    public int? organizationreference_Url_Blaze_RootUrlStoreID { get; set; }
    public string provideridentifier_Code {get; set;}
    public string provideridentifier_System {get; set;}
    public string providerreference_VersionId {get; set;}
    public string providerreference_FhirId {get; set;}
    public string providerreference_Type {get; set;}
    public virtual Blaze_RootUrlStore providerreference_Url { get; set; }
    public int? providerreference_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_ProcessRequest_History> Res_ProcessRequest_History_List { get; set; }
    public ICollection<Res_ProcessRequest_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_ProcessRequest_Index_profile> profile_List { get; set; }
    public ICollection<Res_ProcessRequest_Index_security> security_List { get; set; }
    public ICollection<Res_ProcessRequest_Index_tag> tag_List { get; set; }
   
    public Res_ProcessRequest()
    {
      this.identifier_List = new HashSet<Res_ProcessRequest_Index_identifier>();
      this.profile_List = new HashSet<Res_ProcessRequest_Index_profile>();
      this.security_List = new HashSet<Res_ProcessRequest_Index_security>();
      this.tag_List = new HashSet<Res_ProcessRequest_Index_tag>();
      this.Res_ProcessRequest_History_List = new HashSet<Res_ProcessRequest_History>();
    }
  }
}

