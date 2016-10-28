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

namespace Pyro.DataModel.DatabaseModel
{
  public class Res_ImagingManifest_Index_title_Configuration : EntityTypeConfiguration<Res_ImagingManifest_Index_title>
  {

    public Res_ImagingManifest_Index_title_Configuration()
    {
      HasKey(x => x.Res_ImagingManifest_Index_titleID).Property(x => x.Res_ImagingManifest_Index_titleID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_ImagingManifest).WithMany(x => x.title_List).WillCascadeOnDelete(true);
    }
  }
}
