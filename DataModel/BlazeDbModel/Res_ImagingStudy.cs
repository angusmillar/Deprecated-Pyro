using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_ImagingStudy
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string accession_Code {get; set;}                  
    public string accession_System {get; set;}                
    public string patient_FhirId {get; set;}     
    public string patient_Type {get; set;}     
    public string patient_Url {get; set;}     
    public DateTimeOffset? started_DateTimeOffset {get; set;}              
    public string study_Uri {get; set;}     

    public ICollection<Res_ImagingStudy_Index_bodysite> bodysite_List { get; set; }   
    public ICollection<Res_ImagingStudy_Index_dicom_class> dicom_class_List { get; set; }   
    public ICollection<Res_ImagingStudy_Index_modality> modality_List { get; set; }   
    public ICollection<Res_ImagingStudy_Index_order> order_List { get; set; }   
    public ICollection<Res_ImagingStudy_Index_series> series_List { get; set; }   
    public ICollection<Res_ImagingStudy_Index_uid> uid_List { get; set; }   

    public Res_ImagingStudy()
    {
      this.bodysite_List = new HashSet<Res_ImagingStudy_Index_bodysite>();
      this.dicom_class_List = new HashSet<Res_ImagingStudy_Index_dicom_class>();
      this.modality_List = new HashSet<Res_ImagingStudy_Index_modality>();
      this.order_List = new HashSet<Res_ImagingStudy_Index_order>();
      this.series_List = new HashSet<Res_ImagingStudy_Index_series>();
      this.uid_List = new HashSet<Res_ImagingStudy_Index_uid>();
    }
  }
}