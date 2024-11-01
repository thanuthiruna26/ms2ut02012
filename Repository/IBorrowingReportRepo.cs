using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public interface IBorrowingReportRepo
    {
        IEnumerable<BorrowingReport> GetAll();
        BorrowingReport GetById(int BorrowingReportId);
        //void Add(BorrowingReport borrowingReport);
        //void Update(BorrowingReport borrowingReport);
        //void Delete(int BorrowingReportid);
    }
}
