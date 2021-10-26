using AutoMapper;
using Payment.Api.ViewModels;
using Payment.Avro.Schemas;

namespace Payment.Api.Mapping
{
    public class ViewModelToAvro : Profile
    {
        public ViewModelToAvro()
        {
            CreateMap<PaymentViewModel, PaymentAvro>().ReverseMap();
        }
    }
}
