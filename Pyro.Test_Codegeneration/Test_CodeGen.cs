using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Hl7.Fhir.Model;
using Pyro.CodeGenerationSupport.FhirApiIntrospection;

namespace Pyro.Test.CodeGenerationSupport
{
  [TestFixture]
  [Category("CodeGeneration")]
  class Test_CodeGen
  {
    [Test]
    public void Test_PyroModleInspector()
    {
      Pyro.CodeGenerationSupport.v2_ModelInspector.PryoModleInspector.Inspector();      
    }

    [Test]
    public void Test_GetApiSearchParameterInfo()
    {

      Pyro.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate DatabaseModel = new Pyro.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate();
      DatabaseModel.Generate();
    }


    [Test]
    public void Test_DbEntityCodeGeneration()
    {
      Pyro.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate DatabaseModel = new Pyro.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate();
      List<Pyro.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDbTableModel> ModelList = DatabaseModel.Generate();
    }

    [Test]
    public void Test_RepositoryCodeGeneration()
    {
      var ReposGen = new Pyro.CodeGenerationSupport.RepositoryCodeGeneration.RepositoryCodeGeneration();
      ReposGen.Generate();
    }

    [Test]
    public void Test_GenericCodeDataTypeEnumsCodeGeneration()
    {
      Pyro.CodeGenerationSupport.GenericCodeDataTypeEnums.GenericCodeDataTypeCodeGen oCreate = new Pyro.CodeGenerationSupport.GenericCodeDataTypeEnums.GenericCodeDataTypeCodeGen();
      List<string> List = oCreate.Generate();

      foreach (var item in List)
      {

        Assert.IsTrue(item != string.Empty);
      }
    }

    [Test]
    public void Test_IndexSetterInterfaceCodeGeneration()
    {
      var IndexSetterInterfaceGen = new Pyro.CodeGenerationSupport.IndexSetterInterfaces.IndexSetterInterfaceCodeGeneration();
      var List = IndexSetterInterfaceGen.Generate();
    }


    [Test]
    public void Test_SearchParamEnumInfoCodeGeneration()
    {
      var SearchParamEnumInfoCodeGeneration = new Pyro.CodeGenerationSupport.SearchParameterInfoCodeGeneration.SearchParamEnumCodeGeneration();
      SearchParamEnumInfoCodeGeneration.Generate();
    }

    [Test]
    public void Test_SearchParameterToDbInfoGeneration()
    {
      var SearchParameterToDbInfoGeneration = new Pyro.CodeGenerationSupport.SearchParameterInfoCodeGeneration.SearchParameterToDbInfoGeneration();
      SearchParameterToDbInfoGeneration.Generate();
      var test = SearchParameterToDbInfoGeneration.ResourceSearchParamInfoList;
    }
  }
}
