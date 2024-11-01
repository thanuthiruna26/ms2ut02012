namespace WebApplication1.DTO.Books
{
    public class BookRequest
    {
     
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public DateTime PublicationDate { get; set; }
            public int TotalCopies { get; set; }
      

    }
}
