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
  public class Res_DocumentReference_Index_author_Configuration : EntityTypeConfiguration<Res_DocumentReference_Index_author>
  {

    public Res_DocumentReference_Index_author_Configuration()
    {
      HasKey(x => x.Res_DocumentReference_Index_authorID).Property(x => x.Res_DocumentReference_Index_authorID).IsRequired();
      Property(x => x.FhirId).IsRequired();
      Property(x => x.Type).IsRequired();
      HasRequired(x => x.Aux_RootUrlStoreID);
      HasRequired(x => x.Res_DocumentReference);
    }
  }
}
