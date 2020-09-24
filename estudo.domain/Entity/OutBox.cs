using System;
using System.Text.Json;

namespace estudo.domain.Entity
{
    public class Outbox : EntityBase
    {
       

        public Outbox(string name, string operation, object Objectmessage)
        {
            this.Name = name;
            this.Operation = operation;
            this.Message = JsonSerializer.Serialize(Objectmessage);
            this.Id = Guid.NewGuid().ToString();
        }

        public Outbox() { }


        public string Name { get; set; }
        public string Operation { get; set; }
        public string Message { get; set; }
    }
}