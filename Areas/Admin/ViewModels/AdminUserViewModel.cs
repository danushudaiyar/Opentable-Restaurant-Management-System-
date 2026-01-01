// Areas/Admin/ViewModels/AdminUserViewModel.cs
using OpenTable.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenTable.Areas.Admin.ViewModels
{
    public class AdminUserViewModel
    {
        public User CurrentUser { get; set; } = new User();
        public IEnumerable<User> Users { get; set; } = new List<User>();
        
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string? ConfirmPassword { get; set; }
    }
}