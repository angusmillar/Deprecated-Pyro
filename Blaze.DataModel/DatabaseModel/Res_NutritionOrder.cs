using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_NutritionOrder
  {
    public int Res_NutritionOrderID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? datetime_DateTimeOffset {get; set;}
    public string encounter_FhirId {get; set;}
    public string encounter_Type {get; set;}
    public virtual Aux_RootUrlStore encounter_Aux_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Aux_RootUrlStore patient_Aux_RootUrlStoreID { get; set; }
    public string provider_FhirId {get; set;}
    public string provider_Type {get; set;}
    public virtual Aux_RootUrlStore provider_Aux_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_NutritionOrder_Index_additive> additive_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_formula> formula_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_oraldiet> oraldiet_List { get; set; }
    public ICollection<Res_NutritionOrder_Index_supplement> supplement_List { get; set; }
   
    public Res_NutritionOrder()
    {
      this.additive_List = new HashSet<Res_NutritionOrder_Index_additive>();
      this.formula_List = new HashSet<Res_NutritionOrder_Index_formula>();
      this.identifier_List = new HashSet<Res_NutritionOrder_Index_identifier>();
      this.oraldiet_List = new HashSet<Res_NutritionOrder_Index_oraldiet>();
      this.supplement_List = new HashSet<Res_NutritionOrder_Index_supplement>();
    }
  }
}

