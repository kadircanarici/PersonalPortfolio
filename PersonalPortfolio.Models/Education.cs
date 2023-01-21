using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPortfolio.Models
{
    public class Education:ModelBase
    {
        public string? Year { get; set; }   
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
