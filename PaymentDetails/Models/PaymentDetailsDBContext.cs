using Microsoft.EntityFrameworkCore;

namespace PaymentDetails.Models
{
    public class PaymentDetailsDBContext : DbContext
    {
        public PaymentDetailsDBContext(DbContextOptions<PaymentDetailsDBContext> options) : base(options)
        {
        }

       public DbSet<PaymentDetails> PaymentDetails { get; set; }

    }
}
