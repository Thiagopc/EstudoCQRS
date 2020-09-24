using System.Threading.Tasks;
using estudo.service.Model;
using MongoDB.Driver;

namespace estudo.service.NoSql
{
    public class MongoContext
    {
        private IMongoDatabase _mongo;
        public MongoContext(){
            var mongo = new MongoClient("mongodb://localhost:27017");
            this._mongo  = mongo.GetDatabase("estudo");
        }

       public IMongoCollection<Product> GetProduct(){
           return this._mongo.GetCollection<Product>("product");
       }
    }
}