using Microsoft.EntityFrameworkCore;
using EmployeeRegister.Domain;

namespace EmployeeRegister.Data
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Organization>().ToTable("Organization");

            // felettes beállítása
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Supervisor)
                .WithMany()
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}