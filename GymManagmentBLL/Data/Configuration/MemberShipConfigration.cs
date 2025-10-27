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
    internal class MemberShipConfigration:IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder) {
            builder.Property(x => x.CreatedAt)
                   .HasColumnName("StartDate")
                   .HasDefaultValueSql("GetDate");

            builder.Ignore(x => x.Id);
            builder.HasKey(x=>new { x.planID, x.MemberID });
            
        
        
        
        
        }
    }
}
