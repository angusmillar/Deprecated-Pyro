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
  class Test_FhirApiSearchParameterInfoFactory
  {
    
    [Test]
    public void Test_GetApiSearchParameterInfo()
    {

      Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate oCreate = new Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate();
      List<Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDbTableModel> ModelList = oCreate.CodeGenerationDbTableModelList;
    }

    [Test]
    public void Test_RepositoryCodeGeneration()
    {
      var ReposGen = new Blaze.CodeGenerationSupport.RepositoryCodeGeneration.RepositoryCodeGeneration();
      ReposGen.Generate();
    }

    [Test]
    public void Test_ConstructClassTypeStatment_Items_Are_Not_Empty()
    {
      Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate oCreate = new Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDatabaseModelCreate();
      List<Blaze.CodeGenerationSupport.DbEntityCodeGeneration.CodeGenerationDbTableModel> ModelList = oCreate.CodeGenerationDbTableModelList;
      foreach (var item in ModelList)
      {
        Assert.IsTrue(!String.IsNullOrWhiteSpace(item.TableClassModel.ConstructClassTypeStatment()));
      }
    }



  }
}
