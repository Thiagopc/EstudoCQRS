using System;

namespace estudo.domain.Command
{
    public abstract class ProductCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description {get;set;}
        public decimal Price {get;set;}
        
    }
}