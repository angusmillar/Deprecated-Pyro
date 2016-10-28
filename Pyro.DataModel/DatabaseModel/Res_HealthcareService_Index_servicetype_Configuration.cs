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
  public class Res_HealthcareService_Index_servicetype_Configuration : EntityTypeConfiguration<Res_HealthcareService_Index_servicetype>
  {

    public Res_HealthcareService_Index_servicetype_Configuration()
    {
      HasKey(x => x.Res_HealthcareService_Index_servicetypeID).Property(x => x.Res_HealthcareService_Index_servicetypeID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_HealthcareService).WithMany(x => x.servicetype_List).WillCascadeOnDelete(true);
    }
  }
}
