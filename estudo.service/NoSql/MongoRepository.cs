using System.Threading.Tasks;
using estudo.service.Model;
using MongoDB.Bson;

namespace estudo.service.NoSql
{
    public class MongoRepository
    {
        private MongoContext _context;
        public MongoRepository(){
            this._context = new MongoContext();
        }

        public async Task Insert(Product model){
          var productCollection = this._context.GetProduct();
          await productCollection.InsertOneAsync(model);
        }
    }
}