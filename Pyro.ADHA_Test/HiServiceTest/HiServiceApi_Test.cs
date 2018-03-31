using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pyro.ADHA.Api;

/// <summary>
/// Please note that these tests all marked as 'ADHA HiServiceApi' will only run if you have HI Service connectivity
/// which requires a HI Service x509 certificate to be installed 
/// Without this they will fail.
/// </summary>
namespace Nehta.TestHiService
{
  [TestClass]
  [TestCategory("ADHA HiServiceApi")]
  public class HiServiceApi_Test
  {
    private HiServiceApi HiServiceApi;

    /// <summary>
    /// How to Use:
    /// First you must create a IIhiSearchValidateConfig of which there is an implmentation of this interface 
    /// supplyed named IhiSearchValidateConfig. This provides the HiServiceApi with all required configuration 
    /// that does not need to change per call.
    /// 
    /// You then create a HiServiceApi instance, this is the single dependacy you must take in your 
    /// application, you provide it with the IIhiSearchValidateConfig configuration by its constructor.
    /// 
    /// Now you must create a IIhiRequestData which holds the per request data, Patient names, 
    /// identifiers, sex, dob ...etc. There is an implmentation of this interface supplyed named 
    /// IhiRequestData
    /// 
    /// Then you supply the IIhiRequestData instance to the HiServiceApi.SearchOrValidateIhi(IIhiRequestData) 
    /// method call which will perform the web service call to the HI Service.
    /// 
    /// This then returns a IIhiSearchValidateOutcome instance which holds the results of the call, including 
    /// the data you first supplyed unchanged. This returnd IIhiSearchValidateOutcome has a single top level 
    /// boolean property named IhiSearchValidateOutcome.SuccessfulQuery which indicates that the call was 
    /// successful or not. If False there will be an human readable errormessage string found 
    /// here: IhiSearchValidateOutcome.QueryMetadata.ErrorMessge
    /// 
    /// However, if it was successful then you can inspect the following for results:
    ///   - IhiSearchValidateOutcome.ResponseData 
    ///       (All the retuned information from the HI Service, Names, Sex, Dob, including identifers);
    ///   - IhiSearchValidateOutcome.RequestData
    ///       (All the request data you gave to the call unchanged, Names, Sex, Dob, including identifers)
    ///   - IhiSearchValidateOutcome.QueryMetadata 
    ///       (The soap SoapRequestMessageId & SoapResponseMessageId, the ErrorMessge string only if there 
    ///       was an error and IhiSearchValidateOutcome.SuccessfulQuery == False; otherwise ErrorMessge is 
    ///       null, if IIhiRequestData.ReturnSoapRequestAndResponseData was set to True in the 
    ///       request data then the soap request and response XML data will be returned as a string in
    ///       the properties named SoapRequest and SoapResponse.)
    /// 
    /// And that is it...!
    /// Thanks to Philip Wilford and team from Austrlian Digital Health Agency (ADHA) for the core of the code, 
    /// I just put a simpler API wrappper around it.
    /// 
    /// Also be aware that this alone is not a conformant HI Service system as that conformance accreditation also
    /// involves the managment of the identifers against the Patient resources, not just the web service call which this
    /// performs.
    /// </summary>

    [TestInitialize]
    public void Setup()
    {
      //Setup the Configuration object for the Service
      IhiSearchValidateConfig IhiSearchValidateConfig = new IhiSearchValidateConfig();
      //Production Enviroment
      //IhiSearchValidateConfig.HiServiceEndpoint = "https://www3.medicareaustralia.gov.au/pcert/soap/services/";
      //Test Enviroment
      IhiSearchValidateConfig.HiServiceEndpoint = "https://www5.medicareaustralia.gov.au/cert/soap/services/";      
      //Serial Number of the certificate in windows certificate store under the user acount's Personal store
      IhiSearchValidateConfig.CertificateSerialNumber = "0608d9";
      //The product name must be registered with Medicare, must be registered for Test and Prod
      IhiSearchValidateConfig.ProductName = "NEHTA HIPS";
      //The product version must be registered with Medicare, must be registered for Test and Prod
      IhiSearchValidateConfig.ProductVersion = "6.1";
      //The Vendor Id must be registered with Medicare, must be registered for Test and Prod
      IhiSearchValidateConfig.VendorId = "HIPS0001";
      //The Vendor Id Qualifier must be registered with Medicare, must be registered for Test and Prod
      IhiSearchValidateConfig.VendorIdQualifier = "http://ns.electronichealth.net.au/id/hi/vendorid/1.0";
      
      //Load the configuration in to the API Service
      HiServiceApi = new HiServiceApi(IhiSearchValidateConfig);

    }

    [TestMethod]
    public void MedicareNumberSearch_Test()
    {
      //Setup a IHI Search or Validation Request object
      IhiRequestData IhiRequestData = new IhiRequestData();

      //The User Id , does not need to be registered with Medicare
      IhiRequestData.UserId = "BobSmith";
      //The User Id Qualifier, does not need to be registered with Medicare
      IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      //If True the Soap Request and Response XML data will be returned for each call
      //A conformant Hi Service system must keep an audit trail of this data for 7 years
      IhiRequestData.ReturnSoapRequestAndResponseData = true;

      IhiRequestData.Dob = new DateTime(1982, 01, 24);
      //IhiRequestDemographics.DVANumber = "";
      IhiRequestData.Family = "MARCELLE";
      IhiRequestData.Given = "JUANITA";
      //IhiRequestDemographics.IHINumber = "1234567890123456";
      //IhiRequestDemographics.MedicareIRN = "1";
      IhiRequestData.MedicareNumber = "2950156481";
      IhiRequestData.SexChar = 'F';
      
      //Make the call using the API Service providing the Request Object, an Outcome object will be returned with the results
      IIhiSearchValidateOutcome IhiSearchValidateOutcome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);

      

      Assert.IsTrue(IhiSearchValidateOutcome.SuccessfulQuery);
      Assert.AreEqual("8003603456797233", IhiSearchValidateOutcome.ResponseData.IHINumber);
      Assert.AreEqual("Verified", IhiSearchValidateOutcome.ResponseData.IHIRecordStatus);
      Assert.AreEqual("Active", IhiSearchValidateOutcome.ResponseData.IHIStatus);
      Assert.AreEqual('F', IhiSearchValidateOutcome.ResponseData.SexChar);
      Assert.AreEqual(new DateTime(1982, 01, 24), IhiSearchValidateOutcome.ResponseData.Dob);
      Assert.AreEqual("MARCELLE", IhiSearchValidateOutcome.ResponseData.Family);
      Assert.AreEqual("JUANITA", IhiSearchValidateOutcome.ResponseData.Given);
      Assert.AreEqual("2950156481", IhiSearchValidateOutcome.ResponseData.MedicareNumber);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareIRN);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.DVANumber);
    }

    [TestMethod]
    public void MedicareNumberAndDVANumberNegativeSearch_Test()
    {
      //Setup a IHI Search or Validation Request object
      IhiRequestData IhiRequestData = new IhiRequestData();

      //The User Id , does not need to be registered with Medicare
      IhiRequestData.UserId = "BobSmith";
      //The User Id Qualifier, does not need to be registered with Medicare
      IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      //If True the Soap Request and Response XML data will be returned for each call
      //A conformant Hi Service system must keep an audit trail of this data for 7 years
      IhiRequestData.ReturnSoapRequestAndResponseData = true;

      IhiRequestData.Dob = new DateTime(1949, 05, 16);
      IhiRequestData.DVANumber = "N234578J";
      IhiRequestData.Family = "Wyk";
      IhiRequestData.Given = "Palmer";
      //IhiRequestDemographics.IHINumber = "1234567890123456";
      //IhiRequestDemographics.MedicareIRN = "1";
      IhiRequestData.MedicareNumber = "6950132571";
      IhiRequestData.SexChar = 'M';

      //Make the call using the API Service providing the Request Object, an Outcome object will be returned with the results
      IIhiSearchValidateOutcome IhiSearchValidateOutcome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);

      Assert.IsFalse(IhiSearchValidateOutcome.SuccessfulQuery);
      Assert.AreEqual("A MedicareNumber and DVANumber supplied in the same request. Must only have a single identifier per call: (MedicareNumber, DVANumber or IHINumber).", IhiSearchValidateOutcome.QueryMetadata.ErrorMessge);
      
    }

    [TestMethod]
    public void DVANumberSearch_Test()
    {      
      //Setup a IHI Search or Validation Request object
      IhiRequestData IhiRequestData = new IhiRequestData();

      //The User Id , does not need to be registered with Medicare
      IhiRequestData.UserId = "BobSmith";
      //The User Id Qualifier, does not need to be registered with Medicare
      IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      //If True the Soap Request and Response XML data will be returned for each call
      //A conformant Hi Service system must keep an audit trail of this data for 7 years
      IhiRequestData.ReturnSoapRequestAndResponseData = true;

      IhiRequestData.Dob = new DateTime(1970, 12, 12);
      IhiRequestData.DVANumber = "N908030C";
      IhiRequestData.Family = "LAWSON";
      IhiRequestData.Given = "LUKE";
      //IhiRequestDemographics.IHINumber = "1234567890123456";
      //IhiRequestDemographics.MedicareIRN = "1";
      //IhiRequestDemographics.MedicareNumber = "2950156481";
      IhiRequestData.SexChar = 'M';

      //Make the call using the API Service providing the Request Object, an Outcome object will be returned with the results
      IIhiSearchValidateOutcome IhiSearchValidateOutcome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);

      Assert.IsTrue(IhiSearchValidateOutcome.SuccessfulQuery);
      Assert.AreEqual("8003604567897649", IhiSearchValidateOutcome.ResponseData.IHINumber);
      Assert.AreEqual("Verified", IhiSearchValidateOutcome.ResponseData.IHIRecordStatus);
      Assert.AreEqual("Active", IhiSearchValidateOutcome.ResponseData.IHIStatus);
      Assert.AreEqual('M', IhiSearchValidateOutcome.ResponseData.SexChar);
      Assert.AreEqual(new DateTime(1970, 12, 12), IhiSearchValidateOutcome.ResponseData.Dob);
      Assert.AreEqual("LAWSON", IhiSearchValidateOutcome.ResponseData.Family);
      Assert.AreEqual("LUKE", IhiSearchValidateOutcome.ResponseData.Given);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareNumber);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareIRN);
      Assert.AreEqual("N908030C", IhiSearchValidateOutcome.ResponseData.DVANumber);
    }

    [TestMethod]
    public void IHINumberSearch_Test()
    {      
      //Setup a IHI Search or Validation Request object
      IhiRequestData IhiRequestData = new IhiRequestData();
      //The User Id , does not need to be registered with Medicare
      IhiRequestData.UserId = "BobSmith";
      //The User Id Qualifier, does not need to be registered with Medicare
      IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      //If True the Soap Request and Response XML data will be returned for each call
      //A conformant Hi Service system must keep an audit trail of this data for 7 years
      IhiRequestData.ReturnSoapRequestAndResponseData = true;

      IhiRequestData.Dob = new DateTime(1941, 3, 26);
      //IhiRequestDemographics.DVANumber = "N908030C";
      IhiRequestData.Family = "SUZANNE";
      IhiRequestData.Given = "CALEB";
      IhiRequestData.IHINumber = "8003601011856791";
      //IhiRequestDemographics.MedicareIRN = "1";
      //IhiRequestDemographics.MedicareNumber = "2950156481";
      IhiRequestData.SexChar = 'M';

      //Make the call using the API Service providing the Request Object, an Outcome object will be returned with the results
      IIhiSearchValidateOutcome IhiSearchValidateOutcome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);

      Assert.IsTrue(IhiSearchValidateOutcome.SuccessfulQuery);
      Assert.AreEqual("8003601011856791", IhiSearchValidateOutcome.ResponseData.IHINumber);
      Assert.AreEqual("Verified", IhiSearchValidateOutcome.ResponseData.IHIRecordStatus);
      Assert.AreEqual("Deceased", IhiSearchValidateOutcome.ResponseData.IHIStatus);
      Assert.AreEqual('M', IhiSearchValidateOutcome.ResponseData.SexChar);
      Assert.AreEqual(new DateTime(1941, 3, 26), IhiSearchValidateOutcome.ResponseData.Dob);
      Assert.AreEqual("SUZANNE", IhiSearchValidateOutcome.ResponseData.Family);
      Assert.AreEqual("CALEB", IhiSearchValidateOutcome.ResponseData.Given);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareNumber);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareIRN);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.DVANumber);

    }

    [TestMethod]
    public void ReuseOfService_Test()
    {
      //Setup a IHI Search or Validation Request object
      IhiRequestData IhiRequestData = new IhiRequestData();

      //The User Id , does not need to be registered with Medicare
      IhiRequestData.UserId = "BobSmith";
      //The User Id Qualifier, does not need to be registered with Medicare
      IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      //If True the Soap Request and Response XML data will be returned for each call
      //A conformant Hi Service system must keep an audit trail of this data for 7 years
      IhiRequestData.ReturnSoapRequestAndResponseData = true;

      IhiRequestData.Dob = new DateTime(1982, 01, 24);
      //IhiRequestDemographics.DVANumber = "";
      IhiRequestData.Family = "MARCELLE";
      IhiRequestData.Given = "JUANITA";
      //IhiRequestDemographics.IHINumber = "1234567890123456";
      //IhiRequestDemographics.MedicareIRN = "1";
      IhiRequestData.MedicareNumber = "2950156481";
      IhiRequestData.SexChar = 'F';

      //Make the call using the API Service providing the Request Object, an Outcome object will be returned with the results
      IIhiSearchValidateOutcome IhiSearchValidateOutcome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);

      Assert.IsTrue(IhiSearchValidateOutcome.SuccessfulQuery);
      Assert.AreEqual("8003603456797233", IhiSearchValidateOutcome.ResponseData.IHINumber);
      Assert.AreEqual("Verified", IhiSearchValidateOutcome.ResponseData.IHIRecordStatus);
      Assert.AreEqual("Active", IhiSearchValidateOutcome.ResponseData.IHIStatus);
      Assert.AreEqual('F', IhiSearchValidateOutcome.ResponseData.SexChar);
      Assert.AreEqual(new DateTime(1982, 01, 24), IhiSearchValidateOutcome.ResponseData.Dob);
      Assert.AreEqual("MARCELLE", IhiSearchValidateOutcome.ResponseData.Family);
      Assert.AreEqual("JUANITA", IhiSearchValidateOutcome.ResponseData.Given);
      Assert.AreEqual("2950156481", IhiSearchValidateOutcome.ResponseData.MedicareNumber);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareIRN);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.DVANumber);

      IhiRequestData = new IhiRequestData();
      //Setup a IHI Search or Validation Request object
      //The User Id , does not need to be registered with Medicare
      IhiRequestData.UserId = "BobSmith";
      //The User Id Qualifier, does not need to be registered with Medicare
      IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      //If True the Soap Request and Response XML data will be returned for each call
      //A conformant Hi Service system must keep an audit trail of this data for 7 years
      IhiRequestData.ReturnSoapRequestAndResponseData = true;

      IhiRequestData.Dob = new DateTime(1970, 12, 12);
      IhiRequestData.DVANumber = "N908030C";
      IhiRequestData.Family = "LAWSON";
      IhiRequestData.Given = "LUKE";
      //IhiRequestDemographics.IHINumber = "1234567890123456";
      //IhiRequestDemographics.MedicareIRN = "1";
      //IhiRequestDemographics.MedicareNumber = "2950156481";
      IhiRequestData.SexChar = 'M';

      //Make the call using the API Service providing the Request Object, an Outcome object will be returned with the results
      IhiSearchValidateOutcome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);

      Assert.IsTrue(IhiSearchValidateOutcome.SuccessfulQuery);
      Assert.AreEqual("8003604567897649", IhiSearchValidateOutcome.ResponseData.IHINumber);
      Assert.AreEqual("Verified", IhiSearchValidateOutcome.ResponseData.IHIRecordStatus);
      Assert.AreEqual("Active", IhiSearchValidateOutcome.ResponseData.IHIStatus);
      Assert.AreEqual('M', IhiSearchValidateOutcome.ResponseData.SexChar);
      Assert.AreEqual(new DateTime(1970, 12, 12), IhiSearchValidateOutcome.ResponseData.Dob);
      Assert.AreEqual("LAWSON", IhiSearchValidateOutcome.ResponseData.Family);
      Assert.AreEqual("LUKE", IhiSearchValidateOutcome.ResponseData.Given);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareNumber);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareIRN);
      Assert.AreEqual("N908030C", IhiSearchValidateOutcome.ResponseData.DVANumber);

      //Setup a IHI Search or Validation Request object
      IhiRequestData = new IhiRequestData();
      //The User Id , does not need to be registered with Medicare
      IhiRequestData.UserId = "BobSmith";
      //The User Id Qualifier, does not need to be registered with Medicare
      IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      //If True the Soap Request and Response XML data will be returned for each call
      //A conformant Hi Service system must keep an audit trail of this data for 7 years
      IhiRequestData.ReturnSoapRequestAndResponseData = true;

      IhiRequestData.Dob = new DateTime(1941, 3, 26);
      //IhiRequestDemographics.DVANumber = "N908030C";
      IhiRequestData.Family = "SUZANNE";
      IhiRequestData.Given = "CALEB";
      IhiRequestData.IHINumber = "8003601011856791";
      //IhiRequestDemographics.MedicareIRN = "1";
      //IhiRequestDemographics.MedicareNumber = "2950156481";
      IhiRequestData.SexChar = 'M';

      //Make the call using the API Service providing the Request Object, an Outcome object will be returned with the results
      IhiSearchValidateOutcome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);

      Assert.IsTrue(IhiSearchValidateOutcome.SuccessfulQuery);
      Assert.AreEqual("8003601011856791", IhiSearchValidateOutcome.ResponseData.IHINumber);
      Assert.AreEqual("Verified", IhiSearchValidateOutcome.ResponseData.IHIRecordStatus);
      Assert.AreEqual("Deceased", IhiSearchValidateOutcome.ResponseData.IHIStatus);
      Assert.AreEqual('M', IhiSearchValidateOutcome.ResponseData.SexChar);
      Assert.AreEqual(new DateTime(1941, 3, 26), IhiSearchValidateOutcome.ResponseData.Dob);
      Assert.AreEqual("SUZANNE", IhiSearchValidateOutcome.ResponseData.Family);
      Assert.AreEqual("CALEB", IhiSearchValidateOutcome.ResponseData.Given);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareNumber);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareIRN);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.DVANumber);
    }

    [TestMethod]
    public void MedicareNumberSearch_IncorrectDobTest()
    {
      //Setup a IHI Search or Validation Request object
      IhiRequestData IhiRequestData = new IhiRequestData();

      //The User Id , does not need to be registered with Medicare
      IhiRequestData.UserId = "BobSmith";
      //The User Id Qualifier, does not need to be registered with Medicare
      IhiRequestData.UserIdQualifier = "http://ns.yourcompany.com.au/id/yoursoftware/userid/1.0";
      //If True the Soap Request and Response XML data will be returned for each call
      //A conformant Hi Service system must keep an audit trail of this data for 7 years
      IhiRequestData.ReturnSoapRequestAndResponseData = true;

      IhiRequestData.Dob = new DateTime(1982, 01, 01);
      //IhiRequestDemographics.DVANumber = "";
      IhiRequestData.Family = "MARCELLE";
      IhiRequestData.Given = "JUANITA";
      //IhiRequestDemographics.IHINumber = "1234567890123456";
      //IhiRequestDemographics.MedicareIRN = "1";
      IhiRequestData.MedicareNumber = "2950156481";
      IhiRequestData.SexChar = 'F';

      //Make the call using the API Service providing the Request Object, an Outcome object will be returned with the results
      IIhiSearchValidateOutcome IhiSearchValidateOutcome = HiServiceApi.SearchOrValidateIhi(IhiRequestData);



      Assert.IsTrue(IhiSearchValidateOutcome.SuccessfulQuery);
      Assert.IsNotNull(IhiSearchValidateOutcome.QueryMetadata.ServiceMessage);
      Assert.AreEqual(1, IhiSearchValidateOutcome.QueryMetadata.ServiceMessage.Count);
      Assert.AreEqual("01439", IhiSearchValidateOutcome.QueryMetadata.ServiceMessage[0].Code);
      Assert.AreEqual("Informational", IhiSearchValidateOutcome.QueryMetadata.ServiceMessage[0].SeverityType);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.IHINumber);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.IHIRecordStatus);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.IHIStatus);
      Assert.AreEqual('F', IhiSearchValidateOutcome.ResponseData.SexChar);
      //Assert.AreEqual(new DateTime(1982, 01, 24), IhiSearchValidateOutcome.ResponseData.Dob);
      Assert.IsNull( IhiSearchValidateOutcome.ResponseData.Family);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.Given);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareNumber);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.MedicareIRN);
      Assert.IsNull(IhiSearchValidateOutcome.ResponseData.DVANumber);
    }

  }
}
