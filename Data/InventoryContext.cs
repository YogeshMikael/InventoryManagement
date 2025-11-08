using System;
using InventoryManagementApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementApplication.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options):base(options)
        {
        }

        // Example DbSet – add more as you create models
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<UserValidation> Users { get; set; } = null!;
    }
}

