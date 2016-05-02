using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Substance
  {
    public int Res_SubstanceID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public ICollection<Res_Substance_Index_category> category_List { get; set; }
    public ICollection<Res_Substance_Index_code> code_List { get; set; }
    public ICollection<Res_Substance_Index_container_identifier> container_identifier_List { get; set; }
    public ICollection<Res_Substance_Index_expiry> expiry_List { get; set; }
    public ICollection<Res_Substance_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Substance_Index_quantity> quantity_List { get; set; }
    public ICollection<Res_Substance_Index_substance> substance_List { get; set; }
   
    public Res_Substance()
    {
      this.category_List = new HashSet<Res_Substance_Index_category>();
      this.code_List = new HashSet<Res_Substance_Index_code>();
      this.container_identifier_List = new HashSet<Res_Substance_Index_container_identifier>();
      this.expiry_List = new HashSet<Res_Substance_Index_expiry>();
      this.identifier_List = new HashSet<Res_Substance_Index_identifier>();
      this.quantity_List = new HashSet<Res_Substance_Index_quantity>();
      this.substance_List = new HashSet<Res_Substance_Index_substance>();
    }
  }
}

