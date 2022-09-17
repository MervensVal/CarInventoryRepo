using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventoryAPI.Models
{
    public class Car
    {
        [Key]
        public Guid CarID { get; set; }
        
        [Required]
        [MaxLength(50,ErrorMessage = "Maxlength is 50 characters")]
        public string Make { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Maxlength is 50 characters")]
        public string Model { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "Maxlength is 500 characters")]
        public string Description { get; set; }

        [Required]
        [Range(0.00,5000000.00)]
        public double Price { get; set; }
    }
}
