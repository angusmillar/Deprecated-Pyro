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
  public class Res_NutritionRequest_Index_formula_Configuration : EntityTypeConfiguration<Res_NutritionRequest_Index_formula>
  {

    public Res_NutritionRequest_Index_formula_Configuration()
    {
      HasKey(x => x.Res_NutritionRequest_Index_formulaID).Property(x => x.Res_NutritionRequest_Index_formulaID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_NutritionRequest).WithMany(x => x.formula_List).WillCascadeOnDelete(true);
    }
  }
}
