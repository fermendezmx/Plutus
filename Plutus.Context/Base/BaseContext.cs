using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Plutus.Context.Base
{
    public class BaseContext<TContext> : DbContext where TContext : DbContext
    {
        private string _connection;

        public BaseContext() { }

        public BaseContext(IConfiguration configuration)
        {
            _connection = configuration["DBConnection"];
        }

        public BaseContext(DbContextOptions<TContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connection);
            }
        }
    }
}
