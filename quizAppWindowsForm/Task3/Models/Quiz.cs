using System;
using System.Collections.Generic;

namespace Task3.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            //UserAnswers = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }
        public string Questions { get; set; } = null!;
        public string Answer { get; set; } = null!;

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
