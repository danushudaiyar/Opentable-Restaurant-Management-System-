using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTable.Models
{
    public class Metropolis
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Metropolis name is required")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;
        
        public ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}