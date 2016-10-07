using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Subscription : ResourceIndexBase
  {
    public int Res_SubscriptionID {get; set;}
    public string criteria_String {get; set;}
    public string payload_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public string url_Uri {get; set;}
    public ICollection<Res_Subscription_History> Res_Subscription_History_List { get; set; }
    public ICollection<Res_Subscription_Index_contact> contact_List { get; set; }
    public ICollection<Res_Subscription_Index_tag> tag_List { get; set; }
    public ICollection<Res_Subscription_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Subscription_Index__security> _security_List { get; set; }
    public ICollection<Res_Subscription_Index__tag> _tag_List { get; set; }
   
    public Res_Subscription()
    {
      this.contact_List = new HashSet<Res_Subscription_Index_contact>();
      this.tag_List = new HashSet<Res_Subscription_Index_tag>();
      this._profile_List = new HashSet<Res_Subscription_Index__profile>();
      this._security_List = new HashSet<Res_Subscription_Index__security>();
      this._tag_List = new HashSet<Res_Subscription_Index__tag>();
      this.Res_Subscription_History_List = new HashSet<Res_Subscription_History>();
    }
  }
}

