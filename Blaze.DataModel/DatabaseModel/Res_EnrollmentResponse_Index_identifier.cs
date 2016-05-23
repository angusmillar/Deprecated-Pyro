using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_EnrollmentResponse_Index_identifier : TokenIndex
  {
    public int Res_EnrollmentResponse_Index_identifierID {get; set;}
    public virtual Res_EnrollmentResponse Res_EnrollmentResponse { get; set; }
   
    public Res_EnrollmentResponse_Index_identifier()
    {
    }
  }
}

