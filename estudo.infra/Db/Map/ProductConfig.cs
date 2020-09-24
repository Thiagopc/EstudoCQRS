using estudo.domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace estudo.infra.Db.Map
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
           builder.ToTable("product");
           builder.HasKey(c => c.Id);          
           builder.Property(c => c.Name)
           .HasColumnName("name");

           builder.Property(c => c.Price)
            .HasColumnName("price");
        
            builder.Property(c => c.Description)
                .HasColumnName("description");
        }
    }
}