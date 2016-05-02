using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Sequence
  {
    public int Res_SequenceID {get; set;}
    public string FhirId {get; set;}
    public int versionId {get; set;}
    public DateTimeOffset lastUpdated {get; set;}
    public string XmlBlob {get; set;}
    public decimal? end_Number {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public decimal? start_Number {get; set;}
    public string type_Code {get; set;}
    public string type_System {get; set;}
    public ICollection<Res_Sequence_Index_chromosome> chromosome_List { get; set; }
    public ICollection<Res_Sequence_Index_species> species_List { get; set; }
   
    public Res_Sequence()
    {
      this.chromosome_List = new HashSet<Res_Sequence_Index_chromosome>();
      this.species_List = new HashSet<Res_Sequence_Index_species>();
    }
  }
}

