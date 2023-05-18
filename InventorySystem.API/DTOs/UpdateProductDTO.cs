using InventorySystem.API.Enums;

namespace InventorySystem.API.DTOs
{
    public class UpdateProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}