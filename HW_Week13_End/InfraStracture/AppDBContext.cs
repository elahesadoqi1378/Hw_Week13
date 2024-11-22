using HW_Week13_End.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HW_Week13_End.InfraStracture
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source =ELAMIR\\SQLEXPRESS; Database = HW13_End; Integrated Security=True; User ID = sa; Password =123456 ; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Librarian> Librarians { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
             .HasOne(b => b.Member)
             .WithMany(m => m.BorrowedBooks)
             .HasForeignKey(b => b.MemberId);

            modelBuilder.Entity<Member>()
            .Property(m => m.Role)
            .HasConversion<string>(); // enum be sorate string

            modelBuilder.Entity<Librarian>()
            .Property(l => l.Role)
            .HasConversion<string>();
        }

    }
}
