using System;

namespace Pyro.ADHA.Api
{
  public interface IIhiRequestData
  {
    /// <summary>
    /// The User Id of the personal making the call for the client, can be any 
    /// user of the system
    /// </summary>
    string UserId { get; set; }

    /// <summary>
    /// The user id qualifier, can be any qualifier e.g (http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0)
    /// </summary>
    string UserIdQualifier { get; set; }
    /// <summary>
    /// If true the entire Soap requst and response will be returned for each call
    /// </summary>
    bool ReturnSoapRequestAndResponseData { get; set; }

    /// <summary>
    /// The Patient's Family name, must be supplied
    /// </summary>
    string Family { get; set; }
    
    /// <summary>
    /// The Patient's Given name, is optional
    /// </summary>
    string Given { get; set; }

    /// <summary>
    /// The Patient's sex as a char (M,F,I or N), must be supplied
    /// </summary>
    char SexChar { get; set; }

    /// <summary>
    /// The Patient's Date of Birth, must be supplied
    /// </summary>
    DateTime? Dob { get; set; }

    /// <summary>
    /// The Patient's Austrlian 10-digit Medicare Number, conditionaly supplied, 
    /// must have one identifier (MedicareNumber, DVANumber or IHINumber)
    /// </summary>
    string MedicareNumber { get; set; }
    string MedicareIRN { get; set; }

    /// <summary>
    /// The Patient's Austrlian DVA Number (min 2 char, max 9 char), conditionaly 
    /// supplied, must have one identifier (MedicareNumber, DVANumber or IHINumber)
    /// </summary>
    string DVANumber { get; set; }

    /// <summary>
    /// The Patient's Austrlian 16-digit beginning with '800360nnnnnnnnnn' Individual 
    /// Healthcare Identifier (IHI) Number, conditionaly supplied, must have one 
    /// identifier (MedicareNumber, DVANumber or IHINumber)
    /// </summary>
    string IHINumber { get; set; }
  }
}