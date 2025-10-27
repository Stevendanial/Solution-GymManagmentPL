using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Context
{
    public class GymDBContext : DbContext
    {

        public GymDBContext(DbContextOptions<GymDBContext> options) : base(options)
        {

        }



        //  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=.;Database=GymManagmentDB;Trusted_Connection=True;TrustServerCertificate=True;");

        // }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<HealthRecord>()
            .Property(h => h.Height)
            .HasPrecision(5, 2);

            modelBuilder.Entity<HealthRecord>()
                .Property(h => h.Weight)
                .HasPrecision(5, 2);


        }
        public DbSet<Member> Members { get; set; }
         public DbSet<Trainer> trainers { get; set; }

        public DbSet<Plan> Plans { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }

        public DbSet<MemberSession> MemberSessions { get; set; }
        

        public DbSet<Category> Categories { get; set; }
        public DbSet<Session> sessions { get; set; }
    }
}
