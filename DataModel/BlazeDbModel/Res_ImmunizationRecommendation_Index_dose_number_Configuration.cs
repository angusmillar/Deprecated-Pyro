﻿using System;
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

namespace DataModel.BlazeDbModel
{
  public class Res_ImmunizationRecommendation_Index_dose_number_Configuration : EntityTypeConfiguration<Res_ImmunizationRecommendation_Index_dose_number>
  {
    public Res_ImmunizationRecommendation_Index_dose_number_Configuration()
    {
      HasKey(x => x.Id).Property(x => x.Id).IsRequired();
      HasRequired(x => x.Res_ImmunizationRecommendation);
      Property(x => x.Number).IsRequired();       
     }
  }
}