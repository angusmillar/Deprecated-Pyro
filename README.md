# README #

## Pyro FHIR Server ##

This is a FHIR server under development. 


## Requirements ##

Visual Studio
SQL Server 2016 Management Studio Express 64 Bit

## Important parts ##
Project Description:

*Pyro.CodeGeneration*
When a new version of the fhir-net-api package is loaded (use Nuget package manager) you can 
then run the T4 tempate located in this project at `Pyro.CodeGeneration.Template.MainTemplate.tt`. 
This will update the the key classes in the `Pyro.DataLayer` & `Pyro.Common` projects to adapt to
the new fhir-net-api bringing in any new FHIR resources and base standard search parameters.
Before running the T4 template `MainTemplate.tt` you will need to manually update the Assembly 
references within this file to point to the new packages as updated by Nuget package manager. 
Below are examples of the four references discussed: 

`<#@ Assembly Name="$(SolutionDir)packages\Newtonsoft.Json.9.0.1\lib\net45\Newtonsoft.Json.dll"#>`
`<#@ Assembly Name="$(SolutionDir)packages\Hl7.Fhir.STU3.0.93.3\lib\net45\Hl7.Fhir.STU3.Core.dll"#>`
`<#@ Assembly Name="$(SolutionDir)packages\Hl7.Fhir.Support.0.4.2\lib\net45\Hl7.Fhir.Support.dll"#>`
`<#@ Assembly Name="$(SolutionDir)packages\Hl7.FhirPath.0.4.2\lib\net45\Hl7.FhirPath.dll"#>`

Once these are updated build the project `Pyro.CodeGeneration` in debug and then right click the 
`MainTemplate.tt` file and select 'Run Custom Tool'. This will generate the code classes as discusssed.
You may need to delete all contents in the sub T4 file `MainTemplate.cs` if you receive a compile error. 

Please note that no database upgrades have been implemented so post this process you will need 
to delete the database which will be recreated as the first call is made to the FHIR endpoint.

*Pyro.Common*
This project holds all common code used by the entire solution.

*Pyro.ConsoleServer*
This project allows the server to be started up in a console window as is used for debugging.
This is the project to set as start-up when running in Visual Studio.

*Pyro.DataLayer*
This is the data layer project which handles all database access

*Pyro.Engine*
This is the bussiness logic layer

*Pyro.Test*
This project houses all unit tests and integration tests.

*Pyro.Web*
This is the project run in IIS to host the Pyro Server.

## Repo owner or admin ##

Angus Millar