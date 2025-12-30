using MediatR;
using Microsoft.EntityFrameworkCore;
using Mapster;
using BookReviews.Application.Common.Interfaces;
using BookReviews.Application.Common.Models;
using BookReviews.Domain.Entities;
using BookReviews.Application.Features.Books.Dtos;
using BookReviews.Application.Features.Books.Queries.GetBooks;

namespace BookReviews.Application.Features.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, PagedResponse<BookDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetBooksQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResponse<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            // 1. Ξεκινάμε το Query
            var query = _context.Books.AsQueryable();

            // 2. Εφαρμογή Φίλτρων
            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                query = query.Where(b => b.Title.Contains(request.Title));
            }

            if (!string.IsNullOrWhiteSpace(request.Author))
            {
                query = query.Where(b => b.Author.Contains(request.Author));
            }

            if (!string.IsNullOrWhiteSpace(request.Genre))
            {
                query = query.Where(b => b.Genre == request.Genre);
            }

            // 3. Count (πριν το pagination)
            var totalCount = await query.CountAsync(cancellationToken);

            // 4. Pagination & Projection
            var items = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectToType<BookDto>() // ✅ Mapster Magic!
                .ToListAsync(cancellationToken);

            // 5. Return
            return new PagedResponse<BookDto>(items, totalCount, request.PageNumber, request.PageSize);
        }
    }
}