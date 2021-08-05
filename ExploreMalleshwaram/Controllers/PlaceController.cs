using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExploreMalleshwaram.Data;
using ExploreMalleshwaram.Models;
using ExploreMalleshwaram.Repository;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ExploreMalleshwaram.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceRepository _placeRepository = null;
        private readonly ExploreMalleshwaramContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PlaceController(IPlaceRepository placeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _placeRepository = placeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //   [Route("all-places")]
        public async Task<ViewResult> GetAllPlaces()
        {
            var data = await _placeRepository.GetAllPlaces();
            return View(data);
        }

        //  [Route("place-details/{id:int:min(1)}", Name = "placeDetailsRoute")]
        public async Task<ViewResult> GetPlace(int id)
        {
            var data = await _placeRepository.GetPlaceById(id);
            return View(data);
        }


        public List<PlaceModel> SearchPlaces(string placeName, string placeCategory)
        {
            return _placeRepository.SearchPlace(placeName, placeCategory);
        }

        [Authorize]
        public async Task<ViewResult> AddNewPlace(bool isSuccess = false, int placeId = 0)
        {
            var model = new PlaceModel();

            ViewBag.IsSuccess = isSuccess;
            ViewBag.PlaceId = placeId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPlace(PlaceModel placeModel)
        {
            if (ModelState.IsValid)
            {
                if (placeModel.CoverPhoto != null)
                {
                    string folder = "places/cover/";
                    placeModel.CoverImageUrl = await UploadImage(folder, placeModel.CoverPhoto);
                }

                if (placeModel.GalleryFiles != null)
                {
                    string folder = "places/gallery/";

                    placeModel.Gallery = new List<GalleryModel>();

                    foreach (var file in placeModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        placeModel.Gallery.Add(gallery);

                    }
                }

                int id = await _placeRepository.AddNewPlace(placeModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewPlace), new { isSuccess = true, placeId = id });
                }
            }

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }



    }
}
