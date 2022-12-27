namespace BookAplikation.Models.DTO
{
    public class FilterBooksRequestDto
    {

        /// <summary>
        /// Book title
        /// </summary>
        public string Pavadinimas { get; set; } = "";

        /// <summary>
        /// Author of the book
        /// </summary>
        public string Autorius { get; set; } = "";

        /// <summary>
        /// Cover type of the book
        /// </summary>
        public string KnygosTipas { get; set; } = "";

    }
}
