using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviews.Domain.Interfaces
{
    public interface IUser
    {
        string Id { get; }
        string? UserName { get; }
        string? Email { get; }
    }
}