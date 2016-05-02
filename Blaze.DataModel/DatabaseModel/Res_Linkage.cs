using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Linkage
  {
    public int Res_LinkageID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public string author_FhirId {get; set;}
    public string author_Type {get; set;}
    public virtual Blaze_RootUrlStore author_Url { get; set; }
    public int? author_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Linkage_Index_item> item_List { get; set; }
    public ICollection<Res_Linkage_Index_source> source_List { get; set; }
   
    public Res_Linkage()
    {
      this.item_List = new HashSet<Res_Linkage_Index_item>();
      this.source_List = new HashSet<Res_Linkage_Index_source>();
    }
  }
}

