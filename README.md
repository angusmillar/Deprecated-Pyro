# README #

## Pyro FHIR Server ##

This is a C# .NET Framework 4.6, MSSQL, FHIR server implementing FHIR Version STU-3.0.1 

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

## How do I get this solution up and running fast##

1. First clone from the GitHub repository: https://github.com/angusmillar/Pyro.git and then open in Visual Studio 2017.
2. Right click the main Solution 'Pyro' and select 'Restore Nuget packages' and then 'F6' to Build Solution.
3. You will then need to configure to your development environment database connection string by editing this file: `Pyro.ConsoleServer\App_Data\Connectons.config`
4. The right click the project named 'Pyro.ConsoleServer' and select 'Set as StartUp Project'
5. Hit 'F5' to start the project.
6. You will see a console window open with the Pyro logo stating that the FHIR endpoint is running at 'http://localhost:8888/fhir'. You should then do a Http GET on any thing, for instance `GET: http://localhost:8888/fhir/metadata` as this will trigger the first time initialisation of the database. Please be patient as the database initialisation will take 4 to 5 min while it creates the database and seeds data.
7. Once the call retuns with a Http: 200 OK your server is now ready for use. 

## Understanding the solution a little deeper##

There are two key projects you will need to understand, the development environment and the production environment. They are as follows:

#Development Environment#

The `Pyro.ConsoleServer` project will run the server in console mode and is the primary way to use the server if in a development environment. It's quicker to start and logs on screen the HTTP request coming in. The FHIR server is fully functional run this way.
Before you run this project you will need to change the connection string for the `Pyro.ConsoleServer` project. This can be found in the file:

`Pyro.ConsoleServer\App_Data\Connectons.config`

Just change the `connectionString` element to meet your database.

You may also like to change the `ServiceBaseURL` property, the endpoint the fhir server will run from. this can be done in the file:

`Pyro.ConsoleServer\App_Data\PyroApp.config`

Below is the documentation about this property:

Command: ServiceBaseURL

Value: URL String

Description: This setting sets the service's Service Base URL and must match the URL where the service is hosted. This is the URL that will host the FHIR API. Care must be taken changing this URL post the service being in operation as the physical Resources and the search indexes in the database, and any external references with still have the previous URL reference. In practice, all Resource would need to be updated and recommitted if this was to change. 
Simply changing the setting here does not initiate the updating of all these references.

#Production Enviroment#

The `Pyro.WebApi` project will run the server in Internet Information Services (IIS). This is primarily used for when the server is deployed in a production IIS instance. It does not provide any webpage, only the FHIR API endpoints accessible and hosted in IIS. 

There is a separate independent Javascript React SPA website project named PyroWeb that provide a website landing page for the Pyro Server found here: [PyroWeb WebSite](https://github.com/angusmillar/PyroWeb).

Before you run the `Pyro.WebApi` project you will need to change the connection string for the Pyro.WebApi. This can be found in the file:

`Pyro.WebApi\App_Data\Connectons.config`

Just change the `ConnectionString` element to meet your database.
You will also need to set the `ServiceBaseURL` property in the file below (See the same documentation above in "Development Environment" for this property)

`Pyro.WebApi\App_Data\PyroApp.config`

Both projects `Pyro.WebApi` and `Pyro.ConsoleServer`, when first run will create a database at the given ConnectionString.
This will actually only occur when the first call is made to the FHIR API. So you can do a simple GET: http://yourdomain/fhir/Patient to trigger this to occur.
Be patient as this first call will be slow as it must create all the database tables and populate the seed data before the call will return, roughly 4 to 5 min on my machine. All subsequent calls will be much faster.

In general, you would only use `Pyro.Console` in your development environment and configure its connection strings and ServiceBaseURL to suit. You would then only configure the `Pyro.WebApi` connection strings and ServiceBaseURL to be for your production instance ready for deployment. 

_Logging_
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

This project is a windows service that can be installed and run to perform long-running, out-of-band, asynchronous tasks for the FHIR Pyro Server. There is no hard dependency for this service to be running to use the Pyro FHIR Server. When running it connects to the main Pyro FHIR server via SingnalR to receive notifications of tasks to perform. This is currently in development but in future will manage background task such as Subscription notifications and possibly long-running Patient merge operations.

This windows service uses the [TopShelf](http://topshelf-project.com/) framework and in as easy to install on the command line as follows: 

`C:\BackburnerService\Pyro.Backburner.exe install`  

See [TopShelf Command Documentation](https://topshelf.readthedocs.io/en/latest/overview/commandline.html) for more info.

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

**Very first startup and DB creation**

When you first start the service for the first time it will appear to be running very quickly as the console window will appear with the Pyro logo. You will then make your first HTTP query, such as `GET: [base]/Patient`. This first query will set off the database creation and seeding and will take some 4 minutes to run before the query returns successfully (OK 200). The server is now ready to run and all further queries will be fast.

**First FHIR query speed poor, later fast**

When the server is stopped and restarted the first query will be slow, roughly 1 to 2 minutes, but then all subsequent queries will be fast (200 - 300 ms). this is a common problem with Entity Framework (EF) as it loads the entire database model into memory on startup, once loaded it is fine. I need to do more work here to try and improve this first query speed. Such as https://msdn.microsoft.com/en-us/magazine/jj883952.aspx

**SMART on FHIR and Authentication**
I am slowly progressing to an Authentication system for the server with key elements beginning to fall in place to finally implement. I now have a SMART parser and FHIR compartments. Need to start work on the OAuth component possibly using Identity server: https://www.nuget.org/packages/IdentityServer4/

## Repo owner or admin ##

Angus Millar: angusbmillar@gmail.com