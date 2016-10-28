using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Binary : ResourceIndexBase
  {
    public int Res_BinaryID {get; set;}
    public string contenttype_Code {get; set;}
    public string contenttype_System {get; set;}
    public ICollection<Res_Binary_History> Res_Binary_History_List { get; set; }
    public ICollection<Res_Binary_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Binary_Index__security> _security_List { get; set; }
    public ICollection<Res_Binary_Index__tag> _tag_List { get; set; }
   
    public Res_Binary()
    {
      this._profile_List = new HashSet<Res_Binary_Index__profile>();
      this._security_List = new HashSet<Res_Binary_Index__security>();
      this._tag_List = new HashSet<Res_Binary_Index__tag>();
      this.Res_Binary_History_List = new HashSet<Res_Binary_History>();
    }
  }
}

