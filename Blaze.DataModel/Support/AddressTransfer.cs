using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Introspection;

namespace Blaze.DataModel.Support
{
  public class AddressTransfer
  {
    public List<string> AddressList { get; set; }
    public List<string> CityList { get; set; }
    public List<string> PostCodeList { get; set; }
    public List<string> StateList { get; set; }
    public List<string> CountryList { get; set; }
    public List<string> AddressUseList { get; set; }
    
    public AddressTransfer(IEnumerable<Address> FhirAddress)
    {
      this.AddressList = new List<string>();
      this.CityList = new List<string>();
      this.PostCodeList = new List<string>();
      this.StateList = new List<string>();
      this.CountryList = new List<string>();
      this.AddressUseList = new List<string>();

      ProcessFhirAddress(FhirAddress);

    }

    private void ProcessFhirAddress(IEnumerable<Address> FhirAddressList)
    {
      string OneEmptySpace = " ";
      foreach (var FhirAddress in FhirAddressList)
      {
        var AddressBuilder = new StringBuilder();
        foreach (var Line in FhirAddress.Line)
        {
          AddressBuilder.Append(Line);
          AddressBuilder.Append(OneEmptySpace);
        }

        if (!String.IsNullOrWhiteSpace(FhirAddress.City))
        {
          this.CityList.Add(FhirAddress.City);
          AddressBuilder.Append(FhirAddress.City);
          AddressBuilder.Append(OneEmptySpace);
        }

        if (!String.IsNullOrWhiteSpace(FhirAddress.PostalCode))
        {
          this.PostCodeList.Add(FhirAddress.PostalCode);
          AddressBuilder.Append(FhirAddress.PostalCode);
          AddressBuilder.Append(OneEmptySpace);
        }

        if (!String.IsNullOrWhiteSpace(FhirAddress.State))
        {
          this.StateList.Add(FhirAddress.State);
          AddressBuilder.Append(FhirAddress.State);
          AddressBuilder.Append(OneEmptySpace);
        }

        if (!String.IsNullOrWhiteSpace(FhirAddress.Country))
        {
          this.CountryList.Add(FhirAddress.Country);
          AddressBuilder.Append(FhirAddress.Country);
          AddressBuilder.Append(OneEmptySpace);
        }

        if (FhirAddress.Use != null)
        {
          this.AddressUseList.Add(EnumMapping.Create(typeof(Hl7.Fhir.Model.Address.AddressUse)).GetLiteral(FhirAddress.Use));
        }

        if (AddressBuilder.Length > 0)
        {
          this.AddressList.Add(AddressBuilder.ToString());
        }
      }
    }
  }
}
