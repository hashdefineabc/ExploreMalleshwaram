using ExploreMalleshwaram.Models;
using ExploreMalleshwaram.Service;
using LazZiya.ImageResize;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreMalleshwaram.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public HomeController(ILogger<HomeController> logger, IUserService userService, IEmailService emailService)
        {
            _logger = logger;
            _userService = userService;
            _emailService = emailService;
        }

        public ViewResult Index()
        {
            var img = Image.FromFile("wwwroot\\images\\Banner.png");
            var scaleImage = ImageResize.Scale(img, 100, 100);
            scaleImage.SaveAs("wwwroot\\images\\newBanner.png");

            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
