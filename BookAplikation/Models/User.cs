using System.ComponentModel.DataAnnotations;

namespace BookAplikation.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public virtual IEnumerable<UserBook>? UserBooks { get; set; }
        public int TakenLibraryBooks { get; set; } = 0;
        public int BooksNotReturnedInTime { get; set; } = 0;
        public double TotalDebt { get; set; } = 0;
    }
}
