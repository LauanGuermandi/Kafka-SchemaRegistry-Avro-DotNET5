using System.ComponentModel.DataAnnotations;

namespace Payment.Api.ViewModels
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "O campo 'Name' é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo 'Price' é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public double Price { get; set; }
    }
}
