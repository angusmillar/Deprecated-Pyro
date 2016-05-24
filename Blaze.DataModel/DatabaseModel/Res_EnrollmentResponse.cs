using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_EnrollmentResponse : ResourceIndexBase
  {
    public int Res_EnrollmentResponseID {get; set;}
    public ICollection<Res_EnrollmentResponse_History> Res_EnrollmentResponse_History_List { get; set; }
    public ICollection<Res_EnrollmentResponse_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_EnrollmentResponse_Index_profile> profile_List { get; set; }
    public ICollection<Res_EnrollmentResponse_Index_security> security_List { get; set; }
    public ICollection<Res_EnrollmentResponse_Index_tag> tag_List { get; set; }
   
    public Res_EnrollmentResponse()
    {
      this.identifier_List = new HashSet<Res_EnrollmentResponse_Index_identifier>();
      this.profile_List = new HashSet<Res_EnrollmentResponse_Index_profile>();
      this.security_List = new HashSet<Res_EnrollmentResponse_Index_security>();
      this.tag_List = new HashSet<Res_EnrollmentResponse_Index_tag>();
      this.Res_EnrollmentResponse_History_List = new HashSet<Res_EnrollmentResponse_History>();
    }
  }
}

