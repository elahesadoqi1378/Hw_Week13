
using HW_Week13_End.Contracts;
using HW_Week13_End.Entities;
using HW_Week13_End.Repositories;

namespace HW_Week13_End.Services
{
    public class BookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMemberRepository memberRepository;
        public BookService()
        {
            bookRepository = new BookRepository();
            memberRepository = new MemberRepository();
        }
        public void Create(string title, string author  )  
        {
            var book = new Book
            {
                Title = title,
                Author = author,
                IsBorrowed = false
            };
            bookRepository.Create(book);
        }
        public Book GetById(int id)
        {
            return bookRepository.GetById(id);
        }
        public List<Book> GetAll()
        {
            return bookRepository.GetAll();
        }
        public void Update(int id, Book book)
        {
            bookRepository.Update(id, book);
        }
        public void Delete(int id)
        {
            bookRepository.Delete(id);
        }
        public void BorrowBook(int id, int memberId)
        {
            var book = bookRepository.GetById(id);
            var member = memberRepository.GetById(memberId);

            if (book != null && book.IsBorrowed == false)
            {
                book.IsBorrowed = true;
                book.MemberId = memberId;
                book.BorrowedDate = DateTime.Now;
                book.ReturnDate = DateTime.Now.AddDays(30);
                member.BorrowedBooks.Add(book);
                bookRepository.Update(id, book);
                
            }
            else
            {
                throw new Exception("book is already borrowed or unavailable");
            }
        }
        public void ReturnBook(int id)
        {
            var book = bookRepository.GetById(id);
            
            if (book is not null && book.IsBorrowed == true)
            {
                var member = memberRepository.GetById(book.MemberId.Value);
                book.IsBorrowed = false;
                book.MemberId = null;
                book.BorrowedDate = null;
                book.ReturnDate = null;
                member.BorrowedBooks.Remove(book);

                bookRepository.Update(id, book);
            }
            else
            {
                throw new Exception("book is not borrowed");
            }

        }
        public void ExtendDueDate(int bookId, int additionalDays)
        {
            var book = bookRepository.GetById(bookId);
            if (book != null && book.IsBorrowed)
            {
                book.ReturnDate = book.ReturnDate.Value.AddDays(additionalDays);
                bookRepository.Update(book.Id, book);
                Console.WriteLine($"The due date for '{book.Title}' has been extended by {additionalDays} days.");
            }
            else
            {
                throw new Exception("The book is either not borrowed or doesn't exist.");
            }
        }
        public void ViewBorrowedBooks(int memberId)
        {
            var member = memberRepository.GetById(memberId);
            if (member != null)
            {
                foreach (var book in member.BorrowedBooks)
                {
                    var overdueStatus = book.ReturnDate < DateTime.Now ? "Overdue" : "On Time";
                    Console.WriteLine($"Title: {book.Title}, Due Date: {book.ReturnDate}, Status: {overdueStatus}");
                }
            }
            else
            {
                Console.WriteLine("No borrowed books.");
            }
        }

    }
}
