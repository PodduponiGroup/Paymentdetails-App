using System.ComponentModel.DataAnnotations;

namespace PaymentDetails.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentDetailsId { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpiryDate { get; set; }

    }
}
