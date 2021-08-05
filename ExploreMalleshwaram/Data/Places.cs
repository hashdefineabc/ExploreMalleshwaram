using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreMalleshwaram.Data
{
    public class Places
    {
        [Key]
        public int PlaceId { get; set; }
        public string PlaceCategory { get; set; }
        public string PlaceName { get; set; }
        public string PlaceTagLine { get; set; }

        public string PlaceDescription { get; set; }
        public string PlaceAddress { get; set; }

        public string CoverImageUrl { get; set; }

        public ICollection<PlaceGallery> PlaceGallery { get; set; }
    }
}
