using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Sequence : ResourceIndexBase
  {
    public int Res_SequenceID {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Sequence_History> Res_Sequence_History_List { get; set; }
    public ICollection<Res_Sequence_Index_chromosome> chromosome_List { get; set; }
    public ICollection<Res_Sequence_Index_end> end_List { get; set; }
    public ICollection<Res_Sequence_Index_start> start_List { get; set; }
    public ICollection<Res_Sequence_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Sequence_Index__security> _security_List { get; set; }
    public ICollection<Res_Sequence_Index__tag> _tag_List { get; set; }
   
    public Res_Sequence()
    {
      this.chromosome_List = new HashSet<Res_Sequence_Index_chromosome>();
      this.end_List = new HashSet<Res_Sequence_Index_end>();
      this.start_List = new HashSet<Res_Sequence_Index_start>();
      this._profile_List = new HashSet<Res_Sequence_Index__profile>();
      this._security_List = new HashSet<Res_Sequence_Index__security>();
      this._tag_List = new HashSet<Res_Sequence_Index__tag>();
      this.Res_Sequence_History_List = new HashSet<Res_Sequence_History>();
    }
  }
}

