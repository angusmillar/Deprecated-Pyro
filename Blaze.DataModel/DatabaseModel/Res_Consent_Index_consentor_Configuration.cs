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
  public class Res_Consent_Index_consentor_Configuration : EntityTypeConfiguration<Res_Consent_Index_consentor>
  {

    public Res_Consent_Index_consentor_Configuration()
    {
      HasKey(x => x.Res_Consent_Index_consentorID).Property(x => x.Res_Consent_Index_consentorID).IsRequired();
      Property(x => x.VersionId).IsOptional();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Url);
      HasRequired<ServiceRootURL_Store>(x => x.Url).WithMany().HasForeignKey(x => x.ServiceRootURL_StoreID);
      HasRequired(x => x.Res_Consent).WithMany(x => x.consentor_List).WillCascadeOnDelete(true);
    }
  }
}
