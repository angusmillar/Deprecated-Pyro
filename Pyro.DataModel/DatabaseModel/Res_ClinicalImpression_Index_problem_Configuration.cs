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
  public class Res_ClinicalImpression_Index_problem_Configuration : EntityTypeConfiguration<Res_ClinicalImpression_Index_problem>
  {

    public Res_ClinicalImpression_Index_problem_Configuration()
    {
      HasKey(x => x.Res_ClinicalImpression_Index_problemID).Property(x => x.Res_ClinicalImpression_Index_problemID).IsRequired();
      Property(x => x.VersionId).IsOptional();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<ServiceRootURL_Store>(x => x.Url).WithMany().HasForeignKey(x => x.ServiceRootURL_StoreID);
      HasRequired(x => x.Res_ClinicalImpression).WithMany(x => x.problem_List).WillCascadeOnDelete(true);
    }
  }
}
