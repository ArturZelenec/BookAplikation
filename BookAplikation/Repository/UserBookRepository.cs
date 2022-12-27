using BookAplikation.Data;
using BookAplikation.Models;
using BookAplikation.Repository.IRepository;

namespace BookAplikation.Repository
{

    public class UserBookRepository : Repository<UserBook>, IUserBookRepository
    {
        private readonly BookContext _db;

        public UserBookRepository(BookContext db) : base(db)
        {
            _db = db;
        }

        public UserBook Update(UserBook userBook)
        {
            userBook.Updated = DateTime.Now;
            _db.UserBooks.Update(userBook);
            _db.SaveChanges();
            return userBook;
        }

        public void UpdateDaysLate(int userBookId, int daysLate)
        {
            var userBook = _db.UserBooks.First(u => u.Id == userBookId);
            userBook.DaysLate = daysLate;
            _db.UserBooks.Update(userBook);
            _db.SaveChanges();
        }

    }
}

