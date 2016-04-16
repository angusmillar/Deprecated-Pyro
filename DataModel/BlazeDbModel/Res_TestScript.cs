using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_TestScript
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string description_String {get; set;}                  
    public string identifier_Code {get; set;}                  
    public string identifier_System {get; set;}                
    public string name_String {get; set;}                  
    public string url_Uri {get; set;}     

    public ICollection<Res_TestScript_Index_testscript_capability> testscript_capability_List { get; set; }   
    public ICollection<Res_TestScript_Index_testscript_setup_capability> testscript_setup_capability_List { get; set; }   
    public ICollection<Res_TestScript_Index_testscript_test_capability> testscript_test_capability_List { get; set; }   

    public Res_TestScript()
    {
      this.testscript_capability_List = new HashSet<Res_TestScript_Index_testscript_capability>();
      this.testscript_setup_capability_List = new HashSet<Res_TestScript_Index_testscript_setup_capability>();
      this.testscript_test_capability_List = new HashSet<Res_TestScript_Index_testscript_test_capability>();
    }
  }
}