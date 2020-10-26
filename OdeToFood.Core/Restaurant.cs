using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required, StringLength(80)]
        public string Location { get; set; }
        [Required]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
