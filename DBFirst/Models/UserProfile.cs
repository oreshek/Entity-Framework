using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class UserProfile
    {
        public Guid UserId { get; set; }
        public int? SolvedSolutionsNum { get; set; }
        public bool IsActive { get; set; }

        public virtual Users User { get; set; }
    }
}
