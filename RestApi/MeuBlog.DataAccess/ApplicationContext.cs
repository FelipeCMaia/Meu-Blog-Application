using FluentValidation.Results;
using MeuBlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeuBlog.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) 
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(u => u.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .Ignore(u => u.Name)
                .OwnsOne(u => u.Name, n =>
                {
                    n.Property(un => un.FirstName)
                        .HasColumnName("FirstName")
                        .HasColumnType("varchar(50)");

                    n.Property(un => un.LastName)
                        .HasColumnName("LastName")
                        .HasColumnType("varchar(50)");
                });

            modelBuilder.Entity<User>()
                .Ignore(u => u.Email)
                .OwnsOne(u => u.Email, e =>
                {
                    e.Property(ue => ue.Address)
                        .HasColumnName("Email");
                });
        }
    }
}
