using BookReviews.Application.Features.Books.Dtos;
using BookReviews.Application.Features.Reviews.Dtos;

public class BookDetailsViewModel
{
    public BookDto Book { get; set; } = null!;
    public List<ReviewDto> Reviews { get; set; } = new();
}