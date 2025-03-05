using Microsoft.EntityFrameworkCore;
using Restaurant.Domain;

namespace Restaurant.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User konfiguráció
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Name)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(u => u.Email)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(u => u.Address)
                    .HasMaxLength(255)
                    .IsRequired();
            });

            // Food konfiguráció
            modelBuilder.Entity<Food>(entity =>
            {
                entity.Property(f => f.Id)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(f => f.Name)
                    .HasMaxLength(255)
                    .IsRequired();

                entity.Property(f => f.Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(f => f.Category)
                    .HasConversion<string>()
                    .IsRequired();
            });

            // Order konfiguráció
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .IsRequired();

                entity.Property(o => o.OrderDate)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(o => o.Status)
                    .HasConversion<string>()
                    .IsRequired();

                entity.HasMany(o => o.Foods)
                    .WithMany()
                    .UsingEntity(j => j.ToTable("OrderFood"));
            });
        }
    }
}
