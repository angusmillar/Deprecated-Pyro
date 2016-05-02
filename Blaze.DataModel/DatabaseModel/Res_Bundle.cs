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
    public string composition_FhirId {get; set;}
    public string composition_Type {get; set;}
    public virtual Blaze_RootUrlStore composition_Url { get; set; }
    public int? composition_Url_Blaze_RootUrlStoreID { get; set; }
    public string message_FhirId {get; set;}
    public string message_Type {get; set;}
    public virtual Blaze_RootUrlStore message_Url { get; set; }
    public int? message_Url_Blaze_RootUrlStoreID { get; set; }
    public string type_Code {get; set;}
    public string type_System {get; set;}
   
    public Res_Bundle()
    {
    }
  }
}

