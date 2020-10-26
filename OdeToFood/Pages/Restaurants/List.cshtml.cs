using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IConfiguration Configuration { get; }
        public IRestaurantData RestaurantData { get; }

        public List<Restaurant> restaurantsList;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData )
        {
            Configuration = configuration;
            RestaurantData = restaurantData;
        }
        public void OnGet()
        {
            restaurantsList = RestaurantData.GetRestaurantsByName(SearchTerm).ToList(); ;

            Message = Configuration["Message"];


        }
    }
}