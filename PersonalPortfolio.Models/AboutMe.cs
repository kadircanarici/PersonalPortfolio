using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPortfolio.Models
{
    [Table("AboutMe")]
    public class AboutMe:ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string CurvedText { get; set; }
    }
}
