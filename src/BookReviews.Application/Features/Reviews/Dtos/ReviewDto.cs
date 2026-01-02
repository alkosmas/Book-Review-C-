namespace BookReviews.Application.Features.Reviews.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string UserName { get; set; } = string.Empty; 
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}