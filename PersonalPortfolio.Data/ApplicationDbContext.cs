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
         public DbSet<IntroPhoto> introPhotos { get; set; }   
        public DbSet<User> users { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<Education> Education { get; set; }



    }
}
