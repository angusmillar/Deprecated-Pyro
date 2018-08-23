if not exists(select 1 from [dbo].[_SearchParam])
BEGIN

INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Resource', '_id', 'http://hl7.org/fhir/SearchParameter/Resource-id', 'Logical id of this artifact', '3', 'f:Resource/f:id', 'Resource.id', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Resource', '_lastUpdated', 'http://hl7.org/fhir/SearchParameter/Resource-lastUpdated', 'When the resource version last changed', '1', 'f:Resource/f:meta/f:lastUpdated', 'Resource.meta.lastUpdated', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Resource', '_profile', 'http://hl7.org/fhir/SearchParameter/Resource-profile', 'Profiles this resource claims to conform to', '7', 'f:Resource/f:meta/f:profile', 'Resource.meta.profile', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Resource', '_security', 'http://hl7.org/fhir/SearchParameter/Resource-security', 'Security Labels applied to this resource', '3', 'f:Resource/f:meta/f:security', 'Resource.meta.security', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Resource', '_tag', 'http://hl7.org/fhir/SearchParameter/Resource-tag', 'Tags applied to this resource', '3', 'f:Resource/f:meta/f:tag', 'Resource.meta.tag', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Account', 'balance', 'http://hl7.org/fhir/SearchParameter/Account-balance', 'How much is in account?', '6', 'f:Account/f:balance', 'Account.balance', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Account', 'identifier', 'http://hl7.org/fhir/SearchParameter/Account-identifier', 'Account number', '3', 'f:Account/f:identifier', 'Account.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Account', 'name', 'http://hl7.org/fhir/SearchParameter/Account-name', 'Human-readable label', '2', 'f:Account/f:name', 'Account.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Account', 'owner', 'http://hl7.org/fhir/SearchParameter/Account-owner', 'Who is responsible?', '4', 'f:Account/f:owner', 'Account.owner', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Account', 'patient', 'http://hl7.org/fhir/SearchParameter/Account-patient', 'What is account tied to?', '4', 'f:Account/f:subject', 'Account.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Account', 'period', 'http://hl7.org/fhir/SearchParameter/Account-period', 'Transaction window', '1', 'f:Account/f:period', 'Account.period', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Account', 'status', 'http://hl7.org/fhir/SearchParameter/Account-status', 'active | inactive | entered-in-error', '3', 'f:Account/f:status', 'Account.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Account', 'subject', 'http://hl7.org/fhir/SearchParameter/Account-subject', 'What is account tied to?', '4', 'f:Account/f:subject', 'Account.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Account', 'type', 'http://hl7.org/fhir/SearchParameter/Account-type', 'E.g. patient, expense, depreciation', '3', 'f:Account/f:type', 'Account.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'composed-of', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-composed-of', 'What resource is being referenced', '4', 'f:ActivityDefinition/f:relatedArtifact[f:type/@value=''composed-of'']/f:resource', 'ActivityDefinition.relatedArtifact.where(type=''composed-of'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'date', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-date', 'The activity definition publication date', '1', 'f:ActivityDefinition/f:date', 'ActivityDefinition.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'depends-on', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-depends-on', 'What resource is being referenced', '4', 'f:ActivityDefinition/f:relatedArtifact[f:type/@value=''depends-on'']/f:resource | f:ActivityDefinition/f:library', 'ActivityDefinition.relatedArtifact.where(type=''depends-on'').resource | ActivityDefinition.library', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'derived-from', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-derived-from', 'What resource is being referenced', '4', 'f:ActivityDefinition/f:relatedArtifact[f:type/@value=''derived-from'']/f:resource', 'ActivityDefinition.relatedArtifact.where(type=''derived-from'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'description', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-description', 'The description of the activity definition', '2', 'f:ActivityDefinition/f:description', 'ActivityDefinition.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'effective', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-effective', 'The time during which the activity definition is intended to be in use', '1', 'f:ActivityDefinition/f:effectivePeriod', 'ActivityDefinition.effectivePeriod', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'identifier', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-identifier', 'External identifier for the activity definition', '3', 'f:ActivityDefinition/f:identifier', 'ActivityDefinition.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-jurisdiction', 'Intended jurisdiction for the activity definition', '3', 'f:ActivityDefinition/f:jurisdiction', 'ActivityDefinition.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'name', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-name', 'Computationally friendly name of the activity definition', '2', 'f:ActivityDefinition/f:name', 'ActivityDefinition.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'predecessor', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-predecessor', 'What resource is being referenced', '4', 'f:ActivityDefinition/f:relatedArtifact[f:type/@value=''predecessor'']/f:resource', 'ActivityDefinition.relatedArtifact.where(type=''predecessor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'publisher', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-publisher', 'Name of the publisher of the activity definition', '2', 'f:ActivityDefinition/f:publisher', 'ActivityDefinition.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'status', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-status', 'The current status of the activity definition', '3', 'f:ActivityDefinition/f:status', 'ActivityDefinition.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'successor', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-successor', 'What resource is being referenced', '4', 'f:ActivityDefinition/f:relatedArtifact[f:type/@value=''successor'']/f:resource', 'ActivityDefinition.relatedArtifact.where(type=''successor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'title', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-title', 'The human-friendly name of the activity definition', '2', 'f:ActivityDefinition/f:title', 'ActivityDefinition.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'topic', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-topic', 'Topics associated with the module', '3', 'f:ActivityDefinition/f:topic', 'ActivityDefinition.topic', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'url', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-url', 'The uri that identifies the activity definition', '7', 'f:ActivityDefinition/f:url', 'ActivityDefinition.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ActivityDefinition', 'version', 'http://hl7.org/fhir/SearchParameter/ActivityDefinition-version', 'The business version of the activity definition', '3', 'f:ActivityDefinition/f:version', 'ActivityDefinition.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'category', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-category', 'AE | PAE 
An adverse event is an event that caused harm to a patient,  an adverse reaction is a something that is a subject-specific event that is a result of an exposure to a medication, food, device or environmental substance, a potential adverse event is something that occurred and that could have caused harm to a patient but did not', '3', 'f:AdverseEvent/f:category', 'AdverseEvent.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'date', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-date', 'When the event occurred', '1', 'f:AdverseEvent/f:date', 'AdverseEvent.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'location', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-location', 'Location where adverse event occurred', '4', 'f:AdverseEvent/f:location', 'AdverseEvent.location', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'reaction', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-reaction', 'Adverse Reaction Events linked to exposure to substance', '4', 'f:AdverseEvent/f:reaction', 'AdverseEvent.reaction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'recorder', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-recorder', 'Who recorded the adverse event', '4', 'f:AdverseEvent/f:recorder', 'AdverseEvent.recorder', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'seriousness', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-seriousness', 'Mild | Moderate | Severe', '3', 'f:AdverseEvent/f:seriousness', 'AdverseEvent.seriousness', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'study', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-study', 'AdverseEvent.study', '4', 'f:AdverseEvent/f:study', 'AdverseEvent.study', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'subject', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-subject', 'Subject or group impacted by event', '4', 'f:AdverseEvent/f:subject', 'AdverseEvent.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'substance', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-substance', 'Refers to the specific entity that caused the adverse event', '4', 'f:AdverseEvent/f:suspectEntity/f:instance', 'AdverseEvent.suspectEntity.instance', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AdverseEvent', 'type', 'http://hl7.org/fhir/SearchParameter/AdverseEvent-type', 'actual | potential', '3', 'f:AdverseEvent/f:type', 'AdverseEvent.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'asserter', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-asserter', 'Source of the information about the allergy', '4', 'f:AllergyIntolerance/f:asserter', 'AllergyIntolerance.asserter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'category', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-category', 'food | medication | environment | biologic', '3', 'f:AllergyIntolerance/f:category', 'AllergyIntolerance.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'clinical-status', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-clinical-status', 'active | inactive | resolved', '3', 'f:AllergyIntolerance/f:clinicalStatus', 'AllergyIntolerance.clinicalStatus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'code', 'http://hl7.org/fhir/SearchParameter/clinical-code', '', '3', 'f:FamilyMemberHistory/f:condition/f:code | f:DeviceRequest/f:codeCodeableConcept | f:AllergyIntolerance/f:code | f:AllergyIntolerance/f:reaction/f:substance | f:Procedure/f:code | f:List/f:code | f:ProcedureRequest/f:code | f:Observation/f:code | f:DiagnosticReport/f:code | f:Condition/f:code', 'FamilyMemberHistory.condition.code | DeviceRequest.code.as(CodeableConcept) | AllergyIntolerance.code | AllergyIntolerance.reaction.substance | Procedure.code | List.code | ProcedureRequest.code | Observation.code | DiagnosticReport.code | Condition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'criticality', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-criticality', 'low | high | unable-to-assess', '3', 'f:AllergyIntolerance/f:criticality', 'AllergyIntolerance.criticality', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'last-date', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-last-date', 'Date(/time) of last known occurrence of a reaction', '1', 'f:AllergyIntolerance/f:lastOccurrence', 'AllergyIntolerance.lastOccurrence', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'manifestation', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-manifestation', 'Clinical symptoms/signs associated with the Event', '3', 'f:AllergyIntolerance/f:reaction/f:manifestation', 'AllergyIntolerance.reaction.manifestation', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'onset', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-onset', 'Date(/time) when manifestations showed', '1', 'f:AllergyIntolerance/f:reaction/f:onset', 'AllergyIntolerance.reaction.onset', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'recorder', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-recorder', 'Who recorded the sensitivity', '4', 'f:AllergyIntolerance/f:recorder', 'AllergyIntolerance.recorder', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'route', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-route', 'How the subject was exposed to the substance', '3', 'f:AllergyIntolerance/f:reaction/f:exposureRoute', 'AllergyIntolerance.reaction.exposureRoute', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'severity', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-severity', 'mild | moderate | severe (of event as a whole)', '3', 'f:AllergyIntolerance/f:reaction/f:severity', 'AllergyIntolerance.reaction.severity', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'type', 'http://hl7.org/fhir/SearchParameter/clinical-type', '', '3', 'f:ReferralRequest/f:type | f:DocumentManifest/f:type | f:DocumentReference/f:type | f:Encounter/f:type | f:AllergyIntolerance/f:type | f:EpisodeOfCare/f:type | f:Composition/f:type', 'ReferralRequest.type | DocumentManifest.type | DocumentReference.type | Encounter.type | AllergyIntolerance.type | EpisodeOfCare.type | Composition.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AllergyIntolerance', 'verification-status', 'http://hl7.org/fhir/SearchParameter/AllergyIntolerance-verification-status', 'unconfirmed | confirmed | refuted | entered-in-error', '3', 'f:AllergyIntolerance/f:verificationStatus', 'AllergyIntolerance.verificationStatus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'actor', 'http://hl7.org/fhir/SearchParameter/Appointment-actor', 'Any one of the individuals participating in the appointment', '4', 'f:Appointment/f:participant/f:actor', 'Appointment.participant.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'appointment-type', 'http://hl7.org/fhir/SearchParameter/Appointment-appointment-type', 'The style of appointment or patient that has been booked in the slot (not service type)', '3', 'f:Appointment/f:appointmentType', 'Appointment.appointmentType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'date', 'http://hl7.org/fhir/SearchParameter/Appointment-date', 'Appointment date/time.', '1', 'f:Appointment/f:start', 'Appointment.start', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'identifier', 'http://hl7.org/fhir/SearchParameter/Appointment-identifier', 'An Identifier of the Appointment', '3', 'f:Appointment/f:identifier', 'Appointment.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'incomingreferral', 'http://hl7.org/fhir/SearchParameter/Appointment-incomingreferral', 'The ReferralRequest provided as information to allocate to the Encounter', '4', 'f:Appointment/f:incomingReferral', 'Appointment.incomingReferral', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'location', 'http://hl7.org/fhir/SearchParameter/Appointment-location', 'This location is listed in the participants of the appointment', '4', 'f:Appointment/f:participant/f:actor', 'Appointment.participant.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'part-status', 'http://hl7.org/fhir/SearchParameter/Appointment-part-status', 'The Participation status of the subject, or other participant on the appointment. Can be used to locate participants that have not responded to meeting requests.', '3', 'f:Appointment/f:participant/f:status', 'Appointment.participant.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'patient', 'http://hl7.org/fhir/SearchParameter/Appointment-patient', 'One of the individuals of the appointment is this patient', '4', 'f:Appointment/f:participant/f:actor', 'Appointment.participant.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'practitioner', 'http://hl7.org/fhir/SearchParameter/Appointment-practitioner', 'One of the individuals of the appointment is this practitioner', '4', 'f:Appointment/f:participant/f:actor', 'Appointment.participant.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'service-type', 'http://hl7.org/fhir/SearchParameter/Appointment-service-type', 'The specific service that is to be performed during this appointment', '3', 'f:Appointment/f:serviceType', 'Appointment.serviceType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Appointment', 'status', 'http://hl7.org/fhir/SearchParameter/Appointment-status', 'The overall status of the appointment', '3', 'f:Appointment/f:status', 'Appointment.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AppointmentResponse', 'actor', 'http://hl7.org/fhir/SearchParameter/AppointmentResponse-actor', 'The Person, Location/HealthcareService or Device that this appointment response replies for', '4', 'f:AppointmentResponse/f:actor', 'AppointmentResponse.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AppointmentResponse', 'appointment', 'http://hl7.org/fhir/SearchParameter/AppointmentResponse-appointment', 'The appointment that the response is attached to', '4', 'f:AppointmentResponse/f:appointment', 'AppointmentResponse.appointment', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AppointmentResponse', 'identifier', 'http://hl7.org/fhir/SearchParameter/AppointmentResponse-identifier', 'An Identifier in this appointment response', '3', 'f:AppointmentResponse/f:identifier', 'AppointmentResponse.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AppointmentResponse', 'location', 'http://hl7.org/fhir/SearchParameter/AppointmentResponse-location', 'This Response is for this Location', '4', 'f:AppointmentResponse/f:actor', 'AppointmentResponse.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AppointmentResponse', 'part-status', 'http://hl7.org/fhir/SearchParameter/AppointmentResponse-part-status', 'The participants acceptance status for this appointment', '3', 'f:AppointmentResponse/f:participantStatus', 'AppointmentResponse.participantStatus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AppointmentResponse', 'patient', 'http://hl7.org/fhir/SearchParameter/AppointmentResponse-patient', 'This Response is for this Patient', '4', 'f:AppointmentResponse/f:actor', 'AppointmentResponse.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AppointmentResponse', 'practitioner', 'http://hl7.org/fhir/SearchParameter/AppointmentResponse-practitioner', 'This Response is for this Practitioner', '4', 'f:AppointmentResponse/f:actor', 'AppointmentResponse.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'action', 'http://hl7.org/fhir/SearchParameter/AuditEvent-action', 'Type of action performed during the event', '3', 'f:AuditEvent/f:action', 'AuditEvent.action', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'address', 'http://hl7.org/fhir/SearchParameter/AuditEvent-address', 'Identifier for the network access point of the user device', '2', 'f:AuditEvent/f:agent/f:network/f:address', 'AuditEvent.agent.network.address', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'agent', 'http://hl7.org/fhir/SearchParameter/AuditEvent-agent', 'Direct reference to resource', '4', 'f:AuditEvent/f:agent/f:reference', 'AuditEvent.agent.reference', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'agent-name', 'http://hl7.org/fhir/SearchParameter/AuditEvent-agent-name', 'Human-meaningful name for the agent', '2', 'f:AuditEvent/f:agent/f:name', 'AuditEvent.agent.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'agent-role', 'http://hl7.org/fhir/SearchParameter/AuditEvent-agent-role', 'Agent role in the event', '3', 'f:AuditEvent/f:agent/f:role', 'AuditEvent.agent.role', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'altid', 'http://hl7.org/fhir/SearchParameter/AuditEvent-altid', 'Alternative User id e.g. authentication', '3', 'f:AuditEvent/f:agent/f:altId', 'AuditEvent.agent.altId', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'date', 'http://hl7.org/fhir/SearchParameter/AuditEvent-date', 'Time when the event occurred on source', '1', 'f:AuditEvent/f:recorded', 'AuditEvent.recorded', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'entity', 'http://hl7.org/fhir/SearchParameter/AuditEvent-entity', 'Specific instance of resource', '4', 'f:AuditEvent/f:entity/f:reference', 'AuditEvent.entity.reference', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'entity-id', 'http://hl7.org/fhir/SearchParameter/AuditEvent-entity-id', 'Specific instance of object', '3', 'f:AuditEvent/f:entity/f:identifier', 'AuditEvent.entity.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'entity-name', 'http://hl7.org/fhir/SearchParameter/AuditEvent-entity-name', 'Descriptor for entity', '2', 'f:AuditEvent/f:entity/f:name', 'AuditEvent.entity.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'entity-role', 'http://hl7.org/fhir/SearchParameter/AuditEvent-entity-role', 'What role the entity played', '3', 'f:AuditEvent/f:entity/f:role', 'AuditEvent.entity.role', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'entity-type', 'http://hl7.org/fhir/SearchParameter/AuditEvent-entity-type', 'Type of entity involved', '3', 'f:AuditEvent/f:entity/f:type', 'AuditEvent.entity.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'outcome', 'http://hl7.org/fhir/SearchParameter/AuditEvent-outcome', 'Whether the event succeeded or failed', '3', 'f:AuditEvent/f:outcome', 'AuditEvent.outcome', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'patient', 'http://hl7.org/fhir/SearchParameter/AuditEvent-patient', 'Direct reference to resource', '4', 'f:AuditEvent/f:agent/f:reference | f:AuditEvent/f:entity/f:reference', 'AuditEvent.agent.reference | AuditEvent.entity.reference', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'policy', 'http://hl7.org/fhir/SearchParameter/AuditEvent-policy', 'Policy that authorized event', '7', 'f:AuditEvent/f:agent/f:policy', 'AuditEvent.agent.policy', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'site', 'http://hl7.org/fhir/SearchParameter/AuditEvent-site', 'Logical source location within the enterprise', '3', 'f:AuditEvent/f:source/f:site', 'AuditEvent.source.site', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'source', 'http://hl7.org/fhir/SearchParameter/AuditEvent-source', 'The identity of source detecting the event', '3', 'f:AuditEvent/f:source/f:identifier', 'AuditEvent.source.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'subtype', 'http://hl7.org/fhir/SearchParameter/AuditEvent-subtype', 'More specific type/id for the event', '3', 'f:AuditEvent/f:subtype', 'AuditEvent.subtype', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'type', 'http://hl7.org/fhir/SearchParameter/AuditEvent-type', 'Type/identifier of event', '3', 'f:AuditEvent/f:type', 'AuditEvent.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('AuditEvent', 'user', 'http://hl7.org/fhir/SearchParameter/AuditEvent-user', 'Unique identifier for the user', '3', 'f:AuditEvent/f:agent/f:userId', 'AuditEvent.agent.userId', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Basic', 'author', 'http://hl7.org/fhir/SearchParameter/Basic-author', 'Who created', '4', 'f:Basic/f:author', 'Basic.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Basic', 'code', 'http://hl7.org/fhir/SearchParameter/Basic-code', 'Kind of Resource', '3', 'f:Basic/f:code', 'Basic.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Basic', 'created', 'http://hl7.org/fhir/SearchParameter/Basic-created', 'When created', '1', 'f:Basic/f:created', 'Basic.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Basic', 'identifier', 'http://hl7.org/fhir/SearchParameter/Basic-identifier', 'Business identifier', '3', 'f:Basic/f:identifier', 'Basic.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Basic', 'patient', 'http://hl7.org/fhir/SearchParameter/Basic-patient', 'Identifies the focus of this resource', '4', 'f:Basic/f:subject', 'Basic.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Basic', 'subject', 'http://hl7.org/fhir/SearchParameter/Basic-subject', 'Identifies the focus of this resource', '4', 'f:Basic/f:subject', 'Basic.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Binary', 'contenttype', 'http://hl7.org/fhir/SearchParameter/Binary-contenttype', 'MimeType of the binary content', '3', 'f:Binary/f:contentType', 'Binary.contentType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('BodySite', 'code', 'http://hl7.org/fhir/SearchParameter/BodySite-code', 'Named anatomical location', '3', 'f:BodySite/f:code', 'BodySite.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('BodySite', 'identifier', 'http://hl7.org/fhir/SearchParameter/BodySite-identifier', 'Identifier for this instance of the anatomical location', '3', 'f:BodySite/f:identifier', 'BodySite.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('BodySite', 'patient', 'http://hl7.org/fhir/SearchParameter/BodySite-patient', 'Patient to whom bodysite belongs', '4', 'f:BodySite/f:patient', 'BodySite.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Bundle', 'composition', 'http://hl7.org/fhir/SearchParameter/Bundle-composition', 'The first resource in the bundle, if the bundle type is "document" - this is a composition, and this parameter provides access to searches its contents', '4', 'f:Bundle/f:entry[0]/f:resource', 'Bundle.entry[0].resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Bundle', 'identifier', 'http://hl7.org/fhir/SearchParameter/Bundle-identifier', 'Persistent identifier for the bundle', '3', 'f:Bundle/f:identifier', 'Bundle.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Bundle', 'message', 'http://hl7.org/fhir/SearchParameter/Bundle-message', 'The first resource in the bundle, if the bundle type is "message" - this is a message header, and this parameter provides access to search its contents', '4', 'f:Bundle/f:entry[0]/f:resource', 'Bundle.entry[0].resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Bundle', 'type', 'http://hl7.org/fhir/SearchParameter/Bundle-type', 'document | message | transaction | transaction-response | batch | batch-response | history | searchset | collection', '3', 'f:Bundle/f:type', 'Bundle.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'date', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-date', 'The capability statement publication date', '1', 'f:CapabilityStatement/f:date', 'CapabilityStatement.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'description', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-description', 'The description of the capability statement', '2', 'f:CapabilityStatement/f:description', 'CapabilityStatement.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'event', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-event', 'Event code in a capability statement', '3', 'f:CapabilityStatement/f:messaging/f:event/f:code', 'CapabilityStatement.messaging.event.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'fhirversion', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-fhirversion', 'The version of FHIR', '3', 'f:CapabilityStatement/f:version', 'CapabilityStatement.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'format', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-format', 'formats supported (xml | json | ttl | mime type)', '3', 'f:CapabilityStatement/f:format', 'CapabilityStatement.format', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'guide', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-guide', 'Implementation guides supported', '7', 'f:CapabilityStatement/f:implementationGuide', 'CapabilityStatement.implementationGuide', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-jurisdiction', 'Intended jurisdiction for the capability statement', '3', 'f:CapabilityStatement/f:jurisdiction', 'CapabilityStatement.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'mode', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-mode', 'Mode - restful (server/client) or messaging (sender/receiver)', '3', 'f:CapabilityStatement/f:rest/f:mode', 'CapabilityStatement.rest.mode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'name', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-name', 'Computationally friendly name of the capability statement', '2', 'f:CapabilityStatement/f:name', 'CapabilityStatement.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'publisher', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-publisher', 'Name of the publisher of the capability statement', '2', 'f:CapabilityStatement/f:publisher', 'CapabilityStatement.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'resource', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-resource', 'Name of a resource mentioned in a capability statement', '3', 'f:CapabilityStatement/f:rest/f:resource/f:type', 'CapabilityStatement.rest.resource.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'resource-profile', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-resource-profile', 'A profile id invoked in a capability statement', '4', 'f:CapabilityStatement/f:rest/f:resource/f:profile', 'CapabilityStatement.rest.resource.profile', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'security-service', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-security-service', 'OAuth | SMART-on-FHIR | NTLM | Basic | Kerberos | Certificates', '3', 'f:CapabilityStatement/f:rest/f:security/f:service', 'CapabilityStatement.rest.security.service', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'software', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-software', 'Part of a the name of a software application', '2', 'f:CapabilityStatement/f:software/f:name', 'CapabilityStatement.software.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'status', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-status', 'The current status of the capability statement', '3', 'f:CapabilityStatement/f:status', 'CapabilityStatement.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'supported-profile', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-supported-profile', 'Profiles for use cases supported', '4', 'f:CapabilityStatement/f:profile', 'CapabilityStatement.profile', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'title', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-title', 'The human-friendly name of the capability statement', '2', 'f:CapabilityStatement/f:title', 'CapabilityStatement.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'url', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-url', 'The uri that identifies the capability statement', '7', 'f:CapabilityStatement/f:url', 'CapabilityStatement.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CapabilityStatement', 'version', 'http://hl7.org/fhir/SearchParameter/CapabilityStatement-version', 'The business version of the capability statement', '3', 'f:CapabilityStatement/f:version', 'CapabilityStatement.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'activity-code', 'http://hl7.org/fhir/SearchParameter/CarePlan-activity-code', 'Detail type of activity', '3', 'f:CarePlan/f:activity/f:detail/f:code', 'CarePlan.activity.detail.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'activity-date', 'http://hl7.org/fhir/SearchParameter/CarePlan-activity-date', 'Specified date occurs within period specified by CarePlan.activity.timingSchedule', '1', 'f:CarePlan/f:activity/f:detail/f:scheduledTiming | f:CarePlan/f:activity/f:detail/f:scheduledPeriod | f:CarePlan/f:activity/f:detail/f:scheduledString', 'CarePlan.activity.detail.scheduled', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'activity-reference', 'http://hl7.org/fhir/SearchParameter/CarePlan-activity-reference', 'Activity details defined in specific resource', '4', 'f:CarePlan/f:activity/f:reference', 'CarePlan.activity.reference', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'based-on', 'http://hl7.org/fhir/SearchParameter/CarePlan-based-on', 'Fulfills care plan', '4', 'f:CarePlan/f:basedOn', 'CarePlan.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'care-team', 'http://hl7.org/fhir/SearchParameter/CarePlan-care-team', 'Who''s involved in plan?', '4', 'f:CarePlan/f:careTeam', 'CarePlan.careTeam', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'category', 'http://hl7.org/fhir/SearchParameter/CarePlan-category', 'Type of plan', '3', 'f:CarePlan/f:category', 'CarePlan.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'condition', 'http://hl7.org/fhir/SearchParameter/CarePlan-condition', 'Health issues this plan addresses', '4', 'f:CarePlan/f:addresses', 'CarePlan.addresses', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'context', 'http://hl7.org/fhir/SearchParameter/CarePlan-context', 'Created in context of', '4', 'f:CarePlan/f:context', 'CarePlan.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'definition', 'http://hl7.org/fhir/SearchParameter/CarePlan-definition', 'Protocol or definition', '4', 'f:CarePlan/f:definition', 'CarePlan.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'encounter', 'http://hl7.org/fhir/SearchParameter/CarePlan-encounter', 'Created in context of', '4', 'f:CarePlan/f:context', 'CarePlan.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'goal', 'http://hl7.org/fhir/SearchParameter/CarePlan-goal', 'Desired outcome of plan', '4', 'f:CarePlan/f:goal', 'CarePlan.goal', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'intent', 'http://hl7.org/fhir/SearchParameter/CarePlan-intent', 'proposal | plan | order | option', '3', 'f:CarePlan/f:intent', 'CarePlan.intent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'part-of', 'http://hl7.org/fhir/SearchParameter/CarePlan-part-of', 'Part of referenced CarePlan', '4', 'f:CarePlan/f:partOf', 'CarePlan.partOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'performer', 'http://hl7.org/fhir/SearchParameter/CarePlan-performer', 'Matches if the practitioner is listed as a performer in any of the "simple" activities.  (For performers of the detailed activities, chain through the activitydetail search parameter.)', '4', 'f:CarePlan/f:activity/f:detail/f:performer', 'CarePlan.activity.detail.performer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'replaces', 'http://hl7.org/fhir/SearchParameter/CarePlan-replaces', 'CarePlan replaced by this CarePlan', '4', 'f:CarePlan/f:replaces', 'CarePlan.replaces', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'status', 'http://hl7.org/fhir/SearchParameter/CarePlan-status', 'draft | active | suspended | completed | entered-in-error | cancelled | unknown', '3', 'f:CarePlan/f:status', 'CarePlan.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CarePlan', 'subject', 'http://hl7.org/fhir/SearchParameter/CarePlan-subject', 'Who care plan is for', '4', 'f:CarePlan/f:subject', 'CarePlan.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CareTeam', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CareTeam', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CareTeam', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CareTeam', 'category', 'http://hl7.org/fhir/SearchParameter/CareTeam-category', 'Type of team', '3', 'f:CareTeam/f:category', 'CareTeam.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CareTeam', 'context', 'http://hl7.org/fhir/SearchParameter/CareTeam-context', 'Encounter or episode associated with CareTeam', '4', 'f:CareTeam/f:context', 'CareTeam.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CareTeam', 'encounter', 'http://hl7.org/fhir/SearchParameter/CareTeam-encounter', 'Encounter or episode associated with CareTeam', '4', 'f:CareTeam/f:context', 'CareTeam.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CareTeam', 'participant', 'http://hl7.org/fhir/SearchParameter/CareTeam-participant', 'Who is involved', '4', 'f:CareTeam/f:participant/f:member', 'CareTeam.participant.member', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CareTeam', 'status', 'http://hl7.org/fhir/SearchParameter/CareTeam-status', 'proposed | active | suspended | inactive | entered-in-error', '3', 'f:CareTeam/f:status', 'CareTeam.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CareTeam', 'subject', 'http://hl7.org/fhir/SearchParameter/CareTeam-subject', 'Who care team is for', '4', 'f:CareTeam/f:subject', 'CareTeam.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'account', 'http://hl7.org/fhir/SearchParameter/ChargeItem-account', 'Account to place this charge', '4', 'f:ChargeItem/f:account', 'ChargeItem.account', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'code', 'http://hl7.org/fhir/SearchParameter/ChargeItem-code', 'A code that identifies the charge, like a billing code', '3', 'f:ChargeItem/f:code', 'ChargeItem.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'context', 'http://hl7.org/fhir/SearchParameter/ChargeItem-context', 'Encounter / Episode associated with event', '4', 'f:ChargeItem/f:context', 'ChargeItem.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'entered-date', 'http://hl7.org/fhir/SearchParameter/ChargeItem-entered-date', 'Date the charge item was entered', '1', 'f:ChargeItem/f:enteredDate', 'ChargeItem.enteredDate', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'enterer', 'http://hl7.org/fhir/SearchParameter/ChargeItem-enterer', 'Individual who was entering', '4', 'f:ChargeItem/f:enterer', 'ChargeItem.enterer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'factor-override', 'http://hl7.org/fhir/SearchParameter/ChargeItem-factor-override', 'Factor overriding the associated rules', '0', 'f:ChargeItem/f:factorOverride', 'ChargeItem.factorOverride', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'identifier', 'http://hl7.org/fhir/SearchParameter/ChargeItem-identifier', 'Business Identifier for item', '3', 'f:ChargeItem/f:identifier', 'ChargeItem.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'occurrence', 'http://hl7.org/fhir/SearchParameter/ChargeItem-occurrence', 'When the charged service was applied', '1', 'f:ChargeItem/f:occurrenceDateTime | f:ChargeItem/f:occurrencePeriod | f:ChargeItem/f:occurrenceTiming', 'ChargeItem.occurrence', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'participant-actor', 'http://hl7.org/fhir/SearchParameter/ChargeItem-participant-actor', 'Individual who was performing', '4', 'f:ChargeItem/f:participant/f:actor', 'ChargeItem.participant.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'participant-role', 'http://hl7.org/fhir/SearchParameter/ChargeItem-participant-role', 'What type of performance was done', '3', 'f:ChargeItem/f:participant/f:role', 'ChargeItem.participant.role', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'patient', 'http://hl7.org/fhir/SearchParameter/ChargeItem-patient', 'Individual service was done for/to', '4', 'f:ChargeItem/f:subject', 'ChargeItem.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'performing-organization', 'http://hl7.org/fhir/SearchParameter/ChargeItem-performing-organization', 'Organization providing the charged sevice', '4', 'f:ChargeItem/f:performingOrganization', 'ChargeItem.performingOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'price-override', 'http://hl7.org/fhir/SearchParameter/ChargeItem-price-override', 'Price overriding the associated rules', '6', 'f:ChargeItem/f:priceOverride', 'ChargeItem.priceOverride', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'quantity', 'http://hl7.org/fhir/SearchParameter/ChargeItem-quantity', 'Quantity of which the charge item has been serviced', '6', 'f:ChargeItem/f:quantity', 'ChargeItem.quantity', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'requesting-organization', 'http://hl7.org/fhir/SearchParameter/ChargeItem-requesting-organization', 'Organization requesting the charged service', '4', 'f:ChargeItem/f:requestingOrganization', 'ChargeItem.requestingOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'service', 'http://hl7.org/fhir/SearchParameter/ChargeItem-service', 'Which rendered service is being charged?', '4', 'f:ChargeItem/f:service', 'ChargeItem.service', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ChargeItem', 'subject', 'http://hl7.org/fhir/SearchParameter/ChargeItem-subject', 'Individual service was done for/to', '4', 'f:ChargeItem/f:subject', 'ChargeItem.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'care-team', 'http://hl7.org/fhir/SearchParameter/Claim-care-team', 'Member of the CareTeam', '4', 'f:Claim/f:careTeam/f:provider', 'Claim.careTeam.provider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'created', 'http://hl7.org/fhir/SearchParameter/Claim-created', 'The creation date for the Claim', '1', 'f:Claim/f:created', 'Claim.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'encounter', 'http://hl7.org/fhir/SearchParameter/Claim-encounter', 'Encounters associated with a billed line item', '4', 'f:Claim/f:item/f:encounter', 'Claim.item.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'enterer', 'http://hl7.org/fhir/SearchParameter/Claim-enterer', 'The party responsible for the entry of the Claim', '4', 'f:Claim/f:enterer', 'Claim.enterer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'facility', 'http://hl7.org/fhir/SearchParameter/Claim-facility', 'Facility responsible for the goods and services', '4', 'f:Claim/f:facility', 'Claim.facility', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'identifier', 'http://hl7.org/fhir/SearchParameter/Claim-identifier', 'The primary identifier of the financial resource', '3', 'f:Claim/f:identifier', 'Claim.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'insurer', 'http://hl7.org/fhir/SearchParameter/Claim-insurer', 'The target payor/insurer for the Claim', '4', 'f:Claim/f:insurer', 'Claim.insurer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'organization', 'http://hl7.org/fhir/SearchParameter/Claim-organization', 'The reference to the providing organization', '4', 'f:Claim/f:organization', 'Claim.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'patient', 'http://hl7.org/fhir/SearchParameter/Claim-patient', 'Patient receiving the services', '4', 'f:Claim/f:patient', 'Claim.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'payee', 'http://hl7.org/fhir/SearchParameter/Claim-payee', 'The party receiving any payment for the Claim', '4', 'f:Claim/f:payee/f:party', 'Claim.payee.party', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'priority', 'http://hl7.org/fhir/SearchParameter/Claim-priority', 'Processing priority requested', '3', 'f:Claim/f:priority', 'Claim.priority', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'provider', 'http://hl7.org/fhir/SearchParameter/Claim-provider', 'Provider responsible for the Claim', '4', 'f:Claim/f:provider', 'Claim.provider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Claim', 'use', 'http://hl7.org/fhir/SearchParameter/Claim-use', 'The kind of financial resource', '3', 'f:Claim/f:use', 'Claim.use', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClaimResponse', 'created', 'http://hl7.org/fhir/SearchParameter/ClaimResponse-created', 'The creation date', '1', 'f:ClaimResponse/f:created', 'ClaimResponse.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClaimResponse', 'disposition', 'http://hl7.org/fhir/SearchParameter/ClaimResponse-disposition', 'The contents of the disposition message', '2', 'f:ClaimResponse/f:disposition', 'ClaimResponse.disposition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClaimResponse', 'identifier', 'http://hl7.org/fhir/SearchParameter/ClaimResponse-identifier', 'The identity of the claimresponse', '3', 'f:ClaimResponse/f:identifier', 'ClaimResponse.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClaimResponse', 'insurer', 'http://hl7.org/fhir/SearchParameter/ClaimResponse-insurer', 'The organization who generated this resource', '4', 'f:ClaimResponse/f:insurer', 'ClaimResponse.insurer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClaimResponse', 'outcome', 'http://hl7.org/fhir/SearchParameter/ClaimResponse-outcome', 'The processing outcome', '3', 'f:ClaimResponse/f:outcome', 'ClaimResponse.outcome', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClaimResponse', 'patient', 'http://hl7.org/fhir/SearchParameter/ClaimResponse-patient', 'The subject of care.', '4', 'f:ClaimResponse/f:patient', 'ClaimResponse.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClaimResponse', 'payment-date', 'http://hl7.org/fhir/SearchParameter/ClaimResponse-payment-date', 'The expected paymentDate', '1', 'f:ClaimResponse/f:payment/f:date', 'ClaimResponse.payment.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClaimResponse', 'request', 'http://hl7.org/fhir/SearchParameter/ClaimResponse-request', 'The claim reference', '4', 'f:ClaimResponse/f:request', 'ClaimResponse.request', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClaimResponse', 'request-provider', 'http://hl7.org/fhir/SearchParameter/ClaimResponse-request-provider', 'The Provider of the claim', '4', 'f:ClaimResponse/f:requestProvider', 'ClaimResponse.requestProvider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'action', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-action', 'Action taken as part of assessment procedure', '4', 'f:ClinicalImpression/f:action', 'ClinicalImpression.action', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'assessor', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-assessor', 'The clinician performing the assessment', '4', 'f:ClinicalImpression/f:assessor', 'ClinicalImpression.assessor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'context', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-context', 'Encounter or Episode created from', '4', 'f:ClinicalImpression/f:context', 'ClinicalImpression.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'finding-code', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-finding-code', 'What was found', '3', 'f:ClinicalImpression/f:finding/f:itemCodeableConcept', 'ClinicalImpression.finding.item.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'finding-ref', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-finding-ref', 'What was found', '4', 'f:ClinicalImpression/f:finding/f:itemReference', 'ClinicalImpression.finding.item.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'identifier', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-identifier', 'Business identifier', '3', 'f:ClinicalImpression/f:identifier', 'ClinicalImpression.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'investigation', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-investigation', 'Record of a specific investigation', '4', 'f:ClinicalImpression/f:investigation/f:item', 'ClinicalImpression.investigation.item', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'previous', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-previous', 'Reference to last assessment', '4', 'f:ClinicalImpression/f:previous', 'ClinicalImpression.previous', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'problem', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-problem', 'Relevant impressions of patient state', '4', 'f:ClinicalImpression/f:problem', 'ClinicalImpression.problem', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'status', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-status', 'draft | completed | entered-in-error', '3', 'f:ClinicalImpression/f:status', 'ClinicalImpression.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ClinicalImpression', 'subject', 'http://hl7.org/fhir/SearchParameter/ClinicalImpression-subject', 'Patient or group assessed', '4', 'f:ClinicalImpression/f:subject', 'ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'code', 'http://hl7.org/fhir/SearchParameter/CodeSystem-code', 'A code defined in the code system', '3', 'f:CodeSystem/f:concept/f:code', 'CodeSystem.concept.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'content-mode', 'http://hl7.org/fhir/SearchParameter/CodeSystem-content-mode', 'not-present | example | fragment | complete', '3', 'f:CodeSystem/f:content', 'CodeSystem.content', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'date', 'http://hl7.org/fhir/SearchParameter/CodeSystem-date', 'The code system publication date', '1', 'f:CodeSystem/f:date', 'CodeSystem.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'description', 'http://hl7.org/fhir/SearchParameter/CodeSystem-description', 'The description of the code system', '2', 'f:CodeSystem/f:description', 'CodeSystem.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'identifier', 'http://hl7.org/fhir/SearchParameter/CodeSystem-identifier', 'External identifier for the code system', '3', 'f:CodeSystem/f:identifier', 'CodeSystem.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/CodeSystem-jurisdiction', 'Intended jurisdiction for the code system', '3', 'f:CodeSystem/f:jurisdiction', 'CodeSystem.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'language', 'http://hl7.org/fhir/SearchParameter/CodeSystem-language', 'A language in which a designation is provided', '3', 'f:CodeSystem/f:concept/f:designation/f:language', 'CodeSystem.concept.designation.language', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'name', 'http://hl7.org/fhir/SearchParameter/CodeSystem-name', 'Computationally friendly name of the code system', '2', 'f:CodeSystem/f:name', 'CodeSystem.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'publisher', 'http://hl7.org/fhir/SearchParameter/CodeSystem-publisher', 'Name of the publisher of the code system', '2', 'f:CodeSystem/f:publisher', 'CodeSystem.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'status', 'http://hl7.org/fhir/SearchParameter/CodeSystem-status', 'The current status of the code system', '3', 'f:CodeSystem/f:status', 'CodeSystem.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'system', 'http://hl7.org/fhir/SearchParameter/CodeSystem-system', 'The system for any codes defined by this code system (same as ''url'')', '7', 'f:CodeSystem/f:url', 'CodeSystem.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'title', 'http://hl7.org/fhir/SearchParameter/CodeSystem-title', 'The human-friendly name of the code system', '2', 'f:CodeSystem/f:title', 'CodeSystem.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'url', 'http://hl7.org/fhir/SearchParameter/CodeSystem-url', 'The uri that identifies the code system', '7', 'f:CodeSystem/f:url', 'CodeSystem.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CodeSystem', 'version', 'http://hl7.org/fhir/SearchParameter/CodeSystem-version', 'The business version of the code system', '3', 'f:CodeSystem/f:version', 'CodeSystem.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'based-on', 'http://hl7.org/fhir/SearchParameter/Communication-based-on', 'Request fulfilled by this communication', '4', 'f:Communication/f:basedOn', 'Communication.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'category', 'http://hl7.org/fhir/SearchParameter/Communication-category', 'Message category', '3', 'f:Communication/f:category', 'Communication.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'context', 'http://hl7.org/fhir/SearchParameter/Communication-context', 'Encounter or episode leading to message', '4', 'f:Communication/f:context', 'Communication.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'definition', 'http://hl7.org/fhir/SearchParameter/Communication-definition', 'Instantiates protocol or definition', '4', 'f:Communication/f:definition', 'Communication.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'encounter', 'http://hl7.org/fhir/SearchParameter/Communication-encounter', 'Encounter leading to message', '4', 'f:Communication/f:context', 'Communication.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'identifier', 'http://hl7.org/fhir/SearchParameter/Communication-identifier', 'Unique identifier', '3', 'f:Communication/f:identifier', 'Communication.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'medium', 'http://hl7.org/fhir/SearchParameter/Communication-medium', 'A channel of communication', '3', 'f:Communication/f:medium', 'Communication.medium', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'part-of', 'http://hl7.org/fhir/SearchParameter/Communication-part-of', 'Part of this action', '4', 'f:Communication/f:partOf', 'Communication.partOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'patient', 'http://hl7.org/fhir/SearchParameter/Communication-patient', 'Focus of message', '4', 'f:Communication/f:subject', 'Communication.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'received', 'http://hl7.org/fhir/SearchParameter/Communication-received', 'When received', '1', 'f:Communication/f:received', 'Communication.received', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'recipient', 'http://hl7.org/fhir/SearchParameter/Communication-recipient', 'Message recipient', '4', 'f:Communication/f:recipient', 'Communication.recipient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'sender', 'http://hl7.org/fhir/SearchParameter/Communication-sender', 'Message sender', '4', 'f:Communication/f:sender', 'Communication.sender', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'sent', 'http://hl7.org/fhir/SearchParameter/Communication-sent', 'When sent', '1', 'f:Communication/f:sent', 'Communication.sent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'status', 'http://hl7.org/fhir/SearchParameter/Communication-status', 'preparation | in-progress | suspended | aborted | completed | entered-in-error', '3', 'f:Communication/f:status', 'Communication.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Communication', 'subject', 'http://hl7.org/fhir/SearchParameter/Communication-subject', 'Focus of message', '4', 'f:Communication/f:subject', 'Communication.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'authored', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-authored', 'When request transitioned to being actionable', '1', 'f:CommunicationRequest/f:authoredOn', 'CommunicationRequest.authoredOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'based-on', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-based-on', 'Fulfills plan or proposal', '4', 'f:CommunicationRequest/f:basedOn', 'CommunicationRequest.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'category', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-category', 'Message category', '3', 'f:CommunicationRequest/f:category', 'CommunicationRequest.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'context', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-context', 'Encounter or episode leading to message', '4', 'f:CommunicationRequest/f:context', 'CommunicationRequest.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'encounter', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-encounter', 'Encounter leading to message', '4', 'f:CommunicationRequest/f:context', 'CommunicationRequest.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'group-identifier', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-group-identifier', 'Composite request this is part of', '3', 'f:CommunicationRequest/f:groupIdentifier', 'CommunicationRequest.groupIdentifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'identifier', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-identifier', 'Unique identifier', '3', 'f:CommunicationRequest/f:identifier', 'CommunicationRequest.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'medium', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-medium', 'A channel of communication', '3', 'f:CommunicationRequest/f:medium', 'CommunicationRequest.medium', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'occurrence', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-occurrence', 'When scheduled', '1', 'f:CommunicationRequest/f:occurrenceDateTime', 'CommunicationRequest.occurrence.as(DateTime)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'patient', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-patient', 'Focus of message', '4', 'f:CommunicationRequest/f:subject', 'CommunicationRequest.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'priority', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-priority', 'Message urgency', '3', 'f:CommunicationRequest/f:priority', 'CommunicationRequest.priority', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'recipient', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-recipient', 'Message recipient', '4', 'f:CommunicationRequest/f:recipient', 'CommunicationRequest.recipient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'replaces', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-replaces', 'Request(s) replaced by this request', '4', 'f:CommunicationRequest/f:replaces', 'CommunicationRequest.replaces', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'requester', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-requester', 'Individual making the request', '4', 'f:CommunicationRequest/f:requester/f:agent', 'CommunicationRequest.requester.agent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'sender', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-sender', 'Message sender', '4', 'f:CommunicationRequest/f:sender', 'CommunicationRequest.sender', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'status', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-status', 'draft | active | suspended | cancelled | completed | entered-in-error | unknown', '3', 'f:CommunicationRequest/f:status', 'CommunicationRequest.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CommunicationRequest', 'subject', 'http://hl7.org/fhir/SearchParameter/CommunicationRequest-subject', 'Focus of message', '4', 'f:CommunicationRequest/f:subject', 'CommunicationRequest.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'code', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-code', 'Patient | Encounter | RelatedPerson | Practitioner | Device', '3', 'f:CompartmentDefinition/f:code', 'CompartmentDefinition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'date', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-date', 'The compartment definition publication date', '1', 'f:CompartmentDefinition/f:date', 'CompartmentDefinition.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'description', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-description', 'The description of the compartment definition', '2', 'f:CompartmentDefinition/f:description', 'CompartmentDefinition.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-jurisdiction', 'Intended jurisdiction for the compartment definition', '3', 'f:CompartmentDefinition/f:jurisdiction', 'CompartmentDefinition.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'name', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-name', 'Computationally friendly name of the compartment definition', '2', 'f:CompartmentDefinition/f:name', 'CompartmentDefinition.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'publisher', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-publisher', 'Name of the publisher of the compartment definition', '2', 'f:CompartmentDefinition/f:publisher', 'CompartmentDefinition.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'resource', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-resource', 'Name of resource type', '3', 'f:CompartmentDefinition/f:resource/f:code', 'CompartmentDefinition.resource.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'status', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-status', 'The current status of the compartment definition', '3', 'f:CompartmentDefinition/f:status', 'CompartmentDefinition.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'title', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-title', 'The human-friendly name of the compartment definition', '2', 'f:CompartmentDefinition/f:title', 'CompartmentDefinition.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('CompartmentDefinition', 'url', 'http://hl7.org/fhir/SearchParameter/CompartmentDefinition-url', 'The uri that identifies the compartment definition', '7', 'f:CompartmentDefinition/f:url', 'CompartmentDefinition.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'type', 'http://hl7.org/fhir/SearchParameter/clinical-type', '', '3', 'f:ReferralRequest/f:type | f:DocumentManifest/f:type | f:DocumentReference/f:type | f:Encounter/f:type | f:AllergyIntolerance/f:type | f:EpisodeOfCare/f:type | f:Composition/f:type', 'ReferralRequest.type | DocumentManifest.type | DocumentReference.type | Encounter.type | AllergyIntolerance.type | EpisodeOfCare.type | Composition.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'attester', 'http://hl7.org/fhir/SearchParameter/Composition-attester', 'Who attested the composition', '4', 'f:Composition/f:attester/f:party', 'Composition.attester.party', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'author', 'http://hl7.org/fhir/SearchParameter/Composition-author', 'Who and/or what authored the composition', '4', 'f:Composition/f:author', 'Composition.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'class', 'http://hl7.org/fhir/SearchParameter/Composition-class', 'Categorization of Composition', '3', 'f:Composition/f:class', 'Composition.class', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'confidentiality', 'http://hl7.org/fhir/SearchParameter/Composition-confidentiality', 'As defined by affinity domain', '3', 'f:Composition/f:confidentiality', 'Composition.confidentiality', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'context', 'http://hl7.org/fhir/SearchParameter/Composition-context', 'Code(s) that apply to the event being documented', '3', 'f:Composition/f:event/f:code', 'Composition.event.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'entry', 'http://hl7.org/fhir/SearchParameter/Composition-entry', 'A reference to data that supports this section', '4', 'f:Composition/f:section/f:entry', 'Composition.section.entry', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'period', 'http://hl7.org/fhir/SearchParameter/Composition-period', 'The period covered by the documentation', '1', 'f:Composition/f:event/f:period', 'Composition.event.period', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'related-id', 'http://hl7.org/fhir/SearchParameter/Composition-related-id', 'Target of the relationship', '3', 'f:Composition/f:relatesTo/f:targetIdentifier', 'Composition.relatesTo.target.as(Identifier)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'related-ref', 'http://hl7.org/fhir/SearchParameter/Composition-related-ref', 'Target of the relationship', '4', 'f:Composition/f:relatesTo/f:targetReference', 'Composition.relatesTo.target.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'section', 'http://hl7.org/fhir/SearchParameter/Composition-section', 'Classification of section (recommended)', '3', 'f:Composition/f:section/f:code', 'Composition.section.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'status', 'http://hl7.org/fhir/SearchParameter/Composition-status', 'preliminary | final | amended | entered-in-error', '3', 'f:Composition/f:status', 'Composition.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'subject', 'http://hl7.org/fhir/SearchParameter/Composition-subject', 'Who and/or what the composition is about', '4', 'f:Composition/f:subject', 'Composition.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Composition', 'title', 'http://hl7.org/fhir/SearchParameter/Composition-title', 'Human Readable name/title', '2', 'f:Composition/f:title', 'Composition.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'date', 'http://hl7.org/fhir/SearchParameter/ConceptMap-date', 'The concept map publication date', '1', 'f:ConceptMap/f:date', 'ConceptMap.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'dependson', 'http://hl7.org/fhir/SearchParameter/ConceptMap-dependson', 'Reference to property mapping depends on', '7', 'f:ConceptMap/f:group/f:element/f:target/f:dependsOn/f:property', 'ConceptMap.group.element.target.dependsOn.property', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'description', 'http://hl7.org/fhir/SearchParameter/ConceptMap-description', 'The description of the concept map', '2', 'f:ConceptMap/f:description', 'ConceptMap.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'identifier', 'http://hl7.org/fhir/SearchParameter/ConceptMap-identifier', 'External identifier for the concept map', '3', 'f:ConceptMap/f:identifier', 'ConceptMap.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/ConceptMap-jurisdiction', 'Intended jurisdiction for the concept map', '3', 'f:ConceptMap/f:jurisdiction', 'ConceptMap.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'name', 'http://hl7.org/fhir/SearchParameter/ConceptMap-name', 'Computationally friendly name of the concept map', '2', 'f:ConceptMap/f:name', 'ConceptMap.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'other', 'http://hl7.org/fhir/SearchParameter/ConceptMap-other', 'Canonical URL for other concept map', '7', 'f:ConceptMap/f:group/f:unmapped/f:url', 'ConceptMap.group.unmapped.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'product', 'http://hl7.org/fhir/SearchParameter/ConceptMap-product', 'Reference to property mapping depends on', '7', 'f:ConceptMap/f:group/f:element/f:target/f:product/f:property', 'ConceptMap.group.element.target.product.property', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'publisher', 'http://hl7.org/fhir/SearchParameter/ConceptMap-publisher', 'Name of the publisher of the concept map', '2', 'f:ConceptMap/f:publisher', 'ConceptMap.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'source', 'http://hl7.org/fhir/SearchParameter/ConceptMap-source', 'Identifies the source of the concepts which are being mapped', '4', 'f:ConceptMap/f:sourceReference', 'ConceptMap.source.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'source-code', 'http://hl7.org/fhir/SearchParameter/ConceptMap-source-code', 'Identifies element being mapped', '3', 'f:ConceptMap/f:group/f:element/f:code', 'ConceptMap.group.element.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'source-system', 'http://hl7.org/fhir/SearchParameter/ConceptMap-source-system', 'Code System (if value set crosses code systems)', '7', 'f:ConceptMap/f:group/f:source', 'ConceptMap.group.source', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'source-uri', 'http://hl7.org/fhir/SearchParameter/ConceptMap-source-uri', 'Identifies the source of the concepts which are being mapped', '4', 'f:ConceptMap/f:sourceUri', 'ConceptMap.source.as(Uri)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'status', 'http://hl7.org/fhir/SearchParameter/ConceptMap-status', 'The current status of the concept map', '3', 'f:ConceptMap/f:status', 'ConceptMap.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'target', 'http://hl7.org/fhir/SearchParameter/ConceptMap-target', 'Provides context to the mappings', '4', 'f:ConceptMap/f:targetReference', 'ConceptMap.target.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'target-code', 'http://hl7.org/fhir/SearchParameter/ConceptMap-target-code', 'Code that identifies the target element', '3', 'f:ConceptMap/f:group/f:element/f:target/f:code', 'ConceptMap.group.element.target.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'target-system', 'http://hl7.org/fhir/SearchParameter/ConceptMap-target-system', 'System of the target (if necessary)', '7', 'f:ConceptMap/f:group/f:target', 'ConceptMap.group.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'target-uri', 'http://hl7.org/fhir/SearchParameter/ConceptMap-target-uri', 'Provides context to the mappings', '4', 'f:ConceptMap/f:targetUri', 'ConceptMap.target.as(Uri)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'title', 'http://hl7.org/fhir/SearchParameter/ConceptMap-title', 'The human-friendly name of the concept map', '2', 'f:ConceptMap/f:title', 'ConceptMap.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'url', 'http://hl7.org/fhir/SearchParameter/ConceptMap-url', 'The uri that identifies the concept map', '7', 'f:ConceptMap/f:url', 'ConceptMap.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ConceptMap', 'version', 'http://hl7.org/fhir/SearchParameter/ConceptMap-version', 'The business version of the concept map', '3', 'f:ConceptMap/f:version', 'ConceptMap.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'code', 'http://hl7.org/fhir/SearchParameter/clinical-code', '', '3', 'f:FamilyMemberHistory/f:condition/f:code | f:DeviceRequest/f:codeCodeableConcept | f:AllergyIntolerance/f:code | f:AllergyIntolerance/f:reaction/f:substance | f:Procedure/f:code | f:List/f:code | f:ProcedureRequest/f:code | f:Observation/f:code | f:DiagnosticReport/f:code | f:Condition/f:code', 'FamilyMemberHistory.condition.code | DeviceRequest.code.as(CodeableConcept) | AllergyIntolerance.code | AllergyIntolerance.reaction.substance | Procedure.code | List.code | ProcedureRequest.code | Observation.code | DiagnosticReport.code | Condition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'abatement-age', 'http://hl7.org/fhir/SearchParameter/Condition-abatement-age', 'Abatement as age or age range', '6', 'f:Condition/f:abatementAge | f:Condition/f:abatementRange', 'Condition.abatement.as(Age) | Condition.abatement.as(Range) | Condition.abatement.as(Age)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'abatement-boolean', 'http://hl7.org/fhir/SearchParameter/Condition-abatement-boolean', 'Abatement boolean (boolean is true or non-boolean values are present)', '3', 'f:Condition/f:abatementDateTime | f:Condition/f:abatementAge | f:Condition/f:abatementBoolean | f:Condition/f:abatementPeriod | f:Condition/f:abatementRange | f:Condition/f:abatementString', 'Condition.abatement.as(boolean) | Condition.abatement.is(dateTime) | Condition.abatement.is(Age) | Condition.abatement.is(Period) | Condition.abatement.is(Range) | Condition.abatement.is(string)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'abatement-date', 'http://hl7.org/fhir/SearchParameter/Condition-abatement-date', 'Date-related abatements (dateTime and period)', '1', 'f:Condition/f:abatementDateTime | f:Condition/f:abatementPeriod', 'Condition.abatement.as(dateTime) | Condition.abatement.as(Period)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'abatement-string', 'http://hl7.org/fhir/SearchParameter/Condition-abatement-string', 'Abatement as a string', '2', 'f:Condition/f:abatementString', 'Condition.abatement.as(string)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'asserted-date', 'http://hl7.org/fhir/SearchParameter/Condition-asserted-date', 'Date record was believed accurate', '1', 'f:Condition/f:assertedDate', 'Condition.assertedDate', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'asserter', 'http://hl7.org/fhir/SearchParameter/Condition-asserter', 'Person who asserts this condition', '4', 'f:Condition/f:asserter', 'Condition.asserter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'body-site', 'http://hl7.org/fhir/SearchParameter/Condition-body-site', 'Anatomical location, if relevant', '3', 'f:Condition/f:bodySite', 'Condition.bodySite', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'category', 'http://hl7.org/fhir/SearchParameter/Condition-category', 'The category of the condition', '3', 'f:Condition/f:category', 'Condition.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'clinical-status', 'http://hl7.org/fhir/SearchParameter/Condition-clinical-status', 'The clinical status of the condition', '3', 'f:Condition/f:clinicalStatus', 'Condition.clinicalStatus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'context', 'http://hl7.org/fhir/SearchParameter/Condition-context', 'Encounter or episode when condition first asserted', '4', 'f:Condition/f:context', 'Condition.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'encounter', 'http://hl7.org/fhir/SearchParameter/Condition-encounter', 'Encounter when condition first asserted', '4', 'f:Condition/f:context', 'Condition.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'evidence', 'http://hl7.org/fhir/SearchParameter/Condition-evidence', 'Manifestation/symptom', '3', 'f:Condition/f:evidence/f:code', 'Condition.evidence.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'evidence-detail', 'http://hl7.org/fhir/SearchParameter/Condition-evidence-detail', 'Supporting information found elsewhere', '4', 'f:Condition/f:evidence/f:detail', 'Condition.evidence.detail', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'onset-age', 'http://hl7.org/fhir/SearchParameter/Condition-onset-age', 'Onsets as age or age range', '6', 'f:Condition/f:onsetAge | f:Condition/f:onsetRange', 'Condition.onset.as(Age) | Condition.onset.as(Range)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'onset-date', 'http://hl7.org/fhir/SearchParameter/Condition-onset-date', 'Date related onsets (dateTime and Period)', '1', 'f:Condition/f:onsetDateTime | f:Condition/f:onsetPeriod', 'Condition.onset.as(dateTime) | Condition.onset.as(Period)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'onset-info', 'http://hl7.org/fhir/SearchParameter/Condition-onset-info', 'Onsets as a string', '2', 'f:Condition/f:onsetString', 'Condition.onset.as(string)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'severity', 'http://hl7.org/fhir/SearchParameter/Condition-severity', 'The severity of the condition', '3', 'f:Condition/f:severity', 'Condition.severity', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'stage', 'http://hl7.org/fhir/SearchParameter/Condition-stage', 'Simple summary (disease specific)', '3', 'f:Condition/f:stage/f:summary', 'Condition.stage.summary', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'subject', 'http://hl7.org/fhir/SearchParameter/Condition-subject', 'Who has the condition?', '4', 'f:Condition/f:subject', 'Condition.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Condition', 'verification-status', 'http://hl7.org/fhir/SearchParameter/Condition-verification-status', 'provisional | differential | confirmed | refuted | entered-in-error | unknown', '3', 'f:Condition/f:verificationStatus', 'Condition.verificationStatus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'action', 'http://hl7.org/fhir/SearchParameter/Consent-action', 'Actions controlled by this consent', '3', 'f:Consent/f:action | f:Consent/f:except/f:action', 'Consent.action | Consent.except.action', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'actor', 'http://hl7.org/fhir/SearchParameter/Consent-actor', 'Resource for the actor (or group, by role)', '4', 'f:Consent/f:actor/f:reference | f:Consent/f:except/f:actor/f:reference', 'Consent.actor.reference | Consent.except.actor.reference', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'category', 'http://hl7.org/fhir/SearchParameter/Consent-category', 'Classification of the consent statement - for indexing/retrieval', '3', 'f:Consent/f:category', 'Consent.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'consentor', 'http://hl7.org/fhir/SearchParameter/Consent-consentor', 'Who is agreeing to the policy and exceptions', '4', 'f:Consent/f:consentingParty', 'Consent.consentingParty', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'data', 'http://hl7.org/fhir/SearchParameter/Consent-data', 'The actual data reference', '4', 'f:Consent/f:data/f:reference | f:Consent/f:except/f:data/f:reference', 'Consent.data.reference | Consent.except.data.reference', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'organization', 'http://hl7.org/fhir/SearchParameter/Consent-organization', 'Custodian of the consent', '4', 'f:Consent/f:organization', 'Consent.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'period', 'http://hl7.org/fhir/SearchParameter/Consent-period', 'Period that this consent applies', '1', 'f:Consent/f:period', 'Consent.period', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'purpose', 'http://hl7.org/fhir/SearchParameter/Consent-purpose', 'Context of activities for which the agreement is made', '3', 'f:Consent/f:purpose | f:Consent/f:except/f:purpose', 'Consent.purpose | Consent.except.purpose', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'securitylabel', 'http://hl7.org/fhir/SearchParameter/Consent-securitylabel', 'Security Labels that define affected resources', '3', 'f:Consent/f:securityLabel | f:Consent/f:except/f:securityLabel', 'Consent.securityLabel | Consent.except.securityLabel', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'source', 'http://hl7.org/fhir/SearchParameter/Consent-source', 'Source from which this consent is taken', '4', 'f:Consent/f:sourceAttachment | f:Consent/f:sourceIdentifier | f:Consent/f:sourceReference', 'Consent.source', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Consent', 'status', 'http://hl7.org/fhir/SearchParameter/Consent-status', 'draft | proposed | active | rejected | inactive | entered-in-error', '3', 'f:Consent/f:status', 'Consent.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Contract', 'agent', 'http://hl7.org/fhir/SearchParameter/Contract-agent', 'Agent to the Contact', '4', 'f:Contract/f:agent/f:actor', 'Contract.agent.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Contract', 'authority', 'http://hl7.org/fhir/SearchParameter/Contract-authority', 'The authority of the contract', '4', 'f:Contract/f:authority', 'Contract.authority', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Contract', 'domain', 'http://hl7.org/fhir/SearchParameter/Contract-domain', 'The domain of the contract', '4', 'f:Contract/f:domain', 'Contract.domain', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Contract', 'identifier', 'http://hl7.org/fhir/SearchParameter/Contract-identifier', 'The identity of the contract', '3', 'f:Contract/f:identifier', 'Contract.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Contract', 'issued', 'http://hl7.org/fhir/SearchParameter/Contract-issued', 'The date/time the contract was issued', '1', 'f:Contract/f:issued', 'Contract.issued', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Contract', 'patient', 'http://hl7.org/fhir/SearchParameter/Contract-patient', 'The identity of the subject of the contract (if a patient)', '4', 'f:Contract/f:subject', 'Contract.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Contract', 'signer', 'http://hl7.org/fhir/SearchParameter/Contract-signer', 'Contract Signatory Party', '4', 'f:Contract/f:signer/f:party', 'Contract.signer.party', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Contract', 'subject', 'http://hl7.org/fhir/SearchParameter/Contract-subject', 'The identity of the subject of the contract', '4', 'f:Contract/f:subject', 'Contract.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Contract', 'term-topic', 'http://hl7.org/fhir/SearchParameter/Contract-term-topic', 'The identity of the topic of the contract terms', '4', 'f:Contract/f:term/f:topic', 'Contract.term.topic', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'beneficiary', 'http://hl7.org/fhir/SearchParameter/Coverage-beneficiary', 'Covered party', '4', 'f:Coverage/f:beneficiary', 'Coverage.beneficiary', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'class', 'http://hl7.org/fhir/SearchParameter/Coverage-class', 'Class identifier', '2', 'f:Coverage/f:grouping/f:class', 'Coverage.grouping.class', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'dependent', 'http://hl7.org/fhir/SearchParameter/Coverage-dependent', 'Dependent number', '2', 'f:Coverage/f:dependent', 'Coverage.dependent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'group', 'http://hl7.org/fhir/SearchParameter/Coverage-group', 'Group identifier', '2', 'f:Coverage/f:grouping/f:group', 'Coverage.grouping.group', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'identifier', 'http://hl7.org/fhir/SearchParameter/Coverage-identifier', 'The primary identifier of the insured and the coverage', '3', 'f:Coverage/f:identifier', 'Coverage.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'payor', 'http://hl7.org/fhir/SearchParameter/Coverage-payor', 'The identity of the insurer or party paying for services', '4', 'f:Coverage/f:payor', 'Coverage.payor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'plan', 'http://hl7.org/fhir/SearchParameter/Coverage-plan', 'A plan or policy identifier', '2', 'f:Coverage/f:grouping/f:plan', 'Coverage.grouping.plan', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'policy-holder', 'http://hl7.org/fhir/SearchParameter/Coverage-policy-holder', 'Reference to the policyholder', '4', 'f:Coverage/f:policyHolder', 'Coverage.policyHolder', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'sequence', 'http://hl7.org/fhir/SearchParameter/Coverage-sequence', 'Sequence number', '2', 'f:Coverage/f:sequence', 'Coverage.sequence', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'subclass', 'http://hl7.org/fhir/SearchParameter/Coverage-subclass', 'Sub-class identifier', '2', 'f:Coverage/f:grouping/f:subClass', 'Coverage.grouping.subClass', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'subgroup', 'http://hl7.org/fhir/SearchParameter/Coverage-subgroup', 'Sub-group identifier', '2', 'f:Coverage/f:grouping/f:subGroup', 'Coverage.grouping.subGroup', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'subplan', 'http://hl7.org/fhir/SearchParameter/Coverage-subplan', 'Sub-plan identifier', '2', 'f:Coverage/f:grouping/f:subPlan', 'Coverage.grouping.subPlan', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'subscriber', 'http://hl7.org/fhir/SearchParameter/Coverage-subscriber', 'Reference to the subscriber', '4', 'f:Coverage/f:subscriber', 'Coverage.subscriber', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Coverage', 'type', 'http://hl7.org/fhir/SearchParameter/Coverage-type', 'The kind of coverage (health plan, auto, Workers Compensation)', '3', 'f:Coverage/f:type', 'Coverage.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'code', 'http://hl7.org/fhir/SearchParameter/DataElement-code', 'A code for the data element (server may choose to do subsumption)', '3', 'f:DataElement/f:element/f:code', 'DataElement.element.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'date', 'http://hl7.org/fhir/SearchParameter/DataElement-date', 'The data element publication date', '1', 'f:DataElement/f:date', 'DataElement.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'description', 'http://hl7.org/fhir/SearchParameter/DataElement-description', 'Text search in the description of the data element.  This corresponds to the definition of the first DataElement.element.', '2', 'f:DataElement/f:element/f:definition', 'DataElement.element.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'identifier', 'http://hl7.org/fhir/SearchParameter/DataElement-identifier', 'External identifier for the data element', '3', 'f:DataElement/f:identifier', 'DataElement.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/DataElement-jurisdiction', 'Intended jurisdiction for the data element', '3', 'f:DataElement/f:jurisdiction', 'DataElement.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'name', 'http://hl7.org/fhir/SearchParameter/DataElement-name', 'Computationally friendly name of the data element', '2', 'f:DataElement/f:name', 'DataElement.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'publisher', 'http://hl7.org/fhir/SearchParameter/DataElement-publisher', 'Name of the publisher of the data element', '2', 'f:DataElement/f:publisher', 'DataElement.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'status', 'http://hl7.org/fhir/SearchParameter/DataElement-status', 'The current status of the data element', '3', 'f:DataElement/f:status', 'DataElement.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'stringency', 'http://hl7.org/fhir/SearchParameter/DataElement-stringency', 'The stringency of the data element definition', '3', 'f:DataElement/f:stringency', 'DataElement.stringency', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'title', 'http://hl7.org/fhir/SearchParameter/DataElement-title', 'The human-friendly name of the data element', '2', 'f:DataElement/f:title', 'DataElement.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'url', 'http://hl7.org/fhir/SearchParameter/DataElement-url', 'The uri that identifies the data element', '7', 'f:DataElement/f:url', 'DataElement.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DataElement', 'version', 'http://hl7.org/fhir/SearchParameter/DataElement-version', 'The business version of the data element', '3', 'f:DataElement/f:version', 'DataElement.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DetectedIssue', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DetectedIssue', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DetectedIssue', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DetectedIssue', 'author', 'http://hl7.org/fhir/SearchParameter/DetectedIssue-author', 'The provider or device that identified the issue', '4', 'f:DetectedIssue/f:author', 'DetectedIssue.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DetectedIssue', 'category', 'http://hl7.org/fhir/SearchParameter/DetectedIssue-category', 'Issue Category, e.g. drug-drug, duplicate therapy, etc.', '3', 'f:DetectedIssue/f:category', 'DetectedIssue.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DetectedIssue', 'implicated', 'http://hl7.org/fhir/SearchParameter/DetectedIssue-implicated', 'Problem resource', '4', 'f:DetectedIssue/f:implicated', 'DetectedIssue.implicated', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'device-name', 'http://hl7.org/fhir/SearchParameter/Device-device-name', 'A server defined search that may match any of the string fields in the Device.udi.name  or Device.type.coding.display or  Device.type.text', '2', 'f:Device/f:udi/f:name | f:Device/f:type/f:text | f:Device/f:type/f:coding/f:display', 'Device.udi.name | Device.type.text | Device.type.coding.display', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'identifier', 'http://hl7.org/fhir/SearchParameter/Device-identifier', 'Instance id from manufacturer, owner, and others', '3', 'f:Device/f:identifier', 'Device.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'location', 'http://hl7.org/fhir/SearchParameter/Device-location', 'A location, where the resource is found', '4', 'f:Device/f:location', 'Device.location', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'manufacturer', 'http://hl7.org/fhir/SearchParameter/Device-manufacturer', 'The manufacturer of the device', '2', 'f:Device/f:manufacturer', 'Device.manufacturer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'model', 'http://hl7.org/fhir/SearchParameter/Device-model', 'The model of the device', '2', 'f:Device/f:model', 'Device.model', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'organization', 'http://hl7.org/fhir/SearchParameter/Device-organization', 'The organization responsible for the device', '4', 'f:Device/f:owner', 'Device.owner', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'patient', 'http://hl7.org/fhir/SearchParameter/Device-patient', 'Patient information, if the resource is affixed to a person', '4', 'f:Device/f:patient', 'Device.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'status', 'http://hl7.org/fhir/SearchParameter/Device-status', 'active | inactive | entered-in-error | unknown', '3', 'f:Device/f:status', 'Device.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'type', 'http://hl7.org/fhir/SearchParameter/Device-type', 'The type of the device', '3', 'f:Device/f:type', 'Device.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'udi-carrier', 'http://hl7.org/fhir/SearchParameter/Device-udi-carrier', 'UDI Barcode (RFID or other technology) string either in HRF format or AIDC format converted to base64 string.', '2', 'f:Device/f:udi/f:carrierHRF | f:Device/f:udi/f:carrierAIDC', 'Device.udi.carrierHRF | Device.udi.carrierAIDC', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'udi-di', 'http://hl7.org/fhir/SearchParameter/Device-udi-di', 'The udi Device Identifier (DI)', '2', 'f:Device/f:udi/f:deviceIdentifier', 'Device.udi.deviceIdentifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Device', 'url', 'http://hl7.org/fhir/SearchParameter/Device-url', 'Network address to contact device', '7', 'f:Device/f:url', 'Device.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceComponent', 'identifier', 'http://hl7.org/fhir/SearchParameter/DeviceComponent-identifier', 'The identifier of the component', '3', 'f:DeviceComponent/f:identifier', 'DeviceComponent.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceComponent', 'parent', 'http://hl7.org/fhir/SearchParameter/DeviceComponent-parent', 'The parent DeviceComponent resource', '4', 'f:DeviceComponent/f:parent', 'DeviceComponent.parent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceComponent', 'source', 'http://hl7.org/fhir/SearchParameter/DeviceComponent-source', 'The device source', '4', 'f:DeviceComponent/f:source', 'DeviceComponent.source', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceComponent', 'type', 'http://hl7.org/fhir/SearchParameter/DeviceComponent-type', 'The device component type', '3', 'f:DeviceComponent/f:type', 'DeviceComponent.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceMetric', 'category', 'http://hl7.org/fhir/SearchParameter/DeviceMetric-category', 'The category of the metric', '3', 'f:DeviceMetric/f:category', 'DeviceMetric.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceMetric', 'identifier', 'http://hl7.org/fhir/SearchParameter/DeviceMetric-identifier', 'The identifier of the metric', '3', 'f:DeviceMetric/f:identifier', 'DeviceMetric.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceMetric', 'parent', 'http://hl7.org/fhir/SearchParameter/DeviceMetric-parent', 'The parent DeviceMetric resource', '4', 'f:DeviceMetric/f:parent', 'DeviceMetric.parent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceMetric', 'source', 'http://hl7.org/fhir/SearchParameter/DeviceMetric-source', 'The device resource', '4', 'f:DeviceMetric/f:source', 'DeviceMetric.source', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceMetric', 'type', 'http://hl7.org/fhir/SearchParameter/DeviceMetric-type', 'The component type', '3', 'f:DeviceMetric/f:type', 'DeviceMetric.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'code', 'http://hl7.org/fhir/SearchParameter/clinical-code', '', '3', 'f:FamilyMemberHistory/f:condition/f:code | f:DeviceRequest/f:codeCodeableConcept | f:AllergyIntolerance/f:code | f:AllergyIntolerance/f:reaction/f:substance | f:Procedure/f:code | f:List/f:code | f:ProcedureRequest/f:code | f:Observation/f:code | f:DiagnosticReport/f:code | f:Condition/f:code', 'FamilyMemberHistory.condition.code | DeviceRequest.code.as(CodeableConcept) | AllergyIntolerance.code | AllergyIntolerance.reaction.substance | Procedure.code | List.code | ProcedureRequest.code | Observation.code | DiagnosticReport.code | Condition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'authored-on', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-authored-on', 'When the request transitioned to being actionable', '1', 'f:DeviceRequest/f:authoredOn', 'DeviceRequest.authoredOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'based-on', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-based-on', 'Plan/proposal/order fulfilled by this request', '4', 'f:DeviceRequest/f:basedOn', 'DeviceRequest.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'definition', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-definition', 'Protocol or definition followed by this request', '4', 'f:DeviceRequest/f:definition', 'DeviceRequest.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'device', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-device', 'Reference to resource that is being requested/ordered', '4', 'f:DeviceRequest/f:codeReference', 'DeviceRequest.code.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'event-date', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-event-date', 'When service should occur', '1', 'f:DeviceRequest/f:occurrenceDateTime | f:DeviceRequest/f:occurrencePeriod', 'DeviceRequest.occurrence.as(DateTime) | DeviceRequest.occurrence.as(Period)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'group-identifier', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-group-identifier', 'Composite request this is part of', '3', 'f:DeviceRequest/f:groupIdentifier', 'DeviceRequest.groupIdentifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'intent', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-intent', 'proposal | plan | original-order |reflex-order', '3', 'f:DeviceRequest/f:intent', 'DeviceRequest.intent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'performer', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-performer', 'Desired performer for service', '4', 'f:DeviceRequest/f:performer', 'DeviceRequest.performer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'priorrequest', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-priorrequest', 'Request takes the place of referenced completed or terminated requests', '4', 'f:DeviceRequest/f:priorRequest', 'DeviceRequest.priorRequest', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'requester', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-requester', 'Who/what is requesting service ', '4', 'f:DeviceRequest/f:requester/f:agent', 'DeviceRequest.requester.agent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'status', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-status', 'entered-in-error | draft | active |suspended | completed ', '3', 'f:DeviceRequest/f:status', 'DeviceRequest.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceRequest', 'subject', 'http://hl7.org/fhir/SearchParameter/DeviceRequest-subject', 'Individual the service is ordered for', '4', 'f:DeviceRequest/f:subject', 'DeviceRequest.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceUseStatement', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceUseStatement', 'device', 'http://hl7.org/fhir/SearchParameter/DeviceUseStatement-device', 'Search by device', '4', 'f:DeviceUseStatement/f:device', 'DeviceUseStatement.device', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceUseStatement', 'identifier', 'http://hl7.org/fhir/SearchParameter/DeviceUseStatement-identifier', 'Search by identifier', '3', 'f:DeviceUseStatement/f:identifier', 'DeviceUseStatement.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DeviceUseStatement', 'subject', 'http://hl7.org/fhir/SearchParameter/DeviceUseStatement-subject', 'Search by subject', '4', 'f:DeviceUseStatement/f:subject', 'DeviceUseStatement.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'code', 'http://hl7.org/fhir/SearchParameter/clinical-code', '', '3', 'f:FamilyMemberHistory/f:condition/f:code | f:DeviceRequest/f:codeCodeableConcept | f:AllergyIntolerance/f:code | f:AllergyIntolerance/f:reaction/f:substance | f:Procedure/f:code | f:List/f:code | f:ProcedureRequest/f:code | f:Observation/f:code | f:DiagnosticReport/f:code | f:Condition/f:code', 'FamilyMemberHistory.condition.code | DeviceRequest.code.as(CodeableConcept) | AllergyIntolerance.code | AllergyIntolerance.reaction.substance | Procedure.code | List.code | ProcedureRequest.code | Observation.code | DiagnosticReport.code | Condition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'based-on', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-based-on', 'Reference to the procedure request.', '4', 'f:DiagnosticReport/f:basedOn', 'DiagnosticReport.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'category', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-category', 'Which diagnostic discipline/department created the report', '3', 'f:DiagnosticReport/f:category', 'DiagnosticReport.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'context', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-context', 'Healthcare event (Episode of Care or Encounter) related to the report', '4', 'f:DiagnosticReport/f:context', 'DiagnosticReport.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'diagnosis', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-diagnosis', 'A coded diagnosis on the report', '3', 'f:DiagnosticReport/f:codedDiagnosis', 'DiagnosticReport.codedDiagnosis', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'image', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-image', 'A reference to the image source.', '4', 'f:DiagnosticReport/f:image/f:link', 'DiagnosticReport.image.link', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'issued', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-issued', 'When the report was issued', '1', 'f:DiagnosticReport/f:issued', 'DiagnosticReport.issued', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'performer', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-performer', 'Who was the source of the report (organization)', '4', 'f:DiagnosticReport/f:performer/f:actor', 'DiagnosticReport.performer.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'result', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-result', 'Link to an atomic result (observation resource)', '4', 'f:DiagnosticReport/f:result', 'DiagnosticReport.result', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'specimen', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-specimen', 'The specimen details', '4', 'f:DiagnosticReport/f:specimen', 'DiagnosticReport.specimen', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'status', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-status', 'The status of the report', '3', 'f:DiagnosticReport/f:status', 'DiagnosticReport.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DiagnosticReport', 'subject', 'http://hl7.org/fhir/SearchParameter/DiagnosticReport-subject', 'The subject of the report', '4', 'f:DiagnosticReport/f:subject', 'DiagnosticReport.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'type', 'http://hl7.org/fhir/SearchParameter/clinical-type', '', '3', 'f:ReferralRequest/f:type | f:DocumentManifest/f:type | f:DocumentReference/f:type | f:Encounter/f:type | f:AllergyIntolerance/f:type | f:EpisodeOfCare/f:type | f:Composition/f:type', 'ReferralRequest.type | DocumentManifest.type | DocumentReference.type | Encounter.type | AllergyIntolerance.type | EpisodeOfCare.type | Composition.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'author', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-author', 'Who and/or what authored the manifest', '4', 'f:DocumentManifest/f:author', 'DocumentManifest.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'content-ref', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-content-ref', 'Contents of this set of documents', '4', 'f:DocumentManifest/f:content/f:pReference', 'DocumentManifest.content.p.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'created', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-created', 'When this document manifest created', '1', 'f:DocumentManifest/f:created', 'DocumentManifest.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'description', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-description', 'Human-readable description (title)', '2', 'f:DocumentManifest/f:description', 'DocumentManifest.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'recipient', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-recipient', 'Intended to get notified about this set of documents', '4', 'f:DocumentManifest/f:recipient', 'DocumentManifest.recipient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'related-id', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-related-id', 'Identifiers of things that are related', '3', 'f:DocumentManifest/f:related/f:identifier', 'DocumentManifest.related.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'related-ref', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-related-ref', 'Related Resource', '4', 'f:DocumentManifest/f:related/f:ref', 'DocumentManifest.related.ref', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'source', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-source', 'The source system/application/software', '7', 'f:DocumentManifest/f:source', 'DocumentManifest.source', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'status', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-status', 'current | superseded | entered-in-error', '3', 'f:DocumentManifest/f:status', 'DocumentManifest.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentManifest', 'subject', 'http://hl7.org/fhir/SearchParameter/DocumentManifest-subject', 'The subject of the set of documents', '4', 'f:DocumentManifest/f:subject', 'DocumentManifest.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'type', 'http://hl7.org/fhir/SearchParameter/clinical-type', '', '3', 'f:ReferralRequest/f:type | f:DocumentManifest/f:type | f:DocumentReference/f:type | f:Encounter/f:type | f:AllergyIntolerance/f:type | f:EpisodeOfCare/f:type | f:Composition/f:type', 'ReferralRequest.type | DocumentManifest.type | DocumentReference.type | Encounter.type | AllergyIntolerance.type | EpisodeOfCare.type | Composition.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'authenticator', 'http://hl7.org/fhir/SearchParameter/DocumentReference-authenticator', 'Who/what authenticated the document', '4', 'f:DocumentReference/f:authenticator', 'DocumentReference.authenticator', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'author', 'http://hl7.org/fhir/SearchParameter/DocumentReference-author', 'Who and/or what authored the document', '4', 'f:DocumentReference/f:author', 'DocumentReference.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'class', 'http://hl7.org/fhir/SearchParameter/DocumentReference-class', 'Categorization of document', '3', 'f:DocumentReference/f:class', 'DocumentReference.class', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'created', 'http://hl7.org/fhir/SearchParameter/DocumentReference-created', 'Document creation time', '1', 'f:DocumentReference/f:created', 'DocumentReference.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'custodian', 'http://hl7.org/fhir/SearchParameter/DocumentReference-custodian', 'Organization which maintains the document', '4', 'f:DocumentReference/f:custodian', 'DocumentReference.custodian', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'description', 'http://hl7.org/fhir/SearchParameter/DocumentReference-description', 'Human-readable description (title)', '2', 'f:DocumentReference/f:description', 'DocumentReference.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'event', 'http://hl7.org/fhir/SearchParameter/DocumentReference-event', 'Main clinical acts documented', '3', 'f:DocumentReference/f:context/f:event', 'DocumentReference.context.event', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'facility', 'http://hl7.org/fhir/SearchParameter/DocumentReference-facility', 'Kind of facility where patient was seen', '3', 'f:DocumentReference/f:context/f:facilityType', 'DocumentReference.context.facilityType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'format', 'http://hl7.org/fhir/SearchParameter/DocumentReference-format', 'Format/content rules for the document', '3', 'f:DocumentReference/f:content/f:format', 'DocumentReference.content.format', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'indexed', 'http://hl7.org/fhir/SearchParameter/DocumentReference-indexed', 'When this document reference was created', '1', 'f:DocumentReference/f:indexed', 'DocumentReference.indexed', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'language', 'http://hl7.org/fhir/SearchParameter/DocumentReference-language', 'Human language of the content (BCP-47)', '3', 'f:DocumentReference/f:content/f:attachment/f:language', 'DocumentReference.content.attachment.language', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'location', 'http://hl7.org/fhir/SearchParameter/DocumentReference-location', 'Uri where the data can be found', '7', 'f:DocumentReference/f:content/f:attachment/f:url', 'DocumentReference.content.attachment.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'period', 'http://hl7.org/fhir/SearchParameter/DocumentReference-period', 'Time of service that is being documented', '1', 'f:DocumentReference/f:context/f:period', 'DocumentReference.context.period', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'related-id', 'http://hl7.org/fhir/SearchParameter/DocumentReference-related-id', 'Identifier of related objects or events', '3', 'f:DocumentReference/f:context/f:related/f:identifier', 'DocumentReference.context.related.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'related-ref', 'http://hl7.org/fhir/SearchParameter/DocumentReference-related-ref', 'Related Resource', '4', 'f:DocumentReference/f:context/f:related/f:ref', 'DocumentReference.context.related.ref', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'relatesto', 'http://hl7.org/fhir/SearchParameter/DocumentReference-relatesto', 'Target of the relationship', '4', 'f:DocumentReference/f:relatesTo/f:target', 'DocumentReference.relatesTo.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'relation', 'http://hl7.org/fhir/SearchParameter/DocumentReference-relation', 'replaces | transforms | signs | appends', '3', 'f:DocumentReference/f:relatesTo/f:code', 'DocumentReference.relatesTo.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'relationship', 'http://hl7.org/fhir/SearchParameter/DocumentReference-relationship', 'Combination of relation and relatesTo', '5', '', 'DocumentReference.relatesTo', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'securitylabel', 'http://hl7.org/fhir/SearchParameter/DocumentReference-securitylabel', 'Document security-tags', '3', 'f:DocumentReference/f:securityLabel', 'DocumentReference.securityLabel', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'setting', 'http://hl7.org/fhir/SearchParameter/DocumentReference-setting', 'Additional details about where the content was created (e.g. clinical specialty)', '3', 'f:DocumentReference/f:context/f:practiceSetting', 'DocumentReference.context.practiceSetting', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'status', 'http://hl7.org/fhir/SearchParameter/DocumentReference-status', 'current | superseded | entered-in-error', '3', 'f:DocumentReference/f:status', 'DocumentReference.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('DocumentReference', 'subject', 'http://hl7.org/fhir/SearchParameter/DocumentReference-subject', 'Who/what is the subject of the document', '4', 'f:DocumentReference/f:subject', 'DocumentReference.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityRequest', 'created', 'http://hl7.org/fhir/SearchParameter/EligibilityRequest-created', 'The creation date for the EOB', '1', 'f:EligibilityRequest/f:created', 'EligibilityRequest.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityRequest', 'enterer', 'http://hl7.org/fhir/SearchParameter/EligibilityRequest-enterer', 'The party who is responsible for the request', '4', 'f:EligibilityRequest/f:enterer', 'EligibilityRequest.enterer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityRequest', 'facility', 'http://hl7.org/fhir/SearchParameter/EligibilityRequest-facility', 'Facility responsible for the goods and services', '4', 'f:EligibilityRequest/f:facility', 'EligibilityRequest.facility', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityRequest', 'identifier', 'http://hl7.org/fhir/SearchParameter/EligibilityRequest-identifier', 'The business identifier of the Eligibility', '3', 'f:EligibilityRequest/f:identifier', 'EligibilityRequest.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityRequest', 'organization', 'http://hl7.org/fhir/SearchParameter/EligibilityRequest-organization', 'The reference to the providing organization', '4', 'f:EligibilityRequest/f:organization', 'EligibilityRequest.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityRequest', 'patient', 'http://hl7.org/fhir/SearchParameter/EligibilityRequest-patient', 'The reference to the patient', '4', 'f:EligibilityRequest/f:patient', 'EligibilityRequest.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityRequest', 'provider', 'http://hl7.org/fhir/SearchParameter/EligibilityRequest-provider', 'The reference to the provider', '4', 'f:EligibilityRequest/f:provider', 'EligibilityRequest.provider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityResponse', 'created', 'http://hl7.org/fhir/SearchParameter/EligibilityResponse-created', 'The creation date', '1', 'f:EligibilityResponse/f:created', 'EligibilityResponse.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityResponse', 'disposition', 'http://hl7.org/fhir/SearchParameter/EligibilityResponse-disposition', 'The contents of the disposition message', '2', 'f:EligibilityResponse/f:disposition', 'EligibilityResponse.disposition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityResponse', 'identifier', 'http://hl7.org/fhir/SearchParameter/EligibilityResponse-identifier', 'The business identifier', '3', 'f:EligibilityResponse/f:identifier', 'EligibilityResponse.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityResponse', 'insurer', 'http://hl7.org/fhir/SearchParameter/EligibilityResponse-insurer', 'The organization which generated this resource', '4', 'f:EligibilityResponse/f:insurer', 'EligibilityResponse.insurer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityResponse', 'outcome', 'http://hl7.org/fhir/SearchParameter/EligibilityResponse-outcome', 'The processing outcome', '3', 'f:EligibilityResponse/f:outcome', 'EligibilityResponse.outcome', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityResponse', 'request', 'http://hl7.org/fhir/SearchParameter/EligibilityResponse-request', 'The EligibilityRequest reference', '4', 'f:EligibilityResponse/f:request', 'EligibilityResponse.request', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityResponse', 'request-organization', 'http://hl7.org/fhir/SearchParameter/EligibilityResponse-request-organization', 'The EligibilityRequest organization', '4', 'f:EligibilityResponse/f:requestOrganization', 'EligibilityResponse.requestOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EligibilityResponse', 'request-provider', 'http://hl7.org/fhir/SearchParameter/EligibilityResponse-request-provider', 'The EligibilityRequest provider', '4', 'f:EligibilityResponse/f:requestProvider', 'EligibilityResponse.requestProvider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'type', 'http://hl7.org/fhir/SearchParameter/clinical-type', '', '3', 'f:ReferralRequest/f:type | f:DocumentManifest/f:type | f:DocumentReference/f:type | f:Encounter/f:type | f:AllergyIntolerance/f:type | f:EpisodeOfCare/f:type | f:Composition/f:type', 'ReferralRequest.type | DocumentManifest.type | DocumentReference.type | Encounter.type | AllergyIntolerance.type | EpisodeOfCare.type | Composition.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'appointment', 'http://hl7.org/fhir/SearchParameter/Encounter-appointment', 'The appointment that scheduled this encounter', '4', 'f:Encounter/f:appointment', 'Encounter.appointment', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'class', 'http://hl7.org/fhir/SearchParameter/Encounter-class', 'inpatient | outpatient | ambulatory | emergency +', '3', 'f:Encounter/f:class', 'Encounter.class', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'diagnosis', 'http://hl7.org/fhir/SearchParameter/Encounter-diagnosis', 'Reason the encounter takes place (resource)', '4', 'f:Encounter/f:diagnosis/f:condition', 'Encounter.diagnosis.condition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'episodeofcare', 'http://hl7.org/fhir/SearchParameter/Encounter-episodeofcare', 'Episode(s) of care that this encounter should be recorded against', '4', 'f:Encounter/f:episodeOfCare', 'Encounter.episodeOfCare', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'incomingreferral', 'http://hl7.org/fhir/SearchParameter/Encounter-incomingreferral', 'The ReferralRequest that initiated this encounter', '4', 'f:Encounter/f:incomingReferral', 'Encounter.incomingReferral', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'length', 'http://hl7.org/fhir/SearchParameter/Encounter-length', 'Length of encounter in days', '0', 'f:Encounter/f:length', 'Encounter.length', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'location', 'http://hl7.org/fhir/SearchParameter/Encounter-location', 'Location the encounter takes place', '4', 'f:Encounter/f:location/f:location', 'Encounter.location.location', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'location-period', 'http://hl7.org/fhir/SearchParameter/Encounter-location-period', 'Time period during which the patient was present at the location', '1', 'f:Encounter/f:location/f:period', 'Encounter.location.period', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'part-of', 'http://hl7.org/fhir/SearchParameter/Encounter-part-of', 'Another Encounter this encounter is part of', '4', 'f:Encounter/f:partOf', 'Encounter.partOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'participant', 'http://hl7.org/fhir/SearchParameter/Encounter-participant', 'Persons involved in the encounter other than the patient', '4', 'f:Encounter/f:participant/f:individual', 'Encounter.participant.individual', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'participant-type', 'http://hl7.org/fhir/SearchParameter/Encounter-participant-type', 'Role of participant in encounter', '3', 'f:Encounter/f:participant/f:type', 'Encounter.participant.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'practitioner', 'http://hl7.org/fhir/SearchParameter/Encounter-practitioner', 'Persons involved in the encounter other than the patient', '4', 'f:Encounter/f:participant/f:individual', 'Encounter.participant.individual', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'reason', 'http://hl7.org/fhir/SearchParameter/Encounter-reason', 'Reason the encounter takes place (code)', '3', 'f:Encounter/f:reason', 'Encounter.reason', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'service-provider', 'http://hl7.org/fhir/SearchParameter/Encounter-service-provider', 'The custodian organization of this Encounter record', '4', 'f:Encounter/f:serviceProvider', 'Encounter.serviceProvider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'special-arrangement', 'http://hl7.org/fhir/SearchParameter/Encounter-special-arrangement', 'Wheelchair, translator, stretcher, etc.', '3', 'f:Encounter/f:hospitalization/f:specialArrangement', 'Encounter.hospitalization.specialArrangement', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'status', 'http://hl7.org/fhir/SearchParameter/Encounter-status', 'planned | arrived | triaged | in-progress | onleave | finished | cancelled +', '3', 'f:Encounter/f:status', 'Encounter.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Encounter', 'subject', 'http://hl7.org/fhir/SearchParameter/Encounter-subject', 'The patient ro group present at the encounter', '4', 'f:Encounter/f:subject', 'Encounter.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Endpoint', 'connection-type', 'http://hl7.org/fhir/SearchParameter/Endpoint-connection-type', 'Protocol/Profile/Standard to be used with this endpoint connection', '3', 'f:Endpoint/f:connectionType', 'Endpoint.connectionType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Endpoint', 'identifier', 'http://hl7.org/fhir/SearchParameter/Endpoint-identifier', 'Identifies this endpoint across multiple systems', '3', 'f:Endpoint/f:identifier', 'Endpoint.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Endpoint', 'name', 'http://hl7.org/fhir/SearchParameter/Endpoint-name', 'A name that this endpoint can be identified by', '2', 'f:Endpoint/f:name', 'Endpoint.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Endpoint', 'organization', 'http://hl7.org/fhir/SearchParameter/Endpoint-organization', 'The organization that is managing the endpoint', '4', 'f:Endpoint/f:managingOrganization', 'Endpoint.managingOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Endpoint', 'payload-type', 'http://hl7.org/fhir/SearchParameter/Endpoint-payload-type', 'The type of content that may be used at this endpoint (e.g. XDS Discharge summaries)', '3', 'f:Endpoint/f:payloadType', 'Endpoint.payloadType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Endpoint', 'status', 'http://hl7.org/fhir/SearchParameter/Endpoint-status', 'The current status of the Endpoint (usually expected to be active)', '3', 'f:Endpoint/f:status', 'Endpoint.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EnrollmentRequest', 'identifier', 'http://hl7.org/fhir/SearchParameter/EnrollmentRequest-identifier', 'The business identifier of the Enrollment', '3', 'f:EnrollmentRequest/f:identifier', 'EnrollmentRequest.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EnrollmentRequest', 'organization', 'http://hl7.org/fhir/SearchParameter/EnrollmentRequest-organization', 'The organization who generated this resource', '4', 'f:EnrollmentRequest/f:organization', 'EnrollmentRequest.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EnrollmentRequest', 'patient', 'http://hl7.org/fhir/SearchParameter/EnrollmentRequest-patient', 'The party to be enrolled', '4', 'f:EnrollmentRequest/f:subject', 'EnrollmentRequest.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EnrollmentRequest', 'subject', 'http://hl7.org/fhir/SearchParameter/EnrollmentRequest-subject', 'The party to be enrolled', '4', 'f:EnrollmentRequest/f:subject', 'EnrollmentRequest.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EnrollmentResponse', 'identifier', 'http://hl7.org/fhir/SearchParameter/EnrollmentResponse-identifier', 'The business identifier of the EnrollmentResponse', '3', 'f:EnrollmentResponse/f:identifier', 'EnrollmentResponse.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EnrollmentResponse', 'organization', 'http://hl7.org/fhir/SearchParameter/EnrollmentResponse-organization', 'The organization who generated this resource', '4', 'f:EnrollmentResponse/f:organization', 'EnrollmentResponse.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EnrollmentResponse', 'request', 'http://hl7.org/fhir/SearchParameter/EnrollmentResponse-request', 'The reference to the claim', '4', 'f:EnrollmentResponse/f:request', 'EnrollmentResponse.request', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EpisodeOfCare', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EpisodeOfCare', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EpisodeOfCare', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EpisodeOfCare', 'type', 'http://hl7.org/fhir/SearchParameter/clinical-type', '', '3', 'f:ReferralRequest/f:type | f:DocumentManifest/f:type | f:DocumentReference/f:type | f:Encounter/f:type | f:AllergyIntolerance/f:type | f:EpisodeOfCare/f:type | f:Composition/f:type', 'ReferralRequest.type | DocumentManifest.type | DocumentReference.type | Encounter.type | AllergyIntolerance.type | EpisodeOfCare.type | Composition.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EpisodeOfCare', 'care-manager', 'http://hl7.org/fhir/SearchParameter/EpisodeOfCare-care-manager', 'Care manager/care co-ordinator for the patient', '4', 'f:EpisodeOfCare/f:careManager', 'EpisodeOfCare.careManager', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EpisodeOfCare', 'condition', 'http://hl7.org/fhir/SearchParameter/EpisodeOfCare-condition', 'Conditions/problems/diagnoses this episode of care is for', '4', 'f:EpisodeOfCare/f:diagnosis/f:condition', 'EpisodeOfCare.diagnosis.condition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EpisodeOfCare', 'incomingreferral', 'http://hl7.org/fhir/SearchParameter/EpisodeOfCare-incomingreferral', 'Incoming Referral Request', '4', 'f:EpisodeOfCare/f:referralRequest', 'EpisodeOfCare.referralRequest', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EpisodeOfCare', 'organization', 'http://hl7.org/fhir/SearchParameter/EpisodeOfCare-organization', 'The organization that has assumed the specific responsibilities of this EpisodeOfCare', '4', 'f:EpisodeOfCare/f:managingOrganization', 'EpisodeOfCare.managingOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('EpisodeOfCare', 'status', 'http://hl7.org/fhir/SearchParameter/EpisodeOfCare-status', 'The current status of the Episode of Care as provided (does not check the status history collection)', '3', 'f:EpisodeOfCare/f:status', 'EpisodeOfCare.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExpansionProfile', 'date', 'http://hl7.org/fhir/SearchParameter/ExpansionProfile-date', 'The expansion profile publication date', '1', 'f:ExpansionProfile/f:date', 'ExpansionProfile.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExpansionProfile', 'description', 'http://hl7.org/fhir/SearchParameter/ExpansionProfile-description', 'The description of the expansion profile', '2', 'f:ExpansionProfile/f:description', 'ExpansionProfile.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExpansionProfile', 'identifier', 'http://hl7.org/fhir/SearchParameter/ExpansionProfile-identifier', 'External identifier for the expansion profile', '3', 'f:ExpansionProfile/f:identifier', 'ExpansionProfile.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExpansionProfile', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/ExpansionProfile-jurisdiction', 'Intended jurisdiction for the expansion profile', '3', 'f:ExpansionProfile/f:jurisdiction', 'ExpansionProfile.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExpansionProfile', 'name', 'http://hl7.org/fhir/SearchParameter/ExpansionProfile-name', 'Computationally friendly name of the expansion profile', '2', 'f:ExpansionProfile/f:name', 'ExpansionProfile.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExpansionProfile', 'publisher', 'http://hl7.org/fhir/SearchParameter/ExpansionProfile-publisher', 'Name of the publisher of the expansion profile', '2', 'f:ExpansionProfile/f:publisher', 'ExpansionProfile.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExpansionProfile', 'status', 'http://hl7.org/fhir/SearchParameter/ExpansionProfile-status', 'The current status of the expansion profile', '3', 'f:ExpansionProfile/f:status', 'ExpansionProfile.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExpansionProfile', 'url', 'http://hl7.org/fhir/SearchParameter/ExpansionProfile-url', 'The uri that identifies the expansion profile', '7', 'f:ExpansionProfile/f:url', 'ExpansionProfile.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExpansionProfile', 'version', 'http://hl7.org/fhir/SearchParameter/ExpansionProfile-version', 'The business version of the expansion profile', '3', 'f:ExpansionProfile/f:version', 'ExpansionProfile.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'care-team', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-care-team', 'Member of the CareTeam', '4', 'f:ExplanationOfBenefit/f:careTeam/f:provider', 'ExplanationOfBenefit.careTeam.provider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'claim', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-claim', 'The reference to the claim', '4', 'f:ExplanationOfBenefit/f:claim', 'ExplanationOfBenefit.claim', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'coverage', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-coverage', 'The plan under which the claim was adjudicated', '4', 'f:ExplanationOfBenefit/f:insurance/f:coverage', 'ExplanationOfBenefit.insurance.coverage', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'created', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-created', 'The creation date for the EOB', '1', 'f:ExplanationOfBenefit/f:created', 'ExplanationOfBenefit.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'disposition', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-disposition', 'The contents of the disposition message', '2', 'f:ExplanationOfBenefit/f:disposition', 'ExplanationOfBenefit.disposition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'encounter', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-encounter', 'Encounters associated with a billed line item', '4', 'f:ExplanationOfBenefit/f:item/f:encounter', 'ExplanationOfBenefit.item.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'enterer', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-enterer', 'The party responsible for the entry of the Claim', '4', 'f:ExplanationOfBenefit/f:enterer', 'ExplanationOfBenefit.enterer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'facility', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-facility', 'Facility responsible for the goods and services', '4', 'f:ExplanationOfBenefit/f:facility', 'ExplanationOfBenefit.facility', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'identifier', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-identifier', 'The business identifier of the Explanation of Benefit', '3', 'f:ExplanationOfBenefit/f:identifier', 'ExplanationOfBenefit.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'organization', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-organization', 'The reference to the providing organization', '4', 'f:ExplanationOfBenefit/f:organization', 'ExplanationOfBenefit.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'patient', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-patient', 'The reference to the patient', '4', 'f:ExplanationOfBenefit/f:patient', 'ExplanationOfBenefit.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'payee', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-payee', 'The party receiving any payment for the Claim', '4', 'f:ExplanationOfBenefit/f:payee/f:party', 'ExplanationOfBenefit.payee.party', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ExplanationOfBenefit', 'provider', 'http://hl7.org/fhir/SearchParameter/ExplanationOfBenefit-provider', 'The reference to the provider', '4', 'f:ExplanationOfBenefit/f:provider', 'ExplanationOfBenefit.provider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('FamilyMemberHistory', 'code', 'http://hl7.org/fhir/SearchParameter/clinical-code', '', '3', 'f:FamilyMemberHistory/f:condition/f:code | f:DeviceRequest/f:codeCodeableConcept | f:AllergyIntolerance/f:code | f:AllergyIntolerance/f:reaction/f:substance | f:Procedure/f:code | f:List/f:code | f:ProcedureRequest/f:code | f:Observation/f:code | f:DiagnosticReport/f:code | f:Condition/f:code', 'FamilyMemberHistory.condition.code | DeviceRequest.code.as(CodeableConcept) | AllergyIntolerance.code | AllergyIntolerance.reaction.substance | Procedure.code | List.code | ProcedureRequest.code | Observation.code | DiagnosticReport.code | Condition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('FamilyMemberHistory', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('FamilyMemberHistory', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('FamilyMemberHistory', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('FamilyMemberHistory', 'definition', 'http://hl7.org/fhir/SearchParameter/FamilyMemberHistory-definition', 'Instantiates protocol or definition', '4', 'f:FamilyMemberHistory/f:definition', 'FamilyMemberHistory.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('FamilyMemberHistory', 'gender', 'http://hl7.org/fhir/SearchParameter/FamilyMemberHistory-gender', 'A search by a gender code of a family member', '3', 'f:FamilyMemberHistory/f:gender', 'FamilyMemberHistory.gender', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('FamilyMemberHistory', 'relationship', 'http://hl7.org/fhir/SearchParameter/FamilyMemberHistory-relationship', 'A search by a relationship type', '3', 'f:FamilyMemberHistory/f:relationship', 'FamilyMemberHistory.relationship', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('FamilyMemberHistory', 'status', 'http://hl7.org/fhir/SearchParameter/FamilyMemberHistory-status', 'partial | completed | entered-in-error | health-unknown', '3', 'f:FamilyMemberHistory/f:status', 'FamilyMemberHistory.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Flag', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Flag', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Flag', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Flag', 'author', 'http://hl7.org/fhir/SearchParameter/Flag-author', 'Flag creator', '4', 'f:Flag/f:author', 'Flag.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Flag', 'identifier', 'http://hl7.org/fhir/SearchParameter/Flag-identifier', 'Business identifier', '3', 'f:Flag/f:identifier', 'Flag.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Flag', 'subject', 'http://hl7.org/fhir/SearchParameter/Flag-subject', 'The identity of a subject to list flags for', '4', 'f:Flag/f:subject', 'Flag.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Goal', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Goal', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Goal', 'category', 'http://hl7.org/fhir/SearchParameter/Goal-category', 'E.g. Treatment, dietary, behavioral, etc.', '3', 'f:Goal/f:category', 'Goal.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Goal', 'start-date', 'http://hl7.org/fhir/SearchParameter/Goal-start-date', 'When goal pursuit begins', '1', 'f:Goal/f:startDate', 'Goal.start.as(Date)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Goal', 'status', 'http://hl7.org/fhir/SearchParameter/Goal-status', 'proposed | accepted | planned | in-progress | on-target | ahead-of-target | behind-target | sustaining | achieved | on-hold | cancelled | entered-in-error | rejected', '3', 'f:Goal/f:status', 'Goal.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Goal', 'subject', 'http://hl7.org/fhir/SearchParameter/Goal-subject', 'Who this goal is intended for', '4', 'f:Goal/f:subject', 'Goal.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Goal', 'target-date', 'http://hl7.org/fhir/SearchParameter/Goal-target-date', 'Reach goal on or before', '1', 'f:Goal/f:target/f:dueDate', 'Goal.target.due.as(Date)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GraphDefinition', 'date', 'http://hl7.org/fhir/SearchParameter/GraphDefinition-date', 'The graph definition publication date', '1', 'f:GraphDefinition/f:date', 'GraphDefinition.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GraphDefinition', 'description', 'http://hl7.org/fhir/SearchParameter/GraphDefinition-description', 'The description of the graph definition', '2', 'f:GraphDefinition/f:description', 'GraphDefinition.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GraphDefinition', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/GraphDefinition-jurisdiction', 'Intended jurisdiction for the graph definition', '3', 'f:GraphDefinition/f:jurisdiction', 'GraphDefinition.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GraphDefinition', 'name', 'http://hl7.org/fhir/SearchParameter/GraphDefinition-name', 'Computationally friendly name of the graph definition', '2', 'f:GraphDefinition/f:name', 'GraphDefinition.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GraphDefinition', 'publisher', 'http://hl7.org/fhir/SearchParameter/GraphDefinition-publisher', 'Name of the publisher of the graph definition', '2', 'f:GraphDefinition/f:publisher', 'GraphDefinition.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GraphDefinition', 'start', 'http://hl7.org/fhir/SearchParameter/GraphDefinition-start', 'Type of resource at which the graph starts', '3', 'f:GraphDefinition/f:start', 'GraphDefinition.start', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GraphDefinition', 'status', 'http://hl7.org/fhir/SearchParameter/GraphDefinition-status', 'The current status of the graph definition', '3', 'f:GraphDefinition/f:status', 'GraphDefinition.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GraphDefinition', 'url', 'http://hl7.org/fhir/SearchParameter/GraphDefinition-url', 'The uri that identifies the graph definition', '7', 'f:GraphDefinition/f:url', 'GraphDefinition.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GraphDefinition', 'version', 'http://hl7.org/fhir/SearchParameter/GraphDefinition-version', 'The business version of the graph definition', '3', 'f:GraphDefinition/f:version', 'GraphDefinition.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Group', 'actual', 'http://hl7.org/fhir/SearchParameter/Group-actual', 'Descriptive or actual', '3', 'f:Group/f:actual', 'Group.actual', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Group', 'characteristic', 'http://hl7.org/fhir/SearchParameter/Group-characteristic', 'Kind of characteristic', '3', 'f:Group/f:characteristic/f:code', 'Group.characteristic.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Group', 'characteristic-value', 'http://hl7.org/fhir/SearchParameter/Group-characteristic-value', 'A composite of both characteristic and value', '5', '', 'Group.characteristic', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Group', 'code', 'http://hl7.org/fhir/SearchParameter/Group-code', 'The kind of resources contained', '3', 'f:Group/f:code', 'Group.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Group', 'exclude', 'http://hl7.org/fhir/SearchParameter/Group-exclude', 'Group includes or excludes', '3', 'f:Group/f:characteristic/f:exclude', 'Group.characteristic.exclude', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Group', 'identifier', 'http://hl7.org/fhir/SearchParameter/Group-identifier', 'Unique id', '3', 'f:Group/f:identifier', 'Group.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Group', 'member', 'http://hl7.org/fhir/SearchParameter/Group-member', 'Reference to the group member', '4', 'f:Group/f:member/f:entity', 'Group.member.entity', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Group', 'type', 'http://hl7.org/fhir/SearchParameter/Group-type', 'The type of resources the group contains', '3', 'f:Group/f:type', 'Group.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Group', 'value', 'http://hl7.org/fhir/SearchParameter/Group-value', 'Value held by characteristic', '3', 'f:Group/f:characteristic/f:valueCodeableConcept | f:Group/f:characteristic/f:valueBoolean | f:Group/f:characteristic/f:valueQuantity | f:Group/f:characteristic/f:valueRange', 'Group.characteristic.value', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GuidanceResponse', 'identifier', 'http://hl7.org/fhir/SearchParameter/GuidanceResponse-identifier', 'The identifier of the guidance response', '3', 'f:GuidanceResponse/f:identifier', 'GuidanceResponse.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GuidanceResponse', 'patient', 'http://hl7.org/fhir/SearchParameter/GuidanceResponse-patient', 'The identity of a patient to search for guidance response results', '4', 'f:GuidanceResponse/f:subject', 'GuidanceResponse.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GuidanceResponse', 'request', 'http://hl7.org/fhir/SearchParameter/GuidanceResponse-request', 'The identifier of the request associated with the response', '3', 'f:GuidanceResponse/f:requestId', 'GuidanceResponse.requestId', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('GuidanceResponse', 'subject', 'http://hl7.org/fhir/SearchParameter/GuidanceResponse-subject', 'The subject that the guidance response is about', '4', 'f:GuidanceResponse/f:subject', 'GuidanceResponse.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'active', 'http://hl7.org/fhir/SearchParameter/HealthcareService-active', 'The Healthcare Service is currently marked as active', '3', 'f:HealthcareService/f:active', 'HealthcareService.active', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'category', 'http://hl7.org/fhir/SearchParameter/HealthcareService-category', 'Service Category of the Healthcare Service', '3', 'f:HealthcareService/f:category', 'HealthcareService.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'characteristic', 'http://hl7.org/fhir/SearchParameter/HealthcareService-characteristic', 'One of the HealthcareService''s characteristics', '3', 'f:HealthcareService/f:characteristic', 'HealthcareService.characteristic', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'endpoint', 'http://hl7.org/fhir/SearchParameter/HealthcareService-endpoint', 'Technical endpoints providing access to services operated for the location', '4', 'f:HealthcareService/f:endpoint', 'HealthcareService.endpoint', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'identifier', 'http://hl7.org/fhir/SearchParameter/HealthcareService-identifier', 'External identifiers for this item', '3', 'f:HealthcareService/f:identifier', 'HealthcareService.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'location', 'http://hl7.org/fhir/SearchParameter/HealthcareService-location', 'The location of the Healthcare Service', '4', 'f:HealthcareService/f:location', 'HealthcareService.location', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'name', 'http://hl7.org/fhir/SearchParameter/HealthcareService-name', 'A portion of the Healthcare service name', '2', 'f:HealthcareService/f:name', 'HealthcareService.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'organization', 'http://hl7.org/fhir/SearchParameter/HealthcareService-organization', 'The organization that provides this Healthcare Service', '4', 'f:HealthcareService/f:providedBy', 'HealthcareService.providedBy', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'programname', 'http://hl7.org/fhir/SearchParameter/HealthcareService-programname', 'One of the Program Names serviced by this HealthcareService', '2', 'f:HealthcareService/f:programName', 'HealthcareService.programName', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('HealthcareService', 'type', 'http://hl7.org/fhir/SearchParameter/HealthcareService-type', 'The type of service provided by this healthcare service', '3', 'f:HealthcareService/f:type', 'HealthcareService.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingManifest', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingManifest', 'author', 'http://hl7.org/fhir/SearchParameter/ImagingManifest-author', 'Author of the ImagingManifest (or a DICOM Key Object Selection which it represents)', '4', 'f:ImagingManifest/f:author', 'ImagingManifest.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingManifest', 'authoring-time', 'http://hl7.org/fhir/SearchParameter/ImagingManifest-authoring-time', 'Time of the ImagingManifest (or a DICOM Key Object Selection which it represents) authoring', '1', 'f:ImagingManifest/f:authoringTime', 'ImagingManifest.authoringTime', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingManifest', 'endpoint', 'http://hl7.org/fhir/SearchParameter/ImagingManifest-endpoint', 'The endpoint for the study or series', '4', 'f:ImagingManifest/f:study/f:endpoint | f:ImagingManifest/f:study/f:series/f:endpoint', 'ImagingManifest.study.endpoint | ImagingManifest.study.series.endpoint', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingManifest', 'identifier', 'http://hl7.org/fhir/SearchParameter/ImagingManifest-identifier', 'UID of the ImagingManifest (or a DICOM Key Object Selection which it represents)', '3', 'f:ImagingManifest/f:identifier', 'ImagingManifest.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingManifest', 'imaging-study', 'http://hl7.org/fhir/SearchParameter/ImagingManifest-imaging-study', 'ImagingStudy resource selected in the ImagingManifest (or a DICOM Key Object Selection which it represents)', '4', 'f:ImagingManifest/f:study/f:imagingStudy', 'ImagingManifest.study.imagingStudy', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingManifest', 'selected-study', 'http://hl7.org/fhir/SearchParameter/ImagingManifest-selected-study', 'Study selected in the ImagingManifest (or a DICOM Key Object Selection which it represents)', '7', 'f:ImagingManifest/f:study/f:uid', 'ImagingManifest.study.uid', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'accession', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-accession', 'The accession identifier for the study', '3', 'f:ImagingStudy/f:accession', 'ImagingStudy.accession', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'basedon', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-basedon', 'The order for the image', '4', 'f:ImagingStudy/f:basedOn', 'ImagingStudy.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'bodysite', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-bodysite', 'The body site studied', '3', 'f:ImagingStudy/f:series/f:bodySite', 'ImagingStudy.series.bodySite', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'context', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-context', 'The context of the study', '4', 'f:ImagingStudy/f:context', 'ImagingStudy.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'dicom-class', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-dicom-class', 'The type of the instance', '7', 'f:ImagingStudy/f:series/f:instance/f:sopClass', 'ImagingStudy.series.instance.sopClass', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'endpoint', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-endpoint', 'The endpoint for te study or series', '4', 'f:ImagingStudy/f:endpoint | f:ImagingStudy/f:series/f:endpoint', 'ImagingStudy.endpoint | ImagingStudy.series.endpoint', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'modality', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-modality', 'The modality of the series', '3', 'f:ImagingStudy/f:series/f:modality', 'ImagingStudy.series.modality', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'performer', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-performer', 'The person who performed the study', '4', 'f:ImagingStudy/f:series/f:performer', 'ImagingStudy.series.performer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'reason', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-reason', 'The reason for the study', '3', 'f:ImagingStudy/f:reason', 'ImagingStudy.reason', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'series', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-series', 'The identifier of the series of images', '7', 'f:ImagingStudy/f:series/f:uid', 'ImagingStudy.series.uid', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'started', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-started', 'When the study was started', '1', 'f:ImagingStudy/f:started', 'ImagingStudy.started', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'study', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-study', 'The study identifier for the image', '7', 'f:ImagingStudy/f:uid', 'ImagingStudy.uid', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImagingStudy', 'uid', 'http://hl7.org/fhir/SearchParameter/ImagingStudy-uid', 'The instance unique identifier', '7', 'f:ImagingStudy/f:series/f:instance/f:uid', 'ImagingStudy.series.instance.uid', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'dose-sequence', 'http://hl7.org/fhir/SearchParameter/Immunization-dose-sequence', 'Dose number within series', '0', 'f:Immunization/f:vaccinationProtocol/f:doseSequence', 'Immunization.vaccinationProtocol.doseSequence', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'location', 'http://hl7.org/fhir/SearchParameter/Immunization-location', 'The service delivery location or facility in which the vaccine was / was to be administered', '4', 'f:Immunization/f:location', 'Immunization.location', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'lot-number', 'http://hl7.org/fhir/SearchParameter/Immunization-lot-number', 'Vaccine Lot Number', '2', 'f:Immunization/f:lotNumber', 'Immunization.lotNumber', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'manufacturer', 'http://hl7.org/fhir/SearchParameter/Immunization-manufacturer', 'Vaccine Manufacturer', '4', 'f:Immunization/f:manufacturer', 'Immunization.manufacturer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'notgiven', 'http://hl7.org/fhir/SearchParameter/Immunization-notgiven', 'Administrations which were not given', '3', 'f:Immunization/f:notGiven', 'Immunization.notGiven', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'practitioner', 'http://hl7.org/fhir/SearchParameter/Immunization-practitioner', 'The practitioner who played a role in the vaccination', '4', 'f:Immunization/f:practitioner/f:actor', 'Immunization.practitioner.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'reaction', 'http://hl7.org/fhir/SearchParameter/Immunization-reaction', 'Additional information on reaction', '4', 'f:Immunization/f:reaction/f:detail', 'Immunization.reaction.detail', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'reaction-date', 'http://hl7.org/fhir/SearchParameter/Immunization-reaction-date', 'When reaction started', '1', 'f:Immunization/f:reaction/f:date', 'Immunization.reaction.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'reason', 'http://hl7.org/fhir/SearchParameter/Immunization-reason', 'Why immunization occurred', '3', 'f:Immunization/f:explanation/f:reason', 'Immunization.explanation.reason', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'reason-not-given', 'http://hl7.org/fhir/SearchParameter/Immunization-reason-not-given', 'Explanation of reason vaccination was not administered', '3', 'f:Immunization/f:explanation/f:reasonNotGiven', 'Immunization.explanation.reasonNotGiven', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'status', 'http://hl7.org/fhir/SearchParameter/Immunization-status', 'Immunization event status', '3', 'f:Immunization/f:status', 'Immunization.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Immunization', 'vaccine-code', 'http://hl7.org/fhir/SearchParameter/Immunization-vaccine-code', 'Vaccine Product Administered', '3', 'f:Immunization/f:vaccineCode', 'Immunization.vaccineCode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'date', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-date', 'Date recommendation created', '1', 'f:ImmunizationRecommendation/f:recommendation/f:date', 'ImmunizationRecommendation.recommendation.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'dose-number', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-dose-number', 'Recommended dose number', '0', 'f:ImmunizationRecommendation/f:recommendation/f:doseNumber', 'ImmunizationRecommendation.recommendation.doseNumber', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'dose-sequence', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-dose-sequence', 'Dose number within sequence', '0', 'f:ImmunizationRecommendation/f:recommendation/f:protocol/f:doseSequence', 'ImmunizationRecommendation.recommendation.protocol.doseSequence', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'identifier', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-identifier', 'Business identifier', '3', 'f:ImmunizationRecommendation/f:identifier', 'ImmunizationRecommendation.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'information', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-information', 'Patient observations supporting recommendation', '4', 'f:ImmunizationRecommendation/f:recommendation/f:supportingPatientInformation', 'ImmunizationRecommendation.recommendation.supportingPatientInformation', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'patient', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-patient', 'Who this profile is for', '4', 'f:ImmunizationRecommendation/f:patient', 'ImmunizationRecommendation.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'status', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-status', 'Vaccine administration status', '3', 'f:ImmunizationRecommendation/f:recommendation/f:forecastStatus', 'ImmunizationRecommendation.recommendation.forecastStatus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'support', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-support', 'Past immunizations supporting recommendation', '4', 'f:ImmunizationRecommendation/f:recommendation/f:supportingImmunization', 'ImmunizationRecommendation.recommendation.supportingImmunization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'target-disease', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-target-disease', 'Disease to be immunized against', '3', 'f:ImmunizationRecommendation/f:recommendation/f:targetDisease', 'ImmunizationRecommendation.recommendation.targetDisease', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImmunizationRecommendation', 'vaccine-type', 'http://hl7.org/fhir/SearchParameter/ImmunizationRecommendation-vaccine-type', 'Vaccine recommendation applies to', '3', 'f:ImmunizationRecommendation/f:recommendation/f:vaccineCode', 'ImmunizationRecommendation.recommendation.vaccineCode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'date', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-date', 'The implementation guide publication date', '1', 'f:ImplementationGuide/f:date', 'ImplementationGuide.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'dependency', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-dependency', 'Where to find dependency', '7', 'f:ImplementationGuide/f:dependency/f:uri', 'ImplementationGuide.dependency.uri', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'description', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-description', 'The description of the implementation guide', '2', 'f:ImplementationGuide/f:description', 'ImplementationGuide.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'experimental', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-experimental', 'For testing purposes, not real usage', '3', 'f:ImplementationGuide/f:experimental', 'ImplementationGuide.experimental', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-jurisdiction', 'Intended jurisdiction for the implementation guide', '3', 'f:ImplementationGuide/f:jurisdiction', 'ImplementationGuide.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'name', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-name', 'Computationally friendly name of the implementation guide', '2', 'f:ImplementationGuide/f:name', 'ImplementationGuide.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'publisher', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-publisher', 'Name of the publisher of the implementation guide', '2', 'f:ImplementationGuide/f:publisher', 'ImplementationGuide.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'resource', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-resource', 'Location of the resource', '4', 'f:ImplementationGuide/f:package/f:resource/f:sourceUri | f:ImplementationGuide/f:package/f:resource/f:sourceReference', 'ImplementationGuide.package.resource.source', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'status', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-status', 'The current status of the implementation guide', '3', 'f:ImplementationGuide/f:status', 'ImplementationGuide.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'url', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-url', 'The uri that identifies the implementation guide', '7', 'f:ImplementationGuide/f:url', 'ImplementationGuide.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ImplementationGuide', 'version', 'http://hl7.org/fhir/SearchParameter/ImplementationGuide-version', 'The business version of the implementation guide', '3', 'f:ImplementationGuide/f:version', 'ImplementationGuide.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'composed-of', 'http://hl7.org/fhir/SearchParameter/Library-composed-of', 'What resource is being referenced', '4', 'f:Library/f:relatedArtifact[f:type/@value=''composed-of'']/f:resource', 'Library.relatedArtifact.where(type=''composed-of'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'date', 'http://hl7.org/fhir/SearchParameter/Library-date', 'The library publication date', '1', 'f:Library/f:date', 'Library.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'depends-on', 'http://hl7.org/fhir/SearchParameter/Library-depends-on', 'What resource is being referenced', '4', 'f:Library/f:relatedArtifact[f:type/@value=''depends-on'']/f:resource', 'Library.relatedArtifact.where(type=''depends-on'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'derived-from', 'http://hl7.org/fhir/SearchParameter/Library-derived-from', 'What resource is being referenced', '4', 'f:Library/f:relatedArtifact[f:type/@value=''derived-from'']/f:resource', 'Library.relatedArtifact.where(type=''derived-from'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'description', 'http://hl7.org/fhir/SearchParameter/Library-description', 'The description of the library', '2', 'f:Library/f:description', 'Library.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'effective', 'http://hl7.org/fhir/SearchParameter/Library-effective', 'The time during which the library is intended to be in use', '1', 'f:Library/f:effectivePeriod', 'Library.effectivePeriod', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'identifier', 'http://hl7.org/fhir/SearchParameter/Library-identifier', 'External identifier for the library', '3', 'f:Library/f:identifier', 'Library.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/Library-jurisdiction', 'Intended jurisdiction for the library', '3', 'f:Library/f:jurisdiction', 'Library.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'name', 'http://hl7.org/fhir/SearchParameter/Library-name', 'Computationally friendly name of the library', '2', 'f:Library/f:name', 'Library.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'predecessor', 'http://hl7.org/fhir/SearchParameter/Library-predecessor', 'What resource is being referenced', '4', 'f:Library/f:relatedArtifact[f:type/@value=''predecessor'']/f:resource', 'Library.relatedArtifact.where(type=''predecessor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'publisher', 'http://hl7.org/fhir/SearchParameter/Library-publisher', 'Name of the publisher of the library', '2', 'f:Library/f:publisher', 'Library.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'status', 'http://hl7.org/fhir/SearchParameter/Library-status', 'The current status of the library', '3', 'f:Library/f:status', 'Library.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'successor', 'http://hl7.org/fhir/SearchParameter/Library-successor', 'What resource is being referenced', '4', 'f:Library/f:relatedArtifact[f:type/@value=''successor'']/f:resource', 'Library.relatedArtifact.where(type=''successor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'title', 'http://hl7.org/fhir/SearchParameter/Library-title', 'The human-friendly name of the library', '2', 'f:Library/f:title', 'Library.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'topic', 'http://hl7.org/fhir/SearchParameter/Library-topic', 'Topics associated with the module', '3', 'f:Library/f:topic', 'Library.topic', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'url', 'http://hl7.org/fhir/SearchParameter/Library-url', 'The uri that identifies the library', '7', 'f:Library/f:url', 'Library.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Library', 'version', 'http://hl7.org/fhir/SearchParameter/Library-version', 'The business version of the library', '3', 'f:Library/f:version', 'Library.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Linkage', 'author', 'http://hl7.org/fhir/SearchParameter/Linkage-author', 'Author of the Linkage', '4', 'f:Linkage/f:author', 'Linkage.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Linkage', 'item', 'http://hl7.org/fhir/SearchParameter/Linkage-item', 'Matches on any item in the Linkage', '4', 'f:Linkage/f:item/f:resource', 'Linkage.item.resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Linkage', 'source', 'http://hl7.org/fhir/SearchParameter/Linkage-source', 'Matches on any item in the Linkage with a type of ''source''', '4', 'f:Linkage/f:item/f:resource', 'Linkage.item.resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'code', 'http://hl7.org/fhir/SearchParameter/clinical-code', '', '3', 'f:FamilyMemberHistory/f:condition/f:code | f:DeviceRequest/f:codeCodeableConcept | f:AllergyIntolerance/f:code | f:AllergyIntolerance/f:reaction/f:substance | f:Procedure/f:code | f:List/f:code | f:ProcedureRequest/f:code | f:Observation/f:code | f:DiagnosticReport/f:code | f:Condition/f:code', 'FamilyMemberHistory.condition.code | DeviceRequest.code.as(CodeableConcept) | AllergyIntolerance.code | AllergyIntolerance.reaction.substance | Procedure.code | List.code | ProcedureRequest.code | Observation.code | DiagnosticReport.code | Condition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'empty-reason', 'http://hl7.org/fhir/SearchParameter/List-empty-reason', 'Why list is empty', '3', 'f:List/f:emptyReason', 'List.emptyReason', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'item', 'http://hl7.org/fhir/SearchParameter/List-item', 'Actual entry', '4', 'f:List/f:entry/f:item', 'List.entry.item', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'notes', 'http://hl7.org/fhir/SearchParameter/List-notes', 'The annotation  - text content', '2', 'f:List/f:note/f:text', 'List.note.text', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'source', 'http://hl7.org/fhir/SearchParameter/List-source', 'Who and/or what defined the list contents (aka Author)', '4', 'f:List/f:source', 'List.source', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'status', 'http://hl7.org/fhir/SearchParameter/List-status', 'current | retired | entered-in-error', '3', 'f:List/f:status', 'List.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'subject', 'http://hl7.org/fhir/SearchParameter/List-subject', 'If all resources have the same subject', '4', 'f:List/f:subject', 'List.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('List', 'title', 'http://hl7.org/fhir/SearchParameter/List-title', 'Descriptive name for the list', '2', 'f:List/f:title', 'List.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'address', 'http://hl7.org/fhir/SearchParameter/Location-address', 'A (part of the) address of the location', '2', 'f:Location/f:address', 'Location.address', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'address-city', 'http://hl7.org/fhir/SearchParameter/Location-address-city', 'A city specified in an address', '2', 'f:Location/f:address/f:city', 'Location.address.city', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'address-country', 'http://hl7.org/fhir/SearchParameter/Location-address-country', 'A country specified in an address', '2', 'f:Location/f:address/f:country', 'Location.address.country', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'address-postalcode', 'http://hl7.org/fhir/SearchParameter/Location-address-postalcode', 'A postal code specified in an address', '2', 'f:Location/f:address/f:postalCode', 'Location.address.postalCode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'address-state', 'http://hl7.org/fhir/SearchParameter/Location-address-state', 'A state specified in an address', '2', 'f:Location/f:address/f:state', 'Location.address.state', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'address-use', 'http://hl7.org/fhir/SearchParameter/Location-address-use', 'A use code specified in an address', '3', 'f:Location/f:address/f:use', 'Location.address.use', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'endpoint', 'http://hl7.org/fhir/SearchParameter/Location-endpoint', 'Technical endpoints providing access to services operated for the location', '4', 'f:Location/f:endpoint', 'Location.endpoint', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'identifier', 'http://hl7.org/fhir/SearchParameter/Location-identifier', 'An identifier for the location', '3', 'f:Location/f:identifier', 'Location.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'name', 'http://hl7.org/fhir/SearchParameter/Location-name', 'A portion of the location''s name or alias', '2', 'f:Location/f:name | f:Location/f:alias', 'Location.name | Location.alias', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'near', 'http://hl7.org/fhir/SearchParameter/Location-near', 'The coordinates expressed as [latitude]:[longitude] (using the WGS84 datum, see notes) to find locations near to (servers may search using a square rather than a circle for efficiency)

Requires the near-distance parameter to be provided also', '3', 'f:Location/f:position', 'Location.position', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'near-distance', 'http://hl7.org/fhir/SearchParameter/Location-near-distance', 'A distance quantity to limit the near search to locations within a specific distance

Requires the near parameter to also be included', '6', 'f:Location/f:position', 'Location.position', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'operational-status', 'http://hl7.org/fhir/SearchParameter/Location-operational-status', 'Searches for locations (typically bed/room) that have an operational status (e.g. contaminated, housekeeping)', '3', 'f:Location/f:operationalStatus', 'Location.operationalStatus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'organization', 'http://hl7.org/fhir/SearchParameter/Location-organization', 'Searches for locations that are managed by the provided organization', '4', 'f:Location/f:managingOrganization', 'Location.managingOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'partof', 'http://hl7.org/fhir/SearchParameter/Location-partof', 'A location of which this location is a part', '4', 'f:Location/f:partOf', 'Location.partOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'status', 'http://hl7.org/fhir/SearchParameter/Location-status', 'Searches for locations with a specific kind of status', '3', 'f:Location/f:status', 'Location.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Location', 'type', 'http://hl7.org/fhir/SearchParameter/Location-type', 'A code for the type of location', '3', 'f:Location/f:type', 'Location.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'composed-of', 'http://hl7.org/fhir/SearchParameter/Measure-composed-of', 'What resource is being referenced', '4', 'f:Measure/f:relatedArtifact[f:type/@value=''composed-of'']/f:resource', 'Measure.relatedArtifact.where(type=''composed-of'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'date', 'http://hl7.org/fhir/SearchParameter/Measure-date', 'The measure publication date', '1', 'f:Measure/f:date', 'Measure.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'depends-on', 'http://hl7.org/fhir/SearchParameter/Measure-depends-on', 'What resource is being referenced', '4', 'f:Measure/f:relatedArtifact[f:type/@value=''depends-on'']/f:resource | f:Measure/f:library', 'Measure.relatedArtifact.where(type=''depends-on'').resource | Measure.library', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'derived-from', 'http://hl7.org/fhir/SearchParameter/Measure-derived-from', 'What resource is being referenced', '4', 'f:Measure/f:relatedArtifact[f:type/@value=''derived-from'']/f:resource', 'Measure.relatedArtifact.where(type=''derived-from'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'description', 'http://hl7.org/fhir/SearchParameter/Measure-description', 'The description of the measure', '2', 'f:Measure/f:description', 'Measure.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'effective', 'http://hl7.org/fhir/SearchParameter/Measure-effective', 'The time during which the measure is intended to be in use', '1', 'f:Measure/f:effectivePeriod', 'Measure.effectivePeriod', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'identifier', 'http://hl7.org/fhir/SearchParameter/Measure-identifier', 'External identifier for the measure', '3', 'f:Measure/f:identifier', 'Measure.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/Measure-jurisdiction', 'Intended jurisdiction for the measure', '3', 'f:Measure/f:jurisdiction', 'Measure.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'name', 'http://hl7.org/fhir/SearchParameter/Measure-name', 'Computationally friendly name of the measure', '2', 'f:Measure/f:name', 'Measure.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'predecessor', 'http://hl7.org/fhir/SearchParameter/Measure-predecessor', 'What resource is being referenced', '4', 'f:Measure/f:relatedArtifact[f:type/@value=''predecessor'']/f:resource', 'Measure.relatedArtifact.where(type=''predecessor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'publisher', 'http://hl7.org/fhir/SearchParameter/Measure-publisher', 'Name of the publisher of the measure', '2', 'f:Measure/f:publisher', 'Measure.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'status', 'http://hl7.org/fhir/SearchParameter/Measure-status', 'The current status of the measure', '3', 'f:Measure/f:status', 'Measure.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'successor', 'http://hl7.org/fhir/SearchParameter/Measure-successor', 'What resource is being referenced', '4', 'f:Measure/f:relatedArtifact[f:type/@value=''successor'']/f:resource', 'Measure.relatedArtifact.where(type=''successor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'title', 'http://hl7.org/fhir/SearchParameter/Measure-title', 'The human-friendly name of the measure', '2', 'f:Measure/f:title', 'Measure.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'topic', 'http://hl7.org/fhir/SearchParameter/Measure-topic', 'Topics associated with the module', '3', 'f:Measure/f:topic', 'Measure.topic', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'url', 'http://hl7.org/fhir/SearchParameter/Measure-url', 'The uri that identifies the measure', '7', 'f:Measure/f:url', 'Measure.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Measure', 'version', 'http://hl7.org/fhir/SearchParameter/Measure-version', 'The business version of the measure', '3', 'f:Measure/f:version', 'Measure.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MeasureReport', 'identifier', 'http://hl7.org/fhir/SearchParameter/MeasureReport-identifier', 'External identifier of the measure report to be returned', '3', 'f:MeasureReport/f:identifier', 'MeasureReport.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MeasureReport', 'patient', 'http://hl7.org/fhir/SearchParameter/MeasureReport-patient', 'The identity of a patient to search for individual measure report results for', '4', 'f:MeasureReport/f:patient', 'MeasureReport.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MeasureReport', 'status', 'http://hl7.org/fhir/SearchParameter/MeasureReport-status', 'The status of the measure report', '3', 'f:MeasureReport/f:status', 'MeasureReport.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'based-on', 'http://hl7.org/fhir/SearchParameter/Media-based-on', 'Procedure that caused this media to be created', '4', 'f:Media/f:basedOn', 'Media.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'context', 'http://hl7.org/fhir/SearchParameter/Media-context', 'Encounter / Episode associated with media', '4', 'f:Media/f:context', 'Media.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'created', 'http://hl7.org/fhir/SearchParameter/Media-created', 'Date attachment was first created', '1', 'f:Media/f:content/f:creation', 'Media.content.creation', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'date', 'http://hl7.org/fhir/SearchParameter/Media-date', 'When Media was collected', '1', 'f:Media/f:occurrenceDateTime | f:Media/f:occurrencePeriod', 'Media.occurrence', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'device', 'http://hl7.org/fhir/SearchParameter/Media-device', 'Observing Device', '4', 'f:Media/f:device', 'Media.device', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'identifier', 'http://hl7.org/fhir/SearchParameter/Media-identifier', 'Identifier(s) for the image', '3', 'f:Media/f:identifier', 'Media.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'operator', 'http://hl7.org/fhir/SearchParameter/Media-operator', 'The person who generated the image', '4', 'f:Media/f:operator', 'Media.operator', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'patient', 'http://hl7.org/fhir/SearchParameter/Media-patient', 'Who/What this Media is a record of', '4', 'f:Media/f:subject', 'Media.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'site', 'http://hl7.org/fhir/SearchParameter/Media-site', 'Body part in media', '3', 'f:Media/f:bodySite', 'Media.bodySite', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'subject', 'http://hl7.org/fhir/SearchParameter/Media-subject', 'Who/What this Media is a record of', '4', 'f:Media/f:subject', 'Media.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'subtype', 'http://hl7.org/fhir/SearchParameter/Media-subtype', 'The type of acquisition equipment/process', '3', 'f:Media/f:subtype', 'Media.subtype', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'type', 'http://hl7.org/fhir/SearchParameter/Media-type', 'photo | video | audio', '3', 'f:Media/f:type', 'Media.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Media', 'view', 'http://hl7.org/fhir/SearchParameter/Media-view', 'Imaging view, e.g. Lateral or Antero-posterior', '3', 'f:Media/f:view', 'Media.view', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'code', 'http://hl7.org/fhir/SearchParameter/medications-code', '', '3', 'f:Medication/f:code | f:MedicationRequest/f:medicationCodeableConcept | f:MedicationAdministration/f:medicationCodeableConcept | f:MedicationStatement/f:medicationCodeableConcept | f:MedicationDispense/f:medicationCodeableConcept', 'Medication.code | MedicationRequest.medication.as(CodeableConcept) | MedicationAdministration.medication.as(CodeableConcept) | MedicationStatement.medication.as(CodeableConcept) | MedicationDispense.medication.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'container', 'http://hl7.org/fhir/SearchParameter/Medication-container', 'E.g. box, vial, blister-pack', '3', 'f:Medication/f:package/f:container', 'Medication.package.container', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'form', 'http://hl7.org/fhir/SearchParameter/Medication-form', 'powder | tablets | capsule +', '3', 'f:Medication/f:form', 'Medication.form', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'ingredient', 'http://hl7.org/fhir/SearchParameter/Medication-ingredient', 'The product contained', '4', 'f:Medication/f:ingredient/f:itemReference', 'Medication.ingredient.item.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'ingredient-code', 'http://hl7.org/fhir/SearchParameter/Medication-ingredient-code', 'The product contained', '3', 'f:Medication/f:ingredient/f:itemCodeableConcept', 'Medication.ingredient.item.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'manufacturer', 'http://hl7.org/fhir/SearchParameter/Medication-manufacturer', 'Manufacturer of the item', '4', 'f:Medication/f:manufacturer', 'Medication.manufacturer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'over-the-counter', 'http://hl7.org/fhir/SearchParameter/Medication-over-the-counter', 'True if medication does not require a prescription', '3', 'f:Medication/f:isOverTheCounter', 'Medication.isOverTheCounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'package-item', 'http://hl7.org/fhir/SearchParameter/Medication-package-item', 'The item in the package', '4', 'f:Medication/f:package/f:content/f:itemReference', 'Medication.package.content.item.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'package-item-code', 'http://hl7.org/fhir/SearchParameter/Medication-package-item-code', 'The item in the package', '3', 'f:Medication/f:package/f:content/f:itemCodeableConcept', 'Medication.package.content.item.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Medication', 'status', 'http://hl7.org/fhir/SearchParameter/Medication-status', 'active | inactive | entered-in-error', '3', 'f:Medication/f:status', 'Medication.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'code', 'http://hl7.org/fhir/SearchParameter/medications-code', '', '3', 'f:Medication/f:code | f:MedicationRequest/f:medicationCodeableConcept | f:MedicationAdministration/f:medicationCodeableConcept | f:MedicationStatement/f:medicationCodeableConcept | f:MedicationDispense/f:medicationCodeableConcept', 'Medication.code | MedicationRequest.medication.as(CodeableConcept) | MedicationAdministration.medication.as(CodeableConcept) | MedicationStatement.medication.as(CodeableConcept) | MedicationDispense.medication.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'context', 'http://hl7.org/fhir/SearchParameter/MedicationAdministration-context', 'Return administrations that share this encounter or episode of care', '4', 'f:MedicationAdministration/f:context', 'MedicationAdministration.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'device', 'http://hl7.org/fhir/SearchParameter/MedicationAdministration-device', 'Return administrations with this administration device identity', '4', 'f:MedicationAdministration/f:device', 'MedicationAdministration.device', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'effective-time', 'http://hl7.org/fhir/SearchParameter/MedicationAdministration-effective-time', 'Date administration happened (or did not happen)', '1', 'f:MedicationAdministration/f:effectiveDateTime | f:MedicationAdministration/f:effectivePeriod', 'MedicationAdministration.effective', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'identifier', 'http://hl7.org/fhir/SearchParameter/medications-identifier', '', '3', 'f:MedicationRequest/f:identifier | f:MedicationAdministration/f:identifier | f:MedicationStatement/f:identifier | f:MedicationDispense/f:identifier', 'MedicationRequest.identifier | MedicationAdministration.identifier | MedicationStatement.identifier | MedicationDispense.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'medication', 'http://hl7.org/fhir/SearchParameter/medications-medication', '', '4', 'f:MedicationRequest/f:medicationReference | f:MedicationAdministration/f:medicationReference | f:MedicationStatement/f:medicationReference | f:MedicationDispense/f:medicationReference', 'MedicationRequest.medication.as(Reference) | MedicationAdministration.medication.as(Reference) | MedicationStatement.medication.as(Reference) | MedicationDispense.medication.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'not-given', 'http://hl7.org/fhir/SearchParameter/MedicationAdministration-not-given', 'Administrations that were not made', '3', 'f:MedicationAdministration/f:notGiven', 'MedicationAdministration.notGiven', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'patient', 'http://hl7.org/fhir/SearchParameter/medications-patient', '', '4', 'f:MedicationRequest/f:subject | f:MedicationAdministration/f:subject | f:MedicationStatement/f:subject | f:MedicationDispense/f:subject', 'MedicationRequest.subject | MedicationAdministration.subject | MedicationStatement.subject | MedicationDispense.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'performer', 'http://hl7.org/fhir/SearchParameter/MedicationAdministration-performer', 'The identify of the individual who administered the medication', '4', 'f:MedicationAdministration/f:performer/f:actor', 'MedicationAdministration.performer.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'prescription', 'http://hl7.org/fhir/SearchParameter/medications-prescription', '', '4', 'f:MedicationAdministration/f:prescription | f:MedicationDispense/f:authorizingPrescription', 'MedicationAdministration.prescription | MedicationDispense.authorizingPrescription', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'reason-given', 'http://hl7.org/fhir/SearchParameter/MedicationAdministration-reason-given', 'Reasons for administering the medication', '3', 'f:MedicationAdministration/f:reasonCode', 'MedicationAdministration.reasonCode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'reason-not-given', 'http://hl7.org/fhir/SearchParameter/MedicationAdministration-reason-not-given', 'Reasons for not administering the medication', '3', 'f:MedicationAdministration/f:reasonNotGiven', 'MedicationAdministration.reasonNotGiven', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'status', 'http://hl7.org/fhir/SearchParameter/medications-status', '', '3', 'f:MedicationRequest/f:status | f:MedicationAdministration/f:status | f:MedicationStatement/f:status | f:MedicationDispense/f:status', 'MedicationRequest.status | MedicationAdministration.status | MedicationStatement.status | MedicationDispense.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationAdministration', 'subject', 'http://hl7.org/fhir/SearchParameter/MedicationAdministration-subject', 'The identify of the individual or group to list administrations for', '4', 'f:MedicationAdministration/f:subject', 'MedicationAdministration.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'code', 'http://hl7.org/fhir/SearchParameter/medications-code', '', '3', 'f:Medication/f:code | f:MedicationRequest/f:medicationCodeableConcept | f:MedicationAdministration/f:medicationCodeableConcept | f:MedicationStatement/f:medicationCodeableConcept | f:MedicationDispense/f:medicationCodeableConcept', 'Medication.code | MedicationRequest.medication.as(CodeableConcept) | MedicationAdministration.medication.as(CodeableConcept) | MedicationStatement.medication.as(CodeableConcept) | MedicationDispense.medication.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'identifier', 'http://hl7.org/fhir/SearchParameter/medications-identifier', '', '3', 'f:MedicationRequest/f:identifier | f:MedicationAdministration/f:identifier | f:MedicationStatement/f:identifier | f:MedicationDispense/f:identifier', 'MedicationRequest.identifier | MedicationAdministration.identifier | MedicationStatement.identifier | MedicationDispense.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'medication', 'http://hl7.org/fhir/SearchParameter/medications-medication', '', '4', 'f:MedicationRequest/f:medicationReference | f:MedicationAdministration/f:medicationReference | f:MedicationStatement/f:medicationReference | f:MedicationDispense/f:medicationReference', 'MedicationRequest.medication.as(Reference) | MedicationAdministration.medication.as(Reference) | MedicationStatement.medication.as(Reference) | MedicationDispense.medication.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'patient', 'http://hl7.org/fhir/SearchParameter/medications-patient', '', '4', 'f:MedicationRequest/f:subject | f:MedicationAdministration/f:subject | f:MedicationStatement/f:subject | f:MedicationDispense/f:subject', 'MedicationRequest.subject | MedicationAdministration.subject | MedicationStatement.subject | MedicationDispense.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'prescription', 'http://hl7.org/fhir/SearchParameter/medications-prescription', '', '4', 'f:MedicationAdministration/f:prescription | f:MedicationDispense/f:authorizingPrescription', 'MedicationAdministration.prescription | MedicationDispense.authorizingPrescription', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'status', 'http://hl7.org/fhir/SearchParameter/medications-status', '', '3', 'f:MedicationRequest/f:status | f:MedicationAdministration/f:status | f:MedicationStatement/f:status | f:MedicationDispense/f:status', 'MedicationRequest.status | MedicationAdministration.status | MedicationStatement.status | MedicationDispense.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'context', 'http://hl7.org/fhir/SearchParameter/MedicationDispense-context', 'Returns dispenses with a specific context (episode or episode of care)', '4', 'f:MedicationDispense/f:context', 'MedicationDispense.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'destination', 'http://hl7.org/fhir/SearchParameter/MedicationDispense-destination', 'Return dispenses that should be sent to a specific destination', '4', 'f:MedicationDispense/f:destination', 'MedicationDispense.destination', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'performer', 'http://hl7.org/fhir/SearchParameter/MedicationDispense-performer', 'Return dispenses performed by a specific individual', '4', 'f:MedicationDispense/f:performer/f:actor', 'MedicationDispense.performer.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'receiver', 'http://hl7.org/fhir/SearchParameter/MedicationDispense-receiver', 'The identity of a receiver to list dispenses for', '4', 'f:MedicationDispense/f:receiver', 'MedicationDispense.receiver', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'responsibleparty', 'http://hl7.org/fhir/SearchParameter/MedicationDispense-responsibleparty', 'Return dispenses with the specified responsible party', '4', 'f:MedicationDispense/f:substitution/f:responsibleParty', 'MedicationDispense.substitution.responsibleParty', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'subject', 'http://hl7.org/fhir/SearchParameter/MedicationDispense-subject', 'The identity of a patient to list dispenses  for', '4', 'f:MedicationDispense/f:subject', 'MedicationDispense.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'type', 'http://hl7.org/fhir/SearchParameter/MedicationDispense-type', 'Return dispenses of a specific type', '3', 'f:MedicationDispense/f:type', 'MedicationDispense.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'whenhandedover', 'http://hl7.org/fhir/SearchParameter/MedicationDispense-whenhandedover', 'Returns dispenses handed over on this date', '1', 'f:MedicationDispense/f:whenHandedOver', 'MedicationDispense.whenHandedOver', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationDispense', 'whenprepared', 'http://hl7.org/fhir/SearchParameter/MedicationDispense-whenprepared', 'Returns dispenses prepared on this date', '1', 'f:MedicationDispense/f:whenPrepared', 'MedicationDispense.whenPrepared', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'code', 'http://hl7.org/fhir/SearchParameter/medications-code', '', '3', 'f:Medication/f:code | f:MedicationRequest/f:medicationCodeableConcept | f:MedicationAdministration/f:medicationCodeableConcept | f:MedicationStatement/f:medicationCodeableConcept | f:MedicationDispense/f:medicationCodeableConcept', 'Medication.code | MedicationRequest.medication.as(CodeableConcept) | MedicationAdministration.medication.as(CodeableConcept) | MedicationStatement.medication.as(CodeableConcept) | MedicationDispense.medication.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'identifier', 'http://hl7.org/fhir/SearchParameter/medications-identifier', '', '3', 'f:MedicationRequest/f:identifier | f:MedicationAdministration/f:identifier | f:MedicationStatement/f:identifier | f:MedicationDispense/f:identifier', 'MedicationRequest.identifier | MedicationAdministration.identifier | MedicationStatement.identifier | MedicationDispense.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'medication', 'http://hl7.org/fhir/SearchParameter/medications-medication', '', '4', 'f:MedicationRequest/f:medicationReference | f:MedicationAdministration/f:medicationReference | f:MedicationStatement/f:medicationReference | f:MedicationDispense/f:medicationReference', 'MedicationRequest.medication.as(Reference) | MedicationAdministration.medication.as(Reference) | MedicationStatement.medication.as(Reference) | MedicationDispense.medication.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'patient', 'http://hl7.org/fhir/SearchParameter/medications-patient', '', '4', 'f:MedicationRequest/f:subject | f:MedicationAdministration/f:subject | f:MedicationStatement/f:subject | f:MedicationDispense/f:subject', 'MedicationRequest.subject | MedicationAdministration.subject | MedicationStatement.subject | MedicationDispense.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'status', 'http://hl7.org/fhir/SearchParameter/medications-status', '', '3', 'f:MedicationRequest/f:status | f:MedicationAdministration/f:status | f:MedicationStatement/f:status | f:MedicationDispense/f:status', 'MedicationRequest.status | MedicationAdministration.status | MedicationStatement.status | MedicationDispense.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'authoredon', 'http://hl7.org/fhir/SearchParameter/MedicationRequest-authoredon', 'Return prescriptions written on this date', '1', 'f:MedicationRequest/f:authoredOn', 'MedicationRequest.authoredOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'category', 'http://hl7.org/fhir/SearchParameter/MedicationRequest-category', 'Returns prescriptions with different categories', '3', 'f:MedicationRequest/f:category', 'MedicationRequest.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'context', 'http://hl7.org/fhir/SearchParameter/MedicationRequest-context', 'Return prescriptions with this encounter or episode of care identifier', '4', 'f:MedicationRequest/f:context', 'MedicationRequest.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'date', 'http://hl7.org/fhir/SearchParameter/medications-date', '', '1', 'f:MedicationRequest/f:dosageInstruction/f:timing/f:event', 'MedicationRequest.dosageInstruction.timing.event', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'intended-dispenser', 'http://hl7.org/fhir/SearchParameter/MedicationRequest-intended-dispenser', 'Returns prescriptions intended to be dispensed by this Organization', '4', 'f:MedicationRequest/f:dispenseRequest/f:performer', 'MedicationRequest.dispenseRequest.performer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'intent', 'http://hl7.org/fhir/SearchParameter/MedicationRequest-intent', 'Returns prescriptions with different intents', '3', 'f:MedicationRequest/f:intent', 'MedicationRequest.intent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'priority', 'http://hl7.org/fhir/SearchParameter/MedicationRequest-priority', 'Returns prescriptions with different priorities', '3', 'f:MedicationRequest/f:priority', 'MedicationRequest.priority', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'requester', 'http://hl7.org/fhir/SearchParameter/MedicationRequest-requester', 'Returns prescriptions prescribed by this prescriber', '4', 'f:MedicationRequest/f:requester/f:agent', 'MedicationRequest.requester.agent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationRequest', 'subject', 'http://hl7.org/fhir/SearchParameter/MedicationRequest-subject', 'The identity of a patient to list orders  for', '4', 'f:MedicationRequest/f:subject', 'MedicationRequest.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'code', 'http://hl7.org/fhir/SearchParameter/medications-code', '', '3', 'f:Medication/f:code | f:MedicationRequest/f:medicationCodeableConcept | f:MedicationAdministration/f:medicationCodeableConcept | f:MedicationStatement/f:medicationCodeableConcept | f:MedicationDispense/f:medicationCodeableConcept', 'Medication.code | MedicationRequest.medication.as(CodeableConcept) | MedicationAdministration.medication.as(CodeableConcept) | MedicationStatement.medication.as(CodeableConcept) | MedicationDispense.medication.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'identifier', 'http://hl7.org/fhir/SearchParameter/medications-identifier', '', '3', 'f:MedicationRequest/f:identifier | f:MedicationAdministration/f:identifier | f:MedicationStatement/f:identifier | f:MedicationDispense/f:identifier', 'MedicationRequest.identifier | MedicationAdministration.identifier | MedicationStatement.identifier | MedicationDispense.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'medication', 'http://hl7.org/fhir/SearchParameter/medications-medication', '', '4', 'f:MedicationRequest/f:medicationReference | f:MedicationAdministration/f:medicationReference | f:MedicationStatement/f:medicationReference | f:MedicationDispense/f:medicationReference', 'MedicationRequest.medication.as(Reference) | MedicationAdministration.medication.as(Reference) | MedicationStatement.medication.as(Reference) | MedicationDispense.medication.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'patient', 'http://hl7.org/fhir/SearchParameter/medications-patient', '', '4', 'f:MedicationRequest/f:subject | f:MedicationAdministration/f:subject | f:MedicationStatement/f:subject | f:MedicationDispense/f:subject', 'MedicationRequest.subject | MedicationAdministration.subject | MedicationStatement.subject | MedicationDispense.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'status', 'http://hl7.org/fhir/SearchParameter/medications-status', '', '3', 'f:MedicationRequest/f:status | f:MedicationAdministration/f:status | f:MedicationStatement/f:status | f:MedicationDispense/f:status', 'MedicationRequest.status | MedicationAdministration.status | MedicationStatement.status | MedicationDispense.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'category', 'http://hl7.org/fhir/SearchParameter/MedicationStatement-category', 'Returns statements of this category of medicationstatement', '3', 'f:MedicationStatement/f:category', 'MedicationStatement.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'context', 'http://hl7.org/fhir/SearchParameter/MedicationStatement-context', 'Returns statements for a specific context (episode or episode of Care).', '4', 'f:MedicationStatement/f:context', 'MedicationStatement.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'effective', 'http://hl7.org/fhir/SearchParameter/MedicationStatement-effective', 'Date when patient was taking (or not taking) the medication', '1', 'f:MedicationStatement/f:effectiveDateTime | f:MedicationStatement/f:effectivePeriod', 'MedicationStatement.effective', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'part-of', 'http://hl7.org/fhir/SearchParameter/MedicationStatement-part-of', 'Returns statements that are part of another event.', '4', 'f:MedicationStatement/f:partOf', 'MedicationStatement.partOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'source', 'http://hl7.org/fhir/SearchParameter/MedicationStatement-source', 'Who or where the information in the statement came from', '4', 'f:MedicationStatement/f:informationSource', 'MedicationStatement.informationSource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MedicationStatement', 'subject', 'http://hl7.org/fhir/SearchParameter/MedicationStatement-subject', 'The identity of a patient, animal or group to list statements for', '4', 'f:MedicationStatement/f:subject', 'MedicationStatement.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'category', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-category', 'The behavior associated with the message', '3', 'f:MessageDefinition/f:category', 'MessageDefinition.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'date', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-date', 'The message definition publication date', '1', 'f:MessageDefinition/f:date', 'MessageDefinition.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'description', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-description', 'The description of the message definition', '2', 'f:MessageDefinition/f:description', 'MessageDefinition.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'event', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-event', 'The event that triggers the message', '3', 'f:MessageDefinition/f:event', 'MessageDefinition.event', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'focus', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-focus', 'A resource that is a permitted focus of the message', '3', 'f:MessageDefinition/f:focus/f:code', 'MessageDefinition.focus.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'identifier', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-identifier', 'External identifier for the message definition', '3', 'f:MessageDefinition/f:identifier', 'MessageDefinition.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-jurisdiction', 'Intended jurisdiction for the message definition', '3', 'f:MessageDefinition/f:jurisdiction', 'MessageDefinition.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'name', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-name', 'Computationally friendly name of the message definition', '2', 'f:MessageDefinition/f:name', 'MessageDefinition.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'publisher', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-publisher', 'Name of the publisher of the message definition', '2', 'f:MessageDefinition/f:publisher', 'MessageDefinition.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'status', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-status', 'The current status of the message definition', '3', 'f:MessageDefinition/f:status', 'MessageDefinition.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'title', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-title', 'The human-friendly name of the message definition', '2', 'f:MessageDefinition/f:title', 'MessageDefinition.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'url', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-url', 'The uri that identifies the message definition', '7', 'f:MessageDefinition/f:url', 'MessageDefinition.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageDefinition', 'version', 'http://hl7.org/fhir/SearchParameter/MessageDefinition-version', 'The business version of the message definition', '3', 'f:MessageDefinition/f:version', 'MessageDefinition.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'author', 'http://hl7.org/fhir/SearchParameter/MessageHeader-author', 'The source of the decision', '4', 'f:MessageHeader/f:author', 'MessageHeader.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'code', 'http://hl7.org/fhir/SearchParameter/MessageHeader-code', 'ok | transient-error | fatal-error', '3', 'f:MessageHeader/f:response/f:code', 'MessageHeader.response.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'destination', 'http://hl7.org/fhir/SearchParameter/MessageHeader-destination', 'Name of system', '2', 'f:MessageHeader/f:destination/f:name', 'MessageHeader.destination.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'destination-uri', 'http://hl7.org/fhir/SearchParameter/MessageHeader-destination-uri', 'Actual destination address or id', '7', 'f:MessageHeader/f:destination/f:endpoint', 'MessageHeader.destination.endpoint', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'enterer', 'http://hl7.org/fhir/SearchParameter/MessageHeader-enterer', 'The source of the data entry', '4', 'f:MessageHeader/f:enterer', 'MessageHeader.enterer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'event', 'http://hl7.org/fhir/SearchParameter/MessageHeader-event', 'Code for the event this message represents', '3', 'f:MessageHeader/f:event', 'MessageHeader.event', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'focus', 'http://hl7.org/fhir/SearchParameter/MessageHeader-focus', 'The actual content of the message', '4', 'f:MessageHeader/f:focus', 'MessageHeader.focus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'receiver', 'http://hl7.org/fhir/SearchParameter/MessageHeader-receiver', 'Intended "real-world" recipient for the data', '4', 'f:MessageHeader/f:receiver', 'MessageHeader.receiver', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'response-id', 'http://hl7.org/fhir/SearchParameter/MessageHeader-response-id', 'Id of original message', '3', 'f:MessageHeader/f:response/f:identifier', 'MessageHeader.response.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'responsible', 'http://hl7.org/fhir/SearchParameter/MessageHeader-responsible', 'Final responsibility for event', '4', 'f:MessageHeader/f:responsible', 'MessageHeader.responsible', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'sender', 'http://hl7.org/fhir/SearchParameter/MessageHeader-sender', 'Real world sender of the message', '4', 'f:MessageHeader/f:sender', 'MessageHeader.sender', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'source', 'http://hl7.org/fhir/SearchParameter/MessageHeader-source', 'Name of system', '2', 'f:MessageHeader/f:source/f:name', 'MessageHeader.source.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'source-uri', 'http://hl7.org/fhir/SearchParameter/MessageHeader-source-uri', 'Actual message source address or id', '7', 'f:MessageHeader/f:source/f:endpoint', 'MessageHeader.source.endpoint', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'target', 'http://hl7.org/fhir/SearchParameter/MessageHeader-target', 'Particular delivery destination within the destination', '4', 'f:MessageHeader/f:destination/f:target', 'MessageHeader.destination.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('MessageHeader', 'timestamp', 'http://hl7.org/fhir/SearchParameter/MessageHeader-timestamp', 'Time that the message was sent', '1', 'f:MessageHeader/f:timestamp', 'MessageHeader.timestamp', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'contact', 'http://hl7.org/fhir/SearchParameter/NamingSystem-contact', 'Name of an individual to contact', '2', 'f:NamingSystem/f:contact/f:name', 'NamingSystem.contact.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'date', 'http://hl7.org/fhir/SearchParameter/NamingSystem-date', 'The naming system publication date', '1', 'f:NamingSystem/f:date', 'NamingSystem.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'description', 'http://hl7.org/fhir/SearchParameter/NamingSystem-description', 'The description of the naming system', '2', 'f:NamingSystem/f:description', 'NamingSystem.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'id-type', 'http://hl7.org/fhir/SearchParameter/NamingSystem-id-type', 'oid | uuid | uri | other', '3', 'f:NamingSystem/f:uniqueId/f:type', 'NamingSystem.uniqueId.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/NamingSystem-jurisdiction', 'Intended jurisdiction for the naming system', '3', 'f:NamingSystem/f:jurisdiction', 'NamingSystem.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'kind', 'http://hl7.org/fhir/SearchParameter/NamingSystem-kind', 'codesystem | identifier | root', '3', 'f:NamingSystem/f:kind', 'NamingSystem.kind', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'name', 'http://hl7.org/fhir/SearchParameter/NamingSystem-name', 'Computationally friendly name of the naming system', '2', 'f:NamingSystem/f:name', 'NamingSystem.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'period', 'http://hl7.org/fhir/SearchParameter/NamingSystem-period', 'When is identifier valid?', '1', 'f:NamingSystem/f:uniqueId/f:period', 'NamingSystem.uniqueId.period', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'publisher', 'http://hl7.org/fhir/SearchParameter/NamingSystem-publisher', 'Name of the publisher of the naming system', '2', 'f:NamingSystem/f:publisher', 'NamingSystem.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'replaced-by', 'http://hl7.org/fhir/SearchParameter/NamingSystem-replaced-by', 'Use this instead', '4', 'f:NamingSystem/f:replacedBy', 'NamingSystem.replacedBy', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'responsible', 'http://hl7.org/fhir/SearchParameter/NamingSystem-responsible', 'Who maintains system namespace?', '2', 'f:NamingSystem/f:responsible', 'NamingSystem.responsible', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'status', 'http://hl7.org/fhir/SearchParameter/NamingSystem-status', 'The current status of the naming system', '3', 'f:NamingSystem/f:status', 'NamingSystem.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'telecom', 'http://hl7.org/fhir/SearchParameter/NamingSystem-telecom', 'Contact details for individual or organization', '3', 'f:NamingSystem/f:contact/f:telecom', 'NamingSystem.contact.telecom', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'type', 'http://hl7.org/fhir/SearchParameter/NamingSystem-type', 'e.g. driver,  provider,  patient, bank etc.', '3', 'f:NamingSystem/f:type', 'NamingSystem.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NamingSystem', 'value', 'http://hl7.org/fhir/SearchParameter/NamingSystem-value', 'The unique identifier', '2', 'f:NamingSystem/f:uniqueId/f:value', 'NamingSystem.uniqueId.value', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'additive', 'http://hl7.org/fhir/SearchParameter/NutritionOrder-additive', 'Type of module component to add to the feeding', '3', 'f:NutritionOrder/f:enteralFormula/f:additiveType', 'NutritionOrder.enteralFormula.additiveType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'datetime', 'http://hl7.org/fhir/SearchParameter/NutritionOrder-datetime', 'Return nutrition orders requested on this date', '1', 'f:NutritionOrder/f:dateTime', 'NutritionOrder.dateTime', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'formula', 'http://hl7.org/fhir/SearchParameter/NutritionOrder-formula', 'Type of enteral or infant formula', '3', 'f:NutritionOrder/f:enteralFormula/f:baseFormulaType', 'NutritionOrder.enteralFormula.baseFormulaType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'oraldiet', 'http://hl7.org/fhir/SearchParameter/NutritionOrder-oraldiet', 'Type of diet that can be consumed orally (i.e., take via the mouth).', '3', 'f:NutritionOrder/f:oralDiet/f:type', 'NutritionOrder.oralDiet.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'provider', 'http://hl7.org/fhir/SearchParameter/NutritionOrder-provider', 'The identify of the provider who placed the nutrition order', '4', 'f:NutritionOrder/f:orderer', 'NutritionOrder.orderer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'status', 'http://hl7.org/fhir/SearchParameter/NutritionOrder-status', 'Status of the nutrition order.', '3', 'f:NutritionOrder/f:status', 'NutritionOrder.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('NutritionOrder', 'supplement', 'http://hl7.org/fhir/SearchParameter/NutritionOrder-supplement', 'Type of supplement product requested', '3', 'f:NutritionOrder/f:supplement/f:type', 'NutritionOrder.supplement.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'code', 'http://hl7.org/fhir/SearchParameter/clinical-code', '', '3', 'f:FamilyMemberHistory/f:condition/f:code | f:DeviceRequest/f:codeCodeableConcept | f:AllergyIntolerance/f:code | f:AllergyIntolerance/f:reaction/f:substance | f:Procedure/f:code | f:List/f:code | f:ProcedureRequest/f:code | f:Observation/f:code | f:DiagnosticReport/f:code | f:Condition/f:code', 'FamilyMemberHistory.condition.code | DeviceRequest.code.as(CodeableConcept) | AllergyIntolerance.code | AllergyIntolerance.reaction.substance | Procedure.code | List.code | ProcedureRequest.code | Observation.code | DiagnosticReport.code | Condition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'based-on', 'http://hl7.org/fhir/SearchParameter/Observation-based-on', 'Reference to the test or procedure request.', '4', 'f:Observation/f:basedOn', 'Observation.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'category', 'http://hl7.org/fhir/SearchParameter/Observation-category', 'The classification of the type of observation', '3', 'f:Observation/f:category', 'Observation.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'code-value-concept', 'http://hl7.org/fhir/SearchParameter/Observation-code-value-concept', 'Code and coded value parameter pair', '5', '', 'Observation', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'code-value-date', 'http://hl7.org/fhir/SearchParameter/Observation-code-value-date', 'Code and date/time value parameter pair', '5', '', 'Observation', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'code-value-quantity', 'http://hl7.org/fhir/SearchParameter/Observation-code-value-quantity', 'Code and quantity value parameter pair', '5', '', 'Observation', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'code-value-string', 'http://hl7.org/fhir/SearchParameter/Observation-code-value-string', 'Code and string value parameter pair', '5', '', 'Observation', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'combo-code', 'http://hl7.org/fhir/SearchParameter/Observation-combo-code', 'The code of the observation type or component type', '3', 'f:Observation/f:code | f:Observation/f:component/f:code', 'Observation.code | Observation.component.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'combo-code-value-concept', 'http://hl7.org/fhir/SearchParameter/Observation-combo-code-value-concept', 'Code and coded value parameter pair, including in components', '5', '', 'Observation | Observation.component', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'combo-code-value-quantity', 'http://hl7.org/fhir/SearchParameter/Observation-combo-code-value-quantity', 'Code and quantity value parameter pair, including in components', '5', '', 'Observation | Observation.component', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'combo-data-absent-reason', 'http://hl7.org/fhir/SearchParameter/Observation-combo-data-absent-reason', 'The reason why the expected value in the element Observation.value[x] or Observation.component.value[x] is missing.', '3', 'f:Observation/f:dataAbsentReason | f:Observation/f:component/f:dataAbsentReason', 'Observation.dataAbsentReason | Observation.component.dataAbsentReason', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'combo-value-concept', 'http://hl7.org/fhir/SearchParameter/Observation-combo-value-concept', 'The value or component value of the observation, if the value is a CodeableConcept', '3', 'f:Observation/f:valueCodeableConcept | f:Observation/f:component/f:valueCodeableConcept', 'Observation.value.as(CodeableConcept) | Observation.component.value.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'combo-value-quantity', 'http://hl7.org/fhir/SearchParameter/Observation-combo-value-quantity', 'The value or component value of the observation, if the value is a Quantity, or a SampledData (just search on the bounds of the values in sampled data)', '6', 'f:Observation/f:valueQuantity | f:Observation/f:component/f:valueQuantity', 'Observation.value.as(Quantity) | Observation.component.value.as(Quantity)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'component-code', 'http://hl7.org/fhir/SearchParameter/Observation-component-code', 'The component code of the observation type', '3', 'f:Observation/f:component/f:code', 'Observation.component.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'component-code-value-concept', 'http://hl7.org/fhir/SearchParameter/Observation-component-code-value-concept', 'Component code and component coded value parameter pair', '5', '', 'Observation.component', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'component-code-value-quantity', 'http://hl7.org/fhir/SearchParameter/Observation-component-code-value-quantity', 'Component code and component quantity value parameter pair', '5', '', 'Observation.component', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'component-data-absent-reason', 'http://hl7.org/fhir/SearchParameter/Observation-component-data-absent-reason', 'The reason why the expected value in the element Observation.component.value[x] is missing.', '3', 'f:Observation/f:component/f:dataAbsentReason', 'Observation.component.dataAbsentReason', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'component-value-concept', 'http://hl7.org/fhir/SearchParameter/Observation-component-value-concept', 'The value of the component observation, if the value is a CodeableConcept', '3', 'f:Observation/f:component/f:valueCodeableConcept', 'Observation.component.value.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'component-value-quantity', 'http://hl7.org/fhir/SearchParameter/Observation-component-value-quantity', 'The value of the component observation, if the value is a Quantity, or a SampledData (just search on the bounds of the values in sampled data)', '6', 'f:Observation/f:component/f:valueQuantity', 'Observation.component.value.as(Quantity)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'context', 'http://hl7.org/fhir/SearchParameter/Observation-context', 'Healthcare event  (Episode-of-care or Encounter) related to the observation', '4', 'f:Observation/f:context', 'Observation.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'data-absent-reason', 'http://hl7.org/fhir/SearchParameter/Observation-data-absent-reason', 'The reason why the expected value in the element Observation.value[x] is missing.', '3', 'f:Observation/f:dataAbsentReason', 'Observation.dataAbsentReason', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'device', 'http://hl7.org/fhir/SearchParameter/Observation-device', 'The Device that generated the observation data.', '4', 'f:Observation/f:device', 'Observation.device', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'method', 'http://hl7.org/fhir/SearchParameter/Observation-method', 'The method used for the observation', '3', 'f:Observation/f:method', 'Observation.method', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'performer', 'http://hl7.org/fhir/SearchParameter/Observation-performer', 'Who performed the observation', '4', 'f:Observation/f:performer', 'Observation.performer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'related', 'http://hl7.org/fhir/SearchParameter/Observation-related', 'Related Observations - search on related-type and related-target together', '5', '', 'Observation.related', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'related-target', 'http://hl7.org/fhir/SearchParameter/Observation-related-target', 'Resource that is related to this one', '4', 'f:Observation/f:related/f:target', 'Observation.related.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'related-type', 'http://hl7.org/fhir/SearchParameter/Observation-related-type', 'has-member | derived-from | sequel-to | replaces | qualified-by | interfered-by', '3', 'f:Observation/f:related/f:type', 'Observation.related.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'specimen', 'http://hl7.org/fhir/SearchParameter/Observation-specimen', 'Specimen used for this observation', '4', 'f:Observation/f:specimen', 'Observation.specimen', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'status', 'http://hl7.org/fhir/SearchParameter/Observation-status', 'The status of the observation', '3', 'f:Observation/f:status', 'Observation.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'subject', 'http://hl7.org/fhir/SearchParameter/Observation-subject', 'The subject that the observation is about', '4', 'f:Observation/f:subject', 'Observation.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'value-concept', 'http://hl7.org/fhir/SearchParameter/Observation-value-concept', 'The value of the observation, if the value is a CodeableConcept', '3', 'f:Observation/f:valueCodeableConcept', 'Observation.value.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'value-date', 'http://hl7.org/fhir/SearchParameter/Observation-value-date', 'The value of the observation, if the value is a date or period of time', '1', 'f:Observation/f:valueDateTime | f:Observation/f:valuePeriod', 'Observation.value.as(DateTime) | Observation.value.as(Period)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'value-quantity', 'http://hl7.org/fhir/SearchParameter/Observation-value-quantity', 'The value of the observation, if the value is a Quantity, or a SampledData (just search on the bounds of the values in sampled data)', '6', 'f:Observation/f:valueQuantity', 'Observation.value.as(Quantity)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Observation', 'value-string', 'http://hl7.org/fhir/SearchParameter/Observation-value-string', 'The value of the observation, if the value is a string, and also searches in CodeableConcept.text', '2', 'f:Observation/f:valueString', 'Observation.value.as(String)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'base', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-base', 'Marks this as a profile of the base', '4', 'f:OperationDefinition/f:base', 'OperationDefinition.base', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'code', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-code', 'Name used to invoke the operation', '3', 'f:OperationDefinition/f:code', 'OperationDefinition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'date', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-date', 'The operation definition publication date', '1', 'f:OperationDefinition/f:date', 'OperationDefinition.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'description', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-description', 'The description of the operation definition', '2', 'f:OperationDefinition/f:description', 'OperationDefinition.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'instance', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-instance', 'Invoke on an instance?', '3', 'f:OperationDefinition/f:instance', 'OperationDefinition.instance', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-jurisdiction', 'Intended jurisdiction for the operation definition', '3', 'f:OperationDefinition/f:jurisdiction', 'OperationDefinition.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'kind', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-kind', 'operation | query', '3', 'f:OperationDefinition/f:kind', 'OperationDefinition.kind', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'name', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-name', 'Computationally friendly name of the operation definition', '2', 'f:OperationDefinition/f:name', 'OperationDefinition.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'param-profile', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-param-profile', 'Profile on the type', '4', 'f:OperationDefinition/f:parameter/f:profile', 'OperationDefinition.parameter.profile', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'publisher', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-publisher', 'Name of the publisher of the operation definition', '2', 'f:OperationDefinition/f:publisher', 'OperationDefinition.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'status', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-status', 'The current status of the operation definition', '3', 'f:OperationDefinition/f:status', 'OperationDefinition.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'system', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-system', 'Invoke at the system level?', '3', 'f:OperationDefinition/f:system', 'OperationDefinition.system', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'type', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-type', 'Invole at the type level?', '3', 'f:OperationDefinition/f:type', 'OperationDefinition.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'url', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-url', 'The uri that identifies the operation definition', '7', 'f:OperationDefinition/f:url', 'OperationDefinition.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('OperationDefinition', 'version', 'http://hl7.org/fhir/SearchParameter/OperationDefinition-version', 'The business version of the operation definition', '3', 'f:OperationDefinition/f:version', 'OperationDefinition.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'active', 'http://hl7.org/fhir/SearchParameter/Organization-active', 'A server defined search that may match any of the string fields in the Address, including line, city, state, country, postalCode, and/or text', '3', 'f:Organization/f:active', 'Organization.active', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'address', 'http://hl7.org/fhir/SearchParameter/Organization-address', 'A (part of the) address of the organization', '2', 'f:Organization/f:address', 'Organization.address', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'address-city', 'http://hl7.org/fhir/SearchParameter/Organization-address-city', 'A city specified in an address', '2', 'f:Organization/f:address/f:city', 'Organization.address.city', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'address-country', 'http://hl7.org/fhir/SearchParameter/Organization-address-country', 'A country specified in an address', '2', 'f:Organization/f:address/f:country', 'Organization.address.country', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'address-postalcode', 'http://hl7.org/fhir/SearchParameter/Organization-address-postalcode', 'A postal code specified in an address', '2', 'f:Organization/f:address/f:postalCode', 'Organization.address.postalCode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'address-state', 'http://hl7.org/fhir/SearchParameter/Organization-address-state', 'A state specified in an address', '2', 'f:Organization/f:address/f:state', 'Organization.address.state', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'address-use', 'http://hl7.org/fhir/SearchParameter/Organization-address-use', 'A use code specified in an address', '3', 'f:Organization/f:address/f:use', 'Organization.address.use', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'endpoint', 'http://hl7.org/fhir/SearchParameter/Organization-endpoint', 'Technical endpoints providing access to services operated for the organization', '4', 'f:Organization/f:endpoint', 'Organization.endpoint', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'identifier', 'http://hl7.org/fhir/SearchParameter/Organization-identifier', 'Any identifier for the organization (not the accreditation issuer''s identifier)', '3', 'f:Organization/f:identifier', 'Organization.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'name', 'http://hl7.org/fhir/SearchParameter/Organization-name', 'A portion of the organization''s name or alias', '2', 'f:Organization/f:name | f:Organization/f:alias', 'Organization.name | Organization.alias', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'partof', 'http://hl7.org/fhir/SearchParameter/Organization-partof', 'An organization of which this organization forms a part', '4', 'f:Organization/f:partOf', 'Organization.partOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'phonetic', 'http://hl7.org/fhir/SearchParameter/Organization-phonetic', 'A portion of the organization''s name using some kind of phonetic matching algorithm', '2', 'f:Organization/f:name', 'Organization.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Organization', 'type', 'http://hl7.org/fhir/SearchParameter/Organization-type', 'A code for the type of organization', '3', 'f:Organization/f:type', 'Organization.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'active', 'http://hl7.org/fhir/SearchParameter/Patient-active', 'Whether the patient record is active', '3', 'f:Patient/f:active', 'Patient.active', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'address', 'http://hl7.org/fhir/SearchParameter/individual-address', '', '2', 'f:RelatedPerson/f:address | f:Practitioner/f:address | f:Person/f:address | f:Patient/f:address', 'RelatedPerson.address | Practitioner.address | Person.address | Patient.address', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'address-city', 'http://hl7.org/fhir/SearchParameter/individual-address-city', '', '2', 'f:RelatedPerson/f:address/f:city | f:Practitioner/f:address/f:city | f:Person/f:address/f:city | f:Patient/f:address/f:city', 'RelatedPerson.address.city | Practitioner.address.city | Person.address.city | Patient.address.city', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'address-country', 'http://hl7.org/fhir/SearchParameter/individual-address-country', '', '2', 'f:RelatedPerson/f:address/f:country | f:Practitioner/f:address/f:country | f:Person/f:address/f:country | f:Patient/f:address/f:country', 'RelatedPerson.address.country | Practitioner.address.country | Person.address.country | Patient.address.country', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'address-postalcode', 'http://hl7.org/fhir/SearchParameter/individual-address-postalcode', '', '2', 'f:RelatedPerson/f:address/f:postalCode | f:Practitioner/f:address/f:postalCode | f:Person/f:address/f:postalCode | f:Patient/f:address/f:postalCode', 'RelatedPerson.address.postalCode | Practitioner.address.postalCode | Person.address.postalCode | Patient.address.postalCode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'address-state', 'http://hl7.org/fhir/SearchParameter/individual-address-state', '', '2', 'f:RelatedPerson/f:address/f:state | f:Practitioner/f:address/f:state | f:Person/f:address/f:state | f:Patient/f:address/f:state', 'RelatedPerson.address.state | Practitioner.address.state | Person.address.state | Patient.address.state', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'address-use', 'http://hl7.org/fhir/SearchParameter/individual-address-use', '', '3', 'f:RelatedPerson/f:address/f:use | f:Practitioner/f:address/f:use | f:Person/f:address/f:use | f:Patient/f:address/f:use', 'RelatedPerson.address.use | Practitioner.address.use | Person.address.use | Patient.address.use', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'animal-breed', 'http://hl7.org/fhir/SearchParameter/Patient-animal-breed', 'The breed for animal patients', '3', 'f:Patient/f:animal/f:breed', 'Patient.animal.breed', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'animal-species', 'http://hl7.org/fhir/SearchParameter/Patient-animal-species', 'The species for animal patients', '3', 'f:Patient/f:animal/f:species', 'Patient.animal.species', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'birthdate', 'http://hl7.org/fhir/SearchParameter/individual-birthdate', '', '1', 'f:RelatedPerson/f:birthDate | f:Person/f:birthDate | f:Patient/f:birthDate', 'RelatedPerson.birthDate | Person.birthDate | Patient.birthDate', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'death-date', 'http://hl7.org/fhir/SearchParameter/Patient-death-date', 'The date of death has been provided and satisfies this search value', '1', 'f:Patient/f:deceasedDateTime', 'Patient.deceased.as(DateTime)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'deceased', 'http://hl7.org/fhir/SearchParameter/Patient-deceased', 'This patient has been marked as deceased, or as a death date entered', '3', 'f:Patient/f:deceasedBoolean | f:Patient/f:deceasedDateTime', 'Patient.deceased.exists()', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'email', 'http://hl7.org/fhir/SearchParameter/individual-email', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''email''] | f:RelatedPerson/f:telecom[system/@value=''email''] | f:Practitioner/f:telecom[system/@value=''email''] | f:Person/f:telecom[system/@value=''email''] | f:Patient/f:telecom[system/@value=''email'']', 'PractitionerRole.telecom.where(system=''email'') | RelatedPerson.telecom.where(system=''email'') | Practitioner.telecom.where(system=''email'') | Person.telecom.where(system=''email'') | Patient.telecom.where(system=''email'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'family', 'http://hl7.org/fhir/SearchParameter/individual-family', '', '2', 'f:Practitioner/f:name/f:family | f:Patient/f:name/f:family', 'Practitioner.name.family | Patient.name.family', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'gender', 'http://hl7.org/fhir/SearchParameter/individual-gender', '', '3', 'f:RelatedPerson/f:gender | f:Practitioner/f:gender | f:Person/f:gender | f:Patient/f:gender', 'RelatedPerson.gender | Practitioner.gender | Person.gender | Patient.gender', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'general-practitioner', 'http://hl7.org/fhir/SearchParameter/Patient-general-practitioner', 'Patient''s nominated general practitioner, not the organization that manages the record', '4', 'f:Patient/f:generalPractitioner', 'Patient.generalPractitioner', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'given', 'http://hl7.org/fhir/SearchParameter/individual-given', '', '2', 'f:Practitioner/f:name/f:given | f:Patient/f:name/f:given', 'Practitioner.name.given | Patient.name.given', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'identifier', 'http://hl7.org/fhir/SearchParameter/Patient-identifier', 'A patient identifier', '3', 'f:Patient/f:identifier', 'Patient.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'language', 'http://hl7.org/fhir/SearchParameter/Patient-language', 'Language code (irrespective of use value)', '3', 'f:Patient/f:communication/f:language', 'Patient.communication.language', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'link', 'http://hl7.org/fhir/SearchParameter/Patient-link', 'All patients linked to the given patient', '4', 'f:Patient/f:link/f:other', 'Patient.link.other', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'name', 'http://hl7.org/fhir/SearchParameter/Patient-name', 'A server defined search that may match any of the string fields in the HumanName, including family, give, prefix, suffix, suffix, and/or text', '2', 'f:Patient/f:name', 'Patient.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'organization', 'http://hl7.org/fhir/SearchParameter/Patient-organization', 'The organization at which this person is a patient', '4', 'f:Patient/f:managingOrganization', 'Patient.managingOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'phone', 'http://hl7.org/fhir/SearchParameter/individual-phone', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''phone''] | f:RelatedPerson/f:telecom[system/@value=''phone''] | f:Practitioner/f:telecom[system/@value=''phone''] | f:Person/f:telecom[system/@value=''phone''] | f:Patient/f:telecom[system/@value=''phone'']', 'PractitionerRole.telecom.where(system=''phone'') | RelatedPerson.telecom.where(system=''phone'') | Practitioner.telecom.where(system=''phone'') | Person.telecom.where(system=''phone'') | Patient.telecom.where(system=''phone'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'phonetic', 'http://hl7.org/fhir/SearchParameter/individual-phonetic', '', '2', 'f:RelatedPerson/f:name | f:Practitioner/f:name | f:Person/f:name | f:Patient/f:name', 'RelatedPerson.name | Practitioner.name | Person.name | Patient.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Patient', 'telecom', 'http://hl7.org/fhir/SearchParameter/individual-telecom', '', '3', 'f:PractitionerRole/f:telecom | f:RelatedPerson/f:telecom | f:Practitioner/f:telecom | f:Person/f:telecom | f:Patient/f:telecom', 'PractitionerRole.telecom | RelatedPerson.telecom | Practitioner.telecom | Person.telecom | Patient.telecom', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentNotice', 'created', 'http://hl7.org/fhir/SearchParameter/PaymentNotice-created', 'Creation date fro the notice', '1', 'f:PaymentNotice/f:created', 'PaymentNotice.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentNotice', 'identifier', 'http://hl7.org/fhir/SearchParameter/PaymentNotice-identifier', 'The business identifier of the notice', '3', 'f:PaymentNotice/f:identifier', 'PaymentNotice.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentNotice', 'organization', 'http://hl7.org/fhir/SearchParameter/PaymentNotice-organization', 'The organization who generated this resource', '4', 'f:PaymentNotice/f:organization', 'PaymentNotice.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentNotice', 'payment-status', 'http://hl7.org/fhir/SearchParameter/PaymentNotice-payment-status', 'The type of payment notice', '3', 'f:PaymentNotice/f:paymentStatus', 'PaymentNotice.paymentStatus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentNotice', 'provider', 'http://hl7.org/fhir/SearchParameter/PaymentNotice-provider', 'The reference to the provider', '4', 'f:PaymentNotice/f:provider', 'PaymentNotice.provider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentNotice', 'request', 'http://hl7.org/fhir/SearchParameter/PaymentNotice-request', 'The Claim', '4', 'f:PaymentNotice/f:request', 'PaymentNotice.request', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentNotice', 'response', 'http://hl7.org/fhir/SearchParameter/PaymentNotice-response', 'The ClaimResponse', '4', 'f:PaymentNotice/f:response', 'PaymentNotice.response', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentNotice', 'statusdate', 'http://hl7.org/fhir/SearchParameter/PaymentNotice-statusdate', 'The date of the payment action', '1', 'f:PaymentNotice/f:statusDate', 'PaymentNotice.statusDate', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentReconciliation', 'created', 'http://hl7.org/fhir/SearchParameter/PaymentReconciliation-created', 'The creation date', '1', 'f:PaymentReconciliation/f:created', 'PaymentReconciliation.created', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentReconciliation', 'disposition', 'http://hl7.org/fhir/SearchParameter/PaymentReconciliation-disposition', 'The contents of the disposition message', '2', 'f:PaymentReconciliation/f:disposition', 'PaymentReconciliation.disposition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentReconciliation', 'identifier', 'http://hl7.org/fhir/SearchParameter/PaymentReconciliation-identifier', 'The business identifier of the Explanation of Benefit', '3', 'f:PaymentReconciliation/f:identifier', 'PaymentReconciliation.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentReconciliation', 'organization', 'http://hl7.org/fhir/SearchParameter/PaymentReconciliation-organization', 'The organization who generated this resource', '4', 'f:PaymentReconciliation/f:organization', 'PaymentReconciliation.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentReconciliation', 'outcome', 'http://hl7.org/fhir/SearchParameter/PaymentReconciliation-outcome', 'The processing outcome', '3', 'f:PaymentReconciliation/f:outcome', 'PaymentReconciliation.outcome', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentReconciliation', 'request', 'http://hl7.org/fhir/SearchParameter/PaymentReconciliation-request', 'The reference to the claim', '4', 'f:PaymentReconciliation/f:request', 'PaymentReconciliation.request', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentReconciliation', 'request-organization', 'http://hl7.org/fhir/SearchParameter/PaymentReconciliation-request-organization', 'The organization who generated this resource', '4', 'f:PaymentReconciliation/f:requestOrganization', 'PaymentReconciliation.requestOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PaymentReconciliation', 'request-provider', 'http://hl7.org/fhir/SearchParameter/PaymentReconciliation-request-provider', 'The reference to the provider who sumbitted the claim', '4', 'f:PaymentReconciliation/f:requestProvider', 'PaymentReconciliation.requestProvider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'address', 'http://hl7.org/fhir/SearchParameter/individual-address', '', '2', 'f:RelatedPerson/f:address | f:Practitioner/f:address | f:Person/f:address | f:Patient/f:address', 'RelatedPerson.address | Practitioner.address | Person.address | Patient.address', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'address-city', 'http://hl7.org/fhir/SearchParameter/individual-address-city', '', '2', 'f:RelatedPerson/f:address/f:city | f:Practitioner/f:address/f:city | f:Person/f:address/f:city | f:Patient/f:address/f:city', 'RelatedPerson.address.city | Practitioner.address.city | Person.address.city | Patient.address.city', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'address-country', 'http://hl7.org/fhir/SearchParameter/individual-address-country', '', '2', 'f:RelatedPerson/f:address/f:country | f:Practitioner/f:address/f:country | f:Person/f:address/f:country | f:Patient/f:address/f:country', 'RelatedPerson.address.country | Practitioner.address.country | Person.address.country | Patient.address.country', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'address-postalcode', 'http://hl7.org/fhir/SearchParameter/individual-address-postalcode', '', '2', 'f:RelatedPerson/f:address/f:postalCode | f:Practitioner/f:address/f:postalCode | f:Person/f:address/f:postalCode | f:Patient/f:address/f:postalCode', 'RelatedPerson.address.postalCode | Practitioner.address.postalCode | Person.address.postalCode | Patient.address.postalCode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'address-state', 'http://hl7.org/fhir/SearchParameter/individual-address-state', '', '2', 'f:RelatedPerson/f:address/f:state | f:Practitioner/f:address/f:state | f:Person/f:address/f:state | f:Patient/f:address/f:state', 'RelatedPerson.address.state | Practitioner.address.state | Person.address.state | Patient.address.state', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'address-use', 'http://hl7.org/fhir/SearchParameter/individual-address-use', '', '3', 'f:RelatedPerson/f:address/f:use | f:Practitioner/f:address/f:use | f:Person/f:address/f:use | f:Patient/f:address/f:use', 'RelatedPerson.address.use | Practitioner.address.use | Person.address.use | Patient.address.use', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'birthdate', 'http://hl7.org/fhir/SearchParameter/individual-birthdate', '', '1', 'f:RelatedPerson/f:birthDate | f:Person/f:birthDate | f:Patient/f:birthDate', 'RelatedPerson.birthDate | Person.birthDate | Patient.birthDate', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'email', 'http://hl7.org/fhir/SearchParameter/individual-email', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''email''] | f:RelatedPerson/f:telecom[system/@value=''email''] | f:Practitioner/f:telecom[system/@value=''email''] | f:Person/f:telecom[system/@value=''email''] | f:Patient/f:telecom[system/@value=''email'']', 'PractitionerRole.telecom.where(system=''email'') | RelatedPerson.telecom.where(system=''email'') | Practitioner.telecom.where(system=''email'') | Person.telecom.where(system=''email'') | Patient.telecom.where(system=''email'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'gender', 'http://hl7.org/fhir/SearchParameter/individual-gender', '', '3', 'f:RelatedPerson/f:gender | f:Practitioner/f:gender | f:Person/f:gender | f:Patient/f:gender', 'RelatedPerson.gender | Practitioner.gender | Person.gender | Patient.gender', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'phone', 'http://hl7.org/fhir/SearchParameter/individual-phone', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''phone''] | f:RelatedPerson/f:telecom[system/@value=''phone''] | f:Practitioner/f:telecom[system/@value=''phone''] | f:Person/f:telecom[system/@value=''phone''] | f:Patient/f:telecom[system/@value=''phone'']', 'PractitionerRole.telecom.where(system=''phone'') | RelatedPerson.telecom.where(system=''phone'') | Practitioner.telecom.where(system=''phone'') | Person.telecom.where(system=''phone'') | Patient.telecom.where(system=''phone'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'phonetic', 'http://hl7.org/fhir/SearchParameter/individual-phonetic', '', '2', 'f:RelatedPerson/f:name | f:Practitioner/f:name | f:Person/f:name | f:Patient/f:name', 'RelatedPerson.name | Practitioner.name | Person.name | Patient.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'telecom', 'http://hl7.org/fhir/SearchParameter/individual-telecom', '', '3', 'f:PractitionerRole/f:telecom | f:RelatedPerson/f:telecom | f:Practitioner/f:telecom | f:Person/f:telecom | f:Patient/f:telecom', 'PractitionerRole.telecom | RelatedPerson.telecom | Practitioner.telecom | Person.telecom | Patient.telecom', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'identifier', 'http://hl7.org/fhir/SearchParameter/Person-identifier', 'A person Identifier', '3', 'f:Person/f:identifier', 'Person.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'link', 'http://hl7.org/fhir/SearchParameter/Person-link', 'Any link has this Patient, Person, RelatedPerson or Practitioner reference', '4', 'f:Person/f:link/f:target', 'Person.link.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'name', 'http://hl7.org/fhir/SearchParameter/Person-name', 'A server defined search that may match any of the string fields in the HumanName, including family, give, prefix, suffix, suffix, and/or text', '2', 'f:Person/f:name', 'Person.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'organization', 'http://hl7.org/fhir/SearchParameter/Person-organization', 'The organization at which this person record is being managed', '4', 'f:Person/f:managingOrganization', 'Person.managingOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'patient', 'http://hl7.org/fhir/SearchParameter/Person-patient', 'The Person links to this Patient', '4', 'f:Person/f:link/f:target', 'Person.link.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'practitioner', 'http://hl7.org/fhir/SearchParameter/Person-practitioner', 'The Person links to this Practitioner', '4', 'f:Person/f:link/f:target', 'Person.link.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Person', 'relatedperson', 'http://hl7.org/fhir/SearchParameter/Person-relatedperson', 'The Person links to this RelatedPerson', '4', 'f:Person/f:link/f:target', 'Person.link.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'composed-of', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-composed-of', 'What resource is being referenced', '4', 'f:PlanDefinition/f:relatedArtifact[f:type/@value=''composed-of'']/f:resource', 'PlanDefinition.relatedArtifact.where(type=''composed-of'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'date', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-date', 'The plan definition publication date', '1', 'f:PlanDefinition/f:date', 'PlanDefinition.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'depends-on', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-depends-on', 'What resource is being referenced', '4', 'f:PlanDefinition/f:relatedArtifact[f:type/@value=''depends-on'']/f:resource | f:PlanDefinition/f:library', 'PlanDefinition.relatedArtifact.where(type=''depends-on'').resource | PlanDefinition.library', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'derived-from', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-derived-from', 'What resource is being referenced', '4', 'f:PlanDefinition/f:relatedArtifact[f:type/@value=''derived-from'']/f:resource', 'PlanDefinition.relatedArtifact.where(type=''derived-from'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'description', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-description', 'The description of the plan definition', '2', 'f:PlanDefinition/f:description', 'PlanDefinition.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'effective', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-effective', 'The time during which the plan definition is intended to be in use', '1', 'f:PlanDefinition/f:effectivePeriod', 'PlanDefinition.effectivePeriod', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'identifier', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-identifier', 'External identifier for the plan definition', '3', 'f:PlanDefinition/f:identifier', 'PlanDefinition.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-jurisdiction', 'Intended jurisdiction for the plan definition', '3', 'f:PlanDefinition/f:jurisdiction', 'PlanDefinition.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'name', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-name', 'Computationally friendly name of the plan definition', '2', 'f:PlanDefinition/f:name', 'PlanDefinition.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'predecessor', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-predecessor', 'What resource is being referenced', '4', 'f:PlanDefinition/f:relatedArtifact[f:type/@value=''predecessor'']/f:resource', 'PlanDefinition.relatedArtifact.where(type=''predecessor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'publisher', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-publisher', 'Name of the publisher of the plan definition', '2', 'f:PlanDefinition/f:publisher', 'PlanDefinition.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'status', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-status', 'The current status of the plan definition', '3', 'f:PlanDefinition/f:status', 'PlanDefinition.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'successor', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-successor', 'What resource is being referenced', '4', 'f:PlanDefinition/f:relatedArtifact[f:type/@value=''successor'']/f:resource', 'PlanDefinition.relatedArtifact.where(type=''successor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'title', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-title', 'The human-friendly name of the plan definition', '2', 'f:PlanDefinition/f:title', 'PlanDefinition.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'topic', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-topic', 'Topics associated with the module', '3', 'f:PlanDefinition/f:topic', 'PlanDefinition.topic', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'url', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-url', 'The uri that identifies the plan definition', '7', 'f:PlanDefinition/f:url', 'PlanDefinition.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PlanDefinition', 'version', 'http://hl7.org/fhir/SearchParameter/PlanDefinition-version', 'The business version of the plan definition', '3', 'f:PlanDefinition/f:version', 'PlanDefinition.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'address', 'http://hl7.org/fhir/SearchParameter/individual-address', '', '2', 'f:RelatedPerson/f:address | f:Practitioner/f:address | f:Person/f:address | f:Patient/f:address', 'RelatedPerson.address | Practitioner.address | Person.address | Patient.address', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'address-city', 'http://hl7.org/fhir/SearchParameter/individual-address-city', '', '2', 'f:RelatedPerson/f:address/f:city | f:Practitioner/f:address/f:city | f:Person/f:address/f:city | f:Patient/f:address/f:city', 'RelatedPerson.address.city | Practitioner.address.city | Person.address.city | Patient.address.city', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'address-country', 'http://hl7.org/fhir/SearchParameter/individual-address-country', '', '2', 'f:RelatedPerson/f:address/f:country | f:Practitioner/f:address/f:country | f:Person/f:address/f:country | f:Patient/f:address/f:country', 'RelatedPerson.address.country | Practitioner.address.country | Person.address.country | Patient.address.country', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'address-postalcode', 'http://hl7.org/fhir/SearchParameter/individual-address-postalcode', '', '2', 'f:RelatedPerson/f:address/f:postalCode | f:Practitioner/f:address/f:postalCode | f:Person/f:address/f:postalCode | f:Patient/f:address/f:postalCode', 'RelatedPerson.address.postalCode | Practitioner.address.postalCode | Person.address.postalCode | Patient.address.postalCode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'address-state', 'http://hl7.org/fhir/SearchParameter/individual-address-state', '', '2', 'f:RelatedPerson/f:address/f:state | f:Practitioner/f:address/f:state | f:Person/f:address/f:state | f:Patient/f:address/f:state', 'RelatedPerson.address.state | Practitioner.address.state | Person.address.state | Patient.address.state', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'address-use', 'http://hl7.org/fhir/SearchParameter/individual-address-use', '', '3', 'f:RelatedPerson/f:address/f:use | f:Practitioner/f:address/f:use | f:Person/f:address/f:use | f:Patient/f:address/f:use', 'RelatedPerson.address.use | Practitioner.address.use | Person.address.use | Patient.address.use', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'email', 'http://hl7.org/fhir/SearchParameter/individual-email', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''email''] | f:RelatedPerson/f:telecom[system/@value=''email''] | f:Practitioner/f:telecom[system/@value=''email''] | f:Person/f:telecom[system/@value=''email''] | f:Patient/f:telecom[system/@value=''email'']', 'PractitionerRole.telecom.where(system=''email'') | RelatedPerson.telecom.where(system=''email'') | Practitioner.telecom.where(system=''email'') | Person.telecom.where(system=''email'') | Patient.telecom.where(system=''email'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'family', 'http://hl7.org/fhir/SearchParameter/individual-family', '', '2', 'f:Practitioner/f:name/f:family | f:Patient/f:name/f:family', 'Practitioner.name.family | Patient.name.family', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'gender', 'http://hl7.org/fhir/SearchParameter/individual-gender', '', '3', 'f:RelatedPerson/f:gender | f:Practitioner/f:gender | f:Person/f:gender | f:Patient/f:gender', 'RelatedPerson.gender | Practitioner.gender | Person.gender | Patient.gender', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'given', 'http://hl7.org/fhir/SearchParameter/individual-given', '', '2', 'f:Practitioner/f:name/f:given | f:Patient/f:name/f:given', 'Practitioner.name.given | Patient.name.given', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'phone', 'http://hl7.org/fhir/SearchParameter/individual-phone', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''phone''] | f:RelatedPerson/f:telecom[system/@value=''phone''] | f:Practitioner/f:telecom[system/@value=''phone''] | f:Person/f:telecom[system/@value=''phone''] | f:Patient/f:telecom[system/@value=''phone'']', 'PractitionerRole.telecom.where(system=''phone'') | RelatedPerson.telecom.where(system=''phone'') | Practitioner.telecom.where(system=''phone'') | Person.telecom.where(system=''phone'') | Patient.telecom.where(system=''phone'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'phonetic', 'http://hl7.org/fhir/SearchParameter/individual-phonetic', '', '2', 'f:RelatedPerson/f:name | f:Practitioner/f:name | f:Person/f:name | f:Patient/f:name', 'RelatedPerson.name | Practitioner.name | Person.name | Patient.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'telecom', 'http://hl7.org/fhir/SearchParameter/individual-telecom', '', '3', 'f:PractitionerRole/f:telecom | f:RelatedPerson/f:telecom | f:Practitioner/f:telecom | f:Person/f:telecom | f:Patient/f:telecom', 'PractitionerRole.telecom | RelatedPerson.telecom | Practitioner.telecom | Person.telecom | Patient.telecom', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'active', 'http://hl7.org/fhir/SearchParameter/Practitioner-active', 'Whether the practitioner record is active', '3', 'f:Practitioner/f:active', 'Practitioner.active', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'communication', 'http://hl7.org/fhir/SearchParameter/Practitioner-communication', 'One of the languages that the practitioner can communicate with', '3', 'f:Practitioner/f:communication', 'Practitioner.communication', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'identifier', 'http://hl7.org/fhir/SearchParameter/Practitioner-identifier', 'A practitioner''s Identifier', '3', 'f:Practitioner/f:identifier', 'Practitioner.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Practitioner', 'name', 'http://hl7.org/fhir/SearchParameter/Practitioner-name', 'A server defined search that may match any of the string fields in the HumanName, including family, give, prefix, suffix, suffix, and/or text', '2', 'f:Practitioner/f:name', 'Practitioner.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'email', 'http://hl7.org/fhir/SearchParameter/individual-email', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''email''] | f:RelatedPerson/f:telecom[system/@value=''email''] | f:Practitioner/f:telecom[system/@value=''email''] | f:Person/f:telecom[system/@value=''email''] | f:Patient/f:telecom[system/@value=''email'']', 'PractitionerRole.telecom.where(system=''email'') | RelatedPerson.telecom.where(system=''email'') | Practitioner.telecom.where(system=''email'') | Person.telecom.where(system=''email'') | Patient.telecom.where(system=''email'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'phone', 'http://hl7.org/fhir/SearchParameter/individual-phone', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''phone''] | f:RelatedPerson/f:telecom[system/@value=''phone''] | f:Practitioner/f:telecom[system/@value=''phone''] | f:Person/f:telecom[system/@value=''phone''] | f:Patient/f:telecom[system/@value=''phone'']', 'PractitionerRole.telecom.where(system=''phone'') | RelatedPerson.telecom.where(system=''phone'') | Practitioner.telecom.where(system=''phone'') | Person.telecom.where(system=''phone'') | Patient.telecom.where(system=''phone'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'telecom', 'http://hl7.org/fhir/SearchParameter/individual-telecom', '', '3', 'f:PractitionerRole/f:telecom | f:RelatedPerson/f:telecom | f:Practitioner/f:telecom | f:Person/f:telecom | f:Patient/f:telecom', 'PractitionerRole.telecom | RelatedPerson.telecom | Practitioner.telecom | Person.telecom | Patient.telecom', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'active', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-active', 'Whether this practitioner''s record is in active use', '3', 'f:PractitionerRole/f:active', 'PractitionerRole.active', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'date', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-date', 'The period during which the practitioner is authorized to perform in these role(s)', '1', 'f:PractitionerRole/f:period', 'PractitionerRole.period', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'endpoint', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-endpoint', 'Technical endpoints providing access to services operated for the practitioner with this role', '4', 'f:PractitionerRole/f:endpoint', 'PractitionerRole.endpoint', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'identifier', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-identifier', 'A practitioner''s Identifier', '3', 'f:PractitionerRole/f:identifier', 'PractitionerRole.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'location', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-location', 'One of the locations at which this practitioner provides care', '4', 'f:PractitionerRole/f:location', 'PractitionerRole.location', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'organization', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-organization', 'The identity of the organization the practitioner represents / acts on behalf of', '4', 'f:PractitionerRole/f:organization', 'PractitionerRole.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'practitioner', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-practitioner', 'Practitioner that is able to provide the defined services for the organation', '4', 'f:PractitionerRole/f:practitioner', 'PractitionerRole.practitioner', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'role', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-role', 'The practitioner can perform this role at for the organization', '3', 'f:PractitionerRole/f:code', 'PractitionerRole.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'service', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-service', 'The list of healthcare services that this worker provides for this role''s Organization/Location(s)', '4', 'f:PractitionerRole/f:healthcareService', 'PractitionerRole.healthcareService', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('PractitionerRole', 'specialty', 'http://hl7.org/fhir/SearchParameter/PractitionerRole-specialty', 'The practitioner has this specialty at an organization', '3', 'f:PractitionerRole/f:specialty', 'PractitionerRole.specialty', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'code', 'http://hl7.org/fhir/SearchParameter/clinical-code', '', '3', 'f:FamilyMemberHistory/f:condition/f:code | f:DeviceRequest/f:codeCodeableConcept | f:AllergyIntolerance/f:code | f:AllergyIntolerance/f:reaction/f:substance | f:Procedure/f:code | f:List/f:code | f:ProcedureRequest/f:code | f:Observation/f:code | f:DiagnosticReport/f:code | f:Condition/f:code', 'FamilyMemberHistory.condition.code | DeviceRequest.code.as(CodeableConcept) | AllergyIntolerance.code | AllergyIntolerance.reaction.substance | Procedure.code | List.code | ProcedureRequest.code | Observation.code | DiagnosticReport.code | Condition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'based-on', 'http://hl7.org/fhir/SearchParameter/Procedure-based-on', 'A request for this procedure', '4', 'f:Procedure/f:basedOn', 'Procedure.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'category', 'http://hl7.org/fhir/SearchParameter/Procedure-category', 'Classification of the procedure', '3', 'f:Procedure/f:category', 'Procedure.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'context', 'http://hl7.org/fhir/SearchParameter/Procedure-context', 'Encounter or episode associated with the procedure', '4', 'f:Procedure/f:context', 'Procedure.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'definition', 'http://hl7.org/fhir/SearchParameter/Procedure-definition', 'Instantiates protocol or definition', '4', 'f:Procedure/f:definition', 'Procedure.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'location', 'http://hl7.org/fhir/SearchParameter/Procedure-location', 'Where the procedure happened', '4', 'f:Procedure/f:location', 'Procedure.location', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'part-of', 'http://hl7.org/fhir/SearchParameter/Procedure-part-of', 'Part of referenced event', '4', 'f:Procedure/f:partOf', 'Procedure.partOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'performer', 'http://hl7.org/fhir/SearchParameter/Procedure-performer', 'The reference to the practitioner', '4', 'f:Procedure/f:performer/f:actor', 'Procedure.performer.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'status', 'http://hl7.org/fhir/SearchParameter/Procedure-status', 'preparation | in-progress | suspended | aborted | completed | entered-in-error | unknown', '3', 'f:Procedure/f:status', 'Procedure.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Procedure', 'subject', 'http://hl7.org/fhir/SearchParameter/Procedure-subject', 'Search by subject', '4', 'f:Procedure/f:subject', 'Procedure.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'code', 'http://hl7.org/fhir/SearchParameter/clinical-code', '', '3', 'f:FamilyMemberHistory/f:condition/f:code | f:DeviceRequest/f:codeCodeableConcept | f:AllergyIntolerance/f:code | f:AllergyIntolerance/f:reaction/f:substance | f:Procedure/f:code | f:List/f:code | f:ProcedureRequest/f:code | f:Observation/f:code | f:DiagnosticReport/f:code | f:Condition/f:code', 'FamilyMemberHistory.condition.code | DeviceRequest.code.as(CodeableConcept) | AllergyIntolerance.code | AllergyIntolerance.reaction.substance | Procedure.code | List.code | ProcedureRequest.code | Observation.code | DiagnosticReport.code | Condition.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'authored', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-authored', 'Date request signed', '1', 'f:ProcedureRequest/f:authoredOn', 'ProcedureRequest.authoredOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'based-on', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-based-on', 'What request fulfills', '4', 'f:ProcedureRequest/f:basedOn', 'ProcedureRequest.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'body-site', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-body-site', 'Where procedure is going to be done', '3', 'f:ProcedureRequest/f:bodySite', 'ProcedureRequest.bodySite', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'context', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-context', 'Encounter or Episode during which request was created', '4', 'f:ProcedureRequest/f:context', 'ProcedureRequest.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'definition', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-definition', 'Protocol or definition', '4', 'f:ProcedureRequest/f:definition', 'ProcedureRequest.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'intent', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-intent', 'proposal | plan | order +', '3', 'f:ProcedureRequest/f:intent', 'ProcedureRequest.intent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'occurrence', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-occurrence', 'When procedure should occur', '1', 'f:ProcedureRequest/f:occurrenceDateTime | f:ProcedureRequest/f:occurrencePeriod | f:ProcedureRequest/f:occurrenceTiming', 'ProcedureRequest.occurrence', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'performer', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-performer', 'Requested perfomer', '4', 'f:ProcedureRequest/f:performer', 'ProcedureRequest.performer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'performer-type', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-performer-type', 'Performer role', '3', 'f:ProcedureRequest/f:performerType', 'ProcedureRequest.performerType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'priority', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-priority', 'routine | urgent | asap | stat', '3', 'f:ProcedureRequest/f:priority', 'ProcedureRequest.priority', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'replaces', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-replaces', 'What request replaces', '4', 'f:ProcedureRequest/f:replaces', 'ProcedureRequest.replaces', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'requester', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-requester', 'Individual making the request', '4', 'f:ProcedureRequest/f:requester/f:agent', 'ProcedureRequest.requester.agent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'requisition', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-requisition', 'Composite Request ID', '3', 'f:ProcedureRequest/f:requisition', 'ProcedureRequest.requisition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'specimen', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-specimen', 'Specimen to be tested', '4', 'f:ProcedureRequest/f:specimen', 'ProcedureRequest.specimen', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'status', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-status', 'draft | active | suspended | completed | entered-in-error | cancelled', '3', 'f:ProcedureRequest/f:status', 'ProcedureRequest.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcedureRequest', 'subject', 'http://hl7.org/fhir/SearchParameter/ProcedureRequest-subject', 'Search by subject', '4', 'f:ProcedureRequest/f:subject', 'ProcedureRequest.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcessRequest', 'action', 'http://hl7.org/fhir/SearchParameter/ProcessRequest-action', 'The action requested by this resource', '3', 'f:ProcessRequest/f:action', 'ProcessRequest.action', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcessRequest', 'identifier', 'http://hl7.org/fhir/SearchParameter/ProcessRequest-identifier', 'The business identifier of the ProcessRequest', '3', 'f:ProcessRequest/f:identifier', 'ProcessRequest.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcessRequest', 'organization', 'http://hl7.org/fhir/SearchParameter/ProcessRequest-organization', 'The organization who generated this request', '4', 'f:ProcessRequest/f:organization', 'ProcessRequest.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcessRequest', 'provider', 'http://hl7.org/fhir/SearchParameter/ProcessRequest-provider', 'The provider who regenerated this request', '4', 'f:ProcessRequest/f:provider', 'ProcessRequest.provider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcessResponse', 'identifier', 'http://hl7.org/fhir/SearchParameter/ProcessResponse-identifier', 'The business identifier of the Explanation of Benefit', '3', 'f:ProcessResponse/f:identifier', 'ProcessResponse.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcessResponse', 'organization', 'http://hl7.org/fhir/SearchParameter/ProcessResponse-organization', 'The organization who generated this resource', '4', 'f:ProcessResponse/f:organization', 'ProcessResponse.organization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcessResponse', 'request', 'http://hl7.org/fhir/SearchParameter/ProcessResponse-request', 'The reference to the claim', '4', 'f:ProcessResponse/f:request', 'ProcessResponse.request', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcessResponse', 'request-organization', 'http://hl7.org/fhir/SearchParameter/ProcessResponse-request-organization', 'The Organization who is responsible the request transaction', '4', 'f:ProcessResponse/f:requestOrganization', 'ProcessResponse.requestOrganization', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ProcessResponse', 'request-provider', 'http://hl7.org/fhir/SearchParameter/ProcessResponse-request-provider', 'The Provider who is responsible the request transaction', '4', 'f:ProcessResponse/f:requestProvider', 'ProcessResponse.requestProvider', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'agent', 'http://hl7.org/fhir/SearchParameter/Provenance-agent', 'Who participated', '4', 'f:Provenance/f:agent/f:whoUri | f:Provenance/f:agent/f:whoReference', 'Provenance.agent.who', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'agent-role', 'http://hl7.org/fhir/SearchParameter/Provenance-agent-role', 'What the agents role was', '3', 'f:Provenance/f:agent/f:role', 'Provenance.agent.role', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'end', 'http://hl7.org/fhir/SearchParameter/Provenance-end', 'End time with inclusive boundary, if not ongoing', '1', 'f:Provenance/f:period/f:end', 'Provenance.period.end', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'entity-id', 'http://hl7.org/fhir/SearchParameter/Provenance-entity-id', 'Identity of entity', '3', 'f:Provenance/f:entity/f:whatIdentifier', 'Provenance.entity.what.as(Identifier)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'entity-ref', 'http://hl7.org/fhir/SearchParameter/Provenance-entity-ref', 'Identity of entity', '4', 'f:Provenance/f:entity/f:whatReference', 'Provenance.entity.what.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'location', 'http://hl7.org/fhir/SearchParameter/Provenance-location', 'Where the activity occurred, if relevant', '4', 'f:Provenance/f:location', 'Provenance.location', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'patient', 'http://hl7.org/fhir/SearchParameter/Provenance-patient', 'Target Reference(s) (usually version specific)', '4', 'f:Provenance/f:target', 'Provenance.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'recorded', 'http://hl7.org/fhir/SearchParameter/Provenance-recorded', 'When the activity was recorded / updated', '1', 'f:Provenance/f:recorded', 'Provenance.recorded', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'signature-type', 'http://hl7.org/fhir/SearchParameter/Provenance-signature-type', 'Indication of the reason the entity signed the object(s)', '3', 'f:Provenance/f:signature/f:type', 'Provenance.signature.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'start', 'http://hl7.org/fhir/SearchParameter/Provenance-start', 'Starting time with inclusive boundary', '1', 'f:Provenance/f:period/f:start', 'Provenance.period.start', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Provenance', 'target', 'http://hl7.org/fhir/SearchParameter/Provenance-target', 'Target Reference(s) (usually version specific)', '4', 'f:Provenance/f:target', 'Provenance.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'code', 'http://hl7.org/fhir/SearchParameter/Questionnaire-code', 'A code that corresponds to one of its items in the questionnaire', '3', 'f:Questionnaire/f:item/f:code', 'Questionnaire.item.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'date', 'http://hl7.org/fhir/SearchParameter/Questionnaire-date', 'The questionnaire publication date', '1', 'f:Questionnaire/f:date', 'Questionnaire.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'description', 'http://hl7.org/fhir/SearchParameter/Questionnaire-description', 'The description of the questionnaire', '2', 'f:Questionnaire/f:description', 'Questionnaire.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'effective', 'http://hl7.org/fhir/SearchParameter/Questionnaire-effective', 'The time during which the questionnaire is intended to be in use', '1', 'f:Questionnaire/f:effectivePeriod', 'Questionnaire.effectivePeriod', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'identifier', 'http://hl7.org/fhir/SearchParameter/Questionnaire-identifier', 'External identifier for the questionnaire', '3', 'f:Questionnaire/f:identifier', 'Questionnaire.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/Questionnaire-jurisdiction', 'Intended jurisdiction for the questionnaire', '3', 'f:Questionnaire/f:jurisdiction', 'Questionnaire.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'name', 'http://hl7.org/fhir/SearchParameter/Questionnaire-name', 'Computationally friendly name of the questionnaire', '2', 'f:Questionnaire/f:name', 'Questionnaire.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'publisher', 'http://hl7.org/fhir/SearchParameter/Questionnaire-publisher', 'Name of the publisher of the questionnaire', '2', 'f:Questionnaire/f:publisher', 'Questionnaire.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'status', 'http://hl7.org/fhir/SearchParameter/Questionnaire-status', 'The current status of the questionnaire', '3', 'f:Questionnaire/f:status', 'Questionnaire.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'title', 'http://hl7.org/fhir/SearchParameter/Questionnaire-title', 'The human-friendly name of the questionnaire', '2', 'f:Questionnaire/f:title', 'Questionnaire.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'url', 'http://hl7.org/fhir/SearchParameter/Questionnaire-url', 'The uri that identifies the questionnaire', '7', 'f:Questionnaire/f:url', 'Questionnaire.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Questionnaire', 'version', 'http://hl7.org/fhir/SearchParameter/Questionnaire-version', 'The business version of the questionnaire', '3', 'f:Questionnaire/f:version', 'Questionnaire.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'author', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-author', 'The author of the questionnaire response', '4', 'f:QuestionnaireResponse/f:author', 'QuestionnaireResponse.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'authored', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-authored', 'When the questionnaire response was last changed', '1', 'f:QuestionnaireResponse/f:authored', 'QuestionnaireResponse.authored', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'based-on', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-based-on', 'Plan/proposal/order fulfilled by this questionnaire response', '4', 'f:QuestionnaireResponse/f:basedOn', 'QuestionnaireResponse.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'context', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-context', 'Encounter or episode associated with the questionnaire response', '4', 'f:QuestionnaireResponse/f:context', 'QuestionnaireResponse.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'identifier', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-identifier', 'The unique identifier for the questionnaire response', '3', 'f:QuestionnaireResponse/f:identifier', 'QuestionnaireResponse.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'parent', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-parent', 'Procedure or observation this questionnaire response was performed as a part of', '4', 'f:QuestionnaireResponse/f:parent', 'QuestionnaireResponse.parent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'patient', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-patient', 'The patient that is the subject of the questionnaire response', '4', 'f:QuestionnaireResponse/f:subject', 'QuestionnaireResponse.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'questionnaire', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-questionnaire', 'The questionnaire the answers are provided for', '4', 'f:QuestionnaireResponse/f:questionnaire', 'QuestionnaireResponse.questionnaire', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'source', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-source', 'The individual providing the information reflected in the questionnaire respose', '4', 'f:QuestionnaireResponse/f:source', 'QuestionnaireResponse.source', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'status', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-status', 'The status of the questionnaire response', '3', 'f:QuestionnaireResponse/f:status', 'QuestionnaireResponse.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('QuestionnaireResponse', 'subject', 'http://hl7.org/fhir/SearchParameter/QuestionnaireResponse-subject', 'The subject of the questionnaire response', '4', 'f:QuestionnaireResponse/f:subject', 'QuestionnaireResponse.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'type', 'http://hl7.org/fhir/SearchParameter/clinical-type', '', '3', 'f:ReferralRequest/f:type | f:DocumentManifest/f:type | f:DocumentReference/f:type | f:Encounter/f:type | f:AllergyIntolerance/f:type | f:EpisodeOfCare/f:type | f:Composition/f:type', 'ReferralRequest.type | DocumentManifest.type | DocumentReference.type | Encounter.type | AllergyIntolerance.type | EpisodeOfCare.type | Composition.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'authored-on', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-authored-on', 'Creation or activation date', '1', 'f:ReferralRequest/f:authoredOn', 'ReferralRequest.authoredOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'based-on', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-based-on', 'Request being fulfilled', '4', 'f:ReferralRequest/f:basedOn', 'ReferralRequest.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'context', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-context', 'Part of encounter or episode of care', '4', 'f:ReferralRequest/f:context', 'ReferralRequest.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'definition', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-definition', 'Instantiates protocol or definition', '4', 'f:ReferralRequest/f:definition', 'ReferralRequest.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'encounter', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-encounter', 'Originating encounter', '4', 'f:ReferralRequest/f:context', 'ReferralRequest.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'group-identifier', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-group-identifier', 'Part of common request', '3', 'f:ReferralRequest/f:groupIdentifier', 'ReferralRequest.groupIdentifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'identifier', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-identifier', 'Business identifier', '3', 'f:ReferralRequest/f:identifier', 'ReferralRequest.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'intent', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-intent', 'Proposal, plan or order', '3', 'f:ReferralRequest/f:intent', 'ReferralRequest.intent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'occurrence-date', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-occurrence-date', 'When the service(s) requested in the referral should occur', '1', 'f:ReferralRequest/f:occurrenceDateTime | f:ReferralRequest/f:occurrencePeriod', 'ReferralRequest.occurrence', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'priority', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-priority', 'The priority assigned to the referral', '3', 'f:ReferralRequest/f:priority', 'ReferralRequest.priority', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'recipient', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-recipient', 'The person that the referral was sent to', '4', 'f:ReferralRequest/f:recipient', 'ReferralRequest.recipient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'replaces', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-replaces', 'Request(s) replaced by this request', '4', 'f:ReferralRequest/f:replaces', 'ReferralRequest.replaces', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'requester', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-requester', 'Individual making the request', '4', 'f:ReferralRequest/f:requester/f:agent', 'ReferralRequest.requester.agent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'service', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-service', 'Actions requested as part of the referral', '3', 'f:ReferralRequest/f:serviceRequested', 'ReferralRequest.serviceRequested', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'specialty', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-specialty', 'The specialty that the referral is for', '3', 'f:ReferralRequest/f:specialty', 'ReferralRequest.specialty', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'status', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-status', 'The status of the referral', '3', 'f:ReferralRequest/f:status', 'ReferralRequest.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ReferralRequest', 'subject', 'http://hl7.org/fhir/SearchParameter/ReferralRequest-subject', 'Patient referred to care or transfer', '4', 'f:ReferralRequest/f:subject', 'ReferralRequest.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'address', 'http://hl7.org/fhir/SearchParameter/individual-address', '', '2', 'f:RelatedPerson/f:address | f:Practitioner/f:address | f:Person/f:address | f:Patient/f:address', 'RelatedPerson.address | Practitioner.address | Person.address | Patient.address', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'address-city', 'http://hl7.org/fhir/SearchParameter/individual-address-city', '', '2', 'f:RelatedPerson/f:address/f:city | f:Practitioner/f:address/f:city | f:Person/f:address/f:city | f:Patient/f:address/f:city', 'RelatedPerson.address.city | Practitioner.address.city | Person.address.city | Patient.address.city', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'address-country', 'http://hl7.org/fhir/SearchParameter/individual-address-country', '', '2', 'f:RelatedPerson/f:address/f:country | f:Practitioner/f:address/f:country | f:Person/f:address/f:country | f:Patient/f:address/f:country', 'RelatedPerson.address.country | Practitioner.address.country | Person.address.country | Patient.address.country', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'address-postalcode', 'http://hl7.org/fhir/SearchParameter/individual-address-postalcode', '', '2', 'f:RelatedPerson/f:address/f:postalCode | f:Practitioner/f:address/f:postalCode | f:Person/f:address/f:postalCode | f:Patient/f:address/f:postalCode', 'RelatedPerson.address.postalCode | Practitioner.address.postalCode | Person.address.postalCode | Patient.address.postalCode', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'address-state', 'http://hl7.org/fhir/SearchParameter/individual-address-state', '', '2', 'f:RelatedPerson/f:address/f:state | f:Practitioner/f:address/f:state | f:Person/f:address/f:state | f:Patient/f:address/f:state', 'RelatedPerson.address.state | Practitioner.address.state | Person.address.state | Patient.address.state', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'address-use', 'http://hl7.org/fhir/SearchParameter/individual-address-use', '', '3', 'f:RelatedPerson/f:address/f:use | f:Practitioner/f:address/f:use | f:Person/f:address/f:use | f:Patient/f:address/f:use', 'RelatedPerson.address.use | Practitioner.address.use | Person.address.use | Patient.address.use', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'birthdate', 'http://hl7.org/fhir/SearchParameter/individual-birthdate', '', '1', 'f:RelatedPerson/f:birthDate | f:Person/f:birthDate | f:Patient/f:birthDate', 'RelatedPerson.birthDate | Person.birthDate | Patient.birthDate', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'email', 'http://hl7.org/fhir/SearchParameter/individual-email', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''email''] | f:RelatedPerson/f:telecom[system/@value=''email''] | f:Practitioner/f:telecom[system/@value=''email''] | f:Person/f:telecom[system/@value=''email''] | f:Patient/f:telecom[system/@value=''email'']', 'PractitionerRole.telecom.where(system=''email'') | RelatedPerson.telecom.where(system=''email'') | Practitioner.telecom.where(system=''email'') | Person.telecom.where(system=''email'') | Patient.telecom.where(system=''email'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'gender', 'http://hl7.org/fhir/SearchParameter/individual-gender', '', '3', 'f:RelatedPerson/f:gender | f:Practitioner/f:gender | f:Person/f:gender | f:Patient/f:gender', 'RelatedPerson.gender | Practitioner.gender | Person.gender | Patient.gender', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'phone', 'http://hl7.org/fhir/SearchParameter/individual-phone', '', '3', 'f:PractitionerRole/f:telecom[system/@value=''phone''] | f:RelatedPerson/f:telecom[system/@value=''phone''] | f:Practitioner/f:telecom[system/@value=''phone''] | f:Person/f:telecom[system/@value=''phone''] | f:Patient/f:telecom[system/@value=''phone'']', 'PractitionerRole.telecom.where(system=''phone'') | RelatedPerson.telecom.where(system=''phone'') | Practitioner.telecom.where(system=''phone'') | Person.telecom.where(system=''phone'') | Patient.telecom.where(system=''phone'')', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'phonetic', 'http://hl7.org/fhir/SearchParameter/individual-phonetic', '', '2', 'f:RelatedPerson/f:name | f:Practitioner/f:name | f:Person/f:name | f:Patient/f:name', 'RelatedPerson.name | Practitioner.name | Person.name | Patient.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'telecom', 'http://hl7.org/fhir/SearchParameter/individual-telecom', '', '3', 'f:PractitionerRole/f:telecom | f:RelatedPerson/f:telecom | f:Practitioner/f:telecom | f:Person/f:telecom | f:Patient/f:telecom', 'PractitionerRole.telecom | RelatedPerson.telecom | Practitioner.telecom | Person.telecom | Patient.telecom', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'active', 'http://hl7.org/fhir/SearchParameter/RelatedPerson-active', 'Indicates if the related person record is active', '3', 'f:RelatedPerson/f:active', 'RelatedPerson.active', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'identifier', 'http://hl7.org/fhir/SearchParameter/RelatedPerson-identifier', 'An Identifier of the RelatedPerson', '3', 'f:RelatedPerson/f:identifier', 'RelatedPerson.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'name', 'http://hl7.org/fhir/SearchParameter/RelatedPerson-name', 'A server defined search that may match any of the string fields in the HumanName, including family, give, prefix, suffix, suffix, and/or text', '2', 'f:RelatedPerson/f:name', 'RelatedPerson.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RelatedPerson', 'patient', 'http://hl7.org/fhir/SearchParameter/RelatedPerson-patient', 'The patient this related person is related to', '4', 'f:RelatedPerson/f:patient', 'RelatedPerson.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'author', 'http://hl7.org/fhir/SearchParameter/RequestGroup-author', 'The author of the request group', '4', 'f:RequestGroup/f:author', 'RequestGroup.author', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'authored', 'http://hl7.org/fhir/SearchParameter/RequestGroup-authored', 'The date the request group was authored', '1', 'f:RequestGroup/f:authoredOn', 'RequestGroup.authoredOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'context', 'http://hl7.org/fhir/SearchParameter/RequestGroup-context', 'The context the request group applies to', '4', 'f:RequestGroup/f:context', 'RequestGroup.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'definition', 'http://hl7.org/fhir/SearchParameter/RequestGroup-definition', 'The definition from which the request group is realized', '4', 'f:RequestGroup/f:definition', 'RequestGroup.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'encounter', 'http://hl7.org/fhir/SearchParameter/RequestGroup-encounter', 'The encounter the request group applies to', '4', 'f:RequestGroup/f:context', 'RequestGroup.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'group-identifier', 'http://hl7.org/fhir/SearchParameter/RequestGroup-group-identifier', 'The group identifier for the request group', '3', 'f:RequestGroup/f:groupIdentifier', 'RequestGroup.groupIdentifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'identifier', 'http://hl7.org/fhir/SearchParameter/RequestGroup-identifier', 'External identifiers for the request group', '3', 'f:RequestGroup/f:identifier', 'RequestGroup.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'intent', 'http://hl7.org/fhir/SearchParameter/RequestGroup-intent', 'The intent of the request group', '3', 'f:RequestGroup/f:intent', 'RequestGroup.intent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'participant', 'http://hl7.org/fhir/SearchParameter/RequestGroup-participant', 'The participant in the requests in the group', '4', 'f:RequestGroup/f:action/f:participant', 'RequestGroup.action.participant', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'patient', 'http://hl7.org/fhir/SearchParameter/RequestGroup-patient', 'The identity of a patient to search for request groups', '4', 'f:RequestGroup/f:subject', 'RequestGroup.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'priority', 'http://hl7.org/fhir/SearchParameter/RequestGroup-priority', 'The priority of the request group', '3', 'f:RequestGroup/f:priority', 'RequestGroup.priority', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'status', 'http://hl7.org/fhir/SearchParameter/RequestGroup-status', 'The status of the request group', '3', 'f:RequestGroup/f:status', 'RequestGroup.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RequestGroup', 'subject', 'http://hl7.org/fhir/SearchParameter/RequestGroup-subject', 'The subject that the request group is about', '4', 'f:RequestGroup/f:subject', 'RequestGroup.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'category', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-category', 'Classifications for the study', '3', 'f:ResearchStudy/f:category', 'ResearchStudy.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'date', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-date', 'When the study began and ended', '1', 'f:ResearchStudy/f:period', 'ResearchStudy.period', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'focus', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-focus', 'Drugs, devices, conditions, etc. under study', '3', 'f:ResearchStudy/f:focus', 'ResearchStudy.focus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'identifier', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-identifier', 'Business Identifier for study', '3', 'f:ResearchStudy/f:identifier', 'ResearchStudy.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-jurisdiction', 'Geographic region(s) for study', '3', 'f:ResearchStudy/f:jurisdiction', 'ResearchStudy.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'keyword', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-keyword', 'Used to search for the study', '3', 'f:ResearchStudy/f:keyword', 'ResearchStudy.keyword', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'partof', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-partof', 'Part of larger study', '4', 'f:ResearchStudy/f:partOf', 'ResearchStudy.partOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'principalinvestigator', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-principalinvestigator', 'The individual responsible for the study', '4', 'f:ResearchStudy/f:principalInvestigator', 'ResearchStudy.principalInvestigator', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'protocol', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-protocol', 'Steps followed in executing study', '4', 'f:ResearchStudy/f:protocol', 'ResearchStudy.protocol', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'site', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-site', 'Location involved in study execution', '4', 'f:ResearchStudy/f:site', 'ResearchStudy.site', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'sponsor', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-sponsor', 'Organization responsible for the study', '4', 'f:ResearchStudy/f:sponsor', 'ResearchStudy.sponsor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'status', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-status', 'draft | in-progress | suspended | stopped | completed | entered-in-error', '3', 'f:ResearchStudy/f:status', 'ResearchStudy.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchStudy', 'title', 'http://hl7.org/fhir/SearchParameter/ResearchStudy-title', 'Name for this study', '2', 'f:ResearchStudy/f:title', 'ResearchStudy.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchSubject', 'date', 'http://hl7.org/fhir/SearchParameter/ResearchSubject-date', 'Start and end of participation', '1', 'f:ResearchSubject/f:period', 'ResearchSubject.period', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchSubject', 'identifier', 'http://hl7.org/fhir/SearchParameter/ResearchSubject-identifier', 'Business Identifier for research subject', '3', 'f:ResearchSubject/f:identifier', 'ResearchSubject.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchSubject', 'individual', 'http://hl7.org/fhir/SearchParameter/ResearchSubject-individual', 'Who is part of study', '4', 'f:ResearchSubject/f:individual', 'ResearchSubject.individual', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchSubject', 'patient', 'http://hl7.org/fhir/SearchParameter/ResearchSubject-patient', 'Who is part of study', '4', 'f:ResearchSubject/f:individual', 'ResearchSubject.individual', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ResearchSubject', 'status', 'http://hl7.org/fhir/SearchParameter/ResearchSubject-status', 'candidate | enrolled | active | suspended | withdrawn | completed', '3', 'f:ResearchSubject/f:status', 'ResearchSubject.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'condition', 'http://hl7.org/fhir/SearchParameter/RiskAssessment-condition', 'Condition assessed', '4', 'f:RiskAssessment/f:condition', 'RiskAssessment.condition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'method', 'http://hl7.org/fhir/SearchParameter/RiskAssessment-method', 'Evaluation mechanism', '3', 'f:RiskAssessment/f:method', 'RiskAssessment.method', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'performer', 'http://hl7.org/fhir/SearchParameter/RiskAssessment-performer', 'Who did assessment?', '4', 'f:RiskAssessment/f:performer', 'RiskAssessment.performer', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'probability', 'http://hl7.org/fhir/SearchParameter/RiskAssessment-probability', 'Likelihood of specified outcome', '0', 'f:RiskAssessment/f:prediction/f:probabilityDecimal | f:RiskAssessment/f:prediction/f:probabilityRange', 'RiskAssessment.prediction.probability', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'risk', 'http://hl7.org/fhir/SearchParameter/RiskAssessment-risk', 'Likelihood of specified outcome as a qualitative value', '3', 'f:RiskAssessment/f:prediction/f:qualitativeRisk', 'RiskAssessment.prediction.qualitativeRisk', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('RiskAssessment', 'subject', 'http://hl7.org/fhir/SearchParameter/RiskAssessment-subject', 'Who/what does assessment apply to?', '4', 'f:RiskAssessment/f:subject', 'RiskAssessment.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Schedule', 'active', 'http://hl7.org/fhir/SearchParameter/Schedule-active', 'Is the schedule in active use', '3', 'f:Schedule/f:active', 'Schedule.active', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Schedule', 'actor', 'http://hl7.org/fhir/SearchParameter/Schedule-actor', 'The individual(HealthcareService, Practitioner, Location, ...) to find a Schedule for', '4', 'f:Schedule/f:actor', 'Schedule.actor', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Schedule', 'date', 'http://hl7.org/fhir/SearchParameter/Schedule-date', 'Search for Schedule resources that have a period that contains this date specified', '1', 'f:Schedule/f:planningHorizon', 'Schedule.planningHorizon', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Schedule', 'identifier', 'http://hl7.org/fhir/SearchParameter/Schedule-identifier', 'A Schedule Identifier', '3', 'f:Schedule/f:identifier', 'Schedule.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Schedule', 'type', 'http://hl7.org/fhir/SearchParameter/Schedule-type', 'The type of appointments that can be booked into associated slot(s)', '3', 'f:Schedule/f:serviceType', 'Schedule.serviceType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'base', 'http://hl7.org/fhir/SearchParameter/SearchParameter-base', 'The resource type(s) this search parameter applies to', '3', 'f:SearchParameter/f:base', 'SearchParameter.base', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'code', 'http://hl7.org/fhir/SearchParameter/SearchParameter-code', 'Code used in URL', '3', 'f:SearchParameter/f:code', 'SearchParameter.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'component', 'http://hl7.org/fhir/SearchParameter/SearchParameter-component', 'Defines how the part works', '4', 'f:SearchParameter/f:component/f:definition', 'SearchParameter.component.definition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'date', 'http://hl7.org/fhir/SearchParameter/SearchParameter-date', 'The search parameter publication date', '1', 'f:SearchParameter/f:date', 'SearchParameter.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'derived-from', 'http://hl7.org/fhir/SearchParameter/SearchParameter-derived-from', 'Original Definition for the search parameter', '7', 'f:SearchParameter/f:derivedFrom', 'SearchParameter.derivedFrom', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'description', 'http://hl7.org/fhir/SearchParameter/SearchParameter-description', 'The description of the search parameter', '2', 'f:SearchParameter/f:description', 'SearchParameter.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/SearchParameter-jurisdiction', 'Intended jurisdiction for the search parameter', '3', 'f:SearchParameter/f:jurisdiction', 'SearchParameter.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'name', 'http://hl7.org/fhir/SearchParameter/SearchParameter-name', 'Computationally friendly name of the search parameter', '2', 'f:SearchParameter/f:name', 'SearchParameter.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'publisher', 'http://hl7.org/fhir/SearchParameter/SearchParameter-publisher', 'Name of the publisher of the search parameter', '2', 'f:SearchParameter/f:publisher', 'SearchParameter.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'status', 'http://hl7.org/fhir/SearchParameter/SearchParameter-status', 'The current status of the search parameter', '3', 'f:SearchParameter/f:status', 'SearchParameter.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'target', 'http://hl7.org/fhir/SearchParameter/SearchParameter-target', 'Types of resource (if a resource reference)', '3', 'f:SearchParameter/f:target', 'SearchParameter.target', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'type', 'http://hl7.org/fhir/SearchParameter/SearchParameter-type', 'number | date | string | token | reference | composite | quantity | uri', '3', 'f:SearchParameter/f:type', 'SearchParameter.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'url', 'http://hl7.org/fhir/SearchParameter/SearchParameter-url', 'The uri that identifies the search parameter', '7', 'f:SearchParameter/f:url', 'SearchParameter.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SearchParameter', 'version', 'http://hl7.org/fhir/SearchParameter/SearchParameter-version', 'The business version of the search parameter', '3', 'f:SearchParameter/f:version', 'SearchParameter.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Sequence', 'chromosome', 'http://hl7.org/fhir/SearchParameter/Sequence-chromosome', 'Chromosome number of the reference sequence', '3', 'f:Sequence/f:referenceSeq/f:chromosome', 'Sequence.referenceSeq.chromosome', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Sequence', 'coordinate', 'http://hl7.org/fhir/SearchParameter/Sequence-coordinate', 'Search parameter for region of the reference DNA sequence string. This will refer to part of a locus or part of a gene where search region will be represented in 1-based system. Since the coordinateSystem can either be 0-based or 1-based, this search query will include the result of both coordinateSystem that contains the equivalent segment of the gene or whole genome sequence. For example, a search for sequence can be represented as `coordinate=1$lt345$gt123`, this means it will search for the Sequence resource on chromosome 1 and with position >123 and <345, where in 1-based system resource, all strings within region 1:124-344 will be revealed, while in 0-based system resource, all strings within region 1:123-344 will be revealed. You may want to check detail about 0-based v.s. 1-based above.', '5', '', 'Sequence.variant', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Sequence', 'end', 'http://hl7.org/fhir/SearchParameter/Sequence-end', 'End position (0-based exclusive, which menas the acid at this position will not be included, 1-based inclusive, which means the acid at this position will be included) of the reference sequence.', '0', 'f:Sequence/f:referenceSeq/f:windowEnd', 'Sequence.referenceSeq.windowEnd', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Sequence', 'identifier', 'http://hl7.org/fhir/SearchParameter/Sequence-identifier', 'The unique identity for a particular sequence', '3', 'f:Sequence/f:identifier', 'Sequence.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Sequence', 'patient', 'http://hl7.org/fhir/SearchParameter/Sequence-patient', 'The subject that the observation is about', '4', 'f:Sequence/f:patient', 'Sequence.patient', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Sequence', 'start', 'http://hl7.org/fhir/SearchParameter/Sequence-start', 'Start position (0-based inclusive, 1-based inclusive, that means the nucleic acid or amino acid at this position will be included) of the reference sequence.', '0', 'f:Sequence/f:referenceSeq/f:windowStart', 'Sequence.referenceSeq.windowStart', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Sequence', 'type', 'http://hl7.org/fhir/SearchParameter/Sequence-type', 'Amino Acid Sequence/ DNA Sequence / RNA Sequence', '3', 'f:Sequence/f:type', 'Sequence.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'composed-of', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-composed-of', 'What resource is being referenced', '4', 'f:ServiceDefinition/f:relatedArtifact[f:type/@value=''composed-of'']/f:resource', 'ServiceDefinition.relatedArtifact.where(type=''composed-of'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'date', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-date', 'The service definition publication date', '1', 'f:ServiceDefinition/f:date', 'ServiceDefinition.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'depends-on', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-depends-on', 'What resource is being referenced', '4', 'f:ServiceDefinition/f:relatedArtifact[f:type/@value=''depends-on'']/f:resource', 'ServiceDefinition.relatedArtifact.where(type=''depends-on'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'derived-from', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-derived-from', 'What resource is being referenced', '4', 'f:ServiceDefinition/f:relatedArtifact[f:type/@value=''derived-from'']/f:resource', 'ServiceDefinition.relatedArtifact.where(type=''derived-from'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'description', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-description', 'The description of the service definition', '2', 'f:ServiceDefinition/f:description', 'ServiceDefinition.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'effective', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-effective', 'The time during which the service definition is intended to be in use', '1', 'f:ServiceDefinition/f:effectivePeriod', 'ServiceDefinition.effectivePeriod', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'identifier', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-identifier', 'External identifier for the service definition', '3', 'f:ServiceDefinition/f:identifier', 'ServiceDefinition.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-jurisdiction', 'Intended jurisdiction for the service definition', '3', 'f:ServiceDefinition/f:jurisdiction', 'ServiceDefinition.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'name', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-name', 'Computationally friendly name of the service definition', '2', 'f:ServiceDefinition/f:name', 'ServiceDefinition.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'predecessor', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-predecessor', 'What resource is being referenced', '4', 'f:ServiceDefinition/f:relatedArtifact[f:type/@value=''predecessor'']/f:resource', 'ServiceDefinition.relatedArtifact.where(type=''predecessor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'publisher', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-publisher', 'Name of the publisher of the service definition', '2', 'f:ServiceDefinition/f:publisher', 'ServiceDefinition.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'status', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-status', 'The current status of the service definition', '3', 'f:ServiceDefinition/f:status', 'ServiceDefinition.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'successor', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-successor', 'What resource is being referenced', '4', 'f:ServiceDefinition/f:relatedArtifact[f:type/@value=''successor'']/f:resource', 'ServiceDefinition.relatedArtifact.where(type=''successor'').resource', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'title', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-title', 'The human-friendly name of the service definition', '2', 'f:ServiceDefinition/f:title', 'ServiceDefinition.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'topic', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-topic', 'Topics associated with the module', '3', 'f:ServiceDefinition/f:topic', 'ServiceDefinition.topic', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'url', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-url', 'The uri that identifies the service definition', '7', 'f:ServiceDefinition/f:url', 'ServiceDefinition.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ServiceDefinition', 'version', 'http://hl7.org/fhir/SearchParameter/ServiceDefinition-version', 'The business version of the service definition', '3', 'f:ServiceDefinition/f:version', 'ServiceDefinition.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Slot', 'identifier', 'http://hl7.org/fhir/SearchParameter/Slot-identifier', 'A Slot Identifier', '3', 'f:Slot/f:identifier', 'Slot.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Slot', 'schedule', 'http://hl7.org/fhir/SearchParameter/Slot-schedule', 'The Schedule Resource that we are seeking a slot within', '4', 'f:Slot/f:schedule', 'Slot.schedule', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Slot', 'slot-type', 'http://hl7.org/fhir/SearchParameter/Slot-slot-type', 'The type of appointments that can be booked into the slot', '3', 'f:Slot/f:serviceType', 'Slot.serviceType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Slot', 'start', 'http://hl7.org/fhir/SearchParameter/Slot-start', 'Appointment date/time.', '1', 'f:Slot/f:start', 'Slot.start', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Slot', 'status', 'http://hl7.org/fhir/SearchParameter/Slot-status', 'The free/busy status of the appointment', '3', 'f:Slot/f:status', 'Slot.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'accession', 'http://hl7.org/fhir/SearchParameter/Specimen-accession', 'The accession number associated with the specimen', '3', 'f:Specimen/f:accessionIdentifier', 'Specimen.accessionIdentifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'bodysite', 'http://hl7.org/fhir/SearchParameter/Specimen-bodysite', 'The code for the body site from where the specimen originated', '3', 'f:Specimen/f:collection/f:bodySite', 'Specimen.collection.bodySite', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'collected', 'http://hl7.org/fhir/SearchParameter/Specimen-collected', 'The date the specimen was collected', '1', 'f:Specimen/f:collection/f:collectedDateTime | f:Specimen/f:collection/f:collectedPeriod', 'Specimen.collection.collected', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'collector', 'http://hl7.org/fhir/SearchParameter/Specimen-collector', 'Who collected the specimen', '4', 'f:Specimen/f:collection/f:collector', 'Specimen.collection.collector', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'container', 'http://hl7.org/fhir/SearchParameter/Specimen-container', 'The kind of specimen container', '3', 'f:Specimen/f:container/f:type', 'Specimen.container.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'container-id', 'http://hl7.org/fhir/SearchParameter/Specimen-container-id', 'The unique identifier associated with the specimen container', '3', 'f:Specimen/f:container/f:identifier', 'Specimen.container.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'identifier', 'http://hl7.org/fhir/SearchParameter/Specimen-identifier', 'The unique identifier associated with the specimen', '3', 'f:Specimen/f:identifier', 'Specimen.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'parent', 'http://hl7.org/fhir/SearchParameter/Specimen-parent', 'The parent of the specimen', '4', 'f:Specimen/f:parent', 'Specimen.parent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'patient', 'http://hl7.org/fhir/SearchParameter/Specimen-patient', 'The patient the specimen comes from', '4', 'f:Specimen/f:subject', 'Specimen.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'status', 'http://hl7.org/fhir/SearchParameter/Specimen-status', 'available | unavailable | unsatisfactory | entered-in-error', '3', 'f:Specimen/f:status', 'Specimen.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'subject', 'http://hl7.org/fhir/SearchParameter/Specimen-subject', 'The subject of the specimen', '4', 'f:Specimen/f:subject', 'Specimen.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Specimen', 'type', 'http://hl7.org/fhir/SearchParameter/Specimen-type', 'The specimen type', '3', 'f:Specimen/f:type', 'Specimen.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'abstract', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-abstract', 'Whether the structure is abstract', '3', 'f:StructureDefinition/f:abstract', 'StructureDefinition.abstract', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'base', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-base', 'Definition that this type is constrained/specialized from', '7', 'f:StructureDefinition/f:baseDefinition', 'StructureDefinition.baseDefinition', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'base-path', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-base-path', 'Path that identifies the base element', '3', 'f:StructureDefinition/f:snapshot/f:element/f:base/f:path | f:StructureDefinition/f:differential/f:element/f:base/f:path', 'StructureDefinition.snapshot.element.base.path | StructureDefinition.differential.element.base.path', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'context-type', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-context-type', 'resource | datatype | extension', '3', 'f:StructureDefinition/f:contextType', 'StructureDefinition.contextType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'date', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-date', 'The structure definition publication date', '1', 'f:StructureDefinition/f:date', 'StructureDefinition.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'derivation', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-derivation', 'specialization | constraint - How relates to base definition', '3', 'f:StructureDefinition/f:derivation', 'StructureDefinition.derivation', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'description', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-description', 'The description of the structure definition', '2', 'f:StructureDefinition/f:description', 'StructureDefinition.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'experimental', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-experimental', 'For testing purposes, not real usage', '3', 'f:StructureDefinition/f:experimental', 'StructureDefinition.experimental', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'ext-context', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-ext-context', 'Where the extension can be used in instances', '2', 'f:StructureDefinition/f:context', 'StructureDefinition.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'identifier', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-identifier', 'External identifier for the structure definition', '3', 'f:StructureDefinition/f:identifier', 'StructureDefinition.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-jurisdiction', 'Intended jurisdiction for the structure definition', '3', 'f:StructureDefinition/f:jurisdiction', 'StructureDefinition.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'keyword', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-keyword', 'A code for the profile', '3', 'f:StructureDefinition/f:keyword', 'StructureDefinition.keyword', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'kind', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-kind', 'primitive-type | complex-type | resource | logical', '3', 'f:StructureDefinition/f:kind', 'StructureDefinition.kind', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'name', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-name', 'Computationally friendly name of the structure definition', '2', 'f:StructureDefinition/f:name', 'StructureDefinition.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'path', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-path', 'A path that is constrained in the profile', '3', 'f:StructureDefinition/f:snapshot/f:element/f:path | f:StructureDefinition/f:differential/f:element/f:path', 'StructureDefinition.snapshot.element.path | StructureDefinition.differential.element.path', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'publisher', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-publisher', 'Name of the publisher of the structure definition', '2', 'f:StructureDefinition/f:publisher', 'StructureDefinition.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'status', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-status', 'The current status of the structure definition', '3', 'f:StructureDefinition/f:status', 'StructureDefinition.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'title', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-title', 'The human-friendly name of the structure definition', '2', 'f:StructureDefinition/f:title', 'StructureDefinition.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'type', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-type', 'Type defined or constrained by this structure', '3', 'f:StructureDefinition/f:type', 'StructureDefinition.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'url', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-url', 'The uri that identifies the structure definition', '7', 'f:StructureDefinition/f:url', 'StructureDefinition.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'valueset', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-valueset', 'A vocabulary binding reference', '4', 'f:StructureDefinition/f:snapshot/f:element/f:binding/f:valueSetUri | f:StructureDefinition/f:snapshot/f:element/f:binding/f:valueSetReference', 'StructureDefinition.snapshot.element.binding.valueSet', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureDefinition', 'version', 'http://hl7.org/fhir/SearchParameter/StructureDefinition-version', 'The business version of the structure definition', '3', 'f:StructureDefinition/f:version', 'StructureDefinition.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'date', 'http://hl7.org/fhir/SearchParameter/StructureMap-date', 'The structure map publication date', '1', 'f:StructureMap/f:date', 'StructureMap.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'description', 'http://hl7.org/fhir/SearchParameter/StructureMap-description', 'The description of the structure map', '2', 'f:StructureMap/f:description', 'StructureMap.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'identifier', 'http://hl7.org/fhir/SearchParameter/StructureMap-identifier', 'External identifier for the structure map', '3', 'f:StructureMap/f:identifier', 'StructureMap.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/StructureMap-jurisdiction', 'Intended jurisdiction for the structure map', '3', 'f:StructureMap/f:jurisdiction', 'StructureMap.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'name', 'http://hl7.org/fhir/SearchParameter/StructureMap-name', 'Computationally friendly name of the structure map', '2', 'f:StructureMap/f:name', 'StructureMap.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'publisher', 'http://hl7.org/fhir/SearchParameter/StructureMap-publisher', 'Name of the publisher of the structure map', '2', 'f:StructureMap/f:publisher', 'StructureMap.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'status', 'http://hl7.org/fhir/SearchParameter/StructureMap-status', 'The current status of the structure map', '3', 'f:StructureMap/f:status', 'StructureMap.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'title', 'http://hl7.org/fhir/SearchParameter/StructureMap-title', 'The human-friendly name of the structure map', '2', 'f:StructureMap/f:title', 'StructureMap.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'url', 'http://hl7.org/fhir/SearchParameter/StructureMap-url', 'The uri that identifies the structure map', '7', 'f:StructureMap/f:url', 'StructureMap.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('StructureMap', 'version', 'http://hl7.org/fhir/SearchParameter/StructureMap-version', 'The business version of the structure map', '3', 'f:StructureMap/f:version', 'StructureMap.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Subscription', 'add-tag', 'http://hl7.org/fhir/SearchParameter/Subscription-add-tag', 'A tag to be added to the resource matching the criteria', '3', 'f:Subscription/f:tag', 'Subscription.tag', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Subscription', 'contact', 'http://hl7.org/fhir/SearchParameter/Subscription-contact', 'Contact details for the subscription', '3', 'f:Subscription/f:contact', 'Subscription.contact', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Subscription', 'criteria', 'http://hl7.org/fhir/SearchParameter/Subscription-criteria', 'The search rules used to determine when to send a notification', '2', 'f:Subscription/f:criteria', 'Subscription.criteria', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Subscription', 'payload', 'http://hl7.org/fhir/SearchParameter/Subscription-payload', 'The mime-type of the notification payload', '2', 'f:Subscription/f:channel/f:payload', 'Subscription.channel.payload', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Subscription', 'status', 'http://hl7.org/fhir/SearchParameter/Subscription-status', 'The current state of the subscription', '3', 'f:Subscription/f:status', 'Subscription.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Subscription', 'type', 'http://hl7.org/fhir/SearchParameter/Subscription-type', 'The type of channel for the sent notifications', '3', 'f:Subscription/f:channel/f:type', 'Subscription.channel.type', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Subscription', 'url', 'http://hl7.org/fhir/SearchParameter/Subscription-url', 'The uri that will receive the notifications', '7', 'f:Subscription/f:channel/f:endpoint', 'Subscription.channel.endpoint', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Substance', 'category', 'http://hl7.org/fhir/SearchParameter/Substance-category', 'The category of the substance', '3', 'f:Substance/f:category', 'Substance.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Substance', 'code', 'http://hl7.org/fhir/SearchParameter/Substance-code', 'The code of the substance or ingredient', '3', 'f:Substance/f:code | f:Substance/f:ingredient/f:substanceCodeableConcept', 'Substance.code | Substance.ingredient.substance.as(CodeableConcept)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Substance', 'container-identifier', 'http://hl7.org/fhir/SearchParameter/Substance-container-identifier', 'Identifier of the package/container', '3', 'f:Substance/f:instance/f:identifier', 'Substance.instance.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Substance', 'expiry', 'http://hl7.org/fhir/SearchParameter/Substance-expiry', 'Expiry date of package or container of substance', '1', 'f:Substance/f:instance/f:expiry', 'Substance.instance.expiry', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Substance', 'identifier', 'http://hl7.org/fhir/SearchParameter/Substance-identifier', 'Unique identifier for the substance', '3', 'f:Substance/f:identifier', 'Substance.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Substance', 'quantity', 'http://hl7.org/fhir/SearchParameter/Substance-quantity', 'Amount of substance in the package', '6', 'f:Substance/f:instance/f:quantity', 'Substance.instance.quantity', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Substance', 'status', 'http://hl7.org/fhir/SearchParameter/Substance-status', 'active | inactive | entered-in-error', '3', 'f:Substance/f:status', 'Substance.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Substance', 'substance-reference', 'http://hl7.org/fhir/SearchParameter/Substance-substance-reference', 'A component of the substance', '4', 'f:Substance/f:ingredient/f:substanceReference', 'Substance.ingredient.substance.as(Reference)', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyDelivery', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyDelivery', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyDelivery', 'receiver', 'http://hl7.org/fhir/SearchParameter/SupplyDelivery-receiver', 'Who collected the Supply', '4', 'f:SupplyDelivery/f:receiver', 'SupplyDelivery.receiver', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyDelivery', 'status', 'http://hl7.org/fhir/SearchParameter/SupplyDelivery-status', 'in-progress | completed | abandoned | entered-in-error', '3', 'f:SupplyDelivery/f:status', 'SupplyDelivery.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyDelivery', 'supplier', 'http://hl7.org/fhir/SearchParameter/SupplyDelivery-supplier', 'Dispenser', '4', 'f:SupplyDelivery/f:supplier', 'SupplyDelivery.supplier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyRequest', 'date', 'http://hl7.org/fhir/SearchParameter/clinical-date', '', '1', 'f:Consent/f:dateTime | f:SupplyRequest/f:authoredOn | f:RiskAssessment/f:occurrenceDateTime | f:CareTeam/f:period | f:FamilyMemberHistory/f:date | f:Encounter/f:period | f:AllergyIntolerance/f:assertedDate | f:CarePlan/f:period | f:EpisodeOfCare/f:period | f:Procedure/f:performedDateTime | f:Procedure/f:performedPeriod | f:List/f:date | f:Immunization/f:date | f:Flag/f:period | f:Observation/f:effectiveDateTime | f:Observation/f:effectivePeriod | f:DiagnosticReport/f:effectiveDateTime | f:DiagnosticReport/f:effectivePeriod | f:Composition/f:date | f:DetectedIssue/f:date | f:ClinicalImpression/f:date', 'Consent.dateTime | SupplyRequest.authoredOn | RiskAssessment.occurrence.as(DateTime) | CareTeam.period | FamilyMemberHistory.date | Encounter.period | AllergyIntolerance.assertedDate | CarePlan.period | EpisodeOfCare.period | Procedure.performed | List.date | Immunization.date | Flag.period | Observation.effective | DiagnosticReport.effective | Composition.date | DetectedIssue.date | ClinicalImpression.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyRequest', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyRequest', 'category', 'http://hl7.org/fhir/SearchParameter/SupplyRequest-category', 'The kind of supply (central, non-stock, etc.)', '3', 'f:SupplyRequest/f:category', 'SupplyRequest.category', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyRequest', 'requester', 'http://hl7.org/fhir/SearchParameter/SupplyRequest-requester', 'Individual making the request', '4', 'f:SupplyRequest/f:requester/f:agent', 'SupplyRequest.requester.agent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyRequest', 'status', 'http://hl7.org/fhir/SearchParameter/SupplyRequest-status', 'draft | active | suspended +', '3', 'f:SupplyRequest/f:status', 'SupplyRequest.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('SupplyRequest', 'supplier', 'http://hl7.org/fhir/SearchParameter/SupplyRequest-supplier', 'Who is intended to fulfill the request', '4', 'f:SupplyRequest/f:supplier', 'SupplyRequest.supplier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'authored-on', 'http://hl7.org/fhir/SearchParameter/Task-authored-on', 'Search by creation date', '1', 'f:Task/f:authoredOn', 'Task.authoredOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'based-on', 'http://hl7.org/fhir/SearchParameter/Task-based-on', 'Search by requests this task is based on', '4', 'f:Task/f:basedOn', 'Task.basedOn', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'business-status', 'http://hl7.org/fhir/SearchParameter/Task-business-status', 'Search by business status', '3', 'f:Task/f:businessStatus', 'Task.businessStatus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'code', 'http://hl7.org/fhir/SearchParameter/Task-code', 'Search by task code', '3', 'f:Task/f:code', 'Task.code', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'context', 'http://hl7.org/fhir/SearchParameter/Task-context', 'Search by encounter or episode', '4', 'f:Task/f:context', 'Task.context', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'focus', 'http://hl7.org/fhir/SearchParameter/Task-focus', 'Search by task focus', '4', 'f:Task/f:focus', 'Task.focus', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'group-identifier', 'http://hl7.org/fhir/SearchParameter/Task-group-identifier', 'Search by group identifier', '3', 'f:Task/f:groupIdentifier', 'Task.groupIdentifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'identifier', 'http://hl7.org/fhir/SearchParameter/Task-identifier', 'Search for a task instance by its business identifier', '3', 'f:Task/f:identifier', 'Task.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'intent', 'http://hl7.org/fhir/SearchParameter/Task-intent', 'Search by task intent', '3', 'f:Task/f:intent', 'Task.intent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'modified', 'http://hl7.org/fhir/SearchParameter/Task-modified', 'Search by last modification date', '1', 'f:Task/f:lastModified', 'Task.lastModified', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'organization', 'http://hl7.org/fhir/SearchParameter/Task-organization', 'Search by responsible organization', '4', 'f:Task/f:requester/f:onBehalfOf', 'Task.requester.onBehalfOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'owner', 'http://hl7.org/fhir/SearchParameter/Task-owner', 'Search by task owner', '4', 'f:Task/f:owner', 'Task.owner', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'part-of', 'http://hl7.org/fhir/SearchParameter/Task-part-of', 'Search by task this task is part of', '4', 'f:Task/f:partOf', 'Task.partOf', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'patient', 'http://hl7.org/fhir/SearchParameter/Task-patient', 'Search by patient', '4', 'f:Task/f:for', 'Task.for', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'performer', 'http://hl7.org/fhir/SearchParameter/Task-performer', 'Search by recommended type of performer (e.g., Requester, Performer, Scheduler).', '3', 'f:Task/f:performerType', 'Task.performerType', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'period', 'http://hl7.org/fhir/SearchParameter/Task-period', 'Search by period Task is/was underway', '1', 'f:Task/f:executionPeriod', 'Task.executionPeriod', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'priority', 'http://hl7.org/fhir/SearchParameter/Task-priority', 'Search by task priority', '3', 'f:Task/f:priority', 'Task.priority', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'requester', 'http://hl7.org/fhir/SearchParameter/Task-requester', 'Search by task requester', '4', 'f:Task/f:requester/f:agent', 'Task.requester.agent', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'status', 'http://hl7.org/fhir/SearchParameter/Task-status', 'Search by task status', '3', 'f:Task/f:status', 'Task.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('Task', 'subject', 'http://hl7.org/fhir/SearchParameter/Task-subject', 'Search by subject', '4', 'f:Task/f:for', 'Task.for', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestReport', 'identifier', 'http://hl7.org/fhir/SearchParameter/TestReport-identifier', 'An external identifier for the test report', '3', 'f:TestReport/f:identifier', 'TestReport.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestReport', 'issued', 'http://hl7.org/fhir/SearchParameter/TestReport-issued', 'The test report generation date', '1', 'f:TestReport/f:issued', 'TestReport.issued', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestReport', 'participant', 'http://hl7.org/fhir/SearchParameter/TestReport-participant', 'The reference to a participant in the test execution', '7', 'f:TestReport/f:participant/f:uri', 'TestReport.participant.uri', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestReport', 'result', 'http://hl7.org/fhir/SearchParameter/TestReport-result', 'The result disposition of the test execution', '3', 'f:TestReport/f:result', 'TestReport.result', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestReport', 'tester', 'http://hl7.org/fhir/SearchParameter/TestReport-tester', 'The name of the testing organization', '2', 'f:TestReport/f:tester', 'TestReport.tester', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestReport', 'testscript', 'http://hl7.org/fhir/SearchParameter/TestReport-testscript', 'The test script executed to produce this report', '4', 'f:TestReport/f:testScript', 'TestReport.testScript', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'date', 'http://hl7.org/fhir/SearchParameter/TestScript-date', 'The test script publication date', '1', 'f:TestScript/f:date', 'TestScript.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'description', 'http://hl7.org/fhir/SearchParameter/TestScript-description', 'The description of the test script', '2', 'f:TestScript/f:description', 'TestScript.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'identifier', 'http://hl7.org/fhir/SearchParameter/TestScript-identifier', 'External identifier for the test script', '3', 'f:TestScript/f:identifier', 'TestScript.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/TestScript-jurisdiction', 'Intended jurisdiction for the test script', '3', 'f:TestScript/f:jurisdiction', 'TestScript.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'name', 'http://hl7.org/fhir/SearchParameter/TestScript-name', 'Computationally friendly name of the test script', '2', 'f:TestScript/f:name', 'TestScript.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'publisher', 'http://hl7.org/fhir/SearchParameter/TestScript-publisher', 'Name of the publisher of the test script', '2', 'f:TestScript/f:publisher', 'TestScript.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'status', 'http://hl7.org/fhir/SearchParameter/TestScript-status', 'The current status of the test script', '3', 'f:TestScript/f:status', 'TestScript.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'testscript-capability', 'http://hl7.org/fhir/SearchParameter/TestScript-testscript-capability', 'TestScript required and validated capability', '2', 'f:TestScript/f:metadata/f:capability/f:description', 'TestScript.metadata.capability.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'title', 'http://hl7.org/fhir/SearchParameter/TestScript-title', 'The human-friendly name of the test script', '2', 'f:TestScript/f:title', 'TestScript.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'url', 'http://hl7.org/fhir/SearchParameter/TestScript-url', 'The uri that identifies the test script', '7', 'f:TestScript/f:url', 'TestScript.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('TestScript', 'version', 'http://hl7.org/fhir/SearchParameter/TestScript-version', 'The business version of the test script', '3', 'f:TestScript/f:version', 'TestScript.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'date', 'http://hl7.org/fhir/SearchParameter/ValueSet-date', 'The value set publication date', '1', 'f:ValueSet/f:date', 'ValueSet.date', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'description', 'http://hl7.org/fhir/SearchParameter/ValueSet-description', 'The description of the value set', '2', 'f:ValueSet/f:description', 'ValueSet.description', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'expansion', 'http://hl7.org/fhir/SearchParameter/ValueSet-expansion', 'Uniquely identifies this expansion', '7', 'f:ValueSet/f:expansion/f:identifier', 'ValueSet.expansion.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'identifier', 'http://hl7.org/fhir/SearchParameter/ValueSet-identifier', 'External identifier for the value set', '3', 'f:ValueSet/f:identifier', 'ValueSet.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'jurisdiction', 'http://hl7.org/fhir/SearchParameter/ValueSet-jurisdiction', 'Intended jurisdiction for the value set', '3', 'f:ValueSet/f:jurisdiction', 'ValueSet.jurisdiction', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'name', 'http://hl7.org/fhir/SearchParameter/ValueSet-name', 'Computationally friendly name of the value set', '2', 'f:ValueSet/f:name', 'ValueSet.name', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'publisher', 'http://hl7.org/fhir/SearchParameter/ValueSet-publisher', 'Name of the publisher of the value set', '2', 'f:ValueSet/f:publisher', 'ValueSet.publisher', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'reference', 'http://hl7.org/fhir/SearchParameter/ValueSet-reference', 'A code system included or excluded in the value set or an imported value set', '7', 'f:ValueSet/f:compose/f:include/f:system', 'ValueSet.compose.include.system', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'status', 'http://hl7.org/fhir/SearchParameter/ValueSet-status', 'The current status of the value set', '3', 'f:ValueSet/f:status', 'ValueSet.status', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'title', 'http://hl7.org/fhir/SearchParameter/ValueSet-title', 'The human-friendly name of the value set', '2', 'f:ValueSet/f:title', 'ValueSet.title', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'url', 'http://hl7.org/fhir/SearchParameter/ValueSet-url', 'The uri that identifies the value set', '7', 'f:ValueSet/f:url', 'ValueSet.url', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('ValueSet', 'version', 'http://hl7.org/fhir/SearchParameter/ValueSet-version', 'The business version of the value set', '3', 'f:ValueSet/f:version', 'ValueSet.version', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('VisionPrescription', 'identifier', 'http://hl7.org/fhir/SearchParameter/clinical-identifier', '', '3', 'f:DocumentManifest/f:masterIdentifier | f:DocumentManifest/f:identifier | f:Goal/f:identifier | f:Consent/f:identifier | f:DocumentReference/f:masterIdentifier | f:DocumentReference/f:identifier | f:SupplyRequest/f:identifier | f:RiskAssessment/f:identifier | f:CareTeam/f:identifier | f:ImagingStudy/f:identifier | f:FamilyMemberHistory/f:identifier | f:Encounter/f:identifier | f:DeviceRequest/f:identifier | f:AllergyIntolerance/f:identifier | f:CarePlan/f:identifier | f:EpisodeOfCare/f:identifier | f:Procedure/f:identifier | f:List/f:identifier | f:Immunization/f:identifier | f:VisionPrescription/f:identifier | f:ProcedureRequest/f:identifier | f:Observation/f:identifier | f:DiagnosticReport/f:identifier | f:NutritionOrder/f:identifier | f:Condition/f:identifier | f:Composition/f:identifier | f:DetectedIssue/f:identifier | f:SupplyDelivery/f:identifier', 'DocumentManifest.masterIdentifier | DocumentManifest.identifier | Goal.identifier | Consent.identifier | DocumentReference.masterIdentifier | DocumentReference.identifier | SupplyRequest.identifier | RiskAssessment.identifier | CareTeam.identifier | ImagingStudy.identifier | FamilyMemberHistory.identifier | Encounter.identifier | DeviceRequest.identifier | AllergyIntolerance.identifier | CarePlan.identifier | EpisodeOfCare.identifier | Procedure.identifier | List.identifier | Immunization.identifier | VisionPrescription.identifier | ProcedureRequest.identifier | Observation.identifier | DiagnosticReport.identifier | NutritionOrder.identifier | Condition.identifier | Composition.identifier | DetectedIssue.identifier | SupplyDelivery.identifier', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('VisionPrescription', 'patient', 'http://hl7.org/fhir/SearchParameter/clinical-patient', '', '4', 'f:ReferralRequest/f:subject | f:DocumentManifest/f:subject | f:Goal/f:subject | f:Consent/f:patient | f:DocumentReference/f:subject | f:ImagingManifest/f:patient | f:RiskAssessment/f:subject | f:CareTeam/f:subject | f:ImagingStudy/f:patient | f:FamilyMemberHistory/f:patient | f:Encounter/f:subject | f:DeviceUseStatement/f:subject | f:DeviceRequest/f:subject | f:AllergyIntolerance/f:patient | f:CarePlan/f:subject | f:EpisodeOfCare/f:patient | f:Procedure/f:subject | f:List/f:subject | f:Immunization/f:patient | f:VisionPrescription/f:patient | f:ProcedureRequest/f:subject | f:Flag/f:subject | f:Observation/f:subject | f:DiagnosticReport/f:subject | f:NutritionOrder/f:patient | f:Condition/f:subject | f:Composition/f:subject | f:DetectedIssue/f:patient | f:SupplyDelivery/f:patient | f:ClinicalImpression/f:subject', 'ReferralRequest.subject | DocumentManifest.subject | Goal.subject | Consent.patient | DocumentReference.subject | ImagingManifest.patient | RiskAssessment.subject | CareTeam.subject | ImagingStudy.patient | FamilyMemberHistory.patient | Encounter.subject | DeviceUseStatement.subject | DeviceRequest.subject | AllergyIntolerance.patient | CarePlan.subject | EpisodeOfCare.patient | Procedure.subject | List.subject | Immunization.patient | VisionPrescription.patient | ProcedureRequest.subject | Flag.subject | Observation.subject | DiagnosticReport.subject | NutritionOrder.patient | Condition.subject | Composition.subject | DetectedIssue.patient | SupplyDelivery.patient | ClinicalImpression.subject', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('VisionPrescription', 'encounter', 'http://hl7.org/fhir/SearchParameter/clinical-encounter', '', '4', 'f:DocumentReference/f:context/f:encounter | f:RiskAssessment/f:context | f:DeviceRequest/f:context | f:Procedure/f:context | f:List/f:encounter | f:VisionPrescription/f:encounter | f:ProcedureRequest/f:context | f:Flag/f:encounter | f:Observation/f:context | f:DiagnosticReport/f:context | f:NutritionOrder/f:encounter | f:Composition/f:encounter', 'DocumentReference.context.encounter | RiskAssessment.context | DeviceRequest.context | Procedure.context | List.encounter | VisionPrescription.encounter | ProcedureRequest.context | Flag.encounter | Observation.context | DiagnosticReport.context | NutritionOrder.encounter | Composition.encounter', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('VisionPrescription', 'datewritten', 'http://hl7.org/fhir/SearchParameter/VisionPrescription-datewritten', 'Return prescriptions written on this date', '1', 'f:VisionPrescription/f:dateWritten', 'VisionPrescription.dateWritten', '1', '1', '2018-08-17 02:20:20 +08:00');
INSERT INTO [dbo].[_SearchParam]
    ([Resource], [Name], [Url], [Description], [Type], [XPath], [Expression], [IsIndexed], [Status], [LastUpdated])
VALUES
    ('VisionPrescription', 'prescriber', 'http://hl7.org/fhir/SearchParameter/VisionPrescription-prescriber', 'Who authorizes the vision product', '4', 'f:VisionPrescription/f:prescriber', 'VisionPrescription.prescriber', '1', '1', '2018-08-17 02:20:20 +08:00');
END