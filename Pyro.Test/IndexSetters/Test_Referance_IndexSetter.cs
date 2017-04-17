using System;
using NUnit.Framework;
using Pyro.DataModel.IndexSetter;
using Pyro.DataModel.DatabaseModel.Base;
using Hl7.Fhir.Model;
using NUnit.Framework.Constraints;
using Moq;
using Pyro.Common.Interfaces.UriSupport;
using Pyro.Common.BusinessEntities.UriSupport;

namespace Pyro.Test.IndexSetters
{
  [TestFixture]
  [Category("IndexSetters")]
  class Test_Referance_IndexSetter
  {
    [Test]
    public void Test_FhirUri_Referance_IndexSetter_GoodFormat_MatchesServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrl = "http://somewhere.net.au/FhirApi/Patient";
      string ReferanceUrl = "http://somewhere.net.au/FhirApi/Encounter/10";
      IFhirUri ReferanceFhirUri = Pyro.Common.CommonFactory.GetFhirUri(new Uri(ReferanceUrl));


      var FhirUri = new FhirUri();
      FhirUri.Value = ReferanceUrl;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var RootUrl = new Uri(ServiceRootUrl);
      IFhirUri RequestFhirUri = Pyro.Common.CommonFactory.GetFhirUri(RootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var DtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      DtoRootUrlStore.Id = 1;
      DtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      DtoRootUrlStore.Url = ServiceRootUrl;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(DtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      var RootUrlStore = new Pyro.DataModel.DatabaseModel.ServiceRootURL_Store();
      RootUrlStore.ServiceRootURL_StoreID = 0;
      RootUrlStore.IsServersPrimaryUrlRoot = false;
      RootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(RootUrlStore);

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.AreEqual(Index.ServiceRootURL_StoreID, 1);
      Assert.IsNull(Index.Url);
      Assert.IsNull(Index.VersionId);
      //Test GetAndOrAddPyro_RootUrlStore not called because Reference url root matches server root url
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Never()));
    }

    [Test]
    public void Test_FhirUri_Referance_IndexSetter_GoodFormat_NoMatchOnServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "http://SomeWhereElse.net.au/FhirApi/Encounter/10";
      IFhirUri ReferanceFhirUri = Pyro.Common.CommonFactory.GetFhirUri(new Uri(ReferanceUrlString));

      var FhirUri = new FhirUri();
      FhirUri.Value = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = Pyro.Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Pyro.DataModel.DatabaseModel.ServiceRootURL_Store();
      ReferanceRootUrlStore.ServiceRootURL_StoreID = 0;
      ReferanceRootUrlStore.IsServersPrimaryUrlRoot = false;
      ReferanceRootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(ReferanceRootUrlStore);

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
      //Test GetAndOrAddPyro_RootUrlStore called once to add or get the Url from / to the db 
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Once));
    }

    [Test]
    public void Test_FhirUri_Referance_IndexSetter_GoodFormat_WithVersionId_NoMatchOnServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "http://SomeWhereElse.net.au/FhirApi/Encounter/10/_history/5";
      IFhirUri ReferanceFhirUri = Pyro.Common.CommonFactory.GetFhirUri(new Uri(ReferanceUrlString));

      var FhirUri = new FhirUri();
      FhirUri.Value = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = Pyro.Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Pyro.DataModel.DatabaseModel.ServiceRootURL_Store();
      ReferanceRootUrlStore.ServiceRootURL_StoreID = 0;
      ReferanceRootUrlStore.IsServersPrimaryUrlRoot = false;
      ReferanceRootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(ReferanceRootUrlStore);

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
      //Test GetAndOrAddPyro_RootUrlStore called once to add or get the Url from / to the db 
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Once));
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
      IFhirUri RequestFhirUri = Pyro.Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.IsNull(Index);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceUrlString), Times.Never));
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
      IFhirUri ReferanceFhirUri = Common.CommonFactory.GetFhirUri(ReferanceUrlString);
      //IFhirUri ReferanceFhirUri = new Pyro.Common.BusinessEntities.UriSupport.DtoFhirUri(ReferanceUrlString);

      FhirUri FhirUri = new FhirUri();
      FhirUri.Value = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = Pyro.Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.IsNull(Index.Url);
      Assert.IsNull(Index.VersionId);
      Assert.AreEqual(Index.ServiceRootURL_StoreID, 1);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Never));
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
      IFhirUri RequestFhirUri = Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(FhirUri, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.IsNull(Index);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceUrlString), Times.Never));
    }


    [Test]
    public void Test_ResourceReference_Referance_IndexSetter_GoodFormat_MatchesServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrl = "http://somewhere.net.au/FhirApi/Patient";
      string ReferanceUrl = "http://somewhere.net.au/FhirApi/Encounter/10";
      IFhirUri ReferanceFhirUri = Common.CommonFactory.GetFhirUri(new Uri(ReferanceUrl));

      var ResourceReference = new ResourceReference();
      ResourceReference.Reference = ReferanceUrl;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var RootUrl = new Uri(ServiceRootUrl);
      IFhirUri RequestFhirUri = Common.CommonFactory.GetFhirUri(RootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var DtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      DtoRootUrlStore.Id = 1;
      DtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      DtoRootUrlStore.Url = ServiceRootUrl;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(DtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      var RootUrlStore = new Pyro.DataModel.DatabaseModel.ServiceRootURL_Store();
      RootUrlStore.ServiceRootURL_StoreID = 0;
      RootUrlStore.IsServersPrimaryUrlRoot = false;
      RootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(RootUrlStore);

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.AreEqual(Index.ServiceRootURL_StoreID, 1);
      Assert.IsNull(Index.Url);
      Assert.IsNull(Index.VersionId);
      //Test GetAndOrAddPyro_RootUrlStore not called because Reference url root matches server root url
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Never()));
    }

    [Test]
    public void Test_ResourceReference_Referance_IndexSetter_GoodFormat_NoMatchOnServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "http://SomeWhereElse.net.au/FhirApi/Encounter/10";
      IFhirUri ReferanceFhirUri = Common.CommonFactory.GetFhirUri(new Uri(ReferanceUrlString));

      var ResourceReference = new ResourceReference();
      ResourceReference.Reference = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Pyro.DataModel.DatabaseModel.ServiceRootURL_Store();
      ReferanceRootUrlStore.ServiceRootURL_StoreID = 0;
      ReferanceRootUrlStore.IsServersPrimaryUrlRoot = false;
      ReferanceRootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(ReferanceRootUrlStore);

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
      //Test GetAndOrAddPyro_RootUrlStore called once to add or get the Url from / to the db 
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Once));
    }

    [Test]
    public void Test_ResourceReference_Referance_IndexSetter_GoodFormat_WithVersionId_NoMatchOnServiceRootUrl()
    {
      //Arrange
      string ServiceRootUrlString = "http://SomeWhere.net.au/FhirApi/Patient";
      string ReferanceUrlString = "http://SomeWhereElse.net.au/FhirApi/Encounter/10/_history/5";
      IFhirUri ReferanceFhirUri = Common.CommonFactory.GetFhirUri(new Uri(ReferanceUrlString));

      var ResourceReference = new ResourceReference();
      ResourceReference.Reference = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      var ReferanceRootUrlStore = new Pyro.DataModel.DatabaseModel.ServiceRootURL_Store();
      ReferanceRootUrlStore.ServiceRootURL_StoreID = 0;
      ReferanceRootUrlStore.IsServersPrimaryUrlRoot = false;
      ReferanceRootUrlStore.RootUrl = ReferanceFhirUri.ServiceRootUrlForComparison;
      MockICommonRepository.Setup(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison)).Returns(ReferanceRootUrlStore);

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
      //Test GetAndOrAddPyro_RootUrlStore called once to add or get the Url from / to the db 
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Once));
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
      IFhirUri RequestFhirUri = Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.IsNull(Index);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceUrlString), Times.Never));
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
      IFhirUri ReferanceFhirUri = Common.CommonFactory.GetFhirUri(ReferanceUrlString);

      var ResourceReference = new ResourceReference();

      ResourceReference.Reference = ReferanceUrlString;

      //Mok the inbound Request Url, this contains the service root url from the db.
      Mock<IDtoFhirRequestUri> MockIDtoFhirRequestUri = new Mock<IDtoFhirRequestUri>();

      var ServiceRootUrl = new Uri(ServiceRootUrlString);
      IFhirUri RequestFhirUri = Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.AreEqual(Index.FhirId, ReferanceFhirUri.Id);
      Assert.AreEqual(Index.Type, ReferanceFhirUri.ResourseType);
      Assert.IsNull(Index.Url);
      Assert.IsNull(Index.VersionId);
      Assert.AreEqual(Index.ServiceRootURL_StoreID, 1);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceFhirUri.ServiceRootUrlForComparison), Times.Never));
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
      IFhirUri RequestFhirUri = Common.CommonFactory.GetFhirUri(ServiceRootUrl);
      MockIDtoFhirRequestUri.Setup(x => x.FhirUri).Returns(RequestFhirUri);

      var ServiceDtoRootUrlStore = new Pyro.Common.BusinessEntities.Dto.DtoRootUrlStore();
      ServiceDtoRootUrlStore.Id = 1;
      ServiceDtoRootUrlStore.IsServersPrimaryUrlRoot = true;
      ServiceDtoRootUrlStore.Url = ServiceRootUrlString;
      MockIDtoFhirRequestUri.Setup(x => x.PrimaryRootUrlStore).Returns(ServiceDtoRootUrlStore);

      //Mok the response from the db from the Common repository, this if request Url does not match service root url       
      Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository> MockICommonRepository = new Mock<Pyro.DataModel.Repository.Interfaces.ICommonRepository>();

      ReferenceIndex Index = new ReferenceIndex();
      //Act
      Index = IndexSetterFactory.Create(typeof(ReferenceIndex)).Set(ResourceReference, Index, MockIDtoFhirRequestUri.Object, MockICommonRepository.Object) as ReferenceIndex;

      //Assert
      Assert.IsNull(Index);
      Assert.DoesNotThrow(() => MockICommonRepository.Verify(x => x.GetAndOrAddService_RootUrlStore(ReferanceUrlString), Times.Never));
    }

  }
}
