namespace estudo.service.Model
{
    public class Product
    {
           public Product(){}
        public Product(string id, string name, string description, decimal price){
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }       
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}