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
  public class Blaze_RootUrlStore_Configuration : EntityTypeConfiguration<Blaze_RootUrlStore>
  {

    public Blaze_RootUrlStore_Configuration()
    {
      HasKey(x => x.Blaze_RootUrlStoreID).Property(x => x.Blaze_RootUrlStoreID).IsRequired();
      Property(x => x.RootUrl).IsRequired().HasMaxLength(2083).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_RootUrl") { IsUnique = true }));
      Property(x => x.IsServersPrimaryUrlRoot).IsRequired();
    }
  }
}
