using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OrderFlow.Identity.Data
{
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.EnabledNotifications).HasDefaultValue(true);
                entity.Property(e => e.Initials).HasMaxLength(5);
            });

            builder.HasDefaultSchema("identity");
        }
    }
}

public sealed class ApplicationUser : IdentityUser
{
    public bool EnabledNotifications { get; set; }
    public string Initials { get; set; } = string.Empty;
}