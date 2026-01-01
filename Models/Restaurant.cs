using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenTable.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Restaurant name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int MetropolisId { get; set; }

        [ForeignKey("MetropolisId")]
        public Metropolis? Metropolis { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Price range is required")]
        public string PriceRange { get; set; } = string.Empty; // $, $$, $$$, $$$$

        [Required(ErrorMessage = "Cuisine style is required")]
        public string CuisineStyle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Open hours are required")]
        public string OpenHours { get; set; } = string.Empty; // "11:00-14:00,17:00-21:00"
    }
}