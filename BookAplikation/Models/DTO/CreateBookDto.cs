namespace BookAplikation.Models.DTO
{
    public class CreateBookDto
    {
        public CreateBookDto()
        {
        }

        /// <summary>
        /// Book ISBN number
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Book title
        /// </summary>
        public string Pavadinimas { get; set; }

        /// <summary>
        /// Author of the book
        /// </summary>
        public string Autorius { get; set; }

        /// <summary>
        /// Release year of the book
        /// </summary>
        public DateTime Isleista { get; set; }

        /// <summary>
        /// Cover type of the book
        /// </summary>
        public string KnygosTipas { get; set; }
    }
}
