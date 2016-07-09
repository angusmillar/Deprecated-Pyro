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
using Blaze.DataModel.DatabaseModel.Base;
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

    //private void PopulateResourceEntity(Res_Patient ResourseEntity, string ResourceVersion, Patient ResourceTyped, IDtoFhirRequestUri FhirRequestUri)
    //{
    //  var ResourseEntity2 = new Res_Account();
    //  var ResourceTyped2 = new Hl7.Fhir.Model.Account();


    //  if (ResourceTyped2.Balance != null)
    //  {
    //    var Index = IndexSettingSupport.SetIndex<QuantityIndex>(new QuantityIndex(), ResourceTyped2.Balance);
    //    if (Index != null)
    //    {
    //      ResourseEntity2.balance_Code = Index.Code;
    //      ResourseEntity2.balance_System = Index.System;
    //      ResourseEntity2.balance_Quantity = Index.Quantity;
    //    }
    //  }

    //  if (ResourceTyped2.Name != null)
    //  {
    //    var Index = IndexSettingSupport.SetIndex<StringIndex>(new StringIndex(), ResourceTyped2.NameElement);
    //    if (Index != null)
    //    {
    //      ResourseEntity2.name_String = Index.String;
    //    }
    //  }

    //  if (ResourceTyped2.Owner != null)
    //  {
    //    if (!ResourceTyped2.Owner.IsContainedReference)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped2.Owner, FhirRequestUri, this);
    //      if (Index != null)
    //      {
    //        ResourseEntity2.owner_Type = Index.Type;
    //        ResourseEntity2.owner_FhirId = Index.FhirId;
    //        if (Index.Url != null)
    //        {
    //          ResourseEntity2.owner_Url = Index.Url;
    //        }
    //        else
    //        {
    //          ResourseEntity2.owner_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
    //        }
    //      }
    //    }
    //  }

    //  IndexSettingSupport.SetResourceBaseAddOrUpdate(ResourceTyped, ResourseEntity, ResourceVersion, false);

    //  if (ResourceTyped.Active != null)
    //  {
    //    var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.ActiveElement);
    //    if (Index != null)
    //    {
    //      ResourseEntity.active_Code = Index.Code;
    //      ResourseEntity.active_System = Index.System;
    //    }
    //  }

    //  if (ResourceTyped.BirthDate != null)
    //  {
    //    var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.BirthDateElement);
    //    if (Index != null)
    //    {
    //      ResourseEntity.birthdate_DateTimeOffset = Index.DateTimeOffset;
    //    }
    //  }

    //  if (ResourceTyped.Deceased != null)
    //  {
    //    var Index = IndexSettingSupport.SetIndex<DateIndex>(new DateIndex(), ResourceTyped.Deceased);
    //    if (Index != null)
    //    {
    //      ResourseEntity.death_date_DateTimeOffset = Index.DateTimeOffset;
    //    }
    //  }

    //  if (ResourceTyped.Deceased != null)
    //  {
    //    var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.Deceased);
    //    if (Index != null)
    //    {
    //      ResourseEntity.deceased_Code = Index.Code;
    //      ResourseEntity.deceased_System = Index.System;
    //    }
    //  }

    //  if (ResourceTyped.Gender != null)
    //  {
    //    var Index = IndexSettingSupport.SetIndex<TokenIndex>(new TokenIndex(), ResourceTyped.GenderElement);
    //    if (Index != null)
    //    {
    //      ResourseEntity.gender_Code = Index.Code;
    //      ResourseEntity.gender_System = Index.System;
    //    }
    //  }

    //  if (ResourceTyped.ManagingOrganization != null)
    //  {
    //    if (!ResourceTyped.ManagingOrganization.IsContainedReference)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new ReferenceIndex(), ResourceTyped.ManagingOrganization, FhirRequestUri, this);
    //      if (Index != null)
    //      {
    //        ResourseEntity.organization_Type = Index.Type;
    //        ResourseEntity.organization_FhirId = Index.FhirId;
    //        if (Index.Url != null)
    //        {
    //          ResourseEntity.organization_Url = Index.Url;
    //        }
    //        else
    //        {
    //          ResourseEntity.organization_Url_Blaze_RootUrlStoreID = Index.Url_Blaze_RootUrlStoreID;
    //        }
    //      }
    //    }
    //  }

    //  foreach (var item in ResourceTyped.Address)
    //  {
    //    StringBuilder AddressTotal = new StringBuilder();
    //    foreach (var Line in item.Line)
    //      AddressTotal.Append(Line).Append(" ");
    //    AddressTotal.Append(item.City).Append(" ");
    //    AddressTotal.Append(item.PostalCode).Append(" ");
    //    AddressTotal.Append(item.State).Append(" ");
    //    AddressTotal.Append(item.Country).Append(" ");
    //    var Index = new Res_Patient_Index_address();
    //    Index.String = AddressTotal.ToString();
    //    ResourseEntity.address_List.Add(Index);
    //  }

    //  foreach (var item1 in ResourceTyped.Address)
    //  {
    //    if (item1.City != null)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Patient_Index_address_city(), item1.CityElement) as Res_Patient_Index_address_city;
    //      ResourseEntity.address_city_List.Add(Index);
    //    }
    //  }


    //  foreach (var item1 in ResourceTyped.Address)
    //  {
    //    if (item1.Country != null)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Patient_Index_address_country(), item1.CountryElement) as Res_Patient_Index_address_country;
    //      ResourseEntity.address_country_List.Add(Index);
    //    }
    //  }

    //  foreach (var item1 in ResourceTyped.Address)
    //  {
    //    if (item1.PostalCode != null)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Patient_Index_address_postalcode(), item1.PostalCodeElement) as Res_Patient_Index_address_postalcode;
    //      ResourseEntity.address_postalcode_List.Add(Index);
    //    }
    //  }

    //  foreach (var item1 in ResourceTyped.Address)
    //  {
    //    if (item1.State != null)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Patient_Index_address_state(), item1.StateElement) as Res_Patient_Index_address_state;
    //      ResourseEntity.address_state_List.Add(Index);
    //    }
    //  }

    //  foreach (var item in ResourceTyped.Address)
    //  {
    //    var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_address_use(), item.UseElement) as Res_Patient_Index_address_use;
    //    ResourseEntity.address_use_List.Add(Index);
    //  }



    //  if (ResourceTyped.Animal != null)
    //  {
    //    if (ResourceTyped.Animal.Breed != null)
    //    {
    //      foreach (var item in ResourceTyped.Animal.Breed.Coding)
    //      {
    //        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_animal_breed(), item.CodeElement) as Res_Patient_Index_animal_breed;
    //        ResourseEntity.animal_breed_List.Add(Index);
    //      }
    //    }
    //  }

    //  if (ResourceTyped.Animal != null)
    //  {
    //    if (ResourceTyped.Animal.Species != null)
    //    {
    //      foreach (var item in ResourceTyped.Animal.Species.Coding)
    //      {
    //        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_animal_species(), item.CodeElement) as Res_Patient_Index_animal_species;
    //        ResourseEntity.animal_species_List.Add(Index);
    //      }
    //    }
    //  }

    //  if (ResourceTyped.CareProvider != null)
    //  {
    //    foreach (var item3 in ResourceTyped.CareProvider)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Patient_Index_careprovider(), item3) as Res_Patient_Index_careprovider;
    //      ResourseEntity.careprovider_List.Add(Index);
    //    }
    //  }

    //  if (ResourceTyped.Telecom != null)
    //  {
    //    foreach (var item in ResourceTyped.Telecom)
    //    {
    //      if (item.System != null)
    //      {
    //        if ((ContactPoint.ContactPointSystem)item.System == ContactPoint.ContactPointSystem.Email)
    //        {
    //          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_email(), item) as Res_Patient_Index_email;
    //          ResourseEntity.email_List.Add(Index);
    //        }
    //      }
    //    }
    //  }

    //  foreach (var item1 in ResourceTyped.Name)
    //  {
    //    if (item1.Family != null)
    //    {
    //      foreach (var item4 in item1.FamilyElement)
    //      {
    //        var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Patient_Index_family(), item4) as Res_Patient_Index_family;
    //        ResourseEntity.family_List.Add(Index);
    //      }
    //    }
    //  }

    //  foreach (var item1 in ResourceTyped.Name)
    //  {
    //    if (item1.Given != null)
    //    {
    //      foreach (var item4 in item1.GivenElement)
    //      {
    //        var Index = IndexSettingSupport.SetIndex<StringIndex>(new Res_Patient_Index_given(), item4) as Res_Patient_Index_given;
    //        ResourseEntity.given_List.Add(Index);
    //      }
    //    }
    //  }

    //  if (ResourceTyped.Identifier != null)
    //  {
    //    foreach (var item in ResourceTyped.Identifier)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_identifier(), item) as Res_Patient_Index_identifier;
    //      ResourseEntity.identifier_List.Add(Index);
    //    }
    //  }

    //  foreach (var item1 in ResourceTyped.Communication)
    //  {
    //    if (item1.Language != null)
    //    {
    //      foreach (var item3 in item1.Language.Coding)
    //      {
    //        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_language(), item3.CodeElement) as Res_Patient_Index_language;
    //        ResourseEntity.language_List.Add(Index);
    //      }
    //    }
    //  }

    //  foreach (var item1 in ResourceTyped.Link)
    //  {
    //    if (item1.Other != null)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<ReferenceIndex>(new Res_Patient_Index_link(), item1.Other) as Res_Patient_Index_link;
    //      ResourseEntity.link_List.Add(Index);
    //    }
    //  }

    //  if (ResourceTyped.Name != null)
    //  {
    //    foreach (var item3 in ResourceTyped.Name)
    //    {
    //      StringBuilder NameTotal = new StringBuilder();
    //      foreach (var Given in item3.Given)
    //        NameTotal.Append(Given).Append(" ");
    //      foreach (var Family in item3.Family)
    //        NameTotal.Append(Family).Append(" ");
    //      if (NameTotal.Length > 0)
    //      {
    //        var Index = new Res_Patient_Index_name();
    //        Index.String = NameTotal.ToString();
    //        ResourseEntity.name_List.Add(Index);
    //      }
    //    }
    //  }

    //  if (ResourceTyped.Telecom != null)
    //  {
    //    foreach (var item in ResourceTyped.Telecom)
    //    {
    //      if (item.System != null)
    //      {
    //        if ((ContactPoint.ContactPointSystem)item.System == ContactPoint.ContactPointSystem.Phone)
    //        {
    //          var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_phone(), item) as Res_Patient_Index_phone;
    //          ResourseEntity.phone_List.Add(Index);
    //        }
    //      }
    //    }
    //  }

    //  if (ResourceTyped.Name != null)
    //  {
    //    foreach (var item3 in ResourceTyped.Name)
    //    {
    //      StringBuilder NameTotal = new StringBuilder();
    //      foreach (var Given in item3.Given)
    //        NameTotal.Append(Given).Append(" ");
    //      foreach (var Family in item3.Family)
    //        NameTotal.Append(Family).Append(" ");
    //      if (NameTotal.Length > 0)
    //      {
    //        var Index = new Res_Patient_Index_phonetic();
    //        Index.String = NameTotal.ToString();
    //        ResourseEntity.phonetic_List.Add(Index);
    //      }
    //    }
    //  }

    //  if (ResourceTyped.Telecom != null)
    //  {
    //    foreach (var item in ResourceTyped.Telecom)
    //    {
    //      var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_telecom(), item) as Res_Patient_Index_telecom;
    //      ResourseEntity.telecom_List.Add(Index);
    //    }
    //  }

    //  if (ResourceTyped.Meta != null)
    //  {
    //    if (ResourceTyped.Meta.Profile != null)
    //    {
    //      foreach (var item4 in ResourceTyped.Meta.ProfileElement)
    //      {
    //        var Index = IndexSettingSupport.SetIndex<UriIndex>(new Res_Patient_Index_profile(), item4) as Res_Patient_Index_profile;
    //        ResourseEntity.profile_List.Add(Index);
    //      }
    //    }
    //  }

    //  if (ResourceTyped.Meta != null)
    //  {
    //    if (ResourceTyped.Meta.Security != null)
    //    {
    //      foreach (var item4 in ResourceTyped.Meta.Security)
    //      {
    //        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_security(), item4) as Res_Patient_Index_security;
    //        ResourseEntity.security_List.Add(Index);
    //      }
    //    }
    //  }

    //  if (ResourceTyped.Meta != null)
    //  {
    //    if (ResourceTyped.Meta.Tag != null)
    //    {
    //      foreach (var item4 in ResourceTyped.Meta.Tag)
    //      {
    //        var Index = IndexSettingSupport.SetIndex<TokenIndex>(new Res_Patient_Index_tag(), item4) as Res_Patient_Index_tag;
    //        ResourseEntity.tag_List.Add(Index);
    //      }
    //    }
    //  }



    //}
  }
}



