using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;

//This is an Auto generated file do not change it's contents!!.

namespace Blaze.DataModel.DatabaseModel
{
  public class Res_ValueSet_Index_reference_Configuration : EntityTypeConfiguration<Res_ValueSet_Index_reference>
  {

    public Res_ValueSet_Index_reference_Configuration()
    {
      HasKey(x => x.Res_ValueSet_Index_referenceID).Property(x => x.Res_ValueSet_Index_referenceID).IsRequired();
      Property(x => x.Uri).IsRequired();
      HasRequired(x => x.Res_ValueSet);
    }
  }
}
