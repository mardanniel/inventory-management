using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.API.DTOs
{
    public class LoginUserDTO
    {
        [DisplayName("Username/Email Address")]
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}