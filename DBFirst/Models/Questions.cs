using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Questions
    {
        public Questions()
        {
            Solutions = new HashSet<Solutions>();
            TagnQuestions = new HashSet<TagnQuestions>();
        }

        public Guid QuestionId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Solutions> Solutions { get; set; }
        public virtual ICollection<TagnQuestions> TagnQuestions { get; set; }
    }
}
