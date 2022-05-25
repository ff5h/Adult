using Adult.API.Authentication;
using Adult.API.Data.Configurations;
using Adult.API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Adult.API.Data
{
    public class IdentityDBContext : IdentityDbContext<User>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
