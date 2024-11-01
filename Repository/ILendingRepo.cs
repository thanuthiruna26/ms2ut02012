using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public interface ILendingRepo
    {
        IEnumerable<Lending> GetAll();
        Lending GetById(int LendingId);
        void Add(Lending Lending);
        void Update(Lending Lending);
        void Delete(int LendingId);
    }
}
