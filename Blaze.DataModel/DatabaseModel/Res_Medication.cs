using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Medication : ResourceIndexBase
  {
    public int Res_MedicationID {get; set;}
    public string manufacturer_VersionId {get; set;}
    public string manufacturer_FhirId {get; set;}
    public string manufacturer_Type {get; set;}
    public virtual Blaze_RootUrlStore manufacturer_Url { get; set; }
    public int? manufacturer_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Medication_History> Res_Medication_History_List { get; set; }
    public ICollection<Res_Medication_Index_code> code_List { get; set; }
    public ICollection<Res_Medication_Index_container> container_List { get; set; }
    public ICollection<Res_Medication_Index_form> form_List { get; set; }
    public ICollection<Res_Medication_Index_ingredient> ingredient_List { get; set; }
    public ICollection<Res_Medication_Index_ingredient_code> ingredient_code_List { get; set; }
    public ICollection<Res_Medication_Index_package_item> package_item_List { get; set; }
    public ICollection<Res_Medication_Index_package_item_code> package_item_code_List { get; set; }
    public ICollection<Res_Medication_Index_profile> profile_List { get; set; }
    public ICollection<Res_Medication_Index_security> security_List { get; set; }
    public ICollection<Res_Medication_Index_tag> tag_List { get; set; }
   
    public Res_Medication()
    {
      this.code_List = new HashSet<Res_Medication_Index_code>();
      this.container_List = new HashSet<Res_Medication_Index_container>();
      this.form_List = new HashSet<Res_Medication_Index_form>();
      this.ingredient_List = new HashSet<Res_Medication_Index_ingredient>();
      this.ingredient_code_List = new HashSet<Res_Medication_Index_ingredient_code>();
      this.package_item_List = new HashSet<Res_Medication_Index_package_item>();
      this.package_item_code_List = new HashSet<Res_Medication_Index_package_item_code>();
      this.profile_List = new HashSet<Res_Medication_Index_profile>();
      this.security_List = new HashSet<Res_Medication_Index_security>();
      this.tag_List = new HashSet<Res_Medication_Index_tag>();
      this.Res_Medication_History_List = new HashSet<Res_Medication_History>();
    }
  }
}

