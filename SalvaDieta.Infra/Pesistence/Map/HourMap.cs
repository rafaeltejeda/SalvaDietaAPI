using SalvaDieta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Infra.Pesistence.Map
{
    public class HourMap : EntityTypeConfiguration<Hour>
    {
        public HourMap()
        {
            ToTable("Hour");

            HasKey(x => x.Id);

            Property(x => x.HourOfDay);

            Property(x => x.Active);

            HasRequired(x => x.Day).WithMany(x => x.Hours);
        }
    }
}
