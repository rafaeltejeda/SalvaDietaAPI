using SalvaDieta.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalvaDieta.Infra.Pesistence.Map
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");

            HasKey(x => x.Id);

            Property(x => x.Title)
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Decription)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
