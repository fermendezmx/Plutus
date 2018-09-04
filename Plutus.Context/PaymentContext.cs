using Microsoft.EntityFrameworkCore;
using Plutus.Context.Base;
using Plutus.Model.Entities;
using Plutus.Model.Entities.Mapping;

namespace Plutus.Context
{
    public class PaymentContext : BaseContext<PaymentContext>
    {
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PaymentMap());
        }
    }
}
