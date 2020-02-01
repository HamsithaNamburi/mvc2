using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mvcproject.Models
{
    public class SubcategoryContext:DbContext
    {
        public SubcategoryContext(DbContextOptions<SubcategoryContext> options) : base(options)
        {

        }
        public DbSet<Subcategory> Subcategories { get; set; }
    }
}
