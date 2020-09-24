using estudo.service.Model;
using estudo.service.Repository.Map;
using Microsoft.EntityFrameworkCore;

namespace estudo.service.Repository
{
    public class Context:DbContext
    {
        public DbSet<OutBox> OutBox {get;set;}

           protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=estudo;user=root;password=password");
        }

        protected override void OnModelCreating(ModelBuilder builder){
                builder.ApplyConfiguration( new OutBoxConfig());
                
        }

    }
}