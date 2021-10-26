using Confluent.Kafka;
using Payment.Api.Interfaces;
using System;
using System.Text;
using System.Threading.Tasks;
using Payment.Avro.Schemas;

namespace Payment.Api.Bus
{
	public class PaymentProducer : IPaymentProducer
	{
		private const string _topic = "payment";

		private readonly Lazy<IProducer<string, PaymentAvro>> _producer;

		/// <summary>
		/// Construtor.
		/// </summary>
		/// <param name="producerBuilder"></param>
		public PaymentProducer(
			IProducerBuilder<PaymentAvro> producerBuilder
		)
		{
			_producer = new Lazy<IProducer<string, PaymentAvro>>(() => producerBuilder.Build());
		}

        /// <summary>
        /// Envia uma mensagem a partir do esquema TAvro.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task ProducePaymentAsync(PaymentAvro message, string key)
		{
			var producedMessage = MakeMessage(message, key);
			await _producer.Value.ProduceAsync(_topic, producedMessage);
		}

		/// <summary>
		/// Cria um objeto de Message com o objeto de TAvro.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		private static Message<string, PaymentAvro> MakeMessage(PaymentAvro message, string key)
        {
			var messageType = message.GetType().AssemblyQualifiedName;

			return new Message<string, PaymentAvro>
			{
				Key = key,
				Value = message,
				Headers = new Headers
				{
					{ "message-type", Encoding.UTF8.GetBytes(messageType) }
				}
			};
		}

		/// <summary>
		/// Libera recursos.
		/// </summary>
		public void Dispose()
		{
			if (_producer.IsValueCreated)
				_producer.Value.Dispose();
		}
	}
}
