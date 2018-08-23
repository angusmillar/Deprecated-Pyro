## Pyro FHIR Server ##

This is a C# .NET Framework 4.6, MSSQL or PostgreSQL, FHIR server implementing FHIR Version STU-3.0.1 

See the official FHIR specification page here: [FHIR specification STU-3.0.1](http://hl7.org/fhir/STU3/index.html)

See the publicly accessible Pyro Server instance running here: [Pyrohealth.net](https://pyrohealth.net/)

**This server implements the following FHIR specification components** 

> Or get the server's CapabilityStatement resource from the Pyrohealth.net server: GET https://stu3.test.pyrohealth.net/fhir/metadata

> Or read the web rendered CapabilityStatement here: [Pyro FHIR Server CapabilityStatement](https://pyrohealth.net/metadata-content)

* All Resources Types
* All Resources search parameters (except for composite parameters)
* RestFul CRUD
* Compartments (implemented from dynamic CompartmentDefinition resources)
* Chained parameters
* _includes & _revinclude
* Custom Search parameters
* History
* Conditional Create
* Conditional Update 
* Conditional Read 
* Conditional Delete  
* Bundle Transaction
* Operations

**Operations**

Base Operations:
* $server-indexes-delete-history-indexes    
* $server-indexes-set      
* $server-indexes-index      
* $server-indexes-report      
* $server-resource-report   

Resource Operations:
* $server-indexes-delete-history-indexes (All ResourceTypes)  
* $validate (All ResourceTypes)
* $x-ihisearchorvalidate (Patient ResourceTypes)

Resource Instance Operations:
* $validate (All ResourceTypes)
* $x-set-compartment-active (CompartmentDefinition ResourceTypes)
* $x-set-compartment-inactive (CompartmentDefinition ResourceTypes)



## Requirements ##

Visual Studio 2017

.NET Framework 4.6
  
Microsoft SQL Server 2016 or higher

or

PostgreSQL (Version 10)

## How do I get this solution up and running fast ##

1. First clone from the GitHub repository: https://github.com/angusmillar/Pyro.git and then open in Visual Studio 2017.
2. Right click the main solution 'Pyro' and select 'Restore Nuget packages' and then 'F6' to build the solution.
3. You will then need to configure to your development environment database connection string by editing this file: `Pyro.ConsoleServer\App_Data\Connectons.config`
4. Then right click the project named 'Pyro.DbManager' and select 'Set as StartUp Project'
5. Hit 'F5' to start the 'Pyro.DbManager' console application project and follow the prompts to create the intial database.
6. Then right click the project named 'Pyro.ConsoleServer' and select 'Set as StartUp Project'
7. Hit 'F5' to start the 'Pyro.ConsoleServer' project.
8. A console window opens with the Pyro logo in yellow and the message "Please wait while database schema loads", this will take about 1 min.     
9. Once the load is completed the console will change from yellow to blue and the server is ready for calls to its FHRI API. The console will state the FHIR API endpoint. The default is `http://localhost:8888/fhir` 

## Understanding the solution a little deeper ##

There are three key projects you will need to understand:

* Pyro.DbManager for database management  
* Pyro.ConsoleServer as the development environment 
* Pyro.WebApi as the production environment


**Database Management**

The `Pyro.DbManager` project is a console application that will connect to the databse and create or upgrade the database as required.
This project MUST be run before the others as it will setup the database which the other projects depend upon.
When run in the debugger (Visual Studio) it uses the connection string found in the `Pyro.ConsoleServer` project e.g `Pyro.ConsoleServer\App_Data\Connectons.config`. 
When run outside of the debugger it expects to find a web.config file in the parent directory from where it is run, it will use the connection string referanced from this web.config file which will typlicaly be the Connectons.config file found in the App_Data directory of the same pareent directory. 
This is true when deployed in IIS and the Pyro.DbManager.exe is found in the bin folder, so in this case you just need to run the Pyro.DbManager.exe stright from the bin folder to create or update the production database.   

**Development Environment**

The `Pyro.ConsoleServer` project will run the server in console mode and is the primary way to use the server if in a development environment. It's quicker to start and logs on screen the HTTP request coming in. The FHIR server is fully functional run this way.
Before you run this project you will need to have configured the connection string as showen below and you must have first run the `Pyro.DbManager` project which will have initalised your database. 

`Pyro.ConsoleServer\App_Data\Connectons.config`

You may also like to change the `ServiceBaseURL` property which is the endpoint the FHIR server will run from. This can be done in the file:

`Pyro.ConsoleServer\App_Data\PyroApp.config`

Below is the documentation about this property:

Command: ServiceBaseURL

Value: URL String

Description: This setting sets the service's Service Base URL and must match the URL where the service is hosted. This is the URL that will host the FHIR API. Care must be taken changing this URL post the service being in operation as the physical Resources and the search indexes in the database, and any external references with still have the previous URL reference. In practice, all Resource would need to be updated and recommitted if this was to change. 
Simply changing the setting here does not initiate the updating of all these references.

**Production Enviroment**

The `Pyro.WebApi` project will run the server in Internet Information Services (IIS). This is primarily used for when the server is deployed in a production IIS instance. It does not provide any webpage, only the FHIR API endpoints accessible and hosted in IIS. 

There is a separate independent Javascript React SPA website project named PyroWeb that provide a website landing page for the Pyro Server found here: [PyroWeb WebSite](https://github.com/angusmillar/PyroWeb).

Before you run this project you will need to have configured the connection string as showen below and you must have first run the `Pyro.DbManager` project which will have initalised your database. 

`Pyro.WebApi\App_Data\Connectons.config`

You will also need to set the `ServiceBaseURL` property in the file below (See the same documentation above in "Development Environment" for this property)

`Pyro.WebApi\App_Data\PyroApp.config`


Both projects `Pyro.WebApi` and `Pyro.ConsoleServer`, requires that you first run the `Pyro.DbManager` first to initialise the database.
If you do not do this and start either `Pyro.WebApi` or `Pyro.ConsoleServer` first, they will create a database for themselves yet that database will not 
be seeded with the required reference data. Once you attempt to commit (PUT or POST) a FHIR resource you will receive a FHIR OperationOutcome error in response that reads:

`The _FhirRelease database table returned no entry for the fhir Version '{Hl7.Fhir.Model.ModelInfo.Version}', this typically occurs when the table was never seeded at the time of database creation. You must create the database using the Pyro.DbManager application and not rely on the service creating it on startup as the service will not seed the initial data required.` If this is true for you then drop your database and start again by running the Pyro.DbManager application first.`

In general, you would only use `Pyro.Console` in your development environment and configure its connection strings and ServiceBaseURL to suit. You would then only configure the `Pyro.WebApi` connection strings and ServiceBaseURL to be for your production instance ready for deployment. 

_Logging:_
The solution uses the [NLog](http://nlog-project.org/) logging framework. By default, this is configured to log to the console and to AWS Cloudwatch logs.
You may wish to reconfigure this for your needs. There is already a commented out config to have it log to the file system.

All configuration lives in the file below and the [NLog Configuration Documentation](https://github.com/nlog/NLog/wiki/Configuration-file) is at this link. 

`Pyro.WebApi\NLog.config` (Just search for LogFilePath)


## Full Solution Project Description ##

**Pyro.ADHA (Project)**

This project contains the logic and libraries from the Australian Digital Health Agency to perform HI Service searches for the Australian Individual Healthcare Identifier (IHI) which is the Australian National identifier for healthcare

**Pyro.ADHA_Test (Project)**

This project holds test cases for the HI Service searches for IHI identifier

**Pyro.Backburner (Project)**

This project is a windows service that can be installed and run to perform long-running, out-of-band, asynchronous tasks for the FHIR Pyro Server. There is no hard dependency for this service to be running to use the Pyro FHIR Server. When running, it connects to the main Pyro FHIR server via SingnalR to receive notifications of tasks to perform. This is currently in development but in future will manage background task such as Subscription notifications and possibly long-running Patient merge operations.

This windows service uses the [TopShelf](http://topshelf-project.com/) framework and in as easy to install on the command line as follows: 

`C:\BackburnerService\Pyro.Backburner.exe install`  

See [TopShelf Command Documentation](https://topshelf.readthedocs.io/en/latest/overview/commandline.html) for more info.

The only configration this project requires is the database connection string for the Pyro FHIR server configured here: `Pyro.Backburner\App_Data\Connections.config`


**Pyro.CodeGeneration (Project)**

Please note: You don't need to do the following to get the server running, this is only for future development purposes when a new FHIR release is available'

This project holds the code generation logic used to generate new classes for when a new version of the FHIR specification is released i.e update from STU3 to R4. It interrogates the FHIR .NET API to get the source specification information.

When a new version of the FHIR is released (e.g STU3 to STU4) and the external fhir-net-api package updated and loaded (use NuGet package manager) you can then run the T4 template located in this project at `Pyro.CodeGeneration.Template.MainTemplate.tt`. 

This will update the key classes in the `Pyro.DataLayer` & `Pyro.Common` projects to adapt to
the new fhir-net-api and FHIR release bringing in any new FHIR resources and base standard search 
parameters.

Before running the T4 template `MainTemplate.tt` you will need to manually update the static assembly references within this file to point to the new packages as updated by Nuget package manager. 
Below are examples of the four references discussed: 

`<#@ Assembly Name="$(SolutionDir)packages\Newtonsoft.Json.9.0.1\lib\net45\Newtonsoft.Json.dll"#>`

`<#@ Assembly Name="$(SolutionDir)packages\Hl7.Fhir.STU3.0.93.3\lib\net45\Hl7.Fhir.STU3.Core.dll"#>`

`<#@ Assembly Name="$(SolutionDir)packages\Hl7.Fhir.Support.0.4.2\lib\net45\Hl7.Fhir.Support.dll"#>`

`<#@ Assembly Name="$(SolutionDir)packages\Hl7.FhirPath.0.4.2\lib\net45\Hl7.FhirPath.dll"#>`

Once these are updated first build the project `Pyro.CodeGeneration` in debug and then right-click the 
`MainTemplate.tt` file and select 'Run Custom Tool'. This will generate the code classes as discussed.
You may need to delete all contents in the sub T4 file `MainTemplate.cs` if you receive a compile error. 

Note that no database upgrades have been implemented for this type of modification so post this process you will need to delete the database which will be recreated as the first call is made to the FHIR endpoint.

**Pyro.Common (Project)**

This project holds all common cross-cutting code used by the entire solution.

**Pyro.ConsoleServer (Project)**

This project allows the server to be started up in a console window and is te primary way to run the server in a development environment.
This is the project to set as start-up when running in Visual Studio.

**Pyro.DataLayer (Project)**

This is the data layer project which handles all database access

**Pyro.DbManager (Project)**

This is a console application that manages the Pyro server database initialization and migrations/upgrades. You must run this before running either the `Pyro.ConsoleServer` or the `Pyro.WebApi` and it should be run after any code updates to apply any database changes that may be required.  It is safe to run at any time and multiple times as it tracks what it has done within the database table `__SchemaVersions`. 
When run, it will first list the SQL scripts that it has detected as required to be run. It will then ask whether you would like these SQL scripts written to a folder for your own inspection or review. It will warn you to back up your database and then finally will ask: "Do you wish to perform the upgrade against the database?"  
If you answer No it will abort if you answer yes the scripts will be executed against the database. It will eventually finish with the word "Success!" in green, or a red "Failed!" and some error messages, if it was not successful.
Also, if you wished to automate this task you can provide the switch parameter '-UnattendedMode True' to the launch and it will run without requiring any user interactions, it will just attempt to run the scripts against the database and nothing else. This is a console application that managed the databse initaliseation and migrations or upgrades

**Pyro.Engine (Project)**

This is the business logic layer

**Pyro.Identifiers (Project)**

This project is a library for parsing and validating healthcare identifiers, primarily Australian identifiers, (Medicare Number, Medicare Provider number, DVA Number, IHI Number, HPI-I Number, HPI-O Number)  

**Pyro.Identifiers_Test (Project)**

This project holds test cases for the Pyro.Identifiers project.

**Pyro.Smart (Project)**

This project implements SMART (SMART on FHIR) elements. Currently under development and not used by the server as yet.

**Pyro.Smart_Test (Project)**

This project is the test cases for the  Pyro.Smart project (SMART on FHIR) elements

**Pyro.Test (Project)**

This project houses all unit tests and integration tests for the FHIR server.

**Pyro.WebApi (Project)**

This is the project used when hosting in a production IIS instance. It is this project that you publish from for your production instance.

## Other General Information ##

**SMART on FHIR and Authentication**
I am slowly progressing to an Authentication system for the server with key elements beginning to fall in place to finally implement. I now have a SMART parser and FHIR compartments. Need to start work on the OAuth component possibly using Identity server: https://www.nuget.org/packages/IdentityServer4/

## Repo owner ##

Angus Millar: angusbmillar@gmail.com
