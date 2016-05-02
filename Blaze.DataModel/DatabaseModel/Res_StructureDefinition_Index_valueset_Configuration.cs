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
  public class Res_StructureDefinition_Index_valueset_Configuration : EntityTypeConfiguration<Res_StructureDefinition_Index_valueset>
  {

    public Res_StructureDefinition_Index_valueset_Configuration()
    {
      HasKey(x => x.Res_StructureDefinition_Index_valuesetID).Property(x => x.Res_StructureDefinition_Index_valuesetID).IsRequired();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<Blaze_RootUrlStore>(x => x.Url).WithMany().HasForeignKey(x => x.Url_Blaze_RootUrlStoreID);
      HasRequired(x => x.Res_StructureDefinition);
    }
  }
}
