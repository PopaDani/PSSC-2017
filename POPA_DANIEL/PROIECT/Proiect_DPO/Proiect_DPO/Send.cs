using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proiect_DPO.Evenimente;
using RabbitMQ.Client;

namespace Proiect_DPO
{
    public class Send
    {
        public void TrimiteEveniment(Eveniment e)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                string message = JsonConvert.SerializeObject(e.Detalii).ToString();
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                //  Console.WriteLine(" [x] Sent {0}", message);
            }

        }
    }
}
