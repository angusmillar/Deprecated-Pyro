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
  public class Res_DetectedIssue_Index_implicated_Configuration : EntityTypeConfiguration<Res_DetectedIssue_Index_implicated>
  {

    public Res_DetectedIssue_Index_implicated_Configuration()
    {
      HasKey(x => x.Res_DetectedIssue_Index_implicatedID).Property(x => x.Res_DetectedIssue_Index_implicatedID).IsRequired();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<Blaze_RootUrlStore>(x => x.Url).WithMany().HasForeignKey(x => x.Url_Blaze_RootUrlStoreID);
      HasRequired(x => x.Res_DetectedIssue).WithMany(x => x.implicated_List).WillCascadeOnDelete(true);
    }
  }
}
