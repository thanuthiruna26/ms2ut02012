namespace WebApplication1.Database
{
    public class BorrowingReport
    {
        public int LendingId { get; set; }
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
