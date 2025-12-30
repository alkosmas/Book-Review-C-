namespace BookReviews.Application.Features.Books.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public string Genre { get; set; } = string.Empty;
    }
}