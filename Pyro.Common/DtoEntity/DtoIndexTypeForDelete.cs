﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyro.Common.DtoEntity
{
  public class DtoIndexTypeForDelete
  {
    public int Id { get; set; }
    public bool IsCurrent { get; set; }
    public int ResourceId { get; set; }
  }
}
