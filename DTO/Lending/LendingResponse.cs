namespace WebApplication1.DTO.Lending
{
    public class LendingResponse
    {
        public int LendingId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime LendingDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
