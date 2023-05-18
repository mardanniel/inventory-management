using InventorySystem.API.Enums;

namespace InventorySystem.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
