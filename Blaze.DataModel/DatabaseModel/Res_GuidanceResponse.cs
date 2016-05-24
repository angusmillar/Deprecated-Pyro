using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_GuidanceResponse : ResourceIndexBase
  {
    public int Res_GuidanceResponseID {get; set;}
    public ICollection<Res_GuidanceResponse_History> Res_GuidanceResponse_History_List { get; set; }
    public ICollection<Res_GuidanceResponse_Index_profile> profile_List { get; set; }
    public ICollection<Res_GuidanceResponse_Index_security> security_List { get; set; }
    public ICollection<Res_GuidanceResponse_Index_tag> tag_List { get; set; }
   
    public Res_GuidanceResponse()
    {
      this.profile_List = new HashSet<Res_GuidanceResponse_Index_profile>();
      this.security_List = new HashSet<Res_GuidanceResponse_Index_security>();
      this.tag_List = new HashSet<Res_GuidanceResponse_Index_tag>();
      this.Res_GuidanceResponse_History_List = new HashSet<Res_GuidanceResponse_History>();
    }
  }
}

