# README #

## Blaze FHIR Server ##

This is a FHIR server under development. The initial scope is to support the storage of all the resources required to manage the storage and retrieval of Pathology reports. This scope may be expanded out in time to Pathology Orders and then into the Radiology Report space.


## Requirements ##

Visual Studio
SQL Server 2014 Management Studio Express 64 Bit

## Important parts ##

Blaze/FhirController.cs - REST entry point, delegates execution to services defined in Blaze/Services.
Blaze.Engine/Search - search service implementations (to be rewritten to use LINQ).
Blaze.Engine/Services - per-resource Service implementations, handling all resource-specific operations as well as committing the resource to storage (+ separately to the search DB).
Blaze.Engine/Validation - per-resource validation that's used by a Service before a resource is committed to storage.
BusinessEntities - translates objects between their Blaze representation and the Entity Frameworks representation in storage.
DataModel - sefines the storage layout in the SQL database using Entity Framework.
Dip - dependency injection, defines interfaces that are implemented by Blaze.Engine.
SqlForge - programmatic SQL query builder.

## Repo owner or admin ##

Angus Millar