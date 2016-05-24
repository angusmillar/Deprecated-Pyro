using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_NutritionOrder : ResourceIndexBase
  {
    public int Res_NutritionOrderID {get; set;}
    public DateTimeOffset? datetime_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Blaze_RootUrlStore encounter_Url { get; set; }
    public int? encounter_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string provider_FhirId {get; set;}
    public string provider_Type {get; set;}
    public virtual Blaze_RootUrlStore provider_Url { get; set; }
    public int? provider_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_NutritionOrder_History> Res_NutritionOrder_History_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_additive> additive_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_formula> formula_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_oraldiet> oraldiet_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_supplement> supplement_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_profile> profile_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_security> security_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_tag> tag_List { get; set; }
   
    public Res_NutritionOrder()
    {
      this.additive_List = new HashSet<Res_NutritionOrder_Index_additive>();
      this.formula_List = new HashSet<Res_NutritionOrder_Index_formula>();
      this.identifier_List = new HashSet<Res_NutritionOrder_Index_identifier>();
      this.oraldiet_List = new HashSet<Res_NutritionOrder_Index_oraldiet>();
      this.supplement_List = new HashSet<Res_NutritionOrder_Index_supplement>();
      this.profile_List = new HashSet<Res_NutritionOrder_Index_profile>();
      this.security_List = new HashSet<Res_NutritionOrder_Index_security>();
      this.tag_List = new HashSet<Res_NutritionOrder_Index_tag>();
      this.Res_NutritionOrder_History_List = new HashSet<Res_NutritionOrder_History>();
    }
  }
}

