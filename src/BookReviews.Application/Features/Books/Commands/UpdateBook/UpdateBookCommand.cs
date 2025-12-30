using MediatR;
namespace BookReviews.Application.Features.Books.Commands.UpdateBook;
public class UpdateBookCommand : IRequest 
{
    public int Id { get; set; } 
    public string? Title { get; set; }
    public string? Author { get; set; }
    public int PublishedYear { get; set; }
    public string? Genre { get; set; }
}