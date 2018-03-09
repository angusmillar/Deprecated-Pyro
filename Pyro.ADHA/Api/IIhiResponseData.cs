using System;

namespace Pyro.ADHA.Api
{
  public interface IIhiResponseData
  {
    string IHIRecordStatus { get; set; }
    string IHIStatus { get; set; }

    string Family { get; set; }
    string Given { get; set; }
    char SexChar { get; set; }
    DateTime? Dob { get; set; }

    string MedicareNumber { get; set; }
    string MedicareIRN { get; set; }
    string DVANumber { get; set; }
    string IHINumber { get; set; }
  }
}