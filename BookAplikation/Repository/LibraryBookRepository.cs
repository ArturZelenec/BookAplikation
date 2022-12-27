using BookAplikation.Data;
using BookAplikation.Models;
using BookAplikation.Repository.IRepository;

namespace BookAplikation.Repository
{
    public class LibraryBookRepository : Repository<LibraryBook>, ILibraryBookRepository
    {
        private readonly BookContext _db;

        public LibraryBookRepository(BookContext db) : base(db)
        {
            _db = db;
        }

        public LibraryBook Update(LibraryBook libraryBook)
        {
            libraryBook.Updated = DateTime.Now;
            _db.LibraryBooks.Update(libraryBook);
            _db.SaveChanges();
            return libraryBook;
        }
    }
}
