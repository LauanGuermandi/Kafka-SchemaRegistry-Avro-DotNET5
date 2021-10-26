using Microsoft.Extensions.DependencyInjection;
using Payment.Api.Bus;
using Payment.Api.Interfaces;

namespace Payment.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        /// <summary>
        /// Configura a injeção de dependências
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IProducerBuilder<>), typeof(ProducerBuilder<>));
            services.AddSingleton(typeof(IPaymentProducer), typeof(PaymentProducer));
        }
    }
}
