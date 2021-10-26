using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Api.Interfaces;
using Payment.Api.ViewModels;
using Payment.Avro.Schemas;
using System.Threading.Tasks;

namespace Payment.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentProducer _paymentProducer;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="paymentProducer"></param>
        public PaymentController(
            IPaymentProducer paymentProducer, 
            IMapper mapper
        )
        {
            _paymentProducer = paymentProducer;
            _mapper = mapper;
        }


        /// <summary>
        /// Produz uma mensagem de Payment.
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> AddPayment([FromBody] PaymentViewModel payment)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            var message = _mapper.Map<PaymentAvro>(payment);
            await _paymentProducer.ProducePaymentAsync(message, "payment");

            return Accepted();
        }
    }
}
