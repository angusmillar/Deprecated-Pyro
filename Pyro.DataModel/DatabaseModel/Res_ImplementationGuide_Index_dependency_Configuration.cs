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
  public class Res_ImplementationGuide_Index_dependency_Configuration : EntityTypeConfiguration<Res_ImplementationGuide_Index_dependency>
  {

    public Res_ImplementationGuide_Index_dependency_Configuration()
    {
      HasKey(x => x.Res_ImplementationGuide_Index_dependencyID).Property(x => x.Res_ImplementationGuide_Index_dependencyID).IsRequired();
      Property(x => x.Uri).IsRequired();
      HasRequired(x => x.Res_ImplementationGuide).WithMany(x => x.dependency_List).WillCascadeOnDelete(true);
    }
  }
}
