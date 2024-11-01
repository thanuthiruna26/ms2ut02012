using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public interface IBooksRepo
    {
        IEnumerable<Books> GetAll();
        Books GetById(int BookId);
        void Add(Books Books);
        void Update(Books Books);
        void Delete(int BookId);

    }
}
