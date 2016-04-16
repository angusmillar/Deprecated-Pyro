﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_Subscription
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    
    public string criteria_String {get; set;}                  
    public string payload_String {get; set;}                  
    public string status_Code {get; set;}                  
    public string status_System {get; set;}                
    public string type_Code {get; set;}                  
    public string type_System {get; set;}                
    public string url_Uri {get; set;}     

    public ICollection<Res_Subscription_Index_contact> contact_List { get; set; }   
    public ICollection<Res_Subscription_Index_tag> tag_List { get; set; }   

    public Res_Subscription()
    {
      this.contact_List = new HashSet<Res_Subscription_Index_contact>();
      this.tag_List = new HashSet<Res_Subscription_Index_tag>();
    }
  }
}