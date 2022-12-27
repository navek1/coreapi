using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial.Model
{
    public class artist
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Gender { get; set; }
        public ICollection<song> Songs { get; set; }
        public ICollection<album> Albums { get; set; }

    }
}
