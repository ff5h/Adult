using Adult.API.Core.DAL.Configurations;
using Adult.API.Core.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adult.API.Core.DAL
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MarkConfiguration());
        }

        public DbSet<Mark> Marks { get; private set; }
    }
}
