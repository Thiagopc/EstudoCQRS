using System;
using System.Text;
using System.Threading.Tasks;
using estudo.service.Model;
using estudo.service.NoSql;
using estudo.service.Repository.Request;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace estudo.service.Services
{
    public class ServiceListener
    {

        private static bool queueExist = false;
        private string queueName = "hashed-consumer";
        private RabbitHanddlerRepository _repo;

        public ServiceListener(){
            this._repo = new RabbitHanddlerRepository();
        }
        private void Create(){
            var responseExchange = this._repo.CreateExchange();
            var response = this._repo.CreateQueue(this.queueName);
                            this._repo.CreateBinding();    
                                 
            
        }
        public  void Listener()
        {
            
            if(!queueExist){                
                this.Create();
                queueExist = true;
            }

            var outB = new OutBox();
            var product = new Product();
            var rep = new MongoRepository();
            {
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {


                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        //Console.WriteLine(" [x] Received {0}", message);

                        product = JsonConvert.DeserializeObject<Product>(message);
                        rep.Insert(product).Wait();
                    };
                    channel.BasicConsume(queue: this.queueName,
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}