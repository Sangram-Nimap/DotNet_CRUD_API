namespace crud.DTOs
{
    public class OrderDto
    {
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; } // To store ordered product IDs
    }
}
