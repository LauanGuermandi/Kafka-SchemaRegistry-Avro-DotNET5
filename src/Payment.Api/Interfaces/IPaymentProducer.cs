using Payment.Avro.Schemas;
using System.Threading.Tasks;

namespace Payment.Api.Interfaces
{
    public interface IPaymentProducer
    {
        Task ProducePaymentAsync(PaymentAvro message, string key);
    }
}
