using MediatR;
using BookReviews.Application.Features.Books.Dtos;

namespace BookReviews.Application.Features.Books.Queries.GetBookById
{
    public record GetBookByIdQuery(int Id) : IRequest<BookDto>;
}