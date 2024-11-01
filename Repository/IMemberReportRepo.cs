using WebApplication1.Database;

namespace WebApplication1.Repository
{
    public interface IMemberReportRepo
    {
        IEnumerable<MemberReport> GetAll();
        MemberReport GetById(int MemberId);
        void Add(MemberReport MembersReport);
        void Update(MemberReport MembersReport);
        void Delete(int MemberId);
    }
}
