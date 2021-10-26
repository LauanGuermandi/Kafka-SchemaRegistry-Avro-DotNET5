using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Payment.Api.Mapping;

namespace Payment.Api.Configuration
{
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Configuração dos profiles do AutoMapper.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ViewModelToAvro());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
