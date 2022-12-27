using System.ComponentModel.DataAnnotations;

namespace BookAplikation.Models
{
    public class LibraryBook
    {
        [Key]
        public int Id { get; set; }
        public string BookISBN { get; set; }
        public virtual Book Book { get; set; }
        public bool IsTaken { get; set; }
        public virtual IEnumerable<UserBook>? UserBooks { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
