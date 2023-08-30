using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace NewWeb.Models
{
    public class CountaxStatusCar : DbContext
    
    {


        public CountaxStatusCar()
        {
        }

        public CountaxStatusCar(DbContextOptions<CountaxStatusCar> options)
            : base(options)
        {
            //Database.SetCommandTimeout(900);
            //this.Database.SetCommandTimeout(90);
        }
        public virtual DbSet<StatusCarModel> StatusCar { get; set; }

    }
}
