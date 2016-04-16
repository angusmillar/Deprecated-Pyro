﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Schedule
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string actor_FhirId {get; set;}     
    public string actor_Type {get; set;}     
    public string actor_Url {get; set;}     
    public DateTimeOffset? date_DateTimeOffset {get; set;}              

    public ICollection<Res_Schedule_Index_identifier> identifier_List { get; set; }   
    public ICollection<Res_Schedule_Index_type> type_List { get; set; }   

    public Res_Schedule()
    {
      this.identifier_List = new HashSet<Res_Schedule_Index_identifier>();
      this.type_List = new HashSet<Res_Schedule_Index_type>();
    }
  }
}