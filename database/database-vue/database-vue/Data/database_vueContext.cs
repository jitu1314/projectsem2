using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using database_vue.Model;

namespace database_vue.Data
{
    public class database_vueContext : DbContext
    {
        public database_vueContext (DbContextOptions<database_vueContext> options)
            : base(options)
        {
        }

        public DbSet<database_vue.Model.Product> Product { get; set; }

        public DbSet<database_vue.Model.Comment> Comment { get; set; }
    }
}
