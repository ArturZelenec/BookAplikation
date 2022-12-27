using BookAplikation.Data;
using BookAplikation.Models;
using BookAplikation.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BookAplikation.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly BookContext _db;

        public BookRepository(BookContext db) : base(db)
        {
            _db = db;
        }

        public Book Update(Book book)
        {

            book.Updated = DateTime.Now;
            _db.Books.Update(book);
            _db.SaveChanges();
            return book;
        }
    }
}
