using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreMalleshwaram.Models
{
    public class PlaceModel
    {

        [Key]
        [Display(Name = "Place Id")]
        [Required]
        public int PlaceId { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage ="Please choose a category")]
        public string PlaceCategory { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage ="Please enter a name")]
        public string PlaceName { get; set; }

        [Display(Name = "PlaceTagLine")]
        [Required(ErrorMessage = "Please choose a Tag Line")]
        public string PlaceTagLine { get; set; }

        [Required(ErrorMessage = "Please enter few details about the place")]
        [Display(Name = "Description")]
        public string PlaceDescription { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please enter the address")]
        public string PlaceAddress { get; set; }

        [Display(Name = "Choose a picture of the place")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose the gallery images of the place")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }
    }
}
