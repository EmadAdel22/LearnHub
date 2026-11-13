using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Domain.Entities
{
    public class LessonProgress
    {
        public int Id { get; set; }

        public int EnrollmentId { get; set; }

        public int LessonId { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedAt { get; set; }

        public Enrollment Enrollment { get; set; } = null!;

        public Lesson Lesson { get; set; } = null!;
    }
}
