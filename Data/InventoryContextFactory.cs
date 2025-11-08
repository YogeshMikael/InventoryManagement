using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace InventoryManagementApplication.Data
{
    public class InventoryContextFactory : IDesignTimeDbContextFactory<InventoryContext>
    {
        public InventoryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryContext>();

            // Use your PostgreSQL connection string
            optionsBuilder.UseNpgsql("Host=localhost;Database=inventorydb;Username=elijah;Password=181999");

            return new InventoryContext(optionsBuilder.Options);
        }
    }
}
