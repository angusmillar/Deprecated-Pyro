# README #

## Blaze FHIR Server ##

This is a FHIR server under development. 


## Requirements ##

Visual Studio
SQL Server 2014 Management Studio Express 64 Bit

## Important parts ##
Blaze Code Generation build, The folowing T4 files inspect the FHIR API and build the database and code repositories
These woudl only need to be run to upgrade to a new FHIR API, i.e STU4. The order of running is not critical but this is the order normally followed: 
1. Blaze.CodeGenerationSupport.DbEntityCodeGeneration._DbEntityModelGenerator.tt
2. Blaze.CodeGenerationSupport.DbEntityCodeGeneration._DbContextGenerator.tt
3. Blaze.CodeGenerationSupport.DbEntityCodeGeneration._DbContextConfigGenerator.tt
4. Blaze.CodeGenerationSupport.GenericCodeDataTypeEnums._GenericCodeDataTypeEnumsGenerator.tt
5. Blaze.CodeGenerationSupport.IndexSetterInterfaces._IndexSetterInterfaceGeneration.tt
6. Blaze.CodeGenerationSupport.RepositoryCodeGeneration._RepositoryGenerator.tt
7. Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration.SearchParameterEnumGeneration.tt
8. Blaze.CodeGenerationSupport.UnitOfWorkCodeGeneration._UnitOfWorkGenerator.tt

## Repo owner or admin ##

Angus Millar