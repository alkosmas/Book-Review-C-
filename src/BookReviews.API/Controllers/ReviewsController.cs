using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using BookReviews.Application.Features.Reviews.Queries.GetReviewsByBookId;
using BookReviews.Application.Features.Reviews.Commands.CreateReview;


[Route("api/books/{bookId}/reviews")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int bookId)
    {
        var result = await _mediator.Send(new GetReviewsByBookIdQuery(bookId));
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create(int bookId, [FromBody] CreateReviewCommand command)
    {
        if (bookId != command.BookId) return BadRequest();
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [Authorize]
    [HttpPut("{reviewId}/vote")]
    public async Task<IActionResult> Vote(int reviewId, [FromBody] bool isUpvote)
    {
        await _mediator.Send(new VoteReviewCommand { ReviewId = reviewId, IsUpvote = isUpvote });
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{reviewId}/vote")]
    public async Task<IActionResult> DeleteVote(int reviewId)
    {
        await _mediator.Send(new DeleteVoteCommand(reviewId));
        return NoContent();
}
}