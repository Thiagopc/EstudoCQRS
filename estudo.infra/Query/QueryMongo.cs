using System.Collections.Generic;
using System.Threading.Tasks;
using estudo.infra.Query.Entity;
using MongoDB.Bson;
using MongoDB.Driver;

namespace estudo.infra.Query
{
    public class QueryMongo : IQueryMongo
    {
        private readonly IMongoCollection<QueryProduct> _clientCollection;

        public QueryMongo()
        {
            var _client = new MongoClient("mongodb://localhost:27017");
            _clientCollection = _client.GetDatabase("estudo").GetCollection<QueryProduct>("product");
        }


        public async Task<IEnumerable<QueryProduct>> List()
           => await (await _clientCollection.FindAsync(_ => true)).ToListAsync();



    }
}