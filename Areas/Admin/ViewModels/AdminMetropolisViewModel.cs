using OpenTable.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTable.Areas.Admin.ViewModels
{
    public class AdminMetropolisViewModel
    {
        public Metropolis CurrentMetropolis { get; set; } = new Metropolis();
        public IEnumerable<Metropolis> Metropolises { get; set; } = new List<Metropolis>();
        
        // Optional: Add view-specific properties
        public string CurrentView { get; set; } = "List";
        
        // Optional: Add static options if needed for dropdowns
        public static Dictionary<string, string> StatusOptions => new()
        {
            {"active", "Active"},
            {"inactive", "Inactive"}
        };
    }
}