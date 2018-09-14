using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plutus.Context.Base;
using Plutus.Model.Entities;
using Plutus.Model.Entities.Mapping;

namespace Plutus.Context
{
    public class PaymentContext : BaseContext<PaymentContext>
    {
        public virtual DbSet<Payment> Payments { get; set; }

        public PaymentContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentMap());
        }
    }
}
