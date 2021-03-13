using Microsoft.EntityFrameworkCore;
using DomainModels.Entities;
using DomainModels.Enums;

namespace DatabaseContext.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Log> Logs { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public AppDbContext()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public AppDbContext db
        {
            get { return this; }
        }
    }

    public interface IAppDbContext { }
}
