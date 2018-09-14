using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plutus.Context.Base;
using Plutus.Model.Entities;
using Plutus.Model.Entities.Mapping;

namespace Plutus.Context
{
    public class ReceiptContext : BaseContext<ReceiptContext>
    {
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        public ReceiptContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReceiptMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
        }
    }
}
