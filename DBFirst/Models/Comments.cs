using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Comments
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public Guid? ForSolutionId { get; set; }

        public virtual Users Author { get; set; }
        public virtual Solutions ForSolution { get; set; }
    }
}
