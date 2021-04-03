using System.Text.Json;

namespace NetSampleArch.Infra.CrossCutting.Configuration
{
    public class Configuration
    {
        public static JsonSerializerOptions JsonSerializerOptions => new JsonSerializerOptions(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        
        public ElasticConfiguration ElasticConfiguration { get; set; }
        public SqlConfiguration SqlConfiguration { get; set; }
        public MongoConfiguration MongoConfiguration { get; set; }
        public KafkaConfiguration KafkaConfig { get; set; }
    }
}