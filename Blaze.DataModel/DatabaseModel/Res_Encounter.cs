﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_Encounter : ResourceIndexBase
  {
    public int Res_EncounterID {get; set;}
    public string appointment_FhirId {get; set;}
    public string appointment_Type {get; set;}
    public virtual Blaze_RootUrlStore appointment_Url { get; set; }
    public int? appointment_Url_Blaze_RootUrlStoreID { get; set; }
    public DateTimeOffset? date_DateTimeOffset {get; set;}
    public decimal? length_Number {get; set;}
    public string part_of_FhirId {get; set;}
    public string part_of_Type {get; set;}
    public virtual Blaze_RootUrlStore part_of_Url { get; set; }
    public int? part_of_Url_Blaze_RootUrlStoreID { get; set; }
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual Blaze_RootUrlStore patient_Url { get; set; }
    public int? patient_Url_Blaze_RootUrlStoreID { get; set; }
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public ICollection<Res_Encounter_History> Res_Encounter_History_List { get; set; }
    public ICollection<Res_Encounter_Index_condition> condition_List { get; set; }
    public ICollection<Res_Encounter_Index_episodeofcare> episodeofcare_List { get; set; }
    public ICollection<Res_Encounter_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_Encounter_Index_incomingreferral> incomingreferral_List { get; set; }
    public ICollection<Res_Encounter_Index_indication> indication_List { get; set; }
    public ICollection<Res_Encounter_Index_location> location_List { get; set; }
    public ICollection<Res_Encounter_Index_location_period> location_period_List { get; set; }
    public ICollection<Res_Encounter_Index_participant> participant_List { get; set; }
    public ICollection<Res_Encounter_Index_participant_type> participant_type_List { get; set; }
    public ICollection<Res_Encounter_Index_practitioner> practitioner_List { get; set; }
    public ICollection<Res_Encounter_Index_procedure> procedure_List { get; set; }
    public ICollection<Res_Encounter_Index_reason> reason_List { get; set; }
    public ICollection<Res_Encounter_Index_special_arrangement> special_arrangement_List { get; set; }
    public ICollection<Res_Encounter_Index_type> type_List { get; set; }
    public ICollection<Res_Encounter_Index_profile> profile_List { get; set; }
    public ICollection<Res_Encounter_Index_security> security_List { get; set; }
    public ICollection<Res_Encounter_Index_tag> tag_List { get; set; }
   
    public Res_Encounter()
    {
      this.condition_List = new HashSet<Res_Encounter_Index_condition>();
      this.episodeofcare_List = new HashSet<Res_Encounter_Index_episodeofcare>();
      this.identifier_List = new HashSet<Res_Encounter_Index_identifier>();
      this.incomingreferral_List = new HashSet<Res_Encounter_Index_incomingreferral>();
      this.indication_List = new HashSet<Res_Encounter_Index_indication>();
      this.location_List = new HashSet<Res_Encounter_Index_location>();
      this.location_period_List = new HashSet<Res_Encounter_Index_location_period>();
      this.participant_List = new HashSet<Res_Encounter_Index_participant>();
      this.participant_type_List = new HashSet<Res_Encounter_Index_participant_type>();
      this.practitioner_List = new HashSet<Res_Encounter_Index_practitioner>();
      this.procedure_List = new HashSet<Res_Encounter_Index_procedure>();
      this.reason_List = new HashSet<Res_Encounter_Index_reason>();
      this.special_arrangement_List = new HashSet<Res_Encounter_Index_special_arrangement>();
      this.type_List = new HashSet<Res_Encounter_Index_type>();
      this.profile_List = new HashSet<Res_Encounter_Index_profile>();
      this.security_List = new HashSet<Res_Encounter_Index_security>();
      this.tag_List = new HashSet<Res_Encounter_Index_tag>();
      this.Res_Encounter_History_List = new HashSet<Res_Encounter_History>();
    }
  }
}

