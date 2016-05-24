﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Specimen : ResourceIndexBase
  {
    public int Res_SpecimenID {get; set;}
    public string accession_Code {get; set;}
    public string accession_System {get; set;}
    public DateTimeOffset? collected_DateTimeOffset {get; set;}
    public string collector_FhirId {get; set;}
    public string collector_Type {get; set;}
    public virtual Blaze_RootUrlStore collector_Url { get; set; }
    public int? collector_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual Blaze_RootUrlStore subject_Url { get; set; }
    public int? subject_Url_Blaze_RootUrlStoreID { get; set; }
    public ICollection<Res_Specimen_History> Res_Specimen_History_List { get; set; }
    public ICollection<Res_Specimen_Index_bodysite> bodysite_List { get; set; }
    public ICollection<Res_Specimen_Index_container> container_List { get; set; }
    public ICollection<Res_Specimen_Index_container_id> container_id_List { get; set; }
    public ICollection<Res_Specimen_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Specimen_Index_parent> parent_List { get; set; }
    public ICollection<Res_Specimen_Index_type> type_List { get; set; }
    public ICollection<Res_Specimen_Index_profile> profile_List { get; set; }
    public ICollection<Res_Specimen_Index_security> security_List { get; set; }
    public ICollection<Res_Specimen_Index_tag> tag_List { get; set; }
   
    public Res_Specimen()
    {
      this.bodysite_List = new HashSet<Res_Specimen_Index_bodysite>();
      this.container_List = new HashSet<Res_Specimen_Index_container>();
      this.container_id_List = new HashSet<Res_Specimen_Index_container_id>();
      this.identifier_List = new HashSet<Res_Specimen_Index_identifier>();
      this.parent_List = new HashSet<Res_Specimen_Index_parent>();
      this.type_List = new HashSet<Res_Specimen_Index_type>();
      this.profile_List = new HashSet<Res_Specimen_Index_profile>();
      this.security_List = new HashSet<Res_Specimen_Index_security>();
      this.tag_List = new HashSet<Res_Specimen_Index_tag>();
      this.Res_Specimen_History_List = new HashSet<Res_Specimen_History>();
    }
  }
}

