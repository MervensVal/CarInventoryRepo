using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventoryAPI.Models
{
    public class Car
    {
        public Guid CarID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
