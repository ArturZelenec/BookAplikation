using BookAplikation.Models;

namespace BookAplikation.Repository.IRepository
{
    public interface IUserBookRepository : IRepository<UserBook>
    {
        UserBook Update(UserBook userBook);
        void UpdateDaysLate(int userBookId, int daysLate);
    }
}
