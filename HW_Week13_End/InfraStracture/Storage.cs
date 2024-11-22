using HW_Week13_End.Entities;
using HW_Week13_End.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week13_End.InfraStracture
{
    public class Storage
    {
        private readonly BookService bookService;
        public Storage()
        {
            bookService = new BookService();
            SeedBooks();
        }
        private void SeedBooks()
        {
            if (bookService.GetAll().Any())
            {
                return;
            }



            var books = new List<Book>
            {
              new Book
                    {
                      Title = "Mathematics",
                      Author = "sara",
                      IsBorrowed = false
                    },
              new Book
                    {
                     Title = "Phisycs",
                     Author = "amin",
                     IsBorrowed = false
                    },
              new Book
                    {
                     Title = "Chemistry",
                     Author = "zahra",
                     IsBorrowed = false
                   }
            };

            foreach (var book in books)
            {
                bookService.Create(book.Title, book.Author);
            }
            return;
        }

    }
}
