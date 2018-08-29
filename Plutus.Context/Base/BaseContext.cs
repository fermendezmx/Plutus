using Microsoft.EntityFrameworkCore;

namespace Plutus.Context.Base
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions<TContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=FERNANDOMENDEZ\\SQLEXPRESS;Initial Catalog=plutus-dev;Integrated Security=True");
            }
        }
    }
}
