using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;

namespace BusinessEntities
{
  public static class DtoEnums
  {
    public enum CrudOperationType { None, Create, Read, Update, Delete };
    
    public enum SupportedFhirResource
    {
      Patient,
      ValueSet,
      Resource,
      ConceptMap 
    };

    public static Dictionary<ResourceType, DtoEnums.SupportedFhirResource> GetBlazeSupportedResorceTypeByFhirResourceTypeDictionary()
    {
      return new Dictionary<ResourceType, DtoEnums.SupportedFhirResource>()
      {
        {ResourceType.Patient,DtoEnums.SupportedFhirResource.Patient},
        {ResourceType.ValueSet,DtoEnums.SupportedFhirResource.ValueSet},
        {ResourceType.Resource,DtoEnums.SupportedFhirResource.Resource},
        {ResourceType.ConceptMap,DtoEnums.SupportedFhirResource.ConceptMap}
      };
    }

    public static Dictionary<DtoEnums.SupportedFhirResource, ResourceType> GetFhirResourceTypeByBlazeSupportedResorceTypeDictionary()
    {
      return new Dictionary<DtoEnums.SupportedFhirResource, ResourceType>()
      {
        {DtoEnums.SupportedFhirResource.Patient,ResourceType.Patient},
        {DtoEnums.SupportedFhirResource.ValueSet,ResourceType.ValueSet},
        {DtoEnums.SupportedFhirResource.Resource,ResourceType.Resource},
        {DtoEnums.SupportedFhirResource.ConceptMap,ResourceType.ConceptMap}
      };
    }

    public static Dictionary<string, ResourceType> GetFhirResourceTypeByNameDictionary()
    {
      return new Dictionary<string, ResourceType>()
      {
        {"DomainResource",ResourceType.DomainResource},
        {"Parameters",ResourceType.Parameters},
        {"Resource",ResourceType.Resource},
        {"AllergyIntolerance",ResourceType.AllergyIntolerance},
        {"Appointment",ResourceType.Appointment},
        {"AppointmentResponse",ResourceType.AppointmentResponse},
        {"AuditEvent",ResourceType.AuditEvent},
        {"Basic",ResourceType.Basic},
        {"Binary",ResourceType.Binary},
        {"BodySite",ResourceType.BodySite},
        {"Bundle",ResourceType.Bundle},
        {"CarePlan",ResourceType.CarePlan},
        {"Claim",ResourceType.Claim},
        {"ClaimResponse",ResourceType.ClaimResponse},
        {"ClinicalImpression",ResourceType.ClinicalImpression},
        {"Communication",ResourceType.Communication},
        {"CommunicationRequest",ResourceType.CommunicationRequest},
        {"Composition",ResourceType.Composition},
        {"ConceptMap",ResourceType.ConceptMap},
        {"Condition",ResourceType.Condition},
        {"Conformance",ResourceType.Conformance},
        {"Contract",ResourceType.Contract},        
        {"Coverage",ResourceType.Coverage},
        {"DataElement",ResourceType.DataElement},
        {"Device",ResourceType.Device},
        {"DeviceComponent",ResourceType.DeviceComponent},
        {"DeviceMetric",ResourceType.DeviceMetric},
        {"DeviceUseRequest",ResourceType.DeviceUseRequest},
        {"DeviceUseStatement",ResourceType.DeviceUseStatement},
        {"DiagnosticOrder",ResourceType.DiagnosticOrder},
        {"DiagnosticReport",ResourceType.DiagnosticReport},
        {"DocumentManifest",ResourceType.DocumentManifest},
        {"DocumentReference",ResourceType.DocumentReference},
        {"EligibilityRequest",ResourceType.EligibilityRequest},
        {"EligibilityResponse",ResourceType.EligibilityResponse},
        {"Encounter",ResourceType.Encounter},
        {"EnrollmentRequest",ResourceType.EnrollmentRequest},
        {"EnrollmentResponse",ResourceType.EnrollmentResponse},
        {"EpisodeOfCare",ResourceType.EpisodeOfCare},
        {"ExplanationOfBenefit",ResourceType.ExplanationOfBenefit},
        {"FamilyMemberHistory",ResourceType.FamilyMemberHistory},
        {"Flag",ResourceType.Flag},
        {"Goal",ResourceType.Goal},
        {"Group",ResourceType.Group},
        {"HealthcareService",ResourceType.HealthcareService},
        {"ImagingObjectSelection",ResourceType.ImagingObjectSelection},
        {"ImagingStudy",ResourceType.ImagingStudy},
        {"Immunization",ResourceType.Immunization},
        {"ImmunizationRecommendation",ResourceType.ImmunizationRecommendation},
        {"List",ResourceType.List},
        {"Location",ResourceType.Location},
        {"Media",ResourceType.Media},
        {"Medication",ResourceType.Medication},
        {"MedicationAdministration",ResourceType.MedicationAdministration},
        {"MedicationDispense",ResourceType.MedicationDispense},
        {"MedicationOrder",ResourceType.MedicationOrder},
        {"MedicationStatement",ResourceType.MedicationStatement},
        {"MessageHeader",ResourceType.MessageHeader},
        {"NamingSystem",ResourceType.NamingSystem},
        {"NutritionOrder",ResourceType.NutritionOrder},
        {"Observation",ResourceType.Observation},
        {"OperationDefinition",ResourceType.OperationDefinition},
        {"OperationOutcome",ResourceType.OperationOutcome},
        {"Order",ResourceType.Order},
        {"OrderResponse",ResourceType.OrderResponse},
        {"Organization",ResourceType.Organization},
        {"Patient",ResourceType.Patient},
        {"PaymentNotice",ResourceType.PaymentNotice},
        {"PaymentReconciliation",ResourceType.PaymentReconciliation},
        {"Person",ResourceType.Person},
        {"Practitioner",ResourceType.Practitioner},
        {"Procedure",ResourceType.Procedure},
        {"ProcedureRequest",ResourceType.ProcedureRequest},
        {"ProcessRequest",ResourceType.ProcessRequest},
        {"ProcessResponse",ResourceType.ProcessResponse},
        {"Provenance",ResourceType.Provenance},
        {"Questionnaire",ResourceType.Questionnaire},
        {"QuestionnaireResponse",ResourceType.QuestionnaireResponse},
        {"ReferralRequest",ResourceType.ReferralRequest},
        {"RelatedPerson",ResourceType.RelatedPerson},
        {"RiskAssessment",ResourceType.RiskAssessment},
        {"Schedule",ResourceType.Schedule},
        {"SearchParameter",ResourceType.SearchParameter},
        {"Slot",ResourceType.Slot},
        {"Specimen",ResourceType.Specimen},
        {"StructureDefinition",ResourceType.StructureDefinition},
        {"Subscription",ResourceType.Subscription},
        {"Substance",ResourceType.Substance},
        {"SupplyDelivery",ResourceType.SupplyDelivery},
        {"SupplyRequest",ResourceType.SupplyRequest},
        {"SupplyRequest",ResourceType.TestScript},
        {"ValueSet",ResourceType.ValueSet},    
        {"VisionPrescription",ResourceType.VisionPrescription}
      };
    }
  }
}
