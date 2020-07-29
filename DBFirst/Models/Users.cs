using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            Solutions = new HashSet<Solutions>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Age { get; set; }

        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Solutions> Solutions { get; set; }
    }
}
