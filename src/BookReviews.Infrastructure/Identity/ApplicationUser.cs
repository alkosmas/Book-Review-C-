using Microsoft.AspNetCore.Identity;
using BookReviews.Domain.Interfaces;

namespace BookReviews.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser,IUser
    {

    }
}