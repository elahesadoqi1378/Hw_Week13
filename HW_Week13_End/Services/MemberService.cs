using HW_Week13_End.Contracts;
using HW_Week13_End.Entities;
using HW_Week13_End.Enums;
using HW_Week13_End.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week13_End.Services
{
    public class MemberService
    {
        private readonly IMemberRepository memberRepository;
        public MemberService()
        {
            memberRepository = new MemberRepository();
        }

        public void Register(string username, string password, UserRole role)
        {

            if (memberRepository.GetAll().Any(m => m.UserName == username))

            {
                throw new Exception("Username already exists.Please choose a different username.");
            }

            var member = new Member
            {
                UserName = username,
                Password = password,
                Role = role

            };
            memberRepository.Create(member);
        }
        public Member Login(string username, string password,UserRole role)
        {
            return memberRepository.Login(username, password,role);
        }
        public List<Member> GetAll()
        {
            return memberRepository.GetAll();

        }



    }
}
