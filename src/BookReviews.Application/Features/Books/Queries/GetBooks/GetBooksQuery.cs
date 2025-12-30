using MediatR;
using BookReviews.Application.Common.Models;
using BookReviews.Application.Features.Books.Dtos;

namespace BookReviews.Application.Features.Books.Queries.GetBooks
{
    public class GetBooksQuery : IRequest<PagedResponse<BookDto>>
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}