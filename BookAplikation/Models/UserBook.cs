using System.ComponentModel.DataAnnotations;

namespace BookAplikation.Models
{
    public class UserBook
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int LibraryBookId { get; set; }
        public virtual LibraryBook LibraryBook { get; set; }
        public DateTime BookTaken { get; set; }
        public DateTime? BookReturned { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int DaysLate { get; set; } = 0;
    }
}
