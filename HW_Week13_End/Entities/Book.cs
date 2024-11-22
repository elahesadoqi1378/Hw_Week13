
using System.ComponentModel.DataAnnotations;

namespace HW_Week13_End.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
        public DateTime? BorrowedDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? MemberId { get; set; } //vaqti return kardi
        public Member Member { get; set; }

    }
}
