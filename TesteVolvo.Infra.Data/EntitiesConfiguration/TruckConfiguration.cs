using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteVolvo.Domain.Entities;

namespace TesteVolvo.Infra.Data.EntitiesConfiguration
{
    public class TruckConfiguration : IEntityTypeConfiguration<Truck>
    {
        public void Configure(EntityTypeBuilder<Truck> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.YearManufacture).IsRequired();
            builder.Property(p => p.YearModel).IsRequired();

            builder.HasOne(e => e.Category).WithMany(e => e.Trucks)
                .HasForeignKey(e => e.CategoryId);

        }
    }
}
