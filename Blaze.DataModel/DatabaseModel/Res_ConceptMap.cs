using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ConceptMap : ResourceIndexBase
  {
    public int Res_ConceptMapID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string description_String {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string source_VersionId {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual ServiceRootURL_Store source_Url { get; set; }
    public int? source_ServiceRootURL_StoreID { get; set; }
    public string source_uri_VersionId {get; set;}
    public string source_uri_FhirId {get; set;}
    public string source_uri_Type {get; set;}
    public virtual ServiceRootURL_Store source_uri_Url { get; set; }
    public int? source_uri_ServiceRootURL_StoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string target_VersionId {get; set;}
    public string target_FhirId {get; set;}
    public string target_Type {get; set;}
    public virtual ServiceRootURL_Store target_Url { get; set; }
    public int? target_ServiceRootURL_StoreID { get; set; }
    public string target_uri_VersionId {get; set;}
    public string target_uri_FhirId {get; set;}
    public string target_uri_Type {get; set;}
    public virtual ServiceRootURL_Store target_uri_Url { get; set; }
    public int? target_uri_ServiceRootURL_StoreID { get; set; }
    public string url_Uri {get; set;}
    public string version_Code {get; set;}
    public string version_System {get; set;}
    public ICollection<Res_ConceptMap_History> Res_ConceptMap_History_List { get; set; }
    public ICollection<Res_ConceptMap_Index_context> context_List { get; set; }
    public ICollection<Res_ConceptMap_Index_dependson> dependson_List { get; set; }
    public ICollection<Res_ConceptMap_Index_product> product_List { get; set; }
    public ICollection<Res_ConceptMap_Index_source_code> source_code_List { get; set; }
    public ICollection<Res_ConceptMap_Index_source_system> source_system_List { get; set; }
    public ICollection<Res_ConceptMap_Index_target_code> target_code_List { get; set; }
    public ICollection<Res_ConceptMap_Index_target_system> target_system_List { get; set; }
    public ICollection<Res_ConceptMap_Index__profile> _profile_List { get; set; }
    public ICollection<Res_ConceptMap_Index__security> _security_List { get; set; }
    public ICollection<Res_ConceptMap_Index__tag> _tag_List { get; set; }
   
    public Res_ConceptMap()
    {
      this.context_List = new HashSet<Res_ConceptMap_Index_context>();
      this.dependson_List = new HashSet<Res_ConceptMap_Index_dependson>();
      this.product_List = new HashSet<Res_ConceptMap_Index_product>();
      this.source_code_List = new HashSet<Res_ConceptMap_Index_source_code>();
      this.source_system_List = new HashSet<Res_ConceptMap_Index_source_system>();
      this.target_code_List = new HashSet<Res_ConceptMap_Index_target_code>();
      this.target_system_List = new HashSet<Res_ConceptMap_Index_target_system>();
      this._profile_List = new HashSet<Res_ConceptMap_Index__profile>();
      this._security_List = new HashSet<Res_ConceptMap_Index__security>();
      this._tag_List = new HashSet<Res_ConceptMap_Index__tag>();
      this.Res_ConceptMap_History_List = new HashSet<Res_ConceptMap_History>();
    }
  }
}

