namespace BookAplikation.Models.DTO.DebtDto
{
    public class UserDebtDto
    {
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public List<BookNotReturnedInTime> BooksNotReturnedInTime { get; set; }
        public double TotalDebt { get; set; }

    }
    public class BookNotReturnedInTime
    {
        public int LibraryBookID { get; set; }
        public DateTime BookTaken { get; set; }
        public int DaysLate { get; set; }
        public double Debt { get; set; }
    }
}
