
using HW_Week13_End.Contracts;
using HW_Week13_End.Entities;
using HW_Week13_End.InfraStracture;
using Microsoft.EntityFrameworkCore;

namespace HW_Week13_End.Repositories
{
    public class BookRepository : IBookRepository
    {
        AppDBContext appDBContext;
        public BookRepository()
        {
            appDBContext = new AppDBContext();
           // appDBContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Create(Book book)
        {
            appDBContext.Books.Add(book);
            appDBContext.SaveChanges();
        }
        public Book GetById(int id)
        {
            appDBContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var book = appDBContext.Books.FirstOrDefault(b => b.Id == id);
            if (book is not null)
            {
                return book;
            }
            else
            {
                throw new Exception("can not find book with id " + book.Id);
            }
        }
        public List<Book> GetAll()
        {
            appDBContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return appDBContext.Books.ToList();
        }

        public void Update(int id, Book book)
        {
            var bookToEdit = appDBContext.Books.FirstOrDefault(b => b.Id == id);
            bookToEdit.Author = book.Author;
            bookToEdit.Title = book.Title;
            bookToEdit.IsBorrowed = book.IsBorrowed;
            bookToEdit.MemberId = book.MemberId;

            var x = appDBContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var bookToDelete = appDBContext.Books.FirstOrDefault(b => b.Id == id);
            if (bookToDelete is not null)
            {
                appDBContext.Remove(bookToDelete);
                appDBContext.SaveChanges();
            }
            else
            {
                throw new Exception("can not find book with id " + bookToDelete.Id);
            }

        }
    }
}
