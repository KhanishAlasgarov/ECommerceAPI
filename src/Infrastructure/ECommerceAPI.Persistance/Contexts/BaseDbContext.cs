using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using File = ECommerceAPI.Domain.Entities.File;
namespace ECommerceAPI.Persistance.Contexts
{
    public class BaseDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>().Ignore(x => x.UpdatedDate);
            base.OnModelCreating(modelBuilder);
        }

        // Interceptor
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            // ChangeTracker - It is a property that enables the capture of changes made or added data on                    entities.Allows us to capture and obtain tracked data

            IEnumerable<EntityEntry<BaseEntity<Guid>>> entries = ChangeTracker
                .Entries<BaseEntity<Guid>>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry<BaseEntity<Guid>> entry in entries)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => default
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
