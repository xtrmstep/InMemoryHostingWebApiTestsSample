using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiTestsSample.Models
{
    public class ApiDataContext : DbContext
    {
        public DbSet<Item> Items
        {
            get;
            set;
        }
    }
}