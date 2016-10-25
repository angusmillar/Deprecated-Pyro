using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Introspection;
//This file was Auto Generated and should not be modified here on: 24/10/2016 5:10:33 PM.

namespace Blaze.DataModel.Support
{
  public static partial class FhirCodeDataTypeSupport
  {
     public static bool TokenIndexSetter(Element FhirElement, TokenIndex TokenIndex)
     {
      if (false)
      { 
      }
      else if (FhirElement is Code<Hl7.Fhir.Model.Account.AccountStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Account.AccountStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.LibraryStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.LibraryStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceSeverity>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceSeverity>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCategory>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCategory>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCriticality>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCriticality>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ParticipationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ParticipationStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Appointment.AppointmentStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Appointment.AppointmentStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AuditEvent.AuditEventAction>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AuditEvent.AuditEventAction>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AuditEvent.AuditEventOutcome>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AuditEvent.AuditEventOutcome>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Bundle.BundleType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Bundle.BundleType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.CarePlan.CarePlanRelationship>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.CarePlan.CarePlanRelationship>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Claim.Use>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Claim.Use>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ClinicalImpression.ClinicalImpressionStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ClinicalImpression.ClinicalImpressionStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.CodeSystem.CodeSystemContentMode>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.CodeSystem.CodeSystemContentMode>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ConformanceResourceStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ConformanceResourceStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Communication.CommunicationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Communication.CommunicationStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.CommunicationRequest.CommunicationRequestStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.CommunicationRequest.CommunicationRequestStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ResourceType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ResourceType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.CompartmentDefinition.CompartmentType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.CompartmentDefinition.CompartmentType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Composition.ConfidentialityClassification>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Composition.ConfidentialityClassification>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Composition.CompositionStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Composition.CompositionStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Condition.ConditionClinicalStatusCodes>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Condition.ConditionClinicalStatusCodes>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Conformance.RestfulConformanceMode>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Conformance.RestfulConformanceMode>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Consent.ConsentStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Consent.ConsentStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DataElement.DataElementStringency>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DataElement.DataElementStringency>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DeviceMetric.DeviceMetricCategory>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DeviceMetric.DeviceMetricCategory>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.RequestStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.RequestStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DiagnosticReport.DiagnosticReportStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DiagnosticReport.DiagnosticReportStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DocumentReferenceStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DocumentReferenceStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DocumentReference.DocumentRelationshipType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DocumentReference.DocumentRelationshipType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ClaimProcessingCodes>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ClaimProcessingCodes>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Encounter.EncounterStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Encounter.EncounterStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Endpoint.EndpointStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Endpoint.EndpointStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AdministrativeGender>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AdministrativeGender>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Goal.GoalStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Goal.GoalStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Group.GroupType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Group.GroupType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MedicationAdministrationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MedicationAdministrationStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.List.ListStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.List.ListStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Address.AddressUse>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Address.AddressUse>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Location.LocationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Location.LocationStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Media.DigitalMediaType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Media.DigitalMediaType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MedicationDispense.MedicationDispenseStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MedicationDispense.MedicationDispenseStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MedicationOrder.MedicationOrderStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MedicationOrder.MedicationOrderStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MedicationStatement.MedicationStatementStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MedicationStatement.MedicationStatementStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MessageHeader.ResponseType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MessageHeader.ResponseType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.NamingSystem.NamingSystemIdentifierType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.NamingSystem.NamingSystemIdentifierType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.NamingSystem.NamingSystemType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.NamingSystem.NamingSystemType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.NutritionRequest.NutritionOrderStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.NutritionRequest.NutritionOrderStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Observation.ObservationRelationshipType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Observation.ObservationRelationshipType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ObservationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ObservationStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.OperationDefinition.OperationKind>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.OperationDefinition.OperationKind>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ProcessRequest.ActionList>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ProcessRequest.ActionList>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Questionnaire.QuestionnaireStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Questionnaire.QuestionnaireStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.QuestionnaireResponse.QuestionnaireResponseStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.QuestionnaireResponse.QuestionnaireResponseStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ReferralRequest.ReferralCategory>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ReferralRequest.ReferralCategory>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ReferralRequest.ReferralStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ReferralRequest.ReferralStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.SearchParamType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.SearchParamType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Slot.SlotStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Slot.SlotStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.StructureDefinition.ExtensionContext>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.StructureDefinition.ExtensionContext>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.StructureDefinition.TypeDerivationRule>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.StructureDefinition.TypeDerivationRule>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.StructureDefinition.StructureDefinitionKind>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.StructureDefinition.StructureDefinitionKind>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Subscription.SubscriptionStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Subscription.SubscriptionStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Subscription.SubscriptionChannelType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Subscription.SubscriptionChannelType>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.SupplyDelivery.SupplyDeliveryStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.SupplyDelivery.SupplyDeliveryStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Task.TaskPriority>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Task.TaskPriority>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Task.TaskStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Task.TaskStatus>;
        if (Code.Value != null)
           TokenIndex.Code = Code.Value.GetLiteral();
        TokenIndex.System = null;
        return true;
      }      
      else
      {
        return false;
      }      
    }
  }
}
    
