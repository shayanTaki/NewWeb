using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace NewWeb.Models
{
    public class PlanningDBcontax : DbContext
    {
        public PlanningDBcontax()
        {
        }

        public PlanningDBcontax(DbContextOptions<ContaxDBlogin> options)
            : base(options)
        {
            //Database.SetCommandTimeout(900);
            //this.Database.SetCommandTimeout(90);
        }
        public virtual DbSet<VehicleModel> Tblvehicle { get; set; }
    }
}
