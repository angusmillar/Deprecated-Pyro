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
  public class Res_DiagnosticReport_Index_diagnosis_Configuration : EntityTypeConfiguration<Res_DiagnosticReport_Index_diagnosis>
  {

    public Res_DiagnosticReport_Index_diagnosis_Configuration()
    {
      HasKey(x => x.Res_DiagnosticReport_Index_diagnosisID).Property(x => x.Res_DiagnosticReport_Index_diagnosisID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_DiagnosticReport).WithMany(x => x.diagnosis_List).WillCascadeOnDelete(true);
    }
  }
}
