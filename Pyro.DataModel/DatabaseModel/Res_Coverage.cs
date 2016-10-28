using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Coverage : ResourceIndexBase
  {
    public int Res_CoverageID {get; set;}
    public string beneficiary_identifier_Code {get; set;}
    public string beneficiary_identifier_System {get; set;}
    public string beneficiary_reference_VersionId {get; set;}
    public string beneficiary_reference_FhirId {get; set;}
    public string beneficiary_reference_Type {get; set;}
    public virtual ServiceRootURL_Store beneficiary_reference_Url { get; set; }
    public int? beneficiary_reference_ServiceRootURL_StoreID { get; set; }
    public Hl7.Fhir.Model.Quantity.QuantityComparator? dependent_Comparator {get; set;}
    public decimal? dependent_Quantity {get; set;}
    public string group_Code {get; set;}
    public string group_System {get; set;}
    public string issuer_identifier_Code {get; set;}
    public string issuer_identifier_System {get; set;}
    public string issuer_reference_VersionId {get; set;}
    public string issuer_reference_FhirId {get; set;}
    public string issuer_reference_Type {get; set;}
    public virtual ServiceRootURL_Store issuer_reference_Url { get; set; }
    public int? issuer_reference_ServiceRootURL_StoreID { get; set; }
    public string plan_Code {get; set;}
    public string plan_System {get; set;}
    public string planholder_identifier_Code {get; set;}
    public string planholder_identifier_System {get; set;}
    public string planholder_reference_VersionId {get; set;}
    public string planholder_reference_FhirId {get; set;}
    public string planholder_reference_Type {get; set;}
    public virtual ServiceRootURL_Store planholder_reference_Url { get; set; }
    public int? planholder_reference_ServiceRootURL_StoreID { get; set; }
    public Hl7.Fhir.Model.Quantity.QuantityComparator? sequence_Comparator {get; set;}
    public decimal? sequence_Quantity {get; set;}
    public string subgroup_Code {get; set;}
    public string subgroup_System {get; set;}
    public string subplan_Code {get; set;}
    public string subplan_System {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Coverage_History> Res_Coverage_History_List { get; set; }
    public ICollection<Res_Coverage_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Coverage_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Coverage_Index__security> _security_List { get; set; }
    public ICollection<Res_Coverage_Index__tag> _tag_List { get; set; }
   
    public Res_Coverage()
    {
      this.identifier_List = new HashSet<Res_Coverage_Index_identifier>();
      this._profile_List = new HashSet<Res_Coverage_Index__profile>();
      this._security_List = new HashSet<Res_Coverage_Index__security>();
      this._tag_List = new HashSet<Res_Coverage_Index__tag>();
      this.Res_Coverage_History_List = new HashSet<Res_Coverage_History>();
    }
  }
}

