using AutoMapper;
using Payment.Api.ViewModels;
using Payment.Avro.Schemas;

namespace Payment.Api.Mapping
{
    public class ViewModelToAvro : Profile
    {
        public ViewModelToAvro()
        {
            CreateMap<PaymentViewModel, PaymentAvro>()
                //.ForMember(pvm => pvm.name, output => output.MapFrom(pa => pa.Name))
                //.ForMember(pvm => pvm.price, output => output.MapFrom(pa => pa.Price))
                .ReverseMap();
        }
    }
}
