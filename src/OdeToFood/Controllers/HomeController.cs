using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _restaurantsData;
        private readonly IGreeter _greeter;

        public HomeController(IRestaurantData restaurantsData, IGreeter greeter)
        {
            _restaurantsData = restaurantsData;
            _greeter = greeter;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Restaurants = _restaurantsData.GetAllRestaurants(),
                CurrentMessage = _greeter.GetGreeting()
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantsData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
           
     }
}