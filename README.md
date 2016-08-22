# README #

## Blaze FHIR Server ##

This is a FHIR server under development. 


## Requirements ##

Visual Studio
SQL Server 2014 Management Studio Express 64 Bit

## Important parts ##
Blaze Code Generation build, The folowing T4 files inspect the FHIR API and build the database and code repositories
These would only need to be run to upgrade to a new FHIR API, i.e upgrade to STU4. 
The order of running is critical for the rows with astrixs i.e (7.* & 8.*). 
Aside to this the order below is the order normally followed:
 
1. Blaze.CodeGenerationSupport.DbEntityCodeGeneration._DbEntityModelGenerator.tt
2. Blaze.CodeGenerationSupport.DbEntityCodeGeneration._DbContextGenerator.tt
3. Blaze.CodeGenerationSupport.DbEntityCodeGeneration._DbContextConfigGenerator.tt
4. Blaze.CodeGenerationSupport.GenericCodeDataTypeEnums._GenericCodeDataTypeEnumsGenerator.tt
5. Blaze.CodeGenerationSupport.IndexSetterInterfaces._IndexSetterInterfaceGeneration.tt
6. Blaze.CodeGenerationSupport.RepositoryCodeGeneration._RepositoryGenerator.tt
7.* Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration._SearchParameterEnumGeneration.tt
8.* Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration._SearchParameterToDbInfoGeneration
9. Blaze.CodeGenerationSupport.UnitOfWorkCodeGeneration._UnitOfWorkGenerator.tt

## Repo owner or admin ##

Angus Millar