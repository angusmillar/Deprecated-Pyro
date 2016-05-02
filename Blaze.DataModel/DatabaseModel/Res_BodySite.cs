using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_BodySite
  {
    public int Res_BodySiteID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_BodySite_Index_code> code_List { get; set; }
    public ICollection<Res_BodySite_Index_identifier> identifier_List { get; set; }
   
    public Res_BodySite()
    {
      this.code_List = new HashSet<Res_BodySite_Index_code>();
      this.identifier_List = new HashSet<Res_BodySite_Index_identifier>();
    }
  }
}

