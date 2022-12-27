namespace BookAplikation.Models.DTO
{
    public class UpdateBookDto
    {
        public string ISBN { get; set; }

        /// <summary>
        /// Release date and time of the book
        /// </summary>
        public DateTime Isleista { get; set; }

        /// <summary>
        /// Author of the book
        /// </summary>
        public string Autorius { get; set; }

        /// <summary>
        /// Book title
        /// </summary>
        public string Pavadinimas { get; set; }

        /// <summary>
        /// Cover type of the book
        /// </summary>
        public string KnygosTipas { get; set; }
    }
}
