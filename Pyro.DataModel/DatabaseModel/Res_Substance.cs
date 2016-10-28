using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Substance : ResourceIndexBase
  {
    public int Res_SubstanceID {get; set;}
    public ICollection<Res_Substance_History> Res_Substance_History_List { get; set; }
    public ICollection<Res_Substance_Index_category> category_List { get; set; }
    public ICollection<Res_Substance_Index_code> code_List { get; set; }
    public ICollection<Res_Substance_Index_container_identifier> container_identifier_List { get; set; }
    public ICollection<Res_Substance_Index_expiry> expiry_List { get; set; }
    public ICollection<Res_Substance_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Substance_Index_quantity> quantity_List { get; set; }
    public ICollection<Res_Substance_Index_substance_reference> substance_reference_List { get; set; }
    public ICollection<Res_Substance_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Substance_Index__security> _security_List { get; set; }
    public ICollection<Res_Substance_Index__tag> _tag_List { get; set; }
   
    public Res_Substance()
    {
      this.category_List = new HashSet<Res_Substance_Index_category>();
      this.code_List = new HashSet<Res_Substance_Index_code>();
      this.container_identifier_List = new HashSet<Res_Substance_Index_container_identifier>();
      this.expiry_List = new HashSet<Res_Substance_Index_expiry>();
      this.identifier_List = new HashSet<Res_Substance_Index_identifier>();
      this.quantity_List = new HashSet<Res_Substance_Index_quantity>();
      this.substance_reference_List = new HashSet<Res_Substance_Index_substance_reference>();
      this._profile_List = new HashSet<Res_Substance_Index__profile>();
      this._security_List = new HashSet<Res_Substance_Index__security>();
      this._tag_List = new HashSet<Res_Substance_Index__tag>();
      this.Res_Substance_History_List = new HashSet<Res_Substance_History>();
    }
  }
}

