namespace BookAplikation.Models.DTO
{
    public class GetUserBookDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public int LibraryBookId { get; set; }
        public string BookISBN { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime BookTaken { get; set; }
        public DateTime? BookReturned { get; set; }
    }
}
