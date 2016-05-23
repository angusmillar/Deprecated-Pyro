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
  public class Res_DiagnosticOrder_Index_item_status_Configuration : EntityTypeConfiguration<Res_DiagnosticOrder_Index_item_status>
  {

    public Res_DiagnosticOrder_Index_item_status_Configuration()
    {
      HasKey(x => x.Res_DiagnosticOrder_Index_item_statusID).Property(x => x.Res_DiagnosticOrder_Index_item_statusID).IsRequired();
      Property(x => x.Code).IsRequired();
      Property(x => x.System).IsOptional();
      HasRequired(x => x.Res_DiagnosticOrder).WithMany(x => x.item_status_List).WillCascadeOnDelete(true);
    }
  }
}
