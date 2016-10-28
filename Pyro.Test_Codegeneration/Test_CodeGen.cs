using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Hl7.Fhir.Model;
using Blaze.CodeGenerationSupport.FhirApiIntrospection;

namespace Blaze.Test.CodeGenerationSupport
{
  [TestFixture]
  class Test_CodeGen
  {

    [Test]
    public void Test_GetApiSearchParameterInfo()
    {

      Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate DatabaseModel = new Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate();
      DatabaseModel.Generate();
    }


    [Test]
    public void Test_DbEntityCodeGeneration()
    {
      Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate DatabaseModel = new Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate();
      List<Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDbTableModel> ModelList = DatabaseModel.Generate();
    }

    [Test]
    public void Test_RepositoryCodeGeneration()
    {
      var ReposGen = new Blaze.CodeGenerationSupport.RepositoryCodeGeneration.RepositoryCodeGeneration();
      ReposGen.Generate();
    }

    [Test]
    public void Test_GenericCodeDataTypeEnumsCodeGeneration()
    {
      Blaze.CodeGenerationSupport.GenericCodeDataTypeEnums.GenericCodeDataTypeCodeGen oCreate = new Blaze.CodeGenerationSupport.GenericCodeDataTypeEnums.GenericCodeDataTypeCodeGen();
      List<string> List = oCreate.Generate();

      foreach (var item in List)
      {

        Assert.IsTrue(item != string.Empty);
      }
    }

    [Test]
    public void Test_IndexSetterInterfaceCodeGeneration()
    {
      var IndexSetterInterfaceGen = new Blaze.CodeGenerationSupport.IndexSetterInterfaces.IndexSetterInterfaceCodeGeneration();
      var List = IndexSetterInterfaceGen.Generate();
    }


    [Test]
    public void Test_SearchParamEnumInfoCodeGeneration()
    {
      var SearchParamEnumInfoCodeGeneration = new Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration.SearchParamEnumCodeGeneration();
      SearchParamEnumInfoCodeGeneration.Generate();
    }

    [Test]
    public void Test_SearchParameterToDbInfoGeneration()
    {
      var SearchParameterToDbInfoGeneration = new Blaze.CodeGenerationSupport.SearchParameterInfoCodeGeneration.SearchParameterToDbInfoGeneration();
      SearchParameterToDbInfoGeneration.Generate();
      var test = SearchParameterToDbInfoGeneration.ResourceSearchParamInfoList;
    }
  }
}
