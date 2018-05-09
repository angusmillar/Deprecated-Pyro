using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Support.StandardsInformation.Australian
{
  public class NationalHealthcareIdentifierInfo : INationalHealthcareIdentifierInfo
  {
    /// <summary>
    ///e.g: PID-3.4 (Ordering Provider)
    /// </summary>
    public string IHIAssigningAuthority { get { return "AUSHIC"; } }

    /// <summary>
    ///e.g: PID-3.5 (Ordering Provider)
    /// </summary>
    public string IHIIdentifierTypeCode { get { return "NI"; } }

    /// <summary>
    ///e.g: OBR-16.9 (Ordering Provider)
    /// </summary>
    public string HPIIAssigningAuthority => "AUSHIC";

    /// <summary>
    /// e.g OBR-16.14 (Ordering Provider)
    /// </summary>
    public string HPIIAssigningFacility => "NPI";

    ///e.g: ORC-21.7 (Ordering Facility Name)
    /// </summary>
    public string HPIOIdentifierTypeCode { get { return "NOI"; } }

    /// <summary>
    /// e.g: ORC-21.8 (Ordering Facility Name)
    /// </summary>
    public string HPIOAssigningFacilityID { get { return "AUSHIC"; } }

    /// <summary>
    /// CDA
    /// Same root OID is used for (IHI, HPI-I & HPI-O)
    /// </summary>
    public string RootHealthcareIdentifierOid { get { return "1.2.36.1.2001.1003.0"; } }

    /// <summary>
    ///CDA
    ///root="1.2.36.1.2001.1003.0.8003623233356541" assigningAuthorityName="IHI"
    /// </summary>
    public string IHIAssigningAuthorityName { get { return "IHI"; } }

    /// <summary>
    ///CDA
    ///root="1.2.36.1.2001.1003.0.8003615833340784" assigningAuthorityName="HPI-I"
    /// </summary>
    public string HPIIAssigningAuthorityName { get { return "HPI-I"; } }

    /// <summary>
    ///CDA
    ///root="1.2.36.1.2001.1003.0.8003623233356541" assigningAuthorityName="HPI-O"
    /// </summary>
    public string HPIOAssigningAuthorityName { get { return "HPI-O"; } }

    /// <summary>
    ///FHIR IHI Value System
    ///root="1.2.36.1.2001.1003.0.8003623233356541" assigningAuthorityName="IHI"
    /// </summary>
    public string IHIValueFhirSystem { get { return " http://ns.electronichealth.net.au/id/hi/ihi/1.0"; } }

    /// <summary>
    ///FHIR IHI Status System
    ///root="1.2.36.1.2001.1003.0.8003623233356541" assigningAuthorityName="IHI"
    /// </summary>
    public string IHIStatusFhirSystem { get { return "https://healthterminologies.gov.au/fhir/ValueSet/ihi-status-1"; } }

    /// <summary>
    ///FHIR IHI Record Status System
    ///root="1.2.36.1.2001.1003.0.8003623233356541" assigningAuthorityName="IHI"
    /// </summary>
    public string IHIRecordStatusFhirSystem { get { return "https://healthterminologies.gov.au/fhir/CodeSystem/ihi-record-status-1"; } }


  }
}
