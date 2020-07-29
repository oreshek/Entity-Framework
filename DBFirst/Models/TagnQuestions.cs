using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class TagnQuestions
    {
        public Guid TagId { get; set; }
        public Guid QuestionId { get; set; }

        public virtual Questions Question { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
