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
  public class Res_Provenance_Index_entity_Configuration : EntityTypeConfiguration<Res_Provenance_Index_entity>
  {

    public Res_Provenance_Index_entity_Configuration()
    {
      HasKey(x => x.Res_Provenance_Index_entityID).Property(x => x.Res_Provenance_Index_entityID).IsRequired();
      Property(x => x.Uri).IsRequired();
      HasRequired(x => x.Res_Provenance);
    }
  }
}
