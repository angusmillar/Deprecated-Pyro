using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DetectedIssue
  {
    public int Res_DetectedIssueID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual Blaze_RootUrlStore author_Url { get; set; }
    public int? author_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_DetectedIssue_Index_category> category_List { get; set; }
    public ICollection<Res_DetectedIssue_Index_implicated> implicated_List { get; set; }
   
    public Res_DetectedIssue()
    {
      this.category_List = new HashSet<Res_DetectedIssue_Index_category>();
      this.implicated_List = new HashSet<Res_DetectedIssue_Index_implicated>();
    }
  }
}

