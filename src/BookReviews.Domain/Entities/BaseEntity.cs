using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReviews.Domain.Entities
{
    abstract public class BaseEntity
    {
        public int Id{ get; set; }
        public DateTime CreatedAt{ get; set; }
        public DateTime UpdatedAt{ get; set; }
        public  bool IsDeleted { get; set; }
    }
}