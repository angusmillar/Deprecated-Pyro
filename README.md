# README #

## Pyro FHIR Server ##

This is a FHIR server implmenting FHIR STU-3.0.1

See the offical specification page here: http://hl7.org/fhir/STU3/index.html

See the production Pyro Server instance running here: https://pyrohealth.net/

This server implements the following elements: 

* All Resources Types
* All Resources search parameters (except for composite parameters)
* RestFul CRUD
* Chained parameters
* _includes & _revinclude
* Custom Search parameters
* History
* Conditional Create
* Conditional Update 
* Conditional Read 
* Conditional Delete  
* Operation: Validate a resource
* Bundle Transaction

## Requirements ##

Visual Studio 2017

SQL Server 2016 Management Studio Express 64 Bit

## How do I get this solution up and running ##
There are two key projects you will need to understand to simply run the server in your development enviroment and production enviroment. The are as follows:

**Pyro.ConsoleServer (Project)**

The Pyro.ConsoleServer will run the server in console mode and is the primary way to use the server if in a development enviroment. It’s quicker to start and logs on screen the HTTP request coming in. The FHIR server is fully functional run this way.
Before you run this project you will need to change the connection string for the Pyro.ConsoleServer. This can be found in the file:

`Pyro.ConsoleServer\App_Data\Connectons.config`

Just change the ‘connectionString’ element to meet your database.

You will also need to set the ‘ServiceBaseURL’ property in the file:

`Pyro.ConsoleServer\App_Data\PyroApp.config`

Below is the documentation of this property:

**Command:** ServiceBaseURL

**Value:** URL String

**Description:** This setting sets the service's Service Base URL and must match the URL where the service is hosted. This is the URL that will host the FHIR API. Care must be taken changing this URL post the service being in operation as the physical Resources and the search indexes in the database, and any external references with still have the previous URL reference. In practice, all Resource would need to be updated and recommitted if this was to change. 
Simply changing the setting here does not initate the updating of all these referances.

**Pyro.WebApi (Project)**

The Pyro.WebApi will run the server in IIS Express. This is primarily used for when the server is deployed in production in a production IIS instance. It does not provide any webpage only the FHIR API endpoints hosted in IIS. 

There is a seperate independent javascript React SPA website project named PyroWeb that provide a website landing page for the Pyro Server found here: [PyroWeb WebSite](https://bitbucket.org/angusmillar/pyro-web) .

Before you run the Pyro.WebApi project you will need to change the connection string for the Pyro.WebApi. This can be found in the file:

`Pyro.WebApi\App_Data\Connectons.config`

Just change the ‘connectionString’ element to meet your database.
You will also need to set the ‘ServiceBaseURL’ property in the file (See doco above in Pyro.ConsoleServer for this property)

`Pyro.WebApi\App_Data\PyroApp.config`

Both projects Pyro.WebApi and Pyro.ConsoleServer when first run will create a database at the given ConnectionString.
This will actualy only occur when the first call is made to the FHIR API. So you can do a simple GET: http://yourdomain/fhir/Patient to tigger this to occur.
Be patient as this first call will be slow as it must create all the database tables and populate the seed data before the call will return. All subsequent calls will be much faster.

In general, you would only use Pyro.Console in your development enviroment and configure its connectionstrings and ServiceBaseURL to suit. You would then only configure the Pyro.WebApi connectionstrings and ServiceBaseURL to be for your production instance ready for deployment. 

**Logging**
The solution also uses NLog for logging and it is configured to log to C:\PyroLogs. 
You may need to check this directory is valid in your enviroment or change the loging directory which can be done in the file:

`Pyro.WebApi\NLog.config` (Just search for LogFilePath)


## Full Solution Project Description ##

**Pyro.CodeGeneration (Project)**

When a new version of the FHIR is released (e.g STU3 to STU4) and the external fhir-net-api package 
updated and loaded (use Nuget package manager) you can then run the T4 tempate located in this project 
at `Pyro.CodeGeneration.Template.MainTemplate.tt`. 

This will update the the key classes in the `Pyro.DataLayer` & `Pyro.Common` projects to adapt to
the new fhir-net-api and FHIR release bringing in any new FHIR resources and base standard search 
parameters.

Before running the T4 template `MainTemplate.tt` you will need to manually update the static Assembly 
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

Please note: You don't need to do this just to get the server running this is only for future development purposes when a new FHIR release is available'

**Pyro.Common (Project)**

This project holds all common cross cutting code used by the entire solution.

**Pyro.ConsoleServer (Project)**

This project allows the server to be started up in a console window and is te primary way to run the server in a development enviroment.
This is the project to set as start-up when running in Visual Studio.

**Pyro.DataLayer (Project)**

This is the data layer project which handles all database access

**Pyro.Engine (Project)**

This is the bussiness logic layer

**Pyro.Test (Project)**

This project houses all unit tests and integration tests.

**Pyro.WebApi (Project)**

This is the project used when hosting in a production IIS instance. 
It is this project that you publish from for your production instance.

**Pyro.Smart (Project)**

This project implments SMART (SMART on FHIR) elements. Currently under development and not used by the server as yet.

**Pyro.Smart_Test (Project)**

This project is the test cases for the  Pyro.Smart project (SMART on FHIR) elements


## Repo owner or admin ##

Angus Millar: angusbmillar@gmail.com