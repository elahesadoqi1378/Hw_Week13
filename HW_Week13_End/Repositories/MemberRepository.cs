using HW_Week13_End.Contracts;
using HW_Week13_End.Entities;
using HW_Week13_End.InfraStracture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HW_Week13_End.Enums;

namespace HW_Week13_End.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        AppDBContext appDBContext;
        public MemberRepository()
        {
            appDBContext = new AppDBContext();
            //appDBContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Create(Member member)
        {
            appDBContext.Members.Add(member);
            appDBContext.SaveChanges();
        }

        public Member GetById(int id)
        {
            appDBContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var member = appDBContext.Members.FirstOrDefault(m => m.Id == id);
            if (member is not null)
            {
                return member;
            }
            else
            {
                throw new Exception("can not find ,member with id " + member.Id);
            }
        }

        public List<Member> GetAll()
        {
            appDBContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return appDBContext.Members.ToList();
        }

        public Member Login(string username, string password,UserRole role)
        {
            var member = appDBContext.Members.FirstOrDefault(m => m.UserName == username && m.Password == password);
            if (member == null)
                throw new Exception("Invalid username or password.");
            return member;
        }
    }
}
