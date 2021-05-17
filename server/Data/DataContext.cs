using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using server.Entities;

namespace server.Data
{
    public class DataContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, 
        UserRole, IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<UserCard> UserCards { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);  

            builder.Entity<User>()  
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            
            builder.Entity<Role>()  
                .HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<User>()  
                .HasMany(u => u.UserCards)
                .WithOne(uc => uc.User)
                .HasForeignKey(uс => uс.UserId)
                .IsRequired();

            builder.Entity<Card>()  
                .HasMany(c => c.UserCards)
                .WithOne(uc => uc.Card)
                .HasForeignKey(uс => uс.CardId)
                .IsRequired();

            builder.Entity<UserCard>().HasKey(k => new { k.UserId, k.CardId });

            builder.Entity<Card>()
                .HasOne(c => c.Icon)
                .WithOne(i => i.Card)
                .HasForeignKey<Icon>(i => i.CardId)
                .IsRequired();
        }
    }
}