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

      Blaze.CodeGenerationSupport.CodeGenerationDatabaseModelCreate oCreate = new Blaze.CodeGenerationSupport.CodeGenerationDatabaseModelCreate();
      List<Blaze.CodeGenerationSupport.CodeGenerationDbTableModel> ModelList = oCreate.CodeGenerationDbTableModelList;

      //List<FhirApiSearchParameterInfo> oSearchParameterList = FhirApiSearchParameterInfoFactory.GetApiSearchParameterInfo();
    }

  }
}
