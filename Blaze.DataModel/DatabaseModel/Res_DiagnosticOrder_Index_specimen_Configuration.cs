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
  public class Res_DiagnosticOrder_Index_specimen_Configuration : EntityTypeConfiguration<Res_DiagnosticOrder_Index_specimen>
  {

    public Res_DiagnosticOrder_Index_specimen_Configuration()
    {
      HasKey(x => x.Res_DiagnosticOrder_Index_specimenID).Property(x => x.Res_DiagnosticOrder_Index_specimenID).IsRequired();
      Property(x => x.VersionId).IsOptional();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<Blaze_RootUrlStore>(x => x.Url).WithMany().HasForeignKey(x => x.Url_Blaze_RootUrlStoreID);
      HasRequired(x => x.Res_DiagnosticOrder).WithMany(x => x.specimen_List).WillCascadeOnDelete(true);
    }
  }
}
