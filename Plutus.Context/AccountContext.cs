using Microsoft.EntityFrameworkCore;
using Plutus.Context.Base;
using Plutus.Model.Entities;
using Plutus.Model.Entities.Mapping;

namespace Plutus.Context
{
    public class AccountContext : BaseContext<AccountContext>
    {
        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMap());
        }
    }
}
