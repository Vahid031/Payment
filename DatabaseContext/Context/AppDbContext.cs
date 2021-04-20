using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using System.Threading.Tasks;
using System.Threading;

namespace DataAccess.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Log> Logs { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public override int SaveChanges()
        {
            return base.SaveChanges(true);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(true, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public interface IAppDbContext
    {
        DbSet<Log> Logs { get; set; }

        DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentDetail> PaymentDetails { get; set; }


        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
