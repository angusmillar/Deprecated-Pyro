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
    public ICollection<Res_OperationOutcome_Index_meta_profile> meta_profile_List { get; set; }
    public ICollection<Res_OperationOutcome_Index_meta_security> meta_security_List { get; set; }
    public ICollection<Res_OperationOutcome_Index_meta_tag> meta_tag_List { get; set; }
    public ICollection<Res_OperationOutcome_History> Res_OperationOutcome_History_List { get; set; }
   
    public Res_OperationOutcome()
    {
      this.meta_tag_List = new HashSet<Res_OperationOutcome_Index_meta_tag>();
      this.meta_security_List = new HashSet<Res_OperationOutcome_Index_meta_security>();
      this.meta_profile_List = new HashSet<Res_OperationOutcome_Index_meta_profile>();
      this.Res_OperationOutcome_History_List = new HashSet<Res_OperationOutcome_History>();
    }
  }
}

