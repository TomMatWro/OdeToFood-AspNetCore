using System.Collections.Generic;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        List<Restaurant> GetAllRestaurants();
    }
}