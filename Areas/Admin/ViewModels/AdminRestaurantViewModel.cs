using OpenTable.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTable.Areas.Admin.ViewModels
{
    public class AdminRestaurantViewModel
    {
        public Restaurant CurrentRestaurant { get; set; } = new Restaurant();
        public IEnumerable<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public IEnumerable<Metropolis> Metropolises { get; set; } = new List<Metropolis>();
        
        public string SelectedMetropolis { get; set; } = "all";
        public string SelectedPriceRange { get; set; } = "all";
        public string SelectedCuisine { get; set; } = "all";
        
        public static Dictionary<string, string> PriceRanges => new()
        {
            {"$", "Budget ($)"},
            {"$$", "Moderate ($$)"},
            {"$$$", "Expensive ($$$)"},
            {"$$$$", "Luxury ($$$$)"}
        };

        public static Dictionary<string, string> CuisineStyles => new()
        {
            {"american", "American"},
            {"french", "French"},
            {"italian", "Italian"},
            {"mexican", "Mexican"}, 
            {"japanese", "Japanese"},
            {"chinese", "Chinese"},
            {"indian", "Indian"},
            {"mediterranean", "Mediterranean"}
        };
    }
}