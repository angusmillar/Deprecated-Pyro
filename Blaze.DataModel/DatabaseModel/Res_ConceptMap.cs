using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ConceptMap
  {
    public int Res_ConceptMapID {get; set;}
    public string FhirId {get; set;}
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string description_String {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string source_FhirId {get; set;}
    public string source_Type {get; set;}
    public virtual Aux_RootUrlStore source_Aux_RootUrlStoreID { get; set; }
    public string sourceuri_FhirId {get; set;}
    public string sourceuri_Type {get; set;}
    public virtual Aux_RootUrlStore sourceuri_Aux_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string target_FhirId {get; set;}
    public string target_Type {get; set;}
    public virtual Aux_RootUrlStore target_Aux_RootUrlStoreID { get; set; }
    public string url_Uri {get; set;}
    public string version_Code {get; set;}
    public string version_System {get; set;}
    public ICollection<Res_ConceptMap_Index_context> context_List { get; set; }
    public ICollection<Res_ConceptMap_Index_dependson> dependson_List { get; set; }
    public ICollection<Res_ConceptMap_Index_product> product_List { get; set; }
    public ICollection<Res_ConceptMap_Index_sourcecode> sourcecode_List { get; set; }
    public ICollection<Res_ConceptMap_Index_sourcesystem> sourcesystem_List { get; set; }
    public ICollection<Res_ConceptMap_Index_targetcode> targetcode_List { get; set; }
    public ICollection<Res_ConceptMap_Index_targetsystem> targetsystem_List { get; set; }
   
    public Res_ConceptMap()
    {
      this.context_List = new HashSet<Res_ConceptMap_Index_context>();
      this.dependson_List = new HashSet<Res_ConceptMap_Index_dependson>();
      this.product_List = new HashSet<Res_ConceptMap_Index_product>();
      this.sourcecode_List = new HashSet<Res_ConceptMap_Index_sourcecode>();
      this.sourcesystem_List = new HashSet<Res_ConceptMap_Index_sourcesystem>();
      this.targetcode_List = new HashSet<Res_ConceptMap_Index_targetcode>();
      this.targetsystem_List = new HashSet<Res_ConceptMap_Index_targetsystem>();
    }
  }
}

