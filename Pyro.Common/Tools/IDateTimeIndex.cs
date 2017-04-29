using System;

namespace Pyro.Common.Tools
{
  public interface IDateTimeIndex
  {
    DateTimeOffset? High { get; set; }
    DateTimeOffset? Low { get; set; }
  }
}