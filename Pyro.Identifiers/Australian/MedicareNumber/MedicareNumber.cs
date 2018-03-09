using System;
using System.Text.RegularExpressions;

namespace Pyro.Identifiers.Australian.MedicareNumber
{
  public class MedicareNumber : IMedicareNumber
  {
    /// <summary>
    /// The whole Medicare Number value
    /// </summary>
    public string Value { get; internal set; }

    /// <summary>
    /// 8-digits in total, the first digit should be in the range 2-6
    /// </summary>
    public string Identifer {get; internal set; }

    /// <summary>
    /// Checksum Digits are weighted (1,3,7,9,1,3,7,9)
    /// </summary>
    public string Checksum { get; internal set; }

    /// <summary>
    /// Indicates how many times the card has been issued (1-digit)
    /// </summary>
    public string IssueNumber { get; internal set; }

    /// <summary>
    /// The IRN appears on the left of the cardholder's name on the medicare card 
    /// and distinguishes the individuals named on the card.
    /// </summary>
    public string IRN { get; internal set; }

    /// <summary>
    /// The expiry date of the Medicare Card
    /// Defaults to null can be set independatly 
    /// </summary>
    public DateTime? ExpiryDate { get; set; }

    /// <summary>
    /// MedicareNumber Constructor
    /// </summary>
    public MedicareNumber()
    {      
    }
   
  }
}
