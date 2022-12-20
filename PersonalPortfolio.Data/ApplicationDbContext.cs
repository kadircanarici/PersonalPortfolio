using Microsoft.EntityFrameworkCore;
using PersonalPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPortfolio.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) { }
        public DbSet<Intro> Intros { get; set; }
        public DbSet<AboutMe> AboutMe { get; set; }





    }
}
