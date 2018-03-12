using Nh.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Nh.Data
{

    public class NhContext : DbContext
    {
        public NhContext(DbContextOptions<NhContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\NhDb;Database=EFProviders.InMemory;Trusted_Connection=True;ConnectRetryCount=0");
                //optionsBuilder.UseSqlServer(Configuration["MyConfig"]);
            }
        }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
