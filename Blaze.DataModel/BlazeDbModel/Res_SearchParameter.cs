using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.BlazeDbModel
{

  public class Res_SearchParameter
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string base_Code {get; set;}                  
    public string base_System {get; set;}                
    public string code_Code {get; set;}                  
    public string code_System {get; set;}                
    public string description_String {get; set;}                  
    public string name_String {get; set;}                  
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                
    public string url_Uri {get; set;}     

    public ICollection<Res_SearchParameter_Index_target> target_List { get; set; }   

    public Res_SearchParameter()
    {
      this.target_List = new HashSet<Res_SearchParameter_Index_target>();
    }
  }
}