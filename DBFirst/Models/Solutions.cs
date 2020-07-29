using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Solutions
    {
        public Solutions()
        {
            Comments = new HashSet<Comments>();
        }

        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
        public Guid ByUserId { get; set; }

        public virtual Users ByUser { get; set; }
        public virtual Questions Question { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
