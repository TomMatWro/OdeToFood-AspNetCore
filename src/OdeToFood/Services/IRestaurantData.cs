using System.Collections.Generic;
using OdeToFood.Entities;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
    }
}