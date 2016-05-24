using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_OperationOutcome : ResourceIndexBase
  {
    public int Res_OperationOutcomeID {get; set;}
    public ICollection<Res_OperationOutcome_History> Res_OperationOutcome_History_List { get; set; }
    public ICollection<Res_OperationOutcome_Index_profile> profile_List { get; set; }
    public ICollection<Res_OperationOutcome_Index_security> security_List { get; set; }
    public ICollection<Res_OperationOutcome_Index_tag> tag_List { get; set; }
   
    public Res_OperationOutcome()
    {
      this.profile_List = new HashSet<Res_OperationOutcome_Index_profile>();
      this.security_List = new HashSet<Res_OperationOutcome_Index_security>();
      this.tag_List = new HashSet<Res_OperationOutcome_Index_tag>();
      this.Res_OperationOutcome_History_List = new HashSet<Res_OperationOutcome_History>();
    }
  }
}

