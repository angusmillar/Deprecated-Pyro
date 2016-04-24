using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Goal
  {
    public int Res_GoalID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Aux_RootUrlStore subject_Aux_RootUrlStoreID { get; set; }
    public DateTimeOffset? targetdate_DateTimeOffset {get; set;}
    public ICollection<Res_Goal_Index_category> category_List { get; set; }
    public ICollection<Res_Goal_Index_identifier> identifier_List { get; set; }
   
    public Res_Goal()
    {
      this.category_List = new HashSet<Res_Goal_Index_category>();
      this.identifier_List = new HashSet<Res_Goal_Index_identifier>();
    }
  }
}

