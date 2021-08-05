using ExploreMalleshwaram.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExploreMalleshwaram.Repository
{
    public interface IPlaceRepository
    {
        Task<int> AddNewPlace(PlaceModel model);
        Task<List<PlaceModel>> GetAllPlaces();
        Task<PlaceModel> GetPlaceById(int id);
        Task<List<PlaceModel>> GetTopPlacesAsync(int count);
        List<PlaceModel> SearchPlace(string PlaceName, string PlaceCategory);

        string GetAppName();
    }
}