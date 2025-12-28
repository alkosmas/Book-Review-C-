using BookReviews.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BookReviews.Infrastructure
{
    public class ApplicationUser : IdentityUser,IUser
    {

    }
}