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
      DtoRootUrlStore.ServiceRootUrlStoreID = 1;
      DtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      DtoRootUrlStore.RootUrl = ServiceRootUrl;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(DtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      var RootUrlStore = new Blaze.DataModel.DatabaseModel.ServiceRootURL_Store();
      RootUrlStore.ServiceRootURL_StoreID = 0;
      RootUrlStore.IsServersPrimaryUrlRoot = false;
      RootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(RootUrlStore);

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.AreEqual(Index.ServiceRootURL_StoreID, 1);
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
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Blaze.DataModel.DatabaseModel.ServiceRootURL_Store();
      ReferanceRootUrlStore.ServiceRootURL_StoreID = 0;
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
      Assert.AreEqual(Index.Url.ServiceRootURL_StoreID, 0);
      Assert.IsFalse(Index.Url.IsServersPrimaryUrlRoot);
      Assert.AreEqual(Index.Url.RootUrl, ReferanceFhirUri.ServiceRootUrlForComparison);
      Assert.IsNull(Index.VersionId);
      Assert.IsNull(Index.ServiceRootURL_StoreID);
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
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Blaze.DataModel.DatabaseModel.ServiceRootURL_Store();
      ReferanceRootUrlStore.ServiceRootURL_StoreID = 0;
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
      Assert.AreEqual(Index.Url.ServiceRootURL_StoreID, 0);
      Assert.IsFalse(Index.Url.IsServersPrimaryUrlRoot);
      Assert.AreEqual(Index.Url.RootUrl, ReferanceFhirUri.ServiceRootUrlForComparison);
      Assert.AreEqual(Index.VersionId, "5");
      Assert.IsNull(Index.ServiceRootURL_StoreID);
      //Test GetAndOrAddBlaze_RootUrlStore called once to add or get the Url from / to the db 
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Once));
    }

    [Test]
    public void Test_FhirUri_Referance_IndexSetter_Uri_Is_Not_A_Fhir_Referance_Uri()
    {
      //Info: This is a Uri that is not a Fhir resource reference, it is actually a GUID expressed as a Uri.
      //In this case as it is not a FhirUriReferance we want to return null as it is not searchable as a 
      //Search parameter type of Reference. 
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "urn:uuid:53fefa32-fcbb-4ff8-8a92-55ee120877b7";

      var FhirUri = new FhirUri();
      FhirUri.Value = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.IsNull(Index);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceUrlString), Times.Never));
    }

    [Test]
    public void Test_FhirUri_Referance_IndexSetter_Uri_Is_RelativeUri()
    {
      //Info: This is a Uri that is not a Fhir resource reference, it is actually a GUID expressed as a Uri.
      //In this case as it is not a FhirUriReferance we want to return null as it is not searchable as a 
      //Search parameter type of Reference. 
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "Encounter/10";
      IFhirUri ReferanceFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ReferanceUrlString);

      var FhirUri = new FhirUri();

      FhirUri.Value = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.IsNull(Index.Url);
      Assert.IsNull(Index.VersionId);
      Assert.AreEqual(Index.ServiceRootURL_StoreID, 1);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Never));
    }

    [Test]
    public void Test_FhirUri_Referance_IndexSetter_Uri_Is_Rubbish()
    {
      //Info: This is a Uri that is not a Fhir resource reference, it is actually a GUID expressed as a Uri.
      //In this case as it is not a FhirUriReferance we want to return null as it is not searchable as a 
      //Search parameter type of Reference. 
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "????";

      var FhirUri = new FhirUri();

      FhirUri.Value = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.IsNull(Index);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceUrlString), Times.Never));
    }


    [Test]
    public void Test_ResourceReference_Referance_IndexSetter_GoodFormat_MatchesServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrl = "http://somewhere.net.au/FhirApi/Patient";
      string ReferanceUrl = "http://somewhere.net.au/FhirApi/Encounter/10";
      IFhirUri ReferanceFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(new Uri(ReferanceUrl));

      var ResourceReference = new ResourceReference();
      ResourceReference.Reference = ReferanceUrl;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var RootUrl = new Uri(ServiceRootUrl);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(RootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var DtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      DtoRootUrlStore.ServiceRootUrlStoreID = 1;
      DtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      DtoRootUrlStore.RootUrl = ServiceRootUrl;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(DtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      var RootUrlStore = new Blaze.DataModel.DatabaseModel.ServiceRootURL_Store();
      RootUrlStore.ServiceRootURL_StoreID = 0;
      RootUrlStore.IsServersPrimaryUrlRoot = false;
      RootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(RootUrlStore);

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.AreEqual(Index.ServiceRootURL_StoreID, 1);
      Assert.IsNull(Index.Url);
      Assert.IsNull(Index.VersionId);
      //Test GetAndOrAddBlaze_RootUrlStore not called because Reference url root matches server root url
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Never()));
    }

    [Test]
    public void Test_ResourceReference_Referance_IndexSetter_GoodFormat_NoMatchOnServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "http://SomeWhereElse.net.au/FhirApi/Encounter/10";
      IFhirUri ReferanceFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(new Uri(ReferanceUrlString));

      var ResourceReference = new ResourceReference();
      ResourceReference.Reference = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Blaze.DataModel.DatabaseModel.ServiceRootURL_Store();
      ReferanceRootUrlStore.ServiceRootURL_StoreID = 0;
      ReferanceRootUrlStore.IsServersPrimaryUrlRoot = false;
      ReferanceRootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(ReferanceRootUrlStore);

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.IsNotNull(Index.Url);
      Assert.AreEqual(Index.Url.ServiceRootURL_StoreID, 0);
      Assert.IsFalse(Index.Url.IsServersPrimaryUrlRoot);
      Assert.AreEqual(Index.Url.RootUrl, ReferanceFhirUri.ServiceRootUrlForComparison);
      Assert.IsNull(Index.VersionId);
      Assert.IsNull(Index.ServiceRootURL_StoreID);
      //Test GetAndOrAddBlaze_RootUrlStore called once to add or get the Url from / to the db 
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Once));
    }

    [Test]
    public void Test_ResourceReference_Referance_IndexSetter_GoodFormat_WithVersionId_NoMatchOnServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "http://SomeWhereElse.net.au/FhirApi/Encounter/10/_history/5";
      IFhirUri ReferanceFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(new Uri(ReferanceUrlString));

      var ResourceReference = new ResourceReference();
      ResourceReference.Reference = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Blaze.DataModel.DatabaseModel.ServiceRootURL_Store();
      ReferanceRootUrlStore.ServiceRootURL_StoreID = 0;
      ReferanceRootUrlStore.IsServersPrimaryUrlRoot = false;
      ReferanceRootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(ReferanceRootUrlStore);

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.IsNotNull(Index.Url);
      Assert.AreEqual(Index.Url.ServiceRootURL_StoreID, 0);
      Assert.IsFalse(Index.Url.IsServersPrimaryUrlRoot);
      Assert.AreEqual(Index.Url.RootUrl, ReferanceFhirUri.ServiceRootUrlForComparison);
      Assert.AreEqual(Index.VersionId, "5");
      Assert.IsNull(Index.ServiceRootURL_StoreID);
      //Test GetAndOrAddBlaze_RootUrlStore called once to add or get the Url from / to the db 
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Once));
    }

    [Test]
    public void Test_ResourceReference_Referance_IndexSetter_Uri_Is_Not_A_Fhir_Referance_Uri()
    {
      //Info: This is a Uri that is not a Fhir resource reference, it is actually a GUID expressed as a Uri.
      //In this case as it is not a FhirUriReferance we want to return null as it is not searchable as a 
      //Search parameter type of Reference. 
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "urn:uuid:53fefa32-fcbb-4ff8-8a92-55ee120877b7";

      var ResourceReference = new ResourceReference();
      ResourceReference.Reference = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.IsNull(Index);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceUrlString), Times.Never));
    }

    [Test]
    public void Test_ResourceReference_Referance_IndexSetter_Uri_Is_RelativeUri()
    {
      //Info: This is a Uri that is not a Fhir resource reference, it is actually a GUID expressed as a Uri.
      //In this case as it is not a FhirUriReferance we want to return null as it is not searchable as a 
      //Search parameter type of Reference. 
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "Encounter/10";
      IFhirUri ReferanceFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ReferanceUrlString);

      var ResourceReference = new ResourceReference();

      ResourceReference.Reference = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.IsNull(Index.Url);
      Assert.IsNull(Index.VersionId);
      Assert.AreEqual(Index.ServiceRootURL_StoreID, 1);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Never));
    }

    [Test]
    public void Test_ResourceReference_Referance_IndexSetter_Uri_Is_Rubbish()
    {
      //Info: This is a Uri that is not a Fhir resource reference, it is actually a GUID expressed as a Uri.
      //In this case as it is not a FhirUriReferance we want to return null as it is not searchable as a 
      //Search parameter type of Reference. 
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "????";

      var ResourceReference = new ResourceReference();

      ResourceReference.Reference = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = new Blaze.Common.BusinessEntities.UriSupport.DtoFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Blaze.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.ServiceRootUrlStoreID = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.RootUrl = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Blaze.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.IsNull(Index);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddBlaze_RootUrlStore(ReferanceUrlString), Times.Never));
    }

  }
}
