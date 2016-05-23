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
  public class Res_Conformance_Index_resource_Configuration : EntityTypeConfiguration<Res_Conformance_Index_resource>
  {

    public Res_Conformance_Index_resource_Configuration()
    {
      HasKey(x => x.Res_Conformance_Index_resourceID).Property(x => x.Res_Conformance_Index_resourceID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Conformance).WithMany(x => x.resource_List).WillCascadeOnDelete(true);
    }
  }
}
