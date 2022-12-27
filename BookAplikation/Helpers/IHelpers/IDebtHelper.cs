using BookAplikation.Models.DTO.DebtDto;

namespace BookAplikation.Helpers.IHelpers
{
    public interface IDebtHelper
    {
        List<UserDebtDto> UpdateAndGetAllDebtForEveryone();
    }
}
