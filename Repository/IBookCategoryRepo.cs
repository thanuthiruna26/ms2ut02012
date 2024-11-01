using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public interface IBookCategoryRepo
    {
        IEnumerable<BookCategories> GetAll();
        BookCategories GetById(int CategoryId);
        void Add(BookCategories BookCategories);
        void Update(BookCategories BookCategories);
        void Delete(int CategoryId);
    }
}
