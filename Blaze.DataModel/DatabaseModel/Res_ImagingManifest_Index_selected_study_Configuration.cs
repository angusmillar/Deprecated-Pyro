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
  public class Res_ImagingManifest_Index_selected_study_Configuration : EntityTypeConfiguration<Res_ImagingManifest_Index_selected_study>
  {

    public Res_ImagingManifest_Index_selected_study_Configuration()
    {
      HasKey(x => x.Res_ImagingManifest_Index_selected_studyID).Property(x => x.Res_ImagingManifest_Index_selected_studyID).IsRequired();
      Property(x => x.Uri).IsRequired();
      HasRequired(x => x.Res_ImagingManifest).WithMany(x => x.selected_study_List).WillCascadeOnDelete(true);
    }
  }
}
