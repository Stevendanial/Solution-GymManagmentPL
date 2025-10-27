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
    internal class HealthRecordConfigration : IEntityTypeConfiguration<HealthRecord>
    {
        public void Configure(EntityTypeBuilder<HealthRecord> builder)
        {

            builder.ToTable("Member")
                    .HasKey(x => x.Id);

            builder.HasOne<Member>()
                    .WithOne(x => x.HealthRecord)
                    .HasForeignKey<HealthRecord>(x => x.Id);


        }
    }
}
