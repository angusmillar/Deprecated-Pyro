using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_EnrollmentResponse : ResourceIndexBase
  {
    public int Res_EnrollmentResponseID {get; set;}
    public ICollection<Res_EnrollmentResponse_History> Res_EnrollmentResponse_History_List { get; set; }
    public ICollection<Res_EnrollmentResponse_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_EnrollmentResponse_Index__profile> _profile_List { get; set; }
    public ICollection<Res_EnrollmentResponse_Index__security> _security_List { get; set; }
    public ICollection<Res_EnrollmentResponse_Index__tag> _tag_List { get; set; }
   
    public Res_EnrollmentResponse()
    {
      this.identifier_List = new HashSet<Res_EnrollmentResponse_Index_identifier>();
      this._profile_List = new HashSet<Res_EnrollmentResponse_Index__profile>();
      this._security_List = new HashSet<Res_EnrollmentResponse_Index__security>();
      this._tag_List = new HashSet<Res_EnrollmentResponse_Index__tag>();
      this.Res_EnrollmentResponse_History_List = new HashSet<Res_EnrollmentResponse_History>();
    }
  }
}

