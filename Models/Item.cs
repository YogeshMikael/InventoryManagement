using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApplication.Models
{
	public class Item
	{
        [Key]
        public int Id { get; set; }

        public  string? Name { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
	}
}

