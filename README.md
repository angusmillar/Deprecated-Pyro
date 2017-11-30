# README #

## Pyro FHIR Server ##

This is a FHIR server implmenting FHIR STU-3.0.1

See the offical specification page here: http://hl7.org/fhir/STU3/index.html

See the production Pyro Server instance running here: https://pyrohealth.net/

This server implements the following elements: 

* All Resources Types
* All Resources search parameters (except for composite parameters)
* Chained parameters
* _includes & _revinclude
* Custom Search parameters
* History
* Conditional Create, Conditional Update, Conditional Read, Conditional Delete  
* Operation: Validate a resource
* Bundle Transaction

## Requirements ##

Visual Studio 2017

SQL Server 2016 Management Studio Express 64 Bit

## How do I get this solution up and running ##
There are two key projects for ruunnig the server, as follows:

**Pyro.ConsoleServer (Project)**
The Pyro.ConsoleServer will run the server in console mode and is primary used for development. It’s quicker to start and logs on screen the HTTP request coming in. The FHIR server is fully functional run this way, you just don’t get to see a pretty webpage.
Before you run this project you will need to change the connection string for the Pyro.ConsoleServer. This can be found in the file:

`Pyro.ConsoleServer\App_Data\Connectons.config`

Just change the ‘connectionString’ element to meet your database.

You will also need to set the ‘ServiceBaseURL’ property in the file:

`Pyro.ConsoleServer\App_Data\ PyroApp.config`

Below is the documentation of this property:

**Command:** ServiceBaseURL

**Value:** URL String

**Description:** This setting sets the service's Service Base URL and must match the URL where the service is hosted. This is the URL that will host the FHIR API. Care must be taken changing this URL post the service being in operation as the physical Resources and the search indexes in the database, and any external references with still have the previous URL reference. In practice, all Resource would need to also be updated and recommitted. 
Changing this setting here not perform that update.

**Pyro.Web (Project)**
The Pyro.Web will run the server in IIS Express and launch the browser to show the simple landing page website. This is primarily used for when the server is deployed in production so that we have some sort of landing page for visitors to see. This website will not be developed further as I am working on a separate front end project independent to this solution based in javascript and React.
Before you run this project you will need to change the connection string for the Pyro.Web. This can be found in the file:

`Pyro.Web\App_Data\ Connectons.config`

Just change the ‘connectionString’ element to meet your database.
You will also need to set the ‘ServiceBaseURL’ property in the file (See doco above in Pyro.ConsoleServer for this property)

`Pyro.Web \App_Data\ PyroApp.config`

Both projects when first run will create a database at the given ConnectionString.
This will actualy only occur when the first call is made to the FHIR API. So you can do a simple GET: http://yourdomain/test/stu3/fhir/Patient to tigger this to occur.
Be patient as this first call will be slow as it must create all the database tables and populate the seed data before the call will return. All subsequent calls will be much faster.

**Logging**
The solution also uses NLog for logging and it is configured to log to C:\PyroLogs. 
You may need to check this directory is valid in your enviroment or change the loging directory which can be done in the file:

`Pyro.Web\NLog.config` (Just search for LogFilePath)


## Important parts ##
Project Description:

*Pyro.CodeGeneration*
When a new version of the FHIR is released (e.g STU3 to STU4) and the external fhir-net-api package 
updated and loaded (use Nuget package manager) you can then run the T4 tempate located in this project 
at `Pyro.CodeGeneration.Template.MainTemplate.tt`. 

This will update the the key classes in the `Pyro.DataLayer` & `Pyro.Common` projects to adapt to
the new fhir-net-api and FHIR release bringing in any new FHIR resources and base standard search 
parameters.

Before running the T4 template `MainTemplate.tt` you will need to manually update the Assembly 
references within this file to point to the new packages as updated by Nuget package manager. 
Below are examples of the four references discussed: 

`<#@ Assembly Name="$(SolutionDir)packages\Newtonsoft.Json.9.0.1\lib\net45\Newtonsoft.Json.dll"#>`

`<#@ Assembly Name="$(SolutionDir)packages\Hl7.Fhir.STU3.0.93.3\lib\net45\Hl7.Fhir.STU3.Core.dll"#>`

`<#@ Assembly Name="$(SolutionDir)packages\Hl7.Fhir.Support.0.4.2\lib\net45\Hl7.Fhir.Support.dll"#>`

`<#@ Assembly Name="$(SolutionDir)packages\Hl7.FhirPath.0.4.2\lib\net45\Hl7.FhirPath.dll"#>`

Once these are updated first build the project `Pyro.CodeGeneration` in debug and then right click the 
`MainTemplate.tt` file and select 'Run Custom Tool'. This will generate the code classes as discusssed.
You may need to delete all contents in the sub T4 file `MainTemplate.cs` if you receive a compile error. 

Note that no database upgrades have been implemented for this type of modification so post this process you will need 
to delete the database which will be recreated as the first call is made to the FHIR endpoint.

Please note: You don't need to do this just to get the server running this is only for future purposes when a new FHIR release is available'

*Pyro.Common*
This project holds all common cross cutting code used by the entire solution.

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

Angus Millar: angusbmillar@gmail.com