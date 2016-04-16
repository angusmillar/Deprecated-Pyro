using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Medication
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string manufacturer_FhirId {get; set;}     
    public string manufacturer_Type {get; set;}     
    public string manufacturer_Url {get; set;}     

    public ICollection<Res_Medication_Index_code> code_List { get; set; }   
    public ICollection<Res_Medication_Index_container> container_List { get; set; }   
    public ICollection<Res_Medication_Index_content> content_List { get; set; }   
    public ICollection<Res_Medication_Index_form> form_List { get; set; }   
    public ICollection<Res_Medication_Index_ingredient> ingredient_List { get; set; }   

    public Res_Medication()
    {
      this.code_List = new HashSet<Res_Medication_Index_code>();
      this.container_List = new HashSet<Res_Medication_Index_container>();
      this.content_List = new HashSet<Res_Medication_Index_content>();
      this.form_List = new HashSet<Res_Medication_Index_form>();
      this.ingredient_List = new HashSet<Res_Medication_Index_ingredient>();
    }
  }
}