using System;
using NUnit.Framework;
using Blaze.DataModel.IndexSetter;
using Blaze.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;
using Moq;
using Blaze.Common.Interfaces.UriSupport;
using Blaze.Common.BusinessEntities.UriSupport;

namespace Blaze.Test.IndexSetters
{
  [TestFixture]
  class Test_Referance_IndexSetter
  {
    [Test]
    public void Test_FhirUri_Referance_IndexSetter_GoodFormat_MatchesServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrl = "http://somewhere.net.au/FhirApi/Patient";
      string ReferanceUrl = "http://somewhere.net.au/FhirApi/Encounter/10";
      IFhirUri ReferanceFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(new Uri(ReferanceUrl));

      var FhirUri = new FhirUri();
      FhirUri.Value = ReferanceUrl;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var RootUrl = new Uri(ServiceRootUrl);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(RootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var DtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      DtoRootUrlStore.Blaze_RootUrlStoreID = 1;
      DtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      DtoRootUrlStore.RootUrl = ServiceRootUrl;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(DtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      var RootUrlStore = new Blaze.DataModel.DatabaseModel.Blaze_RootUrlStore();
      RootUrlStore.Blaze_RootUrlStoreID = 0;
      RootUrlStore.IsServersPrimaryUrlRoot = false;
      RootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(RootUrlStore);

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.AreEqual(Index.Url_Blaze_RootUrlStoreID, 1);
      Assert.IsNull(Index.Url);
      Assert.IsNull(Index.VersionId);
      //Test GetAndOrAddBlaze_RootUrlStore not called because Reference url root matches server root url
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Never()));
    }

    [Test]
    public void Test_FhirUri_Referance_IndexSetter_GoodFormat_NoMatchOnServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "http://SomeWhereElse.net.au/FhirApi/Encounter/10";
      IFhirUri ReferanceFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(new Uri(ReferanceUrlString));

      var FhirUri = new FhirUri();
      FhirUri.Value = ReferanceUrlString;
      
      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Blaze_RootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Blaze.DataModel.DatabaseModel.Blaze_RootUrlStore();
      ReferanceRootUrlStore.Blaze_RootUrlStoreID = 0;
      ReferanceRootUrlStore.IsServersPrimaryUrlRoot = false;
      ReferanceRootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(ReferanceRootUrlStore);

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.IsNotNull(Index.Url);
      Assert.AreEqual(Index.Url.Blaze_RootUrlStoreID, 0);
      Assert.IsFalse(Index.Url.IsServersPrimaryUrlRoot);
      Assert.AreEqual(Index.Url.RootUrl, ReferanceFhirUri.ServiceRootUrlForComparison);      
      Assert.IsNull(Index.VersionId);
      Assert.IsNull(Index.Url_Blaze_RootUrlStoreID);
      //Test GetAndOrAddBlaze_RootUrlStore called once to add or get the Url from / to the db 
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Once));
    }

    [Test]
    public void Test_FhirUri_Referance_IndexSetter_GoodFormat_WithVersionId_NoMatchOnServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "http://SomeWhereElse.net.au/FhirApi/Encounter/10/_history/5";
      IFhirUri ReferanceFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(new Uri(ReferanceUrlString));

      var FhirUri = new FhirUri();
      FhirUri.Value = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Blaze_RootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Blaze.DataModel.DatabaseModel.Blaze_RootUrlStore();
      ReferanceRootUrlStore.Blaze_RootUrlStoreID = 0;
      ReferanceRootUrlStore.IsServersPrimaryUrlRoot = false;
      ReferanceRootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(ReferanceRootUrlStore);

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.IsNotNull(Index.Url);
      Assert.AreEqual(Index.Url.Blaze_RootUrlStoreID, 0);
      Assert.IsFalse(Index.Url.IsServersPrimaryUrlRoot);
      Assert.AreEqual(Index.Url.RootUrl, ReferanceFhirUri.ServiceRootUrlForComparison);
      Assert.AreEqual(Index.VersionId, "5");
      Assert.IsNull(Index.Url_Blaze_RootUrlStoreID);
      //Test GetAndOrAddBlaze_RootUrlStore called once to add or get the Url from / to the db 
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Once));
    }
  }
}
