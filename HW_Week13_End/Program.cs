
using HW_Week13_End.Entities;
using HW_Week13_End.Enums;
using HW_Week13_End.InfraStracture;
using HW_Week13_End.Services;
using System;


public class Program
{
    public static object currentUser;
    static void Main(string[] args)
    {
        var storage = new Storage();
        var librarianService = new LibrarianService();
        var memberService = new MemberService();
        var bookService = new BookService();

       
        //librarianService.Create("admin", "admin123");
        //memberService.Register("member1", "password", UserRole.Member);

        while (true)
        {
            Console.WriteLine("Welcome to the Electronic Library System!");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            if (option == "3") break;

            if (option == "1") 
            {
                Console.Write("Enter Username: ");
                var username = Console.ReadLine();
                Console.Write("Enter Password: ");
                var password = Console.ReadLine();
                Console.Write("Select Role (1. Member, 2. Librarian): ");
                var roleOption = Console.ReadLine();
                UserRole role = roleOption == "1" ? UserRole.Member : UserRole.Librarian;


                
                    var member = memberService.Login(username, password,role);
                    //currentUser = member;
                    //ShowMemberMenu(member);
                    if (role == UserRole.Librarian)
                    {
                        ShowLibrarianMenu();

                    }
                    else
                    {
                       ShowMemberMenu(member);

                    }
                
               
                    
                
            }
            else if (option == "2") 
            {
                Console.Write("Enter Username: ");
                var username = Console.ReadLine();
                Console.Write("Enter Password: ");
                var password = Console.ReadLine();
                Console.Write("Select Role (1. Member, 2. Librarian): ");
                var roleOption = Console.ReadLine();
                UserRole role = roleOption == "1" ? UserRole.Member : UserRole.Librarian;
                

                try
                {
                    memberService.Register(username, password, role);
                    Console.WriteLine("Registration successful!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }

    private static void ShowMemberMenu(Member member)
    {
        BookService bookService = new BookService();
        while (true)
        {
            Console.WriteLine($"Welcome {member.UserName}!");
            Console.WriteLine("1. View Available Books");
            Console.WriteLine("2. View Borrowed Books");
            Console.WriteLine("3. Borrow a Book");
            Console.WriteLine("4. Return a Book");
            Console.WriteLine("5. Logout");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            if (option == "5")
                break; 

            switch (option)
            {
                case "1":
                    var availableBooks = bookService.GetAll().Where(b => !b.IsBorrowed).ToList();
                    Console.WriteLine("Available Books:");
                    foreach (var book in availableBooks)
                    {
                        Console.WriteLine($"{book.Id}: {book.Title} by {book.Author}");
                    }
                    break;

                case "2":
                    var bookServicee = new BookService();
                    bookServicee.ViewBorrowedBooks(member.Id);
                    //Console.WriteLine("Your Borrowed Books:");
                    //foreach (var book in member.BorrowedBooks)
                    //{
                    //    Console.WriteLine($"{book.Id}: {book.Title} by {book.Author}");
                    //}
                    break;

                case "3":
                    Console.Write("Enter Book ID to borrow: ");
                    var borrowId = int.Parse(Console.ReadLine());
                    try
                    {
                        bookService.BorrowBook(borrowId, member.Id);
                        Console.WriteLine("Successfully borrowed the book.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "4":
                    Console.Write("Enter Book ID to return: ");
                    var returnId = int.Parse(Console.ReadLine());
                    try
                    {
                        bookService.ReturnBook(returnId);
                        Console.WriteLine("Successfully returned the book.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    private static void ShowLibrarianMenu()
    {
        BookService bookService = new BookService();
        MemberService memberService = new MemberService();
        while (true)
        {
            Console.WriteLine("Librarian Menu:");
            Console.WriteLine("1. View All Books");
            Console.WriteLine("2. View All Members");
            Console.WriteLine("3. Extend Borrowing Period");
            Console.WriteLine("4. Logout");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();
            if (option == "4")
                break;
            switch (option)
            {
                case "1":
                    var books = bookService.GetAll();
                    Console.WriteLine("All Books:");
                    foreach (var book in books)
                    {
                        string status = book.IsBorrowed ? "Borrowed" : "Available";
                        Console.WriteLine($"{book.Id}: {book.Title} by {book.Author} - Status: {status}");
                    }
                    break;
                case "2":
                    var members = memberService.GetAll();
                    Console.WriteLine("All Members:");
                    foreach (var member in members)
                    {
                        Console.WriteLine($"{member.Id}: {member.UserName}  - Role: {member.Role}");
                    }
                    break;
                case "3":
                    Console.WriteLine("Enter the book ID to extend the due date:");
                    int bookId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the number of days to extend:");
                    int additionalDays = int.Parse(Console.ReadLine());

                    var bookServiceee = new BookService();
                    bookServiceee.ExtendDueDate(bookId, additionalDays);
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}