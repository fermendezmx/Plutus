using Microsoft.EntityFrameworkCore;
using Plutus.Context.Base;
using Plutus.Model.Entities;
using Plutus.Model.Entities.Mapping;

namespace Plutus.Context
{
    public class AccountContext : BaseContext<AccountContext>
    {
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PaymentMap());
            modelBuilder.ApplyConfiguration(new ReceiptMap());
        }
    }
}
