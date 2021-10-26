using Confluent.Kafka;

namespace Payment.Api.Interfaces
{
    public interface IProducerBuilder<TAvro>
    {
        IProducer<string, TAvro> Build();
    }
}
