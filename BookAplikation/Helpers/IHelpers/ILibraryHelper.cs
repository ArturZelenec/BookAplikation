using BookAplikation.Models;
using BookAplikation.Models.DTO;
using BookAplikation.Models.DTO.HelperDto;
using BookAplikation.Models.DTO.UserDto;

namespace BookAplikation.Helpers.IHelpers
{
    public interface ILibraryHelper
    {
        BoolAndMsgDto CanThisBookBeTaken(LibraryBook book);
        BoolAndMsgDto CanThisUserTakeABook(GetUserDto user);
    }
}
