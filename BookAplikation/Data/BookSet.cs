using BookAplikation.Models;

namespace BookAplikation.Data
{
    public class BookSet : IBookSet
    {
        private List<Book> books = new List<Book>()
        {
                new Book (1, "The Eye of the World", "Robert Jordan", ECoverType.Paperback, 1976),
                new Book (2, "A Game of Thrones", "George R.R. Martin", ECoverType.Hardcover, 1988),
                new Book (3, "The Way of Kings", "Brandon Sanderson", ECoverType.Hardcover, 1981 ),
                new Book (4, "The Fellowship of the Ring", "J.R.R. Tolkien", ECoverType.Paperback, 1965 ),
                new Book (5, "Sourcery",  "Terry Pratchett", ECoverType.Hardcover, 1990 ),
                new Book (6, "Dune", "Frank Herbert", ECoverType.Electronic, 1975),
                new Book (8, "The Name of the Wind", "Scott Lynch", ECoverType.Paperback, 1981 ),
                new Book (9,"The Lies of Locke Lamora", "Scott Lynch", ECoverType.Hardcover, 1975 ),
                new Book (10, "Assassin's Apprentice", "Scott Lynch", ECoverType.Electronic, 1977 ),
        };
        public List<Book> Books
        {
            get { return books; }
            set { books = value; }
        }
    }
}
