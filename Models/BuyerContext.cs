using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mvcproject.Models;
using Microsoft.EntityFrameworkCore;

namespace Mvcproject.Models
{
    public class BuyerContext:DbContext
    {
        public BuyerContext(DbContextOptions<BuyerContext> options) : base(options)
        {

        }
        public DbSet<Buyer> Buyers { get; set; }

    }
}
