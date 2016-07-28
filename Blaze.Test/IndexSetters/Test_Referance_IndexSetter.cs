using System;
using NUnit.Framework;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;
using Moq;
using Blaze.Common.Interfaces.UriSupport;

namespace Blaze.Test.IndexSetters
{
  [TestFixture]
  class Test_Referance_IndexSetter
  {
    //[Test]
    //public void Test_FhirUri_Referance_IndexSetter_GoodFormat()
    //{
    //  //Arrange
    //  var FhirUri = new FhirUri();
    //  FhirUri.Value = "www.somewhere.net.au/thing/";

    //  ReferenceIndex Index = new ReferenceIndex();
    //  Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

    //  Mock<Blaze.Common.Interfaces.Repositories.IUnitOfWork> MockIUnitOfWork = new Mock<Blaze.Common.Interfaces.Repositories.IUnitOfWork>();
    //  Mock<Blaze.Common.Interfaces.Repositories.ICommonRepository> MockICommonRepository = new Mock<Blaze.Common.Interfaces.Repositories.ICommonRepository>();

    //  MockICommonRepository.Setup(x => x.g).Returns(MockICommonRepository.Object);

    //  MockIUnitOfWork.Setup(x => x.CommonRepository).Returns(MockICommonRepository.Object);



    //  DataModel.DatabaseModel.DatabaseContext Context = new DataModel.DatabaseModel.DatabaseContext();
    //  Blaze.DataModel.Repository.CommonRepository Repos = new DataModel.Repository.CommonRepository(Context);
      


    //  //Act
    //  Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object) as ReferenceIndex;

    //  //Assert
    //  Assert.AreEqual(Index., ValueLow);
    //}
  }
}
