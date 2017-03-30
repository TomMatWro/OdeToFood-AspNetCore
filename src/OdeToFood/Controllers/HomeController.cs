using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantsData;
        private IGreeter _greeter;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            var newRestaurant = new Restaurant
            {
                Cuisine = model.Cuisine,
                Name = model.Name
            };

            newRestaurant = _restaurantsData.Add(newRestaurant);

            return View("Details", newRestaurant);
        }
           
     }
}