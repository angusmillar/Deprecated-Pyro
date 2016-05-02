using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_OrderSet
  {
    public int Res_OrderSetID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string description_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string title_String {get; set;}
    public string version_String {get; set;}
    public ICollection<Res_OrderSet_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_OrderSet_Index_topic> topic_List { get; set; }
   
    public Res_OrderSet()
    {
      this.identifier_List = new HashSet<Res_OrderSet_Index_identifier>();
      this.topic_List = new HashSet<Res_OrderSet_Index_topic>();
    }
  }
}

