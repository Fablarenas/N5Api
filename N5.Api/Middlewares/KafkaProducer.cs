namespace N5.Api.Middlewares
{
    using Confluent.Kafka;
    using System;
    using System.Threading.Tasks;

    public class KafkaProducer
    {
        private readonly IProducer<Null, string> _producer;
        private readonly string _topic;

        public KafkaProducer(string bootstrapServers, string topic)
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<Null, string>(config).Build();
            _topic = topic;
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                var result = await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
                Console.WriteLine($"Delivered '{result.Value}' to '{result.TopicPartitionOffset}'");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Failed to deliver message: {e.Message} [{e.Error.Code}]");
            }
        }
    }

}
