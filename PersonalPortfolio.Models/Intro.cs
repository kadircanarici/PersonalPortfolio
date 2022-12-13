using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalPortfolio.Models
{
    [Table("Intros")]
    public class Intro:ModelBase
    {
        public string TitleStart { get; set; }
        public string TitleMidLine { get; set; }
        public string TitleEnd { get; set; }
        public string Content { get; set; }
    }
}
