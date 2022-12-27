using BookAplikation.Models;
using BookAplikation.Models.DTO;
using BookAplikation.Models.DTO.UserDto;
using System.Linq.Expressions;

namespace BookAplikation.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        LoginResponse Login(LoginRequest loginRequest);
        RegistrationResponse Register(RegistrationRequest registrationRequest);
        public List<GetUserDto> GetAll(Expression<Func<User, bool>>? filter = null);
        public GetUserDto Get(Expression<Func<User, bool>> filter = null);
        public void UpdateTakenLibraryBooks(int userId, int modifier);
        public void UpdateBooksNotReturnedInTimeAndTotalDebt(int userId, int booksNotReturnedInTime, double totalDebt);
    }
}
