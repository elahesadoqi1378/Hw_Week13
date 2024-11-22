
using HW_Week13_End.Enums;
using System.ComponentModel.DataAnnotations;

namespace HW_Week13_End.Entities
{
    public class Librarian
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.Librarian;


    }
}
