using Confluent.Kafka;

namespace Payment.Api.Settings
{
	public class ProducerSettings
	{
		public string BootstrapServer { get; set; }
		public string SchemaRegistryUrl { get; set; }
		public Acks Acks { get; set; }
		public bool EnableIdempotence { get; set; }
		public int MessageSendMaxRetries { get; set; }
		public int MaxInFlight { get; set; }
		public CompressionType CompressionType { get; set; }
		public int LingerMs { get; set; }
		public int BatchSizeKB { get; set; }
		public int AvroBufferBytes { get; set; }
	}
}
