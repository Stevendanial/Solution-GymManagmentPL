using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Configuration
{
    internal class TrainerConfiguration : GymUserConfigraion<Trainer>, IEntityTypeConfiguration<Trainer>
    {
        public new void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Trainer> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.CreatedAt)
                    .HasColumnName("HireDate")
                    .HasDefaultValueSql("GetDate");
        }
    }
}
