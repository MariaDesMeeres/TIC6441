﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OpenWeatherMap.Model;

namespace OpenWeatherMapApi.Domain
{
    public class OWMContext:DbContext
    {
        public DbSet<OWM_Historical> OWM_Historicals;
        public DbSet<OWM_Current> OWM_Currents;
        public DbSet<OWM_Forecast3H> OWM_Forecast3H;

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
