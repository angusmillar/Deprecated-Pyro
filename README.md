# README #

## Pyro FHIR Server ##

This is a FHIR server under development. 


## Requirements ##

Visual Studio
SQL Server 2014 Management Studio Express 64 Bit

## Important parts ##
Pyro Code Generation build, The folowing T4 files inspect the FHIR API and build the database and code repositories
These would only need to be run to upgrade to a new FHIR API, i.e upgrade to STU4. 
The order of running is critical for the rows with astrixs i.e (7.* & 8.*). 
Aside to this the order below is the order normally followed, you will also need to recompile the 'Pyro.CodeGenerationSupport' 
project after each is run as the T4 Template engine appear to lock the FHIR API dll on each run, recompile appears to unlock this dll:
 
1. Pyro.CodeGenerationSupport.DbEntityCodeGeneration._DbEntityModelGenerator.tt
2. Pyro.CodeGenerationSupport.DbEntityCodeGeneration._DbContextGenerator.tt
3. Pyro.CodeGenerationSupport.DbEntityCodeGeneration._DbContextConfigGenerator.tt
4. Pyro.CodeGenerationSupport.GenericCodeDataTypeEnums._GenericCodeDataTypeEnumsGenerator.tt
5. Pyro.CodeGenerationSupport.IndexSetterInterfaces._IndexSetterInterfaceGeneration.tt
6. Pyro.CodeGenerationSupport.RepositoryCodeGeneration._RepositoryGenerator.tt
7.* Pyro.CodeGenerationSupport.SearchParameterInfoCodeGeneration._SearchParameterEnumGeneration.tt
8.* Pyro.CodeGenerationSupport.SearchParameterInfoCodeGeneration._SearchParameterToDbInfoGeneration
9. Pyro.CodeGenerationSupport.UnitOfWorkCodeGeneration._UnitOfWorkGenerator.tt

## Repo owner or admin ##

Angus Millar