using estudo.service.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace estudo.service.Repository.Map
{
    public class OutBoxConfig : IEntityTypeConfiguration<OutBox>
    {
        public void Configure(EntityTypeBuilder<OutBox> builder)
        {
            builder.ToTable("outbox");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Message).HasColumnName("message");
            builder.Property(c => c.Name).HasColumnName("name");
            builder.Property(c => c.Operation).HasColumnName("operation");
            
        }
    }
}