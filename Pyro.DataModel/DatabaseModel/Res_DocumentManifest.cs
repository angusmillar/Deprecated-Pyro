﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blaze.DataModel.DatabaseModel.Base;

//This source file has been auto generated.

namespace Blaze.DataModel.DatabaseModel
{

  public class Res_DocumentManifest : ResourceIndexBase
  {
    public int Res_DocumentManifestID {get; set;}
    public DateTimeOffset? created_DateTimeOffset {get; set;}
    public string description_String {get; set;}
    public string identifier_Code {get; set;}
    public string identifier_System {get; set;}
    public string patient_VersionId {get; set;}
    public string patient_FhirId {get; set;}
    public string patient_Type {get; set;}
    public virtual ServiceRootURL_Store patient_Url { get; set; }
    public int? patient_ServiceRootURL_StoreID { get; set; }
    public string source_Uri {get; set;}
    public string status_Code {get; set;}
    public string status_System {get; set;}
    public string subject_VersionId {get; set;}
    public string subject_FhirId {get; set;}
    public string subject_Type {get; set;}
    public virtual ServiceRootURL_Store subject_Url { get; set; }
    public int? subject_ServiceRootURL_StoreID { get; set; }
    public ICollection<Res_DocumentManifest_History> Res_DocumentManifest_History_List { get; set; }
    public ICollection<Res_DocumentManifest_Index_author> author_List { get; set; }
    public ICollection<Res_DocumentManifest_Index_content_ref> content_ref_List { get; set; }
    public ICollection<Res_DocumentManifest_Index_identifier> identifier_List { get; set; }
    public ICollection<Res_DocumentManifest_Index_recipient> recipient_List { get; set; }
    public ICollection<Res_DocumentManifest_Index_related_id> related_id_List { get; set; }
    public ICollection<Res_DocumentManifest_Index_related_ref> related_ref_List { get; set; }
    public ICollection<Res_DocumentManifest_Index_type> type_List { get; set; }
    public ICollection<Res_DocumentManifest_Index__profile> _profile_List { get; set; }
    public ICollection<Res_DocumentManifest_Index__security> _security_List { get; set; }
    public ICollection<Res_DocumentManifest_Index__tag> _tag_List { get; set; }
   
    public Res_DocumentManifest()
    {
      this.author_List = new HashSet<Res_DocumentManifest_Index_author>();
      this.content_ref_List = new HashSet<Res_DocumentManifest_Index_content_ref>();
      this.identifier_List = new HashSet<Res_DocumentManifest_Index_identifier>();
      this.recipient_List = new HashSet<Res_DocumentManifest_Index_recipient>();
      this.related_id_List = new HashSet<Res_DocumentManifest_Index_related_id>();
      this.related_ref_List = new HashSet<Res_DocumentManifest_Index_related_ref>();
      this.type_List = new HashSet<Res_DocumentManifest_Index_type>();
      this._profile_List = new HashSet<Res_DocumentManifest_Index__profile>();
      this._security_List = new HashSet<Res_DocumentManifest_Index__security>();
      this._tag_List = new HashSet<Res_DocumentManifest_Index__tag>();
      this.Res_DocumentManifest_History_List = new HashSet<Res_DocumentManifest_History>();
    }
  }
}
