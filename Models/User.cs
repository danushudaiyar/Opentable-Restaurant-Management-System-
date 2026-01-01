using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTable.Models
{
public class User
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Username is required")]
    [StringLength(50)]
    public string Username { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Role is required")]
    public string Role { get; set; } = string.Empty; // admin, manager, customer
}
}