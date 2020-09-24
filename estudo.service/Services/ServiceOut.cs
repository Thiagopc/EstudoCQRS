using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using estudo.service.Model;
using estudo.service.NoSql;
using estudo.service.Repository;
using RabbitMQ.Client;

namespace estudo.service.Services
{
    public class ServiceOut
    {
        private static bool exist = false;
        private RepositoryOutbox _repoOutbox;
        private MongoRepository _repoMongo;
        public ServiceOut()
        {
            this._repoOutbox = new RepositoryOutbox();
            this._repoMongo = new MongoRepository();
        }

        public async Task Event()
        {
            
            var lista = await this._repoOutbox.List();
          

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {



                foreach (var item in lista)
                {


                    var body = Encoding.UTF8.GetBytes(item.Message);


                    channel.BasicPublish(exchange: "hashed-consumer",
                                         routingKey: "1",
                                         basicProperties: null,
                                         body: body);

                    try{

                    await this._repoMongo.Insert(this.GetProduct(item.Message));
                    await this._repoOutbox.Remove(item);
                    }catch(System.Exception ex){
                        System.Console.WriteLine(ex.Message);
                    }

                }
            }

        }


        private Product GetProduct(string message)
        {

            return JsonSerializer.Deserialize<Product>(message);
        }


    }
}