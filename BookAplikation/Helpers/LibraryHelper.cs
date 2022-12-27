using BookAplikation.Helpers.IHelpers;
using BookAplikation.Models;
using BookAplikation.Models.DTO;
using BookAplikation.Models.DTO.HelperDto;
using BookAplikation.Models.DTO.UserDto;

namespace BookAplikation.Helpers
{
    public class LibraryHelper : ILibraryHelper
    {
        public BoolAndMsgDto CanThisBookBeTaken(LibraryBook book)
        {
            if (book.IsTaken)
                return new BoolAndMsgDto()
                {
                    Answer = false,
                    Message = "Book is already taken"
                };
            return new BoolAndMsgDto()
            {
                Answer = true,
                Message = "Book can be taken"
            };
        }

        public BoolAndMsgDto CanThisUserTakeABook(GetUserDto user)
        {
            if (user.TakenLibraryBooks >= 5)
                return new BoolAndMsgDto()
                {
                    Answer = false,
                    Message = "User has too many books taken already"
                };

            if (user.BooksNotReturnedInTime >= 2)
                return new BoolAndMsgDto()
                {
                    Answer = false,
                    Message = "User has too many books not returned in time"
                };

            if (user.TotalDebt >= 10)
                return new BoolAndMsgDto()
                {
                    Answer = false,
                    Message = "User has too much debt"
                };

            return new BoolAndMsgDto()
            {
                Answer = true,
                Message = "This user can take a book"
            };
        }

       
    }
}
