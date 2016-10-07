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
  public class Res_DataElement_Index__profile_Configuration : EntityTypeConfiguration<Res_DataElement_Index__profile>
  {

    public Res_DataElement_Index__profile_Configuration()
    {
      HasKey(x => x.Res_DataElement_Index__profileID).Property(x => x.Res_DataElement_Index__profileID).IsRequired();
      Property(x => x.Uri).IsRequired();
      HasRequired(x => x.Res_DataElement).WithMany(x => x._profile_List).WillCascadeOnDelete(true);
    }
  }
}
