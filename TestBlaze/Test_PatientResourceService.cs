using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Blaze.Engine;
using Dip.Interfaces.Repositories;
using Dip.Interfaces.Services;
using Dip.Interfaces;
using Hl7.Fhir.Model;

namespace TestBlaze
{
  [TestFixture]
  [TestOf(typeof(IPatientResourceServices))]
  public class Test_PatientResourceService
  {
    private Mock<IUnitOfWork> MokIUnitOfWork;
      
    [Test]
    public void Deleteing_An_Existing_Resource()
    {
      //Arrange
      MokIUnitOfWork = new Mock<IUnitOfWork>();          
      string FhirResourceId = "1234";
      MokIUnitOfWork.Setup(x => x.ResourceRepository.ResourceExists(FhirResourceId)).Returns(true);
      MokIUnitOfWork.Setup(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId)).Returns(false);
      MokIUnitOfWork.Setup(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId));
      MokIUnitOfWork.Setup(x => x.ResourceRepository.LastDeletedResourceVersion(FhirResourceId)).Returns(5);
      
      var oPatientResourceServices = new Blaze.Engine.Services.PatientResourceServices(MokIUnitOfWork.Object);

      //Act      
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oPatientResourceServices.Delete(FhirResourceId);
      
      //Assert
      MokIUnitOfWork.Verify(x => x.ResourceRepository.ResourceExists(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.ResourceRepository.LastDeletedResourceVersion(FhirResourceId), Times.Exactly(1));

      Assert.AreEqual(System.Net.HttpStatusCode.NoContent, oBlazeServiceOperationOutcome.HttpStatusCodeToReturn);
      Assert.AreEqual(FhirResourceId, oBlazeServiceOperationOutcome.FhirResourceId);                  
      Assert.AreEqual(5, oBlazeServiceOperationOutcome.ResourceVersionNumber);       
    }

    [Test]
    public void Deleteing_A_NonExisting_Resource()
    {
      //Arrange
      MokIUnitOfWork = new Mock<IUnitOfWork>();          
      string FhirResourceId = "1234";
      MokIUnitOfWork.Setup(x => x.ResourceRepository.ResourceExists(FhirResourceId)).Returns(false);
      MokIUnitOfWork.Setup(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId)).Returns(false); ;
      MokIUnitOfWork.Setup(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId));
      var oPatientResourceServices = new Blaze.Engine.Services.PatientResourceServices(MokIUnitOfWork.Object);

      //Act      
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oPatientResourceServices.Delete(FhirResourceId);

      //Assert
      MokIUnitOfWork.Verify(x => x.ResourceRepository.ResourceExists(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId), Times.Never());

      Assert.AreEqual(0, oBlazeServiceOperationOutcome.ResourceVersionNumber);
      Assert.AreEqual(System.Net.HttpStatusCode.NoContent, oBlazeServiceOperationOutcome.HttpStatusCodeToReturn);
      Assert.AreEqual(FhirResourceId, oBlazeServiceOperationOutcome.FhirResourceId);      
    }


    [Test]
    public void Deleteing_An_Existing_Deleted_Resource()
    {
      //Arrange
      MokIUnitOfWork = new Mock<IUnitOfWork>();          
      string FhirResourceId = "1234";
      MokIUnitOfWork.Setup(x => x.ResourceRepository.ResourceExists(FhirResourceId)).Returns(true);
      MokIUnitOfWork.Setup(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId)).Returns(true); ;
      MokIUnitOfWork.Setup(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId));
      MokIUnitOfWork.Setup(x => x.ResourceRepository.LastDeletedResourceVersion(FhirResourceId)).Returns(5);
      var oPatientResourceServices = new Blaze.Engine.Services.PatientResourceServices(MokIUnitOfWork.Object);

      //Act      
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oPatientResourceServices.Delete(FhirResourceId);

      //Assert
      MokIUnitOfWork.Verify(x => x.ResourceRepository.ResourceExists(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.ResourceRepository.LastDeletedResourceVersion(FhirResourceId), Times.Exactly(1));

      Assert.AreEqual(System.Net.HttpStatusCode.NoContent, oBlazeServiceOperationOutcome.HttpStatusCodeToReturn);
      Assert.AreEqual(FhirResourceId, oBlazeServiceOperationOutcome.FhirResourceId);
      Assert.AreEqual(5, oBlazeServiceOperationOutcome.ResourceVersionNumber);
    }

    [Test]
    public void PUT_Adds_New_Resource()
    {
      //Arrange
      MokIUnitOfWork = new Mock<IUnitOfWork>();          
      string FhirResourceId = "1234";
      string FhirResourceIdReturned = "ItWorked";
      var oPatient = ResourceSupport.PatientResource.GetPatientResource(FhirResourceId);
      MokIUnitOfWork.Setup(x => x.ResourceRepository.ResourceExists(FhirResourceId)).Returns(false);
      MokIUnitOfWork.Setup(x => x.PatientRepository.AddResource(oPatient)).Returns(FhirResourceIdReturned);
      var oPatientResourceServices = new Blaze.Engine.Services.PatientResourceServices(MokIUnitOfWork.Object);

      //Act      
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oPatientResourceServices.Put(FhirResourceId, oPatient);

      //Assert
      MokIUnitOfWork.Verify(x => x.ResourceRepository.ResourceExists(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.PatientRepository.AddResource(oPatient), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId), Times.Never());

      Assert.AreEqual(System.Net.HttpStatusCode.Created, oBlazeServiceOperationOutcome.HttpStatusCodeToReturn);
      Assert.AreEqual(FhirResourceIdReturned, oBlazeServiceOperationOutcome.FhirResourceId);
      Assert.AreEqual(1, oBlazeServiceOperationOutcome.ResourceVersionNumber);
      Assert.GreaterOrEqual(DateTimeOffset.Now, oBlazeServiceOperationOutcome.LastModified);            
    }

    [Test]
    public void PUT_Detects_No_FhirResourceId()
    {
      //Arrange
      MokIUnitOfWork = new Mock<IUnitOfWork>();          
      string FhirResourceId = "1234";
            var oPatient = ResourceSupport.PatientResource.GetPatientResource(FhirResourceId);
      oPatient.Id = null;
      var oPatientResourceServices = new Blaze.Engine.Services.PatientResourceServices(MokIUnitOfWork.Object);
          
      //Act            
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oPatientResourceServices.Put(FhirResourceId, oPatient);

      //Assert
      MokIUnitOfWork.Verify(x => x.ResourceRepository.ResourceExists(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.AddResource(oPatient), Times.Never());
      MokIUnitOfWork.Verify(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId), Times.Never());

      Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, oBlazeServiceOperationOutcome.HttpStatusCodeToReturn);
      Resource oResourceToReturn = oBlazeServiceOperationOutcome.ResourceToReturn;
      Assert.IsInstanceOf<OperationOutcome>(oResourceToReturn);
      OperationOutcome oOperationOutcome = oResourceToReturn as OperationOutcome;
      Assert.AreEqual(1, oOperationOutcome.Issue.Count);
      Assert.AreEqual(OperationOutcome.IssueSeverity.Error, oOperationOutcome.Issue[0].Severity);
      Assert.AreEqual(OperationOutcome.IssueType.Required, oOperationOutcome.Issue[0].Code);
      Assert.NotNull(oOperationOutcome.Issue[0].Details);
    }

    [Test]
    public void PUT_Detects_FhirResourceIds_Do_Not_Match()
    {
      //Arrange
      MokIUnitOfWork = new Mock<IUnitOfWork>();          
      string FhirResourceId = "1234";
      var oPatient = ResourceSupport.PatientResource.GetPatientResource(FhirResourceId);
      oPatient.Id = "4321";
      var oPatientResourceServices = new Blaze.Engine.Services.PatientResourceServices(MokIUnitOfWork.Object);

      //Act            
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oPatientResourceServices.Put(FhirResourceId, oPatient);

      //Assert
      MokIUnitOfWork.Verify(x => x.ResourceRepository.ResourceExists(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.AddResource(oPatient), Times.Never());
      MokIUnitOfWork.Verify(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId), Times.Never());

      Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, oBlazeServiceOperationOutcome.HttpStatusCodeToReturn);
      Resource oResourceToReturn = oBlazeServiceOperationOutcome.ResourceToReturn;
      Assert.IsInstanceOf<OperationOutcome>(oResourceToReturn);
      OperationOutcome oOperationOutcome = oResourceToReturn as OperationOutcome;
      Assert.AreEqual(1, oOperationOutcome.Issue.Count);
      Assert.AreEqual(OperationOutcome.IssueSeverity.Error, oOperationOutcome.Issue[0].Severity);
      Assert.AreEqual(OperationOutcome.IssueType.Required, oOperationOutcome.Issue[0].Code);
      Assert.NotNull(oOperationOutcome.Issue[0].Details);
    }

    [Test]
    public void PUT_Detects_Validation_Error_Of_Incorrectly_Formated_DateOfBirth()
    {
      //Arrange
      MokIUnitOfWork = new Mock<IUnitOfWork>();          
      string FhirResourceId = "1234";
      var oPatient = ResourceSupport.PatientResource.GetPatientResource(FhirResourceId);
      oPatient.BirthDate = "1973-09-31"; //September only has 30 days
      MokIUnitOfWork.Setup(x => x.ResourceRepository.ResourceExists(FhirResourceId)).Returns(true);
      MokIUnitOfWork.Setup(x => x.ResourceRepository.GetResourceCurrentVersion(FhirResourceId)).Returns(1);      
      var oPatientResourceServices = new Blaze.Engine.Services.PatientResourceServices(MokIUnitOfWork.Object);

      //Act            
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oPatientResourceServices.Put(FhirResourceId, oPatient);

      //Assert
      MokIUnitOfWork.Verify(x => x.ResourceRepository.ResourceExists(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.ResourceRepository.GetResourceCurrentVersion(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.PatientRepository.AddResource(oPatient), Times.Never());
      MokIUnitOfWork.Verify(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId), Times.Never());

      Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, oBlazeServiceOperationOutcome.HttpStatusCodeToReturn);
      Resource oResourceToReturn = oBlazeServiceOperationOutcome.ResourceToReturn;
      Assert.IsInstanceOf<OperationOutcome>(oResourceToReturn);
      OperationOutcome oOperationOutcome = oResourceToReturn as OperationOutcome;
      Assert.AreEqual(1, oOperationOutcome.Issue.Count);
      Assert.AreEqual(OperationOutcome.IssueSeverity.Fatal, oOperationOutcome.Issue[0].Severity);
      Assert.AreEqual(OperationOutcome.IssueType.Value, oOperationOutcome.Issue[0].Code);
      Assert.NotNull(oOperationOutcome.Issue[0].Details);
    }

    [Test]
    public void PUT_Updates_Existing_Resource()
    {
      //Arrange
      MokIUnitOfWork = new Mock<IUnitOfWork>();          
      string FhirResourceId = "1234";      
      int CurrentRescourceVersion = 2;
      int UpdatedRescourceVersion = CurrentRescourceVersion + 1;
      var oPatient = ResourceSupport.PatientResource.GetPatientResource(FhirResourceId);
      MokIUnitOfWork.Setup(x => x.ResourceRepository.ResourceExists(FhirResourceId)).Returns(true);
      MokIUnitOfWork.Setup(x => x.ResourceRepository.GetResourceCurrentVersion(FhirResourceId)).Returns(CurrentRescourceVersion);      
      MokIUnitOfWork.Setup(x => x.PatientRepository.UpdateResource(CurrentRescourceVersion + 1,oPatient));
      var oPatientResourceServices = new Blaze.Engine.Services.PatientResourceServices(MokIUnitOfWork.Object);

      //Act      
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oPatientResourceServices.Put(FhirResourceId, oPatient);

      //Assert
      MokIUnitOfWork.Verify(x => x.ResourceRepository.ResourceExists(FhirResourceId), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResource(CurrentRescourceVersion + 1, oPatient), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.PatientRepository.AddResource(oPatient), Times.Never());
      MokIUnitOfWork.Verify(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId), Times.Never());

      Assert.AreEqual(System.Net.HttpStatusCode.OK, oBlazeServiceOperationOutcome.HttpStatusCodeToReturn);
      Assert.AreEqual(FhirResourceId, oBlazeServiceOperationOutcome.FhirResourceId);
      //Assert.Null(oBlazeServiceOperationOutcome.ResourceToReturn);
      Assert.AreEqual(UpdatedRescourceVersion, oBlazeServiceOperationOutcome.ResourceVersionNumber);
      Assert.GreaterOrEqual(DateTimeOffset.Now, oBlazeServiceOperationOutcome.LastModified);           
    }

    [Test]
    public void POST_Adds_New_Resource()
    {
      //Arrange
      MokIUnitOfWork = new Mock<IUnitOfWork>();          
      string FhirResourceId = "1234";
      string FhirResourceIdReturned = "ItWorked";
      var oPatient = ResourceSupport.PatientResource.GetPatientResource(FhirResourceId);
      MokIUnitOfWork.Setup(x => x.PatientRepository.AddResource(oPatient)).Returns(FhirResourceIdReturned);      
      var oPatientResourceServices = new Blaze.Engine.Services.PatientResourceServices(MokIUnitOfWork.Object);

      //Act      
      IBlazeServiceOperationOutcome oBlazeServiceOperationOutcome = oPatientResourceServices.Post(oPatient);

      //Assert
      MokIUnitOfWork.Verify(x => x.ResourceRepository.ResourceExists(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.AddResource(oPatient), Times.Exactly(1));
      MokIUnitOfWork.Verify(x => x.ResourceRepository.IsCurrentResourceDeleted(FhirResourceId), Times.Never());
      MokIUnitOfWork.Verify(x => x.PatientRepository.UpdateResouceAsDeleted(FhirResourceId), Times.Never());

      Assert.AreEqual(System.Net.HttpStatusCode.Created, oBlazeServiceOperationOutcome.HttpStatusCodeToReturn);
      Assert.AreEqual(FhirResourceIdReturned, oBlazeServiceOperationOutcome.FhirResourceId);
      //Assert.Null(oBlazeServiceOperationOutcome.ResourceToReturn);
      Assert.AreEqual(1, oBlazeServiceOperationOutcome.ResourceVersionNumber);
      Assert.GreaterOrEqual(DateTimeOffset.Now, oBlazeServiceOperationOutcome.LastModified);
            
    }

  }
}
