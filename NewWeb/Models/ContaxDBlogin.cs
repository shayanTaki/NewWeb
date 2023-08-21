using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace NewWeb.Models
{
    public class ContaxDBlogin : DbContext
    {
        public ContaxDBlogin()
        {
        }

        public ContaxDBlogin(DbContextOptions<ContaxDBlogin> options)
            : base(options)
        {
            //Database.SetCommandTimeout(900);
            //this.Database.SetCommandTimeout(90);
        }
        public virtual DbSet<LoginModel> tblogin { get; set; }
    }
}
