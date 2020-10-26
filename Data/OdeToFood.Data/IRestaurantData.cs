using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string restaurantName);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant restaurant);
        int Commit();
    }
        public class InMemoryRestaurantData : IRestaurantData
        {
            readonly List<Restaurant> restaurants;
            public InMemoryRestaurantData()
            {
                restaurants = new List<Restaurant>()
                {
                    new Restaurant{ Id=0, Name = "U Wojtka", Location="Kuźniki", Cuisine = CuisineType.Indian},
                    new Restaurant{ Id=1, Name = "Senior Gomez", Location="Kowale", Cuisine = CuisineType.Mexiacan},
                    new Restaurant{ Id=2, Name = "Smakosz", Location="Maryland", Cuisine = CuisineType.Italian},
                };
            }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id)+1;
            return restaurant;

        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
           
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string restaurantName = null)
        {
                var rest = from r in restaurants
                           where string.IsNullOrEmpty(restaurantName) || r.Name.ToLower().Contains(restaurantName.ToLower())
                           orderby r.Name
                           select r;
                return rest;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
                restaurant.Location = updatedRestaurant.Location;
            }
            return restaurant;
        }
    }
    
}
 