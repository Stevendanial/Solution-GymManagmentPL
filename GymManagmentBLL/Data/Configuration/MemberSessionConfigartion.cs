
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
    internal class MemberSessionConfigartion:IEntityTypeConfiguration<MemberSession>
    {
        public void Configure(EntityTypeBuilder<MemberSession> builder)
        {


            builder.Property(x => x.CreatedAt)
                .HasColumnName("BookingDate")
                .HasDefaultValueSql("GetDate()");

            builder.Ignore(x => x.Id);
            builder.HasKey(x => new { x.SessionID, x.MemberID });

        }
    }
}
