using HW_Week13_End.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week13_End.Contracts
{
    public interface ILibrarianRepository
    {
        void Create(Librarian librarian);
        List<Librarian> GetAll();
    }
}
