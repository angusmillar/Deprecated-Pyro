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
  public class Res_Medication_Index_form_Configuration : EntityTypeConfiguration<Res_Medication_Index_form>
  {

    public Res_Medication_Index_form_Configuration()
    {
      HasKey(x => x.Res_Medication_Index_formID).Property(x => x.Res_Medication_Index_formID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_Medication).WithMany(x => x.form_List).WillCascadeOnDelete(true);
    }
  }
}
