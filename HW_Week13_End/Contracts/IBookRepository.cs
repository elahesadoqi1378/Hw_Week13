
using HW_Week13_End.Entities;

namespace HW_Week13_End.Contracts
{
    public interface IBookRepository
    {
        void Create(Book book);
        Book GetById(int id);
        List<Book> GetAll();
        void Update(int id, Book book);
        void Delete(int id);

    }
}
