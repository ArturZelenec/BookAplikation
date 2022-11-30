using BookAplikation.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAplikation.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .Property(u => u.CoverType)
            .HasConversion<string>()
            .HasMaxLength(50);

            modelBuilder.Entity<Book>()
                .HasData(
                new Book(1, "The Eye of the World", "Robert Jordan", ECoverType.Paperback, 1976),
                new Book(2, "A Game of Thrones", "George R.R. Martin", ECoverType.Hardcover, 1988),
                new Book(3, "The Way of Kings", "Brandon Sanderson", ECoverType.Hardcover, 1981),
                new Book(4, "The Fellowship of the Ring", "J.R.R. Tolkien", ECoverType.Paperback, 1965),
                new Book(5, "Sourcery", "Terry Pratchett", ECoverType.Hardcover, 1990),
                new Book(6, "Dune", "Frank Herbert", ECoverType.Electronic, 1975),
                new Book(8, "The Name of the Wind", "Scott Lynch", ECoverType.Paperback, 1981),
                new Book(9, "The Lies of Locke Lamora", "Scott Lynch", ECoverType.Hardcover, 1975),
                new Book(10, "Assassin's Apprentice", "Scott Lynch", ECoverType.Electronic, 1977)
                );
        } 
    }
}
