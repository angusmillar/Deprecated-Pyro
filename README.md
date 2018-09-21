
![][logo]

[logo]: https://github.com/angusmillar/PyroWeb/blob/master/src/Images/SiteIcon/NewPyroIconLong-200.png "Pyro Server Logo"


This is a C# .NET Framework 4.6, MSSQL or PostgreSQL, FHIR server implementing FHIR Version STU-3.0.1 

See the publicly accessible Pyro Server instance running here: [Pyrohealth.net](https://pyrohealth.net/)

See the official FHIR specification page here: [FHIR specification STU-3.0.1](http://hl7.org/fhir/STU3/index.html)


>Read the servers rendered CapabilityStatement here: [Pyro FHIR Server CapabilityStatement](https://pyrohealth.net/metadata-content)
>
> HTTP Get the server's CapabilityStatement resource from the Pyrohealth.net server: 
>
>`GET https://stu3.test.pyrohealth.net/fhir/metadata`


**This server implements the following FHIR specification components** 

* All resource types
* All resource's search parameters
* RestFul CRUD
* Compartments 
* Chained search parameters
* \_includes & \_revinclude
* Custom search parameters
* Custom compartments
* History
* Conditional Create
* Conditional Update 
* Conditional Read 
* Conditional Delete  
* Bundle Transactions

Base operations:
* $server-indexes-set      
* $server-indexes-index      
* $server-indexes-report      
* $server-resource-report   

Resource operations:
* $validate (All ResourceTypes)
* $x-ihisearchorvalidate (Patient ResourceTypes)

Resource instance operations:
* $validate (All ResourceTypes)
* $x-set-compartment-active (CompartmentDefinition ResourceTypes)
* $x-set-compartment-inactive (CompartmentDefinition ResourceTypes)


## Development requirements ##

* Visual Studio 2017
* .NET Framework 4.6  
* Microsoft SQL Server 2016 or higher, or
* PostgreSQL (Version 10)

## Get the solution up and running fast ##

1. Clone from the GitHub repository: https://github.com/angusmillar/Pyro.git and then open in Visual Studio 2017.
2. Right click the main solution 'Pyro' and select 'Restore Nuget packages' and then 'F6' to build the solution.
3. You will then need to configure to your development environment database connection string by editing this file: `Pyro.ConsoleServer\App_Data\Connectons.config`
4. Right click the project named 'Pyro.DbManager' and select 'Set as StartUp Project'
5. Hit 'F5' to start the 'Pyro.DbManager' console application project and follow the prompts to create the initial database.
6. Right click the project named 'Pyro.ConsoleServer' and select 'Set as StartUp Project'
7. Hit 'F5' to start the 'Pyro.ConsoleServer' project.
8. A console window will start with the Pyro logo in yellow and the message "Please wait while database schema loads", this will take about 1 min.     
9. Once the load is completed the console will change from yellow to blue and the server is ready for calls to its FHRI API. The console will state the FHIR API endpoint. The default is `http://localhost:8888/fhir` 

**Please note**

On a clean install, the server runs a background task that loads all the FHIR specification SearchParameter resources to create the active search indexes for the server. While this is running the server is in read-only mode until it completes. This is required to prevent resources from being committed through the API before the resource indexes are ready. You can monitor the task's progress by either attempting to perform a POST or PUT or by performing a GET on the FHIR Task resource with the Id of: **set-searchParameter-definitions**. The server can be stopped and started while this task is running and it will continue from where it last left off.

## Understanding the solution a little deeper ##

There are three key projects you will need to understand:

| Concept                  | Solution Project      |
| :----------------------- |:----------------------|
| Database Management      | `Pyro.DbManager`      |
| Development Environment  | `Pyro.ConsoleServer`  |
| Production Environment   | `Pyro.WebApi`         |


**Database Management**

The `Pyro.DbManager` project is a console application that will connect to the database and create or upgrade the database as required. This project MUST be run first as it will create the database which the other projects depend upon. 

When running in the debugger (Visual Studio) it uses the connection string found in the `Pyro.ConsoleServer` project file found here: `Pyro.ConsoleServer\App_Data\Connectons.config`. You must configure you database connection string in this file before running the `Pyro.DbManager` project.

When running outside of the debugger the `Pyro.DbManager` executable expects to find a web.config file in the parent directory from where it is run, it will use the connection string referenced from this `web.config` file which will be the `Connectons.config` file found in the `App_Data` directory of the same parent directory. This is true when deployed in IIS where the `Pyro.DbManager.exe` is found in the `bin` folder. So in this case, you just need to run the `Pyro.DbManager.exe` straight from the `bin` folder to create or update the production database.

_**Here is a representation of this production IIS file structure**_



```
wwwRoot
│   web.config
│   ...    
│
└───App_Data
│   │   
│   │   Connectons.config
│   │   PyroApp.config
│   │   ...
│   
└───bin
    │   Pyro.DbManager.exe
    │   ....
```


**Development Environment**

The `Pyro.ConsoleServer` project will run the server in console mode and is the primary way to use the server if in a development environment. It's quicker to start and logs on screen the HTTP request coming in. The FHIR server is fully functional run this way.
Before you run this project you will need to have configured the connection string as shown below and you must have first run the `Pyro.DbManager` project which will have initialised your database. 

`Pyro.ConsoleServer\App_Data\Connectons.config`

You may also like to change the `ServiceBaseURL` property which is the endpoint the FHIR server will run from. The default is `http://localhost:8888/fhir` This can be changed in the file:

`Pyro.ConsoleServer\App_Data\PyroApp.config`

Below is the documentation about the property:

| ***Item***        | ***Value***  |
| :------------- |:-------------|
|**Command:**| ServiceBaseURL|
| **Value:**| URL String|
| **Description:**   | This setting sets the service's Service Base URL and must match the URL where the service is hosted. This is the URL that will host the FHIR API. Care must be taken changing this URL post the service being in operation as the physical Resources and the search indexes in the database, and any external references with still have the previous URL reference. In practice, all Resource would need to be updated and recommitted if this was to change. Simply changing the setting here does not initiate the updating of all these references.        |

**Production Environment**

The `Pyro.WebApi` project will run the server in Internet Information Services (IIS). This is primarily used for when the server is deployed in a production IIS instance. It does not provide any web page, only the FHIR API endpoints accessible and hosted in IIS. 

There is a separate independent JavaScript React SPA website project named PyroWeb that provide a website landing page for the Pyro Server found here: [PyroWeb WebSite](https://github.com/angusmillar/PyroWeb).

Before you run this project you will need to have configured the connection string as shown below and you must have first run the `Pyro.DbManager` project which will have initialised your database. 

`Pyro.WebApi\App_Data\Connectons.config`

You will also need to set the `ServiceBaseURL` property in the file below (See the same documentation above in "Development Environment" for this property)

`Pyro.WebApi\App_Data\PyroApp.config`

**General Information**

***Database Migration Check***

Both projects `Pyro.WebApi` and `Pyro.ConsoleServer`, require that you first run the `Pyro.DbManager` to initialise the database. Furthermore, if the code is updated and a database upgrade is required the `Pyro.DbManager` must be run. In general you should always run the `Pyro.DbManager` when a code update is sourced. Their is never any harm in running it many times. If you do not do run it when it is required to be run, starting either `Pyro.WebApi` or `Pyro.ConsoleServer` will throw and log an error, and stop. That error will read:
```
Database upgrade is required.
Please consider running the Pyro.DbManager to upgrade your database.
The application must now exit
```

***Development vs production enviroment setup***

In general, you would only use `Pyro.ConsoleServer` in your development environment and configure its connection strings and ServiceBaseURL to suit. You would then only configure the `Pyro.WebApi` connection strings and ServiceBaseURL to be for your production instance ready for deployment. 

***Logging***

The solution uses the [NLog](http://nlog-project.org/) logging framework. By default, this is configured to log to the console and to AWS Cloudwatch logs for the `Pyro.WebApi` project and for the `Pyro.ConsoleServer` project it is configured to log to the console and to a system file located at `C:\PyroLogs'.
You may wish to reconfigure this for your needs.

The logging configuration lives in the following files and the [NLog Configuration Documentation](https://github.com/nlog/NLog/wiki/Configuration-file) is found at this link.

*NLog logging config file locations:*

`Pyro.WebApi\NLog.config`

`Pyro.ConsoleServer\NLog.config`


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

The only configuration this project requires is the database connection string for the Pyro FHIR server configured here: `Pyro.Backburner\App_Data\Connections.config`


**Pyro.CodeGeneration (Project)**

Please note: You don't need to do the following to get the server running, this is only for future development purposes when a new FHIR release is available'

This project holds the code generation logic used to generate new classes for when a new version of the FHIR specification is released i.e update from STU3 to R4. It interrogates the FHIR .NET API to get the source specification information.

When a new version of the FHIR is released (e.g STU3 to STU4) and the external fhir-net-api package updated and loaded (use NuGet package manager) you can then run the T4 template located in this project at `Pyro.CodeGeneration.Template.MainTemplate.tt`. 

This will update the key classes in the `Pyro.DataLayer` & `Pyro.Common` projects to adapt to
the new fhir-net-api and FHIR release bringing in any new FHIR resources and base standard search 
parameters.

Before running the T4 template `MainTemplate.tt` you will need to manually update the static assembly references within this file to point to the new packages as updated by Nuget package manager. 
Below are examples of the four references discussed: 

```
<#@ Assembly Name="$(SolutionDir)packages\Newtonsoft.Json.9.0.1\lib\net45\Newtonsoft.Json.dll"#>
<#@ Assembly Name="$(SolutionDir)packages\Hl7.Fhir.STU3.0.93.3\lib\net45\Hl7.Fhir.STU3.Core.dll"#>
<#@ Assembly Name="$(SolutionDir)packages\Hl7.Fhir.Support.0.4.2\lib\net45\Hl7.Fhir.Support.dll"#>
<#@ Assembly Name="$(SolutionDir)packages\Hl7.FhirPath.0.4.2\lib\net45\Hl7.FhirPath.dll"#>
```

Once these are updated first build the project `Pyro.CodeGeneration` in debug and then right-click the 
`MainTemplate.tt` file and select 'Run Custom Tool'. This will generate the code classes as discussed.
You may need to delete all contents in the sub T4 file `MainTemplate.cs` if you receive a compile error. 

Note that no database upgrades have been implemented for this type of modification so post this process you will need to delete the database which will be recreated as the first call is made to the FHIR endpoint.

**Pyro.Common (Project)**

This project holds all common cross-cutting code used by the entire solution.

**Pyro.ConsoleServer (Project)**

This project allows the server to be started up in a console window and is the primary way to run the server in a development environment.
This is the project to set as start-up when running in Visual Studio.

**Pyro.DataLayer (Project)**

This is the data layer project which handles all database access

**Pyro.DbManager (Project)**

This is a console application that manages the Pyro server database initialisation and migrations/upgrades. You must run this before running either the `Pyro.ConsoleServer` or the `Pyro.WebApi` and it should be run after any code updates to apply any database changes that may be required.  It is safe to run at any time and multiple times as it tracks what it has done within the database table `__SchemaVersions`. 

When run, it will first list the SQL scripts that it has detected as required to be run. It will then ask whether you would like these SQL scripts written to a folder for your own inspection or review. It will warn you to back up your database and then finally will ask: "Do you wish to perform the upgrade against the database?"  

If you answer No it will abort if you answer Yes the scripts will be executed against the database. It will eventually finish with the word "Success!" in green, or a red "Failed!" and some error messages.

If you wished to automate this task you can provide the switch parameter '-UnattendedMode True' to the launch and it will run without requiring any user interactions, it will just attempt to run the scripts against the database and nothing else.

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

**FHIR Release 4 (R4)** A FHIR R4 version of the Pyro Server is in development and should be be ready soon, see the GitHub repository branch `develop-r4`. 

## Repo owner ##

Angus Millar: angusbmillar@gmail.com
