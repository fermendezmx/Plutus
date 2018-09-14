using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plutus.Context.Base;
using Plutus.Model.Entities;
using Plutus.Model.Entities.Mapping;

namespace Plutus.Context
{
    public class AccountContext : BaseContext<AccountContext>
    {
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }

        public AccountContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
            modelBuilder.ApplyConfiguration(new ReceiptMap());
        }
    }
}
