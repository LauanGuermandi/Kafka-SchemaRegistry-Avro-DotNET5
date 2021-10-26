using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using Microsoft.Extensions.Options;
using Payment.Api.Interfaces;
using Payment.Api.Settings;

namespace Payment.Api.Bus
{
	public class ProducerBuilder<TAvro> : IProducerBuilder<TAvro>
	{
		private readonly ProducerSettings _producerSettings;

        public ProducerBuilder(
			IOptions<ProducerSettings> producerSettings
		)
        {
            _producerSettings = producerSettings.Value;
        }

        /// <summary>
        /// Gera uma instâcia de de um producer.
        /// </summary>
        /// <returns></returns>
        public IProducer<string, TAvro> Build()
		{
			var schemaRegistry = new CachedSchemaRegistryClient(SchemaRegistryConfig);

			var producerBuilder = new ProducerBuilder<string, TAvro>(ProducerConfig)
										.SetKeySerializer(new AvroSerializer<string>(schemaRegistry, AvroSerializerConfig))
										.SetValueSerializer(new AvroSerializer<TAvro>(schemaRegistry, AvroSerializerConfig));

			return producerBuilder.Build();
		}

		/// <summary>
		/// Cria um objeto com configurações do Producer.
		/// </summary>
		/// <returns></returns>
		private ProducerConfig ProducerConfig =>
			new()
			{
				BootstrapServers = _producerSettings.BootstrapServer,
				Acks = _producerSettings.Acks,
				EnableIdempotence = _producerSettings.EnableIdempotence,
				MessageSendMaxRetries = _producerSettings.MessageSendMaxRetries,
				MaxInFlight = _producerSettings.MaxInFlight,
				CompressionType = _producerSettings.CompressionType,
				LingerMs = _producerSettings.LingerMs,
				BatchSize = _producerSettings.BatchSizeKB * 1024,
				Debug = "All"
			};

		/// <summary>
		/// Cria um objeto com configurações do SchemaRegistry.
		/// </summary>
		/// <returns></returns>
		private SchemaRegistryConfig SchemaRegistryConfig =>
			new()
			{
				Url = _producerSettings.SchemaRegistryUrl
			};

		/// <summary>
		/// Cria um objeto com configurações do AvroSerializer.
		/// </summary>
		/// <returns></returns>
		private AvroSerializerConfig AvroSerializerConfig =>
			new()
			{
				BufferBytes = _producerSettings.AvroBufferBytes
			};
	}
}
