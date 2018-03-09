using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pyro.Identifiers.Australian.DepartmentVeteransAffairs
{
  public class DVANumber : IDVANumber
  {
    /// <summary>
    /// 1st character is the State Code (an alpha) - N, V, Q, W, S or T for
    /// the appropriate State/Territory.ACT is included in NSW(N) and
    /// NT with SA(S).
    /// </summary>
    public string StateCode { get; internal set; }

    /// <summary>
    /// if War Code is 1 alpha character, add 6 digits (ANNNNNN)
    /// if War Code is 2 alpha characters, add 5 digits(AANNNNN)
    /// if War Code is 3 alpha characters, add 4 digits(AAANNNN)
    /// </summary>
    public string WarCode { get; internal set; }

    /// <summary>
    /// 7 characters are the File Number, made up of:
    /// War Code + numeric digits, where:    
    /// if War Code is 1 alpha character, add 6 digits (ANNNNNN)
    /// if War Code is 2 alpha characters, add 5 digits (AANNNNN)
    /// if War Code is 3 alpha characters, add 4 digits (AAANNNN)
    /// </summary>
    public string Number { get; internal set; }

    /// <summary>
    /// The FileNumber concept is the WarCode + Number
    /// </summary>
    public string FileNumber { get { return this.WarCode + this.Number; } }

    /// <summary>
    /// 9th character is the Segment Link (an alpha) which represent
    /// members related to the veteran. The alpha code is generated in
    /// the order that cards are issued. For example A, B, C, D etc.
    /// CAUTIONARY NOTE: For Veterans the 9th character is left
    /// blank.
    /// </summary>
    public string SegmentLink { get; internal set; }

    /// <summary>
    /// DVW : DVA Card- White
    /// DVG : DVA Card - Gold
    //  DVO : DVA Card - Orange
    /// </summary>
    public string CardColor { get; set; }

    /// <summary>
    /// The complete DVA Number
    /// </summary>
    public string Value { get; internal set; }


  }
}
