using BookAplikation.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAplikation.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<LibraryBook> LibraryBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var books = modelBuilder.Entity<Book>();
            books.HasData(
                new Book("0553211765", "A Tale of Two Cities", "Charles Dickens", ECoverType.Hardcover, 1989),
                new Book("0786275391", "The Little Prince", "Antoine de Saint-Exupery", ECoverType.Hardcover, 2005),
                new Book("1856134032", "Harry Potter and The Philosopher's Stone", "Rowling, J. K.", ECoverType.Hardcover, 1997),
                new Book("0451528905", "Don Quixote", "Miguel de Cervantes", ECoverType.Paperback, 2003),
                new Book("0847980790", "And Then There Were None", "Agatha Christie", ECoverType.Paperback, 1939),
                new Book("0020198817", "The Great Gatsby", "F. Scott Fitzgerald", ECoverType.Paperback, 1992),
                new Book("0553213113", "Moby Dick", "Herman Melville", ECoverType.Paperback, 1981),
                new Book("1400079985", "War and Peace", "Leo Tolstoy", ECoverType.Paperback, 2008),
                new Book("0451526929", "Hamlet", "William Shakespeare", ECoverType.Paperback, 1998),
                new Book("0439136350", "Harry Potter And The Prisoner Of Azkaban", "Rowling, J. K.", ECoverType.Hardcover, 1999),
                new Book("1856136124", "Harry Potter and the Chamber of Secrets", "Rowling, J. K.", ECoverType.Paperback, 1998)
                );
            books.Property(b => b.Title)
                 .HasMaxLength(200);
            books.Property(b => b.Author)
                 .HasMaxLength(100);
            books.Property(b => b.ECoverType)
                 .HasConversion<string>()
                 .HasMaxLength(50);

            var users = modelBuilder.Entity<User>();
            users.Property(u => u.Username)
                .HasMaxLength(100);
            users.Property(u => u.FullName)
                .HasMaxLength(100);

        }
    }
}
