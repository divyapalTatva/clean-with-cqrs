namespace CleanCQRS.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        // Navigation
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
