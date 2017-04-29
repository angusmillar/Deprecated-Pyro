using System;

namespace Pyro.Common.Tools
{
  public class DateTimeIndex : IDateTimeIndex
  {
    public DateTimeOffset? Low { get; set; }
    public DateTimeOffset? High { get; set; }

    public DateTimeIndex() { }    
    public DateTimeIndex(DateTimeOffset Low, DateTimeOffset High)
    {
      this.Low = Low;
      this.High = High;
    }
  }
}
