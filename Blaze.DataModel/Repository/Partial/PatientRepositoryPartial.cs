using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq.Expressions;
using Blaze.DataModel.DatabaseModel;
using Blaze.DataModel.Support;
using Hl7.Fhir.Model;
using Blaze.Common.BusinessEntities;
using Blaze.Common.Interfaces;
using Blaze.Common.Interfaces.Repositories;
using Blaze.Common.Interfaces.UriSupport;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Repository
{
  public partial class PatientRepository : CommonRepository, IResourceRepository
  {
    public string AddResource(Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Patient;
      var ResourceEntity = new Res_Patient();
      this.PopulateResourceEntity(ResourceEntity, 1, ResourceTyped, FhirRequestUri);
      using (var scope = new TransactionScope())
      {
        _Context.Res_Patient.Add(ResourceEntity);
        this.Save();
        scope.Complete();
      }
      return ResourceTyped.Id;
    }

    public string UpdateResource(int ResourceVersion, Resource Resource, IDtoFhirRequestUri FhirRequestUri)
    {
      var ResourceTyped = Resource as Patient;
      var ResourceEntity = LoadCurrentResourceEntity(Resource.Id);

      var ResourceHistoryEntity = new Res_Patient_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);
      ResourceEntity.Res_Patient_History_List.Add(ResourceHistoryEntity);

      this.ResetResourceEntity(ResourceEntity);
      this.PopulateResourceEntity(ResourceEntity, ResourceVersion, ResourceTyped, FhirRequestUri);

      using (var scope = new TransactionScope())
      {
        this.Save();
        scope.Complete();
      }
      return ResourceTyped.Id;
    }

    private T DbGet<T>(Expression<Func<T, bool>> predicate) where T : class
    {
      T ResourceEntity = null;
      ResourceEntity = _Context.Set<T>().SingleOrDefault(predicate);
      return ResourceEntity;

    }


    public void UpdateResouceAsDeleted(string FhirResourceId, int ResourceVersion)
    {
      var ResourceEntity = this.LoadCurrentResourceEntity(FhirResourceId);

      var ResourceHistoryEntity = new Res_Patient_History();
      IndexSettingSupport.SetHistoryResourceEntity(ResourceEntity, ResourceHistoryEntity);

      ResourceEntity.Res_Patient_History_List.Add(ResourceHistoryEntity);

      this.ResetResourceEntity(ResourceEntity);
      ResourceEntity.IsDeleted = true;
      ResourceEntity.versionId = ResourceVersion;

      using (var scope = new TransactionScope())
      {
        this.Save();
        scope.Complete();
      }
    }

    public IDatabaseOperationOutcome GetResourceByFhirIDAndVersionNumber(string FhirResourceId, int ResourceVersionNumber)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceEntity = DbGet<Res_Patient>(x => x.FhirId == FhirResourceId && x.versionId == ResourceVersionNumber);
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      return DatabaseOperationOutcome;

    }

    public IDatabaseOperationOutcome GetResourceByFhirID(string FhirResourceId)
    {
      IDatabaseOperationOutcome DatabaseOperationOutcome = new DatabaseOperationOutcome();
      DatabaseOperationOutcome.SingleResourceRead = true;
      var ResourceEntity = DbGet<Res_Patient>(x => x.FhirId == FhirResourceId);
      DatabaseOperationOutcome.ResourceMatchingSearch = IndexSettingSupport.SetDtoResource(ResourceEntity);
      return DatabaseOperationOutcome;
    }


    private Res_Patient LoadCurrentResourceEntity(string FhirId)
    {

      //MUCK AROUND ----------------------------------------------------------------------
      //----------------------------------------------------------------------------------

      var IncludeList = new List<Expression<Func<Res_Patient, object>>>();
      IncludeList.Add(x => x.address_city_List);
      IncludeList.Add(x => x.address_country_List);
      IncludeList.Add(x => x.address_List);
      IncludeList.Add(x => x.address_postalcode_List);
      IncludeList.Add(x => x.address_state_List);
      IncludeList.Add(x => x.address_use_List);
      IncludeList.Add(x => x.animal_breed_List);
      IncludeList.Add(x => x.animal_species_List);
      IncludeList.Add(x => x.careprovider_List);
      IncludeList.Add(x => x.email_List);
      IncludeList.Add(x => x.ethnicity_List);
      IncludeList.Add(x => x.family_List);
      IncludeList.Add(x => x.given_List);
      IncludeList.Add(x => x.identifier_List);
      IncludeList.Add(x => x.language_List);
      IncludeList.Add(x => x.link_List);
      IncludeList.Add(x => x.meta_profile_List);
      IncludeList.Add(x => x.meta_security_List);
      IncludeList.Add(x => x.meta_tag_List);
      IncludeList.Add(x => x.link_List);
      IncludeList.Add(x => x.name_List);
      IncludeList.Add(x => x.phone_List);
      IncludeList.Add(x => x.phonetic_List);
      IncludeList.Add(x => x.race_List);
      IncludeList.Add(x => x.telecom_List);

      var ResourceEntity = this.DbQueryWithInclude<Res_Patient>(x => x.FhirId == FhirId, IncludeList);


      //----------------------------------------------------------------------------------
      //----------------------------------------------------------------------------------

      //var ResourceEntity = (from r in _Context.Res_Patient
      //                             .Include(x => x.address_city_List)
      //                             .Include(x => x.address_country_List)
      //                             .Include(x => x.address_List)
      //                             .Include(x => x.address_postalcode_List)
      //                             .Include(x => x.address_state_List)
      //                             .Include(x => x.address_use_List)
      //                             .Include(x => x.animal_breed_List)
      //                             .Include(x => x.animal_species_List)
      //                             .Include(x => x.careprovider_List)
      //                             .Include(x => x.email_List)
      //                             .Include(x => x.ethnicity_List)
      //                             .Include(x => x.family_List)
      //                             .Include(x => x.given_List)
      //                             .Include(x => x.identifier_List)
      //                             .Include(x => x.language_List)
      //                             .Include(x => x.link_List)
      //                             .Include(x => x.meta_profile_List)
      //                             .Include(x => x.meta_security_List)
      //                             .Include(x => x.meta_tag_List)
      //                             .Include(x => x.link_List)
      //                             .Include(x => x.name_List)
      //                             .Include(x => x.phone_List)
      //                             .Include(x => x.phonetic_List)
      //                             .Include(x => x.race_List)
      //                             .Include(x => x.telecom_List)
      //                              where r.FhirId == FhirId
      //                              select r).SingleOrDefault();
      return ResourceEntity;
    }

    private void PopulateResourceEntity(Res_Patient ResourseEntity, int ResourceVersion, Patient ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {
      IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

      if (ResourceTyped.Active != null)
      {
        var token = IndexSettingSupport.CreateToken(ResourceTyped.ActiveElement);
        ResourseEntity.active_Code = ResourceTyped.Active.ToString();
        ResourseEntity.active_System = "http://hl7.org/fhir/ValueSet/special-values";
      }

      if (ResourceTyped.BirthDate != null)
        ResourseEntity.birthdate_DateTimeOffset = IndexSettingSupport.CreateDateTime(ResourceTyped.BirthDateElement);
      else
        ResourseEntity.birthdate_DateTimeOffset = null;


      if (ResourceTyped.Deceased != null)
      {
        if (ResourceTyped.Deceased.TypeName == ModelInfo.FhirCsTypeToString[typeof(FhirBoolean)])
        {
          var Token = IndexSettingSupport.CreateToken(ResourceTyped.Deceased);
          ResourseEntity.deceased_Code = Token.Code;
          ResourseEntity.deceased_System = Token.CodeSystem;
        }
        else if (ResourceTyped.Deceased.TypeName == ModelInfo.FhirCsTypeToString[typeof(FhirDateTime)])
        {
          ResourseEntity.death_date_DateTimeOffset = IndexSettingSupport.CreateDateTime(ResourceTyped.Deceased);
        }
      }

      if (ResourceTyped.Gender != null)
      {
        ResourseEntity.gender_Code = EnumMapping.Create(typeof(AdministrativeGender)).GetLiteral(ResourceTyped.Gender);
        ResourseEntity.gender_System = null;
      }

      if (ResourceTyped.ManagingOrganization != null)
      {
        if (!ResourceTyped.ManagingOrganization.IsContainedReference)
        {
          ResourceReferenceTransfer ResourceReferenceTransfer = IndexSettingSupport.SetResourceReferanceIndex(ResourceTyped.ManagingOrganization, FhirRequestUri, this);
          ResourseEntity.organization_Type = ResourceReferenceTransfer.Type;
          ResourseEntity.organization_FhirId = ResourceReferenceTransfer.FhirId;
          if (ResourceReferenceTransfer.Url != null)
          {
            ResourseEntity.organization_Url = ResourceReferenceTransfer.Url;
          }
          else
          {
            ResourseEntity.organization_Url_Blaze_RootUrlStoreID = ResourceReferenceTransfer.Blaze_RootUrlStoreID;
          }
        }
      }


      if (ResourceTyped.Address != null)
      {
        foreach (var address in ResourceTyped.Address)
        {
          StringBuilder AddressTotal = new StringBuilder();
          if (!String.IsNullOrWhiteSpace(address.City))
          {
            var Index = new Res_Patient_Index_address_city();
            IndexSettingSupport.SetIndex(address.CityElement, Index);
            ResourseEntity.address_city_List.Add(Index);
            AddressTotal.Append(Index.String).Append(" ");
          }

          if (!String.IsNullOrWhiteSpace(address.Country))
          {
            var Index = new Res_Patient_Index_address_country();
            IndexSettingSupport.SetIndex(address.CountryElement, Index);
            ResourseEntity.address_country_List.Add(Index);
            AddressTotal.Append(Index.String).Append(" ");
          }

          if (!String.IsNullOrWhiteSpace(address.PostalCode))
          {
            var Index = new Res_Patient_Index_address_postalcode();
            IndexSettingSupport.SetIndex(address.PostalCodeElement, Index);
            ResourseEntity.address_postalcode_List.Add(Index);
            AddressTotal.Append(Index.String).Append(" ");
          }

          if (!String.IsNullOrWhiteSpace(address.State))
          {
            var Index = new Res_Patient_Index_address_state();
            IndexSettingSupport.SetIndex(address.StateElement, Index);
            ResourseEntity.address_state_List.Add(Index);
            AddressTotal.Append(Index.String).Append(" ");
          }

          if (address.Use != null)
          {
            var Index = new Res_Patient_Index_address_use();
            Index.Code = Hl7.Fhir.Support.EnumExtensions.GetLiteral(address.Use);
            Index.System = null;
            ResourseEntity.address_use_List.Add(Index);
          }

          if (AddressTotal.Length > 0)
          {
            var Index = new Res_Patient_Index_address();
            Index.String = AddressTotal.ToString();
            ResourseEntity.address_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Animal != null)
      {
        if (ResourceTyped.Animal.Breed != null)
        {
          foreach (var item in ResourceTyped.Animal.Breed.Coding)
          {
            var Index = new Res_Patient_Index_animal_breed();
            IndexSettingSupport.SetIndex(item, Index);
            ResourseEntity.animal_breed_List.Add(Index);
          }
        }
      }

      if (ResourceTyped.Animal != null)
      {
        if (ResourceTyped.Animal.Species != null)
        {
          foreach (var item in ResourceTyped.Animal.Species.Coding)
          {
            var Index = new Res_Patient_Index_animal_species();
            IndexSettingSupport.SetIndex(item, Index);
            ResourseEntity.animal_species_List.Add(Index);
          }
        }
      }

      foreach (var item in ResourceTyped.CareProvider)
      {
        var Index = new Res_Patient_Index_careprovider();
        IndexSettingSupport.SetIndex(item, Index);
        ResourseEntity.careprovider_List.Add(Index);
      }

      if (ResourceTyped.Telecom != null)
      {
        foreach (var Telecom in ResourceTyped.Telecom)
        {
          if (Telecom.System != null)
          {
            if ((ContactPoint.ContactPointSystem)Telecom.System == ContactPoint.ContactPointSystem.Email)
            {
              var Index = new Res_Patient_Index_email();
              IndexSettingSupport.SetIndex(Telecom, Index);
              ResourseEntity.email_List.Add(Index);
            }
          }
        }
      }

      // US Realm Extensions
      //oResourse.ethnicity_List
      //oResourse.race_List

      foreach (var Name in ResourceTyped.Name)
      {
        StringBuilder NameTotal = new StringBuilder();
        foreach (var Item in Name.Family)
        {
          var Index = new Res_Patient_Index_family();
          Index.String = Item;
          ResourseEntity.family_List.Add(Index);
          NameTotal.Append(Item).Append(" ");
        }

        foreach (var Item in Name.Given)
        {
          var Index = new Res_Patient_Index_given();
          Index.String = Item;
          ResourseEntity.given_List.Add(Index);
          NameTotal.Append(Item).Append(" ");
        }

        if (NameTotal.Length > 0)
        {
          var Index1 = new Res_Patient_Index_name();
          Index1.String = NameTotal.ToString();
          ResourseEntity.name_List.Add(Index1);

          var Index2 = new Res_Patient_Index_phonetic();
          Index2.String = NameTotal.ToString();
          ResourseEntity.phonetic_List.Add(Index2);
        }
      }

      foreach (var item in ResourceTyped.Identifier)
      {
        var Index = new Res_Patient_Index_identifier();
        IndexSettingSupport.SetIndex(item, Index);
        ResourseEntity.identifier_List.Add(Index);
      }

      foreach (var Communication in ResourceTyped.Communication)
      {
        if (Communication.Language != null)
        {
          foreach (var Code in Communication.Language.Coding)
          {
            var Index = new Res_Patient_Index_language();
            IndexSettingSupport.SetIndex(Code, Index);
            ResourseEntity.language_List.Add(Index);
          }
        }
      }

      foreach (var Item in ResourceTyped.Link)
      {
        if (Item.Other != null)
        {
          var Index = new Res_Patient_Index_link();
          IndexSettingSupport.SetIndex(Item.Other, Index);
          ResourseEntity.link_List.Add(Index);
        }
      }

      if (ResourceTyped.Meta != null)
      {
        foreach (var Item in ResourceTyped.Meta.Profile)
        {
          var Index = new Res_Patient_Index_meta_profile();
          Index.Uri = Item;
          ResourseEntity.meta_profile_List.Add(Index);
        }
        foreach (var Item in ResourceTyped.Meta.Security)
        {
          var Index = new Res_Patient_Index_meta_security();
          IndexSettingSupport.SetIndex(Item, Index);
          ResourseEntity.meta_security_List.Add(Index);
        }
        foreach (var Item in ResourceTyped.Meta.Tag)
        {
          var Index = new Res_Patient_Index_meta_tag();
          IndexSettingSupport.SetIndex(Item, Index);
          ResourseEntity.meta_tag_List.Add(Index);
        }
      }

      if (ResourceTyped.Telecom != null)
      {
        foreach (var Item in ResourceTyped.Telecom)
        {
          if (Item.System != null)
          {
            if ((ContactPoint.ContactPointSystem)Item.System == ContactPoint.ContactPointSystem.Phone)
            {
              var Index = new Res_Patient_Index_phone();
              IndexSettingSupport.SetIndex(Item, Index);
              ResourseEntity.phone_List.Add(Index);
            }
          }
        }
      }

      if (ResourceTyped.Telecom != null)
      {
        foreach (var Item in ResourceTyped.Telecom)
        {
          var Index = new Res_Patient_Index_telecom();
          IndexSettingSupport.SetIndex(Item, Index);
          ResourseEntity.telecom_List.Add(Index);
        }
      }

    }

    private void ResetResourceEntity(Res_Patient ResourceEntity)
    {
      ResourceEntity.active_Code = null;
      ResourceEntity.active_System = null;
      ResourceEntity.birthdate_DateTimeOffset = null;
      ResourceEntity.death_date_DateTimeOffset = null;
      ResourceEntity.deceased_Code = null;
      ResourceEntity.deceased_System = null;
      //Do not reset the Fhir ID
      //PatientEntity.FhirId
      ResourceEntity.gender_Code = null;
      ResourceEntity.gender_System = null;
      //Do not reset IsDeleted
      //PatientEntity.IsDeleted = ;      
      ResourceEntity.lastUpdated = DateTimeOffset.Now;
      ResourceEntity.organization_FhirId = null;
      ResourceEntity.organization_Type = null;
      ResourceEntity.organization_Url = null;
      ResourceEntity.organization_Url_Blaze_RootUrlStoreID = null;
      //Do not reset Res_PatientID
      //PatientEntity.Res_PatientID = ;
      //Do not reset versionId
      //PatientEntity.versionId = ;      
      ResourceEntity.XmlBlob = string.Empty;

      _Context.Res_Patient_Index_address_city.RemoveRange(ResourceEntity.address_city_List);
      _Context.Res_Patient_Index_address_country.RemoveRange(ResourceEntity.address_country_List);
      _Context.Res_Patient_Index_address.RemoveRange(ResourceEntity.address_List);
      _Context.Res_Patient_Index_address_postalcode.RemoveRange(ResourceEntity.address_postalcode_List);
      _Context.Res_Patient_Index_address_state.RemoveRange(ResourceEntity.address_state_List);
      _Context.Res_Patient_Index_address_use.RemoveRange(ResourceEntity.address_use_List);
      _Context.Res_Patient_Index_animal_breed.RemoveRange(ResourceEntity.animal_breed_List);
      _Context.Res_Patient_Index_animal_species.RemoveRange(ResourceEntity.animal_species_List);
      _Context.Res_Patient_Index_careprovider.RemoveRange(ResourceEntity.careprovider_List);
      _Context.Res_Patient_Index_email.RemoveRange(ResourceEntity.email_List);
      _Context.Res_Patient_Index_ethnicity.RemoveRange(ResourceEntity.ethnicity_List);
      _Context.Res_Patient_Index_family.RemoveRange(ResourceEntity.family_List);
      _Context.Res_Patient_Index_given.RemoveRange(ResourceEntity.given_List);
      _Context.Res_Patient_Index_identifier.RemoveRange(ResourceEntity.identifier_List);
      _Context.Res_Patient_Index_language.RemoveRange(ResourceEntity.language_List);
      _Context.Res_Patient_Index_link.RemoveRange(ResourceEntity.link_List);
      _Context.Res_Patient_Index_meta_profile.RemoveRange(ResourceEntity.meta_profile_List);
      _Context.Res_Patient_Index_meta_security.RemoveRange(ResourceEntity.meta_security_List);
      _Context.Res_Patient_Index_meta_tag.RemoveRange(ResourceEntity.meta_tag_List);
      _Context.Res_Patient_Index_name.RemoveRange(ResourceEntity.name_List);
      _Context.Res_Patient_Index_phone.RemoveRange(ResourceEntity.phone_List);
      _Context.Res_Patient_Index_phonetic.RemoveRange(ResourceEntity.phonetic_List);
      _Context.Res_Patient_Index_race.RemoveRange(ResourceEntity.race_List);
      _Context.Res_Patient_Index_telecom.RemoveRange(ResourceEntity.telecom_List);

    }


  }
}



