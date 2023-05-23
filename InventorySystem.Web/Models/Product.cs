using System.ComponentModel.DataAnnotations;
using InventorySystem.Web.Enums;

namespace InventorySystem.Web.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MMMM dd, yyyy}")]
        public DateTime UpdatedAt { get; set; }
    }
}