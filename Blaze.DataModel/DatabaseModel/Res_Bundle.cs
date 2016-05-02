using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Bundle
  {
    public int Res_BundleID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Bundle_Index_composition> composition_List { get; set; }
    public ICollection<Res_Bundle_Index_message> message_List { get; set; }
   
    public Res_Bundle()
    {
      this.composition_List = new HashSet<Res_Bundle_Index_composition>();
      this.message_List = new HashSet<Res_Bundle_Index_message>();
    }
  }
}

