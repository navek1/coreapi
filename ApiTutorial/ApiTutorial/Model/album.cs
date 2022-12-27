using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial.Model
{
    public class album
    {
        public int Id { get; set; }
        public string language { get; set; }

        public int year { get; set; }
        public int artistId { get; set; }
        public ICollection<song> Songs { get; set; }
    }
}
