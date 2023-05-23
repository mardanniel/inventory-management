using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Web.ViewModels
{
    public class LoginUserViewModel
    {
        [DisplayName("Username/Email Address")]
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}