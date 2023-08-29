using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace NewWeb.Models
{
    public class ContaxTopCoat : DbContext
    {
        public ContaxTopCoat()
        {
        }

        public ContaxTopCoat(DbContextOptions<ContaxTopCoat> options)
            : base(options)
        {
            //Database.SetCommandTimeout(900);
            //this.Database.SetCommandTimeout(90);
        }
        public virtual DbSet<TopCoatModel> TblTopCoat { get; set; }
    }

}
