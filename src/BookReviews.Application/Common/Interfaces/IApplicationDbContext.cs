using Microsoft.EntityFrameworkCore;
using BookReviews.Domain.Entities;

namespace BookReviews.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; }
        DbSet<Review> Reviews{ get; }
        DbSet<ReviewVote> ReviewVotes{ get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
