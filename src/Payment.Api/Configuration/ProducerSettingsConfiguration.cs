using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Api.Settings;

namespace Payment.Api.Configuration
{
    public static class ProducerSettingsConfiguration
    {
        /// <summary>
        /// Carrega as configurações do producer.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void LoadProducerSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var producerSettingsSection = configuration.GetSection(nameof(ProducerSettings));
            services.Configure<ProducerSettings>(producerSettingsSection);
        }
    }
}
