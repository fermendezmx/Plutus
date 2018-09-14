using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plutus.Context.Base;
using Plutus.Model.Entities;
using Plutus.Model.Entities.Mapping;

namespace Plutus.Context
{
    public class CategoryContext : BaseContext<CategoryContext>
    {
        public virtual DbSet<Category> Categories { get; set; }

        public CategoryContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
