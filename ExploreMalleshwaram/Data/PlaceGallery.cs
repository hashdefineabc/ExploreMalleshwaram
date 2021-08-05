using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreMalleshwaram.Data
{
    public class PlaceGallery
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public Places Place { get; set; }
    }
}
