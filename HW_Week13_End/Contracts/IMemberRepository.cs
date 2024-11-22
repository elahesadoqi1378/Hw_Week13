
using HW_Week13_End.Entities;
using HW_Week13_End.Enums;

namespace HW_Week13_End.Contracts
{
    public interface IMemberRepository
    {
        void Create(Member member);
        Member GetById(int id);
        List<Member> GetAll();
        Member Login(string username, string password,UserRole role);
    }
}
