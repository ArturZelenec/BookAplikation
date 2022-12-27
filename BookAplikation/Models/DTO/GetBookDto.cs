namespace BookAplikation.Models.DTO
{
    public class GetBookDto
    {
        public string ISBN { get; set; }

        /// <summary>
        /// Book title and author seperated by space
        /// </summary>
        public string PavadinimasIrAutorius { get; set; }

        /// <summary>
        /// Release year of the book
        /// </summary>
        public int LeidybosMetai { get; set; }
    }
}
