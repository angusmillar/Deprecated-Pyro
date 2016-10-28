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
  public class Res_Conformance_Index_securityservice_Configuration : EntityTypeConfiguration<Res_Conformance_Index_securityservice>
  {

    public Res_Conformance_Index_securityservice_Configuration()
    {
      HasKey(x => x.Res_Conformance_Index_securityserviceID).Property(x => x.Res_Conformance_Index_securityserviceID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Conformance).WithMany(x => x.securityservice_List).WillCascadeOnDelete(true);
    }
  }
}
