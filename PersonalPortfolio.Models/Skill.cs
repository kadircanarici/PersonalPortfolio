using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPortfolio.Models
{
    public class Skill:ModelBase
    {
        public string? Title { get; set; }
        public string? Name { get; set; }
        public int? Column { get; set; }
    }
}
