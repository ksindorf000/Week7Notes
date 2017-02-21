using Day2Server.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day2Server.Controllers
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cereal> Cereals { get; set; }
    }
}