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
  public class Res_ClinicalImpression_Index_plan_Configuration : EntityTypeConfiguration<Res_ClinicalImpression_Index_plan>
  {

    public Res_ClinicalImpression_Index_plan_Configuration()
    {
      HasKey(x => x.Res_ClinicalImpression_Index_planID).Property(x => x.Res_ClinicalImpression_Index_planID).IsRequired();
      Property(x => x.VersionId).IsOptional();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<Blaze_RootUrlStore>(x => x.Url).WithMany().HasForeignKey(x => x.Url_Blaze_RootUrlStoreID);
      HasRequired(x => x.Res_ClinicalImpression).WithMany(x => x.plan_List).WillCascadeOnDelete(true);
    }
  }
}
