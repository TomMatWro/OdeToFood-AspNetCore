using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _restaurantsData;

        public HomeController(IRestaurantData restaurantsData)
        {
            _restaurantsData = restaurantsData;
        }

        public IActionResult Index()
        {
            var model = _restaurantsData.GetAllRestaurants();
            return View(model);
        }
           
     }
}