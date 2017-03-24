using System.Collections.Generic;
using System.Reflection.Metadata;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "XYZ"},
                new Restaurant {Id = 2, Name = "BezSmaku"}
            };
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _restaurants;
        }
    }
}