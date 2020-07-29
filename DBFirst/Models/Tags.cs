using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Tags
    {
        public Tags()
        {
            TagnQuestions = new HashSet<TagnQuestions>();
        }

        public Guid TagId { get; set; }
        public string Tag { get; set; }

        public virtual ICollection<TagnQuestions> TagnQuestions { get; set; }
    }
}
