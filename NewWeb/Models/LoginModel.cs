using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewWeb.Models
{
    public class LoginModel
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string Users { get; internal set; }
    }
}
