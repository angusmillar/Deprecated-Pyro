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
  public class Res_DiagnosticOrder_Index_event_date_Configuration : EntityTypeConfiguration<Res_DiagnosticOrder_Index_event_date>
  {

    public Res_DiagnosticOrder_Index_event_date_Configuration()
    {
      HasKey(x => x.Res_DiagnosticOrder_Index_event_dateID).Property(x => x.Res_DiagnosticOrder_Index_event_dateID).IsRequired();
      Property(x => x.DateTimeOffset).IsRequired();
      HasRequired(x => x.Res_DiagnosticOrder).WithMany(x => x.event_date_List).WillCascadeOnDelete(true);
    }
  }
}
