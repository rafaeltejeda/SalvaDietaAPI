using SalvaDieta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Infra.Pesistence.Map
{
    public class DayMap : EntityTypeConfiguration<Day>
    {
        public DayMap()
        {
            ToTable("Day");

            HasKey(x => x.Id);

            Property(x => x.DayOfWeek);

            Property(x => x.Active);

            Property(x => x.Reserved);           
        }
    }
}
