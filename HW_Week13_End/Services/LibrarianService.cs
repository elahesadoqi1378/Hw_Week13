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
    public class LibrarianService
    {
        private readonly ILibrarianRepository librarianRepository;
        public LibrarianService()
        {
            librarianRepository = new LibrarianRepository();
        }
        public void Create(string username, string password)

        {
            var librarian = new Librarian

            {
                UserName = username,
                Password = password
            };

            librarianRepository.Create(librarian);
        }
        public void Register(string username, string password,UserRole role)
        {
            var librarian = new Librarian
            {
                UserName = username,
                Password = password,
                Role = role


            };
            librarianRepository.Create(librarian);
        }
        public List<Librarian> GetAll()
        {
            return librarianRepository.GetAll();
        }

    }
}
