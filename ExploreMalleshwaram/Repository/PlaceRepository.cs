using ExploreMalleshwaram.Data;
using ExploreMalleshwaram.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreMalleshwaram.Repository
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly ExploreMalleshwaramContext _context = null;

        public PlaceRepository(ExploreMalleshwaramContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewPlace(PlaceModel model)
        {
            var newPlace = new Places()
            {
                PlaceCategory = model.PlaceCategory,
                PlaceName = model.PlaceName,
                PlaceAddress = model.PlaceAddress,
                PlaceTagLine = model.PlaceTagLine,
                PlaceDescription = model.PlaceDescription,
                CoverImageUrl = model.CoverImageUrl
            };

            newPlace.PlaceGallery = new List<PlaceGallery>();

            foreach (var file in model.Gallery)
            {
                newPlace.PlaceGallery.Add(new PlaceGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Places.AddAsync(newPlace);
            await _context.SaveChangesAsync();

            return newPlace.PlaceId;
        }
        public async Task<List<PlaceModel>> GetAllPlaces()
        {
            return await _context.Places
                .Select(place => new PlaceModel()
                {
                    PlaceId = place.PlaceId,
                    PlaceCategory = place.PlaceCategory,
                    PlaceName = place.PlaceName,
                    PlaceAddress = place.PlaceAddress,
                    PlaceTagLine = place.PlaceTagLine,
                    PlaceDescription = place.PlaceDescription,
                    CoverImageUrl = place.CoverImageUrl
                }).ToListAsync();
        }

        public async Task<List<PlaceModel>> GetTopPlacesAsync(int count)
        {
            return await _context.Places
                .Select(place => new PlaceModel()
                {
                    PlaceId = place.PlaceId,
                    PlaceCategory = place.PlaceCategory,
                    PlaceName = place.PlaceName,
                    PlaceAddress = place.PlaceAddress,
                    PlaceTagLine = place.PlaceTagLine,
                    PlaceDescription = place.PlaceDescription,
                    CoverImageUrl = place.CoverImageUrl
                }).Take(count).ToListAsync();
        }


        public async Task<PlaceModel> GetPlaceById(int id)
        {
            return await _context.Places.Where(x => x.PlaceId == id)
                .Select(place => new PlaceModel()
                {
                    PlaceId = place.PlaceId,
                    PlaceCategory = place.PlaceCategory,
                    PlaceName = place.PlaceName,
                    PlaceAddress = place.PlaceAddress,
                    PlaceDescription = place.PlaceDescription,
                    PlaceTagLine = place.PlaceTagLine,
                    CoverImageUrl = place.CoverImageUrl,
                    Gallery = place.PlaceGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList()
                }).FirstOrDefaultAsync();

        }

        public List<PlaceModel> SearchPlace(string PlaceName, string PlaceCategory)
        {
            return null;
        }

        public string GetAppName()
        {
            return "Explore Malleswaram";
        }

        

        
    }
}
