using ExploreMalleshwaram.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreMalleshwaram.Components
{
    public class TopPlacesViewComponent : ViewComponent
    {
        private readonly IPlaceRepository _placeRepository;
        public TopPlacesViewComponent(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var places = await _placeRepository.GetTopPlacesAsync(500);
            return View(places);
        }
    }
}
