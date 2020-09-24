using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace estudo.service.Repository.Request
{
    public class RabbitHanddlerRepository
    {
        private string host = @"http://localhost:15672/api/";
        private HttpClient _client;
        public RabbitHanddlerRepository(){
            this._client = new HttpClient();
            this._client.BaseAddress = new Uri(host);
            this._client.DefaultRequestHeaders.Add("Authorization", this.BasicAuthentiaction("guest","guest"));
        }

        public  HttpResponseMessage CreateExchange(){            
            return this._client.PutAsync("exchanges/%2f/hashed-consumer", null).Result;            
        }

        public HttpResponseMessage CreateBinding(){
            var content = new StringContent("{\"routing_key\":\"1\", \"arguments\":{\"x-arg\": \"value\"}}");
            return this._client.PostAsync("/api/bindings/%2f/e/hashed-consumer/q/hashed-consumer", content).Result;
        }

         public  HttpResponseMessage CreateQueue(string queueName){     
            var content = new StringContent("{\"auto_delete\":false,\"durable\":true,\"arguments\":{}}");
            return this._client.PutAsync($"queues/%2f/{queueName}", content).Result;            
        }

        private string BasicAuthentiaction(string name, string password){
            var enconded = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{name}:{password}"));            
            Console.WriteLine($"Basic {enconded}");
            return $"Basic {enconded}";
        }
        
    }
}