using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_ImagingObjectSelection
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string author_FhirId {get; set;}     
    public string author_Type {get; set;}     
    public string author_Url {get; set;}     
    public DateTimeOffset? authoring_time_DateTimeOffset {get; set;}              
    public string identifier_Uri {get; set;}     
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     

    public ICollection<Res_ImagingObjectSelection_Index_selected_study> selected_study_List { get; set; }   
    public ICollection<Res_ImagingObjectSelection_Index_title> title_List { get; set; }   

    public Res_ImagingObjectSelection()
    {
      this.selected_study_List = new HashSet<Res_ImagingObjectSelection_Index_selected_study>();
      this.title_List = new HashSet<Res_ImagingObjectSelection_Index_title>();
    }
  }
}