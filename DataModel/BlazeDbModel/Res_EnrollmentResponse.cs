﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This source file has been auto generated.

namespace DataModel.BlazeDbModel
{

  public class Res_EnrollmentResponse
  {
    public int Id {get; set;}
    public string FhirId {get; set;}    
    public int Version {get; set;}
    public DateTimeOffset Received {get; set;}
    public string XmlBlob {get; set;}    

    public ICollection<Res_EnrollmentResponse_Index_identifier> identifier_List { get; set; }   

    public Res_EnrollmentResponse()
    {
      this.identifier_List = new HashSet<Res_EnrollmentResponse_Index_identifier>();
    }
  }
}