namespace WebApplication1.Database
{
    public class Books
    {
        public int BookId { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
    }
}

