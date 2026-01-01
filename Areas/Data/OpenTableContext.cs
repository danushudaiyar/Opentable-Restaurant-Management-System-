using Microsoft.EntityFrameworkCore;
using OpenTable.Models;

namespace OpenTable.Data
{
    public class OpenTableContext : DbContext
    {
        public OpenTableContext(DbContextOptions<OpenTableContext> options) 
            : base(options) 
        {
        }

        public DbSet<Metropolis> Metropolises { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<User> Users { get; set; } // Added missing User DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Metropolis entity
            modelBuilder.Entity<Metropolis>(entity =>
            {
                entity.Property(m => m.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                
                entity.HasIndex(m => m.Name)
                    .IsUnique();
            });

            // Configure Restaurant entity
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(r => r.Address)
                    .IsRequired();
                
                entity.Property(r => r.PriceRange)
                    .IsRequired()
                    .HasMaxLength(10);
                
                entity.Property(r => r.CuisineStyle)
                    .IsRequired()
                    .HasMaxLength(50);
                
                entity.Property(r => r.OpenHours)
                    .IsRequired();

                // Configure the one-to-many relationship
                entity.HasOne(r => r.Metropolis)
                    .WithMany(m => m.Restaurants)
                    .HasForeignKey(r => r.MetropolisId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                
                entity.Property(u => u.Email)
                    .IsRequired();
                
                entity.Property(u => u.Role)
                    .IsRequired()
                    .HasMaxLength(20);
                
                entity.HasIndex(u => u.Username)
                    .IsUnique();
                
                entity.HasIndex(u => u.Email)
                    .IsUnique();
            });

            // Seed initial data
            modelBuilder.Entity<Metropolis>().HasData(
                new Metropolis { Id = 1, Name = "New York" },
                new Metropolis { Id = 2, Name = "Los Angeles" },
                new Metropolis { Id = 3, Name = "Chicago" },
                new Metropolis { Id = 4, Name = "Houston" },
                new Metropolis { Id = 5, Name = "Miami" }
            );

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant 
                { 
                    Id = 1,
                    Name = "Gotham Bar & Grill",
                    MetropolisId = 1,
                    Address = "12 E 12th St, New York, NY",
                    PriceRange = "$$$",
                    CuisineStyle = "American",
                    OpenHours = "11:00-14:00,17:00-22:00"
                },
                new Restaurant 
                { 
                    Id = 2,
                    Name = "Nobu Malibu",
                    MetropolisId = 2,
                    Address = "22706 Pacific Coast Hwy, Malibu, CA",
                    PriceRange = "$$$$",
                    CuisineStyle = "Japanese",
                    OpenHours = "17:00-21:30"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Email = "admin@opentable.com",
                    Role = "admin"
                },
                new User
                {
                    Id = 2,
                    Username = "manager",
                    Email = "manager@opentable.com",
                    Role = "manager"
                }
            );
        }
    }
}