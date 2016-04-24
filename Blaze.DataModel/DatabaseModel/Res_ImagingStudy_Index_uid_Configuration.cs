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
  public class Res_ImagingStudy_Index_uid_Configuration : EntityTypeConfiguration<Res_ImagingStudy_Index_uid>
  {

    public Res_ImagingStudy_Index_uid_Configuration()
    {
      HasKey(x => x.Res_ImagingStudy_Index_uidID).Property(x => x.Res_ImagingStudy_Index_uidID).IsRequired();
      Property(x => x.Uri).IsRequired();
      HasRequired(x => x.Res_ImagingStudy);
    }
  }
}
