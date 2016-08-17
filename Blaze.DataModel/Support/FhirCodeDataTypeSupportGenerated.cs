using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Blaze.DataModel.DatabaseModel.Base;

//This file was Auto Generated and should not be modified here.

namespace Blaze.DataModel.Support
{
  public static partial class FhirCodeDataTypeSupport
  {
     public static bool TokenIndexSetter(Element FhirElement, TokenIndex TokenIndex)
     {
      if (false)
      { 
      }
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceSeverity>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceSeverity>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceSeverity)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCategory>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCategory>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCategory)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCriticality>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCriticality>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceCriticality)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.AllergyIntolerance.AllergyIntoleranceType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ParticipationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ParticipationStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ParticipationStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Appointment.AppointmentStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Appointment.AppointmentStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Appointment.AppointmentStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AuditEvent.AuditEventAction>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AuditEvent.AuditEventAction>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.AuditEvent.AuditEventAction)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Bundle.BundleType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Bundle.BundleType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Bundle.BundleType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.CarePlan.CarePlanRelationship>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.CarePlan.CarePlanRelationship>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.CarePlan.CarePlanRelationship)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Claim.Use>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Claim.Use>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Claim.Use)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.RemittanceOutcome>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.RemittanceOutcome>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.RemittanceOutcome)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ClinicalImpression.ClinicalImpressionStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ClinicalImpression.ClinicalImpressionStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ClinicalImpression.ClinicalImpressionStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ConformanceResourceStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ConformanceResourceStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ConformanceResourceStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Communication.CommunicationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Communication.CommunicationStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Communication.CommunicationStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.CommunicationRequest.CommunicationRequestStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.CommunicationRequest.CommunicationRequestStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.CommunicationRequest.CommunicationRequestStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ResourceType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ResourceType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ResourceType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.CompartmentDefinition.CompartmentType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.CompartmentDefinition.CompartmentType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.CompartmentDefinition.CompartmentType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Composition.v3CodeSystemConfidentiality>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Composition.v3CodeSystemConfidentiality>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Composition.v3CodeSystemConfidentiality)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Composition.CompositionStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Composition.CompositionStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Composition.CompositionStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Conformance.RestfulConformanceMode>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Conformance.RestfulConformanceMode>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Conformance.RestfulConformanceMode)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DataElement.DataElementStringency>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DataElement.DataElementStringency>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.DataElement.DataElementStringency)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ModuleMetadata.ModuleMetadataStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ModuleMetadata.ModuleMetadataStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ModuleMetadata.ModuleMetadataStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DeviceMetric.DeviceMetricCategory>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DeviceMetric.DeviceMetricCategory>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.DeviceMetric.DeviceMetricCategory)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.DiagnosticOrder.DiagnosticOrderStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DiagnosticReport.DiagnosticReportStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DiagnosticReport.DiagnosticReportStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.DiagnosticReport.DiagnosticReportStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DocumentReferenceStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DocumentReferenceStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.DocumentReferenceStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.DocumentReference.DocumentRelationshipType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.DocumentReference.DocumentRelationshipType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.DocumentReference.DocumentRelationshipType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Encounter.EncounterState>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Encounter.EncounterState>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Encounter.EncounterState)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.AdministrativeGender>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.AdministrativeGender>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.AdministrativeGender)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Goal.GoalStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Goal.GoalStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Goal.GoalStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Group.GroupType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Group.GroupType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Group.GroupType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MedicationAdministrationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MedicationAdministrationStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.MedicationAdministrationStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.List.ListStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.List.ListStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.List.ListStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Address.AddressUse>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Address.AddressUse>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Address.AddressUse)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Location.LocationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Location.LocationStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Location.LocationStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Media.DigitalMediaType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Media.DigitalMediaType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Media.DigitalMediaType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MedicationDispense.MedicationDispenseStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MedicationDispense.MedicationDispenseStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.MedicationDispense.MedicationDispenseStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MedicationOrder.MedicationOrderStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MedicationOrder.MedicationOrderStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.MedicationOrder.MedicationOrderStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MedicationStatement.MedicationStatementStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MedicationStatement.MedicationStatementStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.MedicationStatement.MedicationStatementStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.MessageHeader.ResponseType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.MessageHeader.ResponseType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.MessageHeader.ResponseType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.NamingSystem.NamingSystemIdentifierType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.NamingSystem.NamingSystemIdentifierType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.NamingSystem.NamingSystemIdentifierType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.NamingSystem.NamingSystemType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.NamingSystem.NamingSystemType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.NamingSystem.NamingSystemType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.NutritionOrder.NutritionOrderStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.NutritionOrder.NutritionOrderStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.NutritionOrder.NutritionOrderStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Observation.ObservationRelationshipType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Observation.ObservationRelationshipType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Observation.ObservationRelationshipType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Observation.ObservationStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Observation.ObservationStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Observation.ObservationStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.OperationDefinition.OperationKind>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.OperationDefinition.OperationKind>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.OperationDefinition.OperationKind)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.OrderResponse.OrderStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.OrderResponse.OrderStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.OrderResponse.OrderStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ProcessRequest.ActionList>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ProcessRequest.ActionList>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ProcessRequest.ActionList)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Questionnaire.QuestionnaireStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Questionnaire.QuestionnaireStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Questionnaire.QuestionnaireStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.QuestionnaireResponse.QuestionnaireResponseStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.QuestionnaireResponse.QuestionnaireResponseStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.QuestionnaireResponse.QuestionnaireResponseStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ReferralRequest.ReferralCategory>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ReferralRequest.ReferralCategory>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ReferralRequest.ReferralCategory)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.ReferralRequest.ReferralStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.ReferralRequest.ReferralStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.ReferralRequest.ReferralStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.SearchParamType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.SearchParamType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.SearchParamType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Slot.SlotStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Slot.SlotStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Slot.SlotStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.StructureDefinition.ExtensionContext>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.StructureDefinition.ExtensionContext>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.StructureDefinition.ExtensionContext)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.StructureDefinition.TypeDerivationRule>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.StructureDefinition.TypeDerivationRule>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.StructureDefinition.TypeDerivationRule)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.StructureDefinition.StructureDefinitionKind>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.StructureDefinition.StructureDefinitionKind>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.StructureDefinition.StructureDefinitionKind)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.FHIRDefinedType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.FHIRDefinedType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.FHIRDefinedType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Subscription.SubscriptionStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Subscription.SubscriptionStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Subscription.SubscriptionStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Subscription.SubscriptionChannelType>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Subscription.SubscriptionChannelType>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Subscription.SubscriptionChannelType)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.SupplyDelivery.SupplyDeliveryStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.SupplyDelivery.SupplyDeliveryStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.SupplyDelivery.SupplyDeliveryStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Task.TaskPriority>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Task.TaskPriority>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Task.TaskPriority)).GetLiteral(Code.Value);
        TokenIndex.System = null;
        return true;
      }      
      else if (FhirElement is Code<Hl7.Fhir.Model.Task.TaskStatus>)
      {
        var Code = FhirElement as Code<Hl7.Fhir.Model.Task.TaskStatus>;
        if (Code.Value != null)
          TokenIndex.Code = Hl7.Fhir.Introspection.EnumMapping.Create(typeof(Hl7.Fhir.Model.Task.TaskStatus)).GetLiteral(Code.Value);
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
    
