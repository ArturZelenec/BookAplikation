namespace BookAplikation.Models
{
    public class Book
    {
        public Book()
        {
        }

        public Book(int id, string title, string author, ECoverType coverType, int publishYear)
        {
            Id = id;
            Title = title;
            Author = author;
            CoverType = coverType;
            PublishYear = publishYear;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public ECoverType CoverType { get; set; }
        public int PublishYear { get; set; }
    }
}
