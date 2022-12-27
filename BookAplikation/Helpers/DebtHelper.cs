using BookAplikation.Helpers.IHelpers;
using BookAplikation.Models;
using BookAplikation.Models.DTO.DebtDto;
using BookAplikation.Models.DTO.UserDto;
using BookAplikation.Repository.IRepository;

namespace BookAplikation.Helpers
{
    public class DebtHelper : IDebtHelper
    {
        private readonly int _daysFromWhenDebtIsCounted = 28;
        private readonly int _debtDoesNotIncreaseAboveThisAmount = 50;
        private readonly IUserRepository _userRepo;
        private readonly IUserBookRepository _userBookRepo;

        public DebtHelper(IUserRepository userRepo, IUserBookRepository userBookRepo)
        {
            _userRepo = userRepo;
            _userBookRepo = userBookRepo;
        }

        public List<UserDebtDto> UpdateAndGetAllDebtForEveryone()
        {
            List<GetUserDto> usersWithBooks = _userRepo.GetAll(u => u.TakenLibraryBooks > 0).ToList();
            List<UserBook> notReturnedBooks = _userBookRepo.GetAll(ub => ub.BookReturned == null).ToList();
            List<UserDebtDto> allUserDebt = BuildListOfAllUsersWithDebt(usersWithBooks, notReturnedBooks);

            foreach (var user in allUserDebt)
            {
                if (user.TotalDebt > _debtDoesNotIncreaseAboveThisAmount) user.TotalDebt = _debtDoesNotIncreaseAboveThisAmount;
                _userRepo.UpdateBooksNotReturnedInTimeAndTotalDebt(user.UserId, user.BooksNotReturnedInTime.Count, user.TotalDebt); // NESAUGOTI ISSKAICIUOJAMU DUOMENU
            }
            return allUserDebt;
        }

        private List<UserDebtDto> BuildListOfAllUsersWithDebt(List<GetUserDto> usersWithBooks, List<UserBook> notReturnedBooks)
        {
            List<UserDebtDto> allUserDebt = new List<UserDebtDto>();
            foreach (var user in usersWithBooks)
            {
                UserDebtDto userDebt = BuildListOfBooksThatUserIsLateToReturn(notReturnedBooks, user);
                if (userDebt.TotalDebt > 0) allUserDebt.Add(userDebt);
            }
            return allUserDebt;
        }

        private UserDebtDto BuildListOfBooksThatUserIsLateToReturn(List<UserBook> listUserBooks, GetUserDto user)
        {
            UserDebtDto userDebt = new UserDebtDto();
            userDebt.UserId = user.UserId;
            userDebt.UserFullName = user.FullName;
            userDebt.BooksNotReturnedInTime = new List<BookNotReturnedInTime>();
            userDebt.TotalDebt = 0;

            foreach (var userBook in listUserBooks)
            {
                if (user.UserId == userBook.UserId)
                {
                    var bookNotReturnedInTime = new BookNotReturnedInTime();
                    bookNotReturnedInTime.LibraryBookID = userBook.LibraryBookId;
                    bookNotReturnedInTime.BookTaken = userBook.BookTaken;
                    bookNotReturnedInTime.DaysLate = 0;

                    var daysPassed = (DateTime.Now - userBook.BookTaken).Days;

                    if (daysPassed > _daysFromWhenDebtIsCounted)
                    {
                        bookNotReturnedInTime.DaysLate = daysPassed - _daysFromWhenDebtIsCounted;
                        bookNotReturnedInTime.Debt = Math.Pow(bookNotReturnedInTime.DaysLate, 2) * 0.2;

                        userDebt.TotalDebt += bookNotReturnedInTime.Debt;
                        userDebt.BooksNotReturnedInTime.Add(bookNotReturnedInTime);

                        _userBookRepo.UpdateDaysLate(userBook.Id, bookNotReturnedInTime.DaysLate); // NESAUGOTI ISSKAICIUOJAMU DUOMENU
                    }
                }
            }
            return userDebt;
        }

        public UserDebtDto GetUserDebtWithListOfBooks(int id)
        {
            var user = _userRepo.Get(u => u.Id == id);
            var userTakenBooks = _userBookRepo.GetAll(ub => ub.UserId == id && ub.BookReturned == null);

            UserDebtDto userDebt = new UserDebtDto();
            userDebt = BuildListOfBooksThatUserIsLateToReturn(userTakenBooks, user);

            return userDebt;
        }

    }
}
