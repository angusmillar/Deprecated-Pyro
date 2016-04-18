using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure.Annotations;

//This is an Auto generated file do not change it's contents!!.

namespace Blaze.DataModel.BlazeDbModel
{
  public class Res_RiskAssessment_Index_method_Configuration : EntityTypeConfiguration<Res_RiskAssessment_Index_method>
  {
    public Res_RiskAssessment_Index_method_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      HasRequired(x => x.Res_RiskAssessment);
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
     }
  }
}