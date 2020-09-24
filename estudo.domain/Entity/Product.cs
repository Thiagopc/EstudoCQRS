using System;

namespace estudo.domain.Entity
{
    public class Product : EntityBase
    {
        public Product() { }
        public Product(Guid id, string name, string description, decimal price)
        {
            this.Id = id.ToString();
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }

       

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}