using Microsoft.EntityFrameworkCore;

namespace ShopAzure.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; } = null!;

        public virtual DbSet<Category> Categories { get; set; } = null!;
    }
}
