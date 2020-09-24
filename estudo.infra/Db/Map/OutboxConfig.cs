using estudo.domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace estudo.infra.Db.Map
{
    public class OutboxConfig : IEntityTypeConfiguration<Outbox>
    {
        public void Configure(EntityTypeBuilder<Outbox> builder)
        {
            builder.ToTable("outbox");
            builder.HasKey(c => c.Id);
            
            builder.Property(c => c.Id).HasColumnName("id");
            builder.Property(c => c.Name).HasColumnName("name");
            builder.Property(c => c.Operation).HasColumnName("operation");
            builder.Property(c => c.Message).HasColumnName("message");
        }
    }

    // public class Outbox:EntityBase{

    //     public Outbox(string name, string operation, object Objectmessage){
    //         this.Name = name;
    //         this.Operation = operation;
    //        this.Message = JsonSerializer.Serialize(Objectmessage);
    //     }

    //     public Outbox(){}

        
    //     public string Name {get;set;}
    //     public string Operation {get;set;}
    //     public string Message {get;set;}
    // }
}