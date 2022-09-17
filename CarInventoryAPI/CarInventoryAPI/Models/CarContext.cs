using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarInventoryAPI.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options): base(options)
        {

        }

        public DbSet<Car> Car { get; set;}
    }
}
