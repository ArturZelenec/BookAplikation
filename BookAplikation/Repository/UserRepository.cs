using BookAplikation.Data;
using BookAplikation.Models;
using BookAplikation.Models.DTO;
using BookAplikation.Models.DTO.UserDto;
using BookAplikation.Repository.IRepository;
using BookAplikation.Services;
using System.Linq.Expressions;
using System.Text;

namespace BookAplikation.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BookContext _db;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;
        private readonly LoginResponse _emptyTokenAndNullUser = new LoginResponse
        {
            Token = "",
            User = null
        };

        public UserRepository(BookContext db, IConfiguration conf, IPasswordService passwordService, IJwtService jwtService)
        {
            _db = db;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        public bool IsUniqueUser(string username) => !_db.Users.Any(u => u.Username == username);

        public LoginResponse Login(LoginRequest loginRequest)
        {
            var inputPastwordBytes = Encoding.UTF8.GetBytes(loginRequest.Password);
            var user = _db.Users.FirstOrDefault(u => u.Username.ToLower() == loginRequest.Username.ToLower());

            if (user == null) return _emptyTokenAndNullUser;

            if (!_passwordService.VerifyPasswordHash(loginRequest.Password, user.PasswordHash, user.PasswordSalt)) return _emptyTokenAndNullUser;

            var token = _jwtService.GetJwtToken(user.Id, user.Role);

            LoginResponse loginResponse = new()
            {
                Token = token,
                User = new RegistrationResponse()
                {
                    Id = user.Id,
                    Username = user.Username,
                    FullName = user.FullName,
                    Role = user.Role
                }
            };

            return loginResponse;
        }

        public RegistrationResponse Register(RegistrationRequest registrationRequest)
        {
            _passwordService.CreatePasswordHash(registrationRequest.Password, out byte[] hash, out byte[] salt);

            User user = new()
            {
                Username = registrationRequest.Username,
                PasswordHash = hash,
                PasswordSalt = salt,
                FullName = registrationRequest.FullName,
                Role = registrationRequest.Role,
                Created = DateTime.Now,
                Updated = DateTime.Now
            };

            RegistrationResponse registrationResponse = new()
            {
                Username = registrationRequest.Username,
                FullName = registrationRequest.FullName,
                Role = registrationRequest.Role
            };

            _db.Users.Add(user);
            _db.SaveChanges();

            return registrationResponse;
        }

        public List<GetUserDto> GetAll(Expression<Func<User, bool>>? filter = null)
        {
            IQueryable<User> users = _db.Users;
            if (filter != null) users = _db.Users.Where(filter);

            var userDto = new List<GetUserDto>();
            foreach (var user in users)
            {
                userDto.Add(new GetUserDto()
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    Role = user.Role,
                    TakenLibraryBooks = user.TakenLibraryBooks
                });

            }
            return userDto;
        }

        public GetUserDto Get(Expression<Func<User, bool>> filter)
        {
            User user = _db.Users.Where(filter).FirstOrDefault();
            var userDto = new GetUserDto()
            {
                UserId = user.Id,
                FullName = user.FullName,
                Role = user.Role,
                TakenLibraryBooks = user.TakenLibraryBooks,
                BooksNotReturnedInTime = user.BooksNotReturnedInTime,
                TotalDebt = user.TotalDebt
            };
            return userDto;
        }

        public void UpdateTakenLibraryBooks(int userId, int modifier)
        {
            User user = _db.Users.First(u => u.Id == userId);
            user.TakenLibraryBooks += modifier;
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public void UpdateBooksNotReturnedInTimeAndTotalDebt(int userId, int booksNotReturnedInTime, double totalDebt)
        {
            User user = _db.Users.First(u => u.Id == userId);
            user.BooksNotReturnedInTime = booksNotReturnedInTime;
            user.TotalDebt = totalDebt;
            _db.Users.Update(user);
            _db.SaveChanges();
        }

    }
}
