using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_ProcessResponse
  {
    public int Res_ProcessResponseID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string organization_FhirId {get; set;}
    public string organization_Type {get; set;}
    public virtual Blaze_RootUrlStore organization_Url { get; set; }
    public int? organization_Url_Blaze_RootUrlStoreID { get; set; }
    public string request_FhirId {get; set;}
    public string request_Type {get; set;}
    public virtual Blaze_RootUrlStore request_Url { get; set; }
    public int? request_Url_Blaze_RootUrlStoreID { get; set; }
    public string requestorganization_FhirId {get; set;}
    public string requestorganization_Type {get; set;}
    public virtual Blaze_RootUrlStore requestorganization_Url { get; set; }
    public int? requestorganization_Url_Blaze_RootUrlStoreID { get; set; }
    public string requestprovider_FhirId {get; set;}
    public string requestprovider_Type {get; set;}
    public virtual Blaze_RootUrlStore requestprovider_Url { get; set; }
    public int? requestprovider_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_ProcessResponse_Index_identifier> identifier_List { get; set; }
   
    public Res_ProcessResponse()
    {
      this.identifier_List = new HashSet<Res_ProcessResponse_Index_identifier>();
    }
  }
}

