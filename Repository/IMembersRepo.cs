using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public interface IMembersRepo
    {
        IEnumerable<Members> GetAll();
        Members GetById(int MemberId);
        void Add(Members Members);
        void Update(Members Members);
        void Delete(int MemberId);
    }
}
