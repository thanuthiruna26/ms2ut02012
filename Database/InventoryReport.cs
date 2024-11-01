namespace WebApplication1.Database
{
    public class InventoryReport
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
    }
}
