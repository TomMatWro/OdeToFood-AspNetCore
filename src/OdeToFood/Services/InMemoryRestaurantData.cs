using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant {Id = 1, Name = "XYZ", Cuisine = CuisineType.Polish},
                new Restaurant {Id = 2, Name = "BezSmaku", Cuisine = CuisineType.Italian}
            };
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);

            return newRestaurant;
        }
    }
}