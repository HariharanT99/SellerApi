using Identity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Context
{
    public class IdentityDbContext : IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(b =>
            {
                // Maps to the Users table
                b.ToTable("User");

            });

            builder.Entity<UserClaim>(b =>
            {

                // Maps to the UserClaims table
                b.ToTable("UserClaim");
            });

            builder.Entity<UserLogin>(b =>
            {
                // Maps to the UserLogins table
                b.ToTable("UserLogin");
            });

            builder.Entity<UserToken>(b =>
            {
                // Maps to the UserTokens table
                b.ToTable("UserToken");
            });

            builder.Entity<Role>(b =>
            {
                // Maps to the AspNetRoles table
                b.ToTable("Role");

            });

            builder.Entity<RoleClaim>(b =>
            {
                // Maps to the AspNetRoleClaims table
                b.ToTable("RoleClaim");
            });

            builder.Entity<UserRole>(b =>
            {
                // Maps to the UserRoles table
                b.ToTable("UserRole");
            });
        }
    }
}
