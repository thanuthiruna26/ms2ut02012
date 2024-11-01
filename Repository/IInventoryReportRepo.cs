using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public interface IInventoryReportRepo
    {
        IEnumerable<InventoryReport> GetAll();
        InventoryReport GetById(int BookId);
        void Add(InventoryReport InventoryReport);
        void Update(InventoryReport InventoryReport);
        void Delete(int BookId);
    }
}
