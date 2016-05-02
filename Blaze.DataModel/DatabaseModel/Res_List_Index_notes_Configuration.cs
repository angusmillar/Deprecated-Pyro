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
  public class Res_List_Index_notes_Configuration : EntityTypeConfiguration<Res_List_Index_notes>
  {

    public Res_List_Index_notes_Configuration()
    {
      HasKey(x => x.Res_List_Index_notesID).Property(x => x.Res_List_Index_notesID).IsRequired();
      Property(x => x.String).IsRequired();
      HasRequired(x => x.Res_List);
    }
  }
}
