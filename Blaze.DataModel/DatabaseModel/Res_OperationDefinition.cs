using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_OperationDefinition
  {
    public int Res_OperationDefinitionID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string base_FhirId {get; set;}
    public string base_Type {get; set;}
    public virtual Blaze_RootUrlStore base_Url { get; set; }
    public int? base_Url_Blaze_RootUrlStoreID { get; set; }
    public string code_Code {get; set;}
    public string code_System {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string instance_Code {get; set;}
    public string instance_System {get; set;}
    public string kind_Code {get; set;}
    public string kind_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string system_Code {get; set;}
    public string system_System {get; set;}
    public string url_Uri {get; set;}
    public string version_Code {get; set;}
    public string version_System {get; set;}
    public ICollection<Res_OperationDefinition_Index_profile> profile_List { get; set; }
    public ICollection<Res_OperationDefinition_Index_type> type_List { get; set; }
   
    public Res_OperationDefinition()
    {
      this.profile_List = new HashSet<Res_OperationDefinition_Index_profile>();
      this.type_List = new HashSet<Res_OperationDefinition_Index_type>();
    }
  }
}

