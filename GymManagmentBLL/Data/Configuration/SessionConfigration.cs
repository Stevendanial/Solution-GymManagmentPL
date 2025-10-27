using GymManagmentBLL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Data.Configuration
{
    internal class SessionConfigration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("SessionCapacityCheck","Capacity Between 1 and 25");

                tb.HasCheckConstraint("SessionEndCheck","EndDate>StartDate");
            }

                );

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Sessions)
                   .HasForeignKey(x => x.CategoryID);

            builder.HasOne(x=>x.Trainer)
                   .WithMany(x=>x.trinerSession)
                   .HasForeignKey(x=>x.trainerID);
        }
    }
}
