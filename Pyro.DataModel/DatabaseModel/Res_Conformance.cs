using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyro.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Pyro.DataModel.DatabaseModel
{

  public class Res_Conformance : ResourceIndexBase
  {
    public int Res_ConformanceID {get; set;}
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public string description_String {get; set;}
    public string fhirversion_Code {get; set;}
    public string fhirversion_System {get; set;}
    public string name_String {get; set;}
    public string publisher_String {get; set;}
    public string software_String {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string url_Uri {get; set;}
    public string version_Code {get; set;}
    public string version_System {get; set;}
    public ICollection<Res_Conformance_History> Res_Conformance_History_List { get; set; }
    public ICollection<Res_Conformance_Index_context> context_List { get; set; }
    public ICollection<Res_Conformance_Index_event> event_List { get; set; }
    public ICollection<Res_Conformance_Index_format> format_List { get; set; }
    public ICollection<Res_Conformance_Index_mode> mode_List { get; set; }
    public ICollection<Res_Conformance_Index_resource> resource_List { get; set; }
    public ICollection<Res_Conformance_Index_resourceprofile> resourceprofile_List { get; set; }
    public ICollection<Res_Conformance_Index_securityservice> securityservice_List { get; set; }
    public ICollection<Res_Conformance_Index_supported_profile> supported_profile_List { get; set; }
    public ICollection<Res_Conformance_Index__profile> _profile_List { get; set; }
    public ICollection<Res_Conformance_Index__security> _security_List { get; set; }
    public ICollection<Res_Conformance_Index__tag> _tag_List { get; set; }
   
    public Res_Conformance()
    {
      this.context_List = new HashSet<Res_Conformance_Index_context>();
      this.event_List = new HashSet<Res_Conformance_Index_event>();
      this.format_List = new HashSet<Res_Conformance_Index_format>();
      this.mode_List = new HashSet<Res_Conformance_Index_mode>();
      this.resource_List = new HashSet<Res_Conformance_Index_resource>();
      this.resourceprofile_List = new HashSet<Res_Conformance_Index_resourceprofile>();
      this.securityservice_List = new HashSet<Res_Conformance_Index_securityservice>();
      this.supported_profile_List = new HashSet<Res_Conformance_Index_supported_profile>();
      this._profile_List = new HashSet<Res_Conformance_Index__profile>();
      this._security_List = new HashSet<Res_Conformance_Index__security>();
      this._tag_List = new HashSet<Res_Conformance_Index__tag>();
      this.Res_Conformance_History_List = new HashSet<Res_Conformance_History>();
    }
  }
}

