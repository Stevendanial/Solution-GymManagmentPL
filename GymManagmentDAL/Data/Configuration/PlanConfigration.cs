using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Configuration
{
    internal class PlanConfigration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(x => x.Name)
                   .HasColumnType("varchar(50)")
                   .HasMaxLength(50);

            builder.Property(x => x.Description)
                   .HasColumnType("varchar(50)")
                   .HasMaxLength(200);

            builder.Property(x => x.Price)
                   .HasPrecision(10, 2);

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("planDurationCheck", "DurationDays Between 1 and 356");



            });
        }
    }
}
