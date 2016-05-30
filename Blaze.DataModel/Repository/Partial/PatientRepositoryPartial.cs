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
    //This is an example of a Partial Repository. When you need to extend the database access for a particular 
    //Resource type then a class like this can be created to develop any custom db queries required for that resources Repository.

    private void PopulateResourceEntity(Res_Patient ResourseEntity, string ResourceVersion, Patient ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    {      
      IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

      if (ResourceTyped.Active != null)
      {
        var token = IndexSettingSupport.CreateToken(ResourceTyped.ActiveElement);
        ResourseEntity.active_Code = token.Code;
        ResourseEntity.active_System = token.CodeSystem;
      }

      if (ResourceTyped.BirthDate != null)
      {
        ResourseEntity.birthdate_DateTimeOffset = IndexSettingSupport.CreateDateTime(ResourceTyped.BirthDateElement);
      }      

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
          var Index = new Res_Patient_Index_profile();
          Index.Uri = Item;
          ResourseEntity.profile_List.Add(Index);
        }
        foreach (var Item in ResourceTyped.Meta.Security)
        {
          var Index = new Res_Patient_Index_security();
          IndexSettingSupport.SetIndex(Item, Index);
          ResourseEntity.security_List.Add(Index);
        }
        foreach (var Item in ResourceTyped.Meta.Tag)
        {
          var Index = new Res_Patient_Index_tag();
          IndexSettingSupport.SetIndex(Item, Index);
          ResourseEntity.tag_List.Add(Index);
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
  }
}



