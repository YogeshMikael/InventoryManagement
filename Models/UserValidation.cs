using System;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApplication.Models
{
	public class UserValidation
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}

