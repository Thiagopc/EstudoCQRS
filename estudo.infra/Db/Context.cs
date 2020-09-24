using estudo.domain.Entity;
using estudo.infra.Db.Map;
using Microsoft.EntityFrameworkCore;

namespace estudo.infra.Db
{
    public class Context : DbContext
    {
        public DbSet<Product> Products {get;set;}
        public DbSet<Outbox> Outbox {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=estudo;user=root;password=password");
        }

        protected override void OnModelCreating(ModelBuilder builder){
                builder.ApplyConfiguration( new ProductConfig());
                builder.ApplyConfiguration(new OutboxConfig());
        }
    }
}