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
    internal class GymUserConfigraion<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.ToTable(tb => {

                tb.HasCheckConstraint("GymUserValidEmailCheck", "Email like '_%@_%._%'");
                tb.HasCheckConstraint("GymUserValidPhoneCheck", "Phone like '01%' and Phone Not like '%[^0-9]%");
            });

            //unique non clustered index
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();


            builder.Property(x => x.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(11);

            builder.OwnsOne(x => x.Address, addressbuilder =>
            {
                addressbuilder.Property(x => x.Street)
                              .HasColumnName("street")
                              .HasColumnType("varchar")
                              .HasMaxLength(50);

                addressbuilder.Property(x => x.City)
                              .HasColumnName("city")
                              .HasColumnType("varchar")
                              .HasMaxLength(30);

                addressbuilder.Property(x => x.BuilderNumber)
                             .HasColumnName("builderNumber")
                             .HasColumnType("varchar")
                             .HasMaxLength(50);

            });

        }
    }
}
