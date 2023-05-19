using System.ComponentModel.DataAnnotations;

namespace InventorySystem.Web.ViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Double Price { get; set; }

        [Required]
        public string Description { get; set; }
    }
}