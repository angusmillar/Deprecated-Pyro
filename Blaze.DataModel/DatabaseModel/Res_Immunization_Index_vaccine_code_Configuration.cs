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
  public class Res_Immunization_Index_vaccine_code_Configuration : EntityTypeConfiguration<Res_Immunization_Index_vaccine_code>
  {

    public Res_Immunization_Index_vaccine_code_Configuration()
    {
      HasKey(x => x.Res_Immunization_Index_vaccine_codeID).Property(x => x.Res_Immunization_Index_vaccine_codeID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Immunization).WithMany(x => x.vaccine_code_List).WillCascadeOnDelete(true);
    }
  }
}
