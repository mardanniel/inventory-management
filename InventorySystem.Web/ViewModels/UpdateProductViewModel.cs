using System.ComponentModel.DataAnnotations;
using InventorySystem.Web.Enums;

namespace InventorySystem.Web.ViewModels
{
    public class UpdateProductViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Status Status { get; set; }
    }
}