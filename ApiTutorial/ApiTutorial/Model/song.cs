using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTutorial.Model
{
    public class song
    {
        public int Id { get; set; }
       
        public string Title { get; set; }
        public string language { get; set; }
        public int artistId { get; set; }
        public int? albumId { get; set; }
    }
}
