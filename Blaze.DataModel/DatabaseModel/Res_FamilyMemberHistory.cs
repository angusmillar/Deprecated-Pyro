using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_FamilyMemberHistory
  {
    public int Res_FamilyMemberHistoryID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string gender_Code {get; set;}
    public string gender_System {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_FamilyMemberHistory_Index_code> code_List { get; set; }
    public ICollection<Res_FamilyMemberHistory_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_FamilyMemberHistory_Index_relationship> relationship_List { get; set; }
   
    public Res_FamilyMemberHistory()
    {
      this.code_List = new HashSet<Res_FamilyMemberHistory_Index_code>();
      this.identifier_List = new HashSet<Res_FamilyMemberHistory_Index_identifier>();
      this.relationship_List = new HashSet<Res_FamilyMemberHistory_Index_relationship>();
    }
  }
}

