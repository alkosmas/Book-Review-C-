using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;  
using BookReviews.Domain.Entities;
using BookReviews.Infrastructure.Identity;

namespace BookReviews.Infrastructure.Persistence.Configurations
{
    public class ReviewVoteConfiguration : IEntityTypeConfiguration<ReviewVote>
    {
        public void Configure(EntityTypeBuilder<ReviewVote> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId);
            
            builder.HasOne(x => x.Review)
                .WithMany(x => x.ReviewVotes)
                .HasForeignKey(x => x.ReviewId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new {x.UserId, x.ReviewId})
                .IsUnique();

            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}