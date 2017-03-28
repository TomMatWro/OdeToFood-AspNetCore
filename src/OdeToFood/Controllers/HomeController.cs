using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
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

        public string Details(int id)
        {
            return id.ToString();
        }
           
     }
}