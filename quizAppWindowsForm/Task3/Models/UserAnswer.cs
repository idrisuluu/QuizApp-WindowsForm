using System;
using System.Collections.Generic;

namespace Task3.Models
{
    public partial class UserAnswer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int QuizId { get; set; }
        public string Answer { get; set; } = null!;

        public virtual Quiz Quiz { get; set; } = null!;
    }
}
