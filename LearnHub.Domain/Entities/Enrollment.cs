using LearnHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Domain.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }

        public Guid StudentId { get; set; }

        public int CourseId { get; set; }

        public Guid? EnrolledByUserId { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;

        public EnrollmentStatus Status { get; set; }

        public Course Course { get; set; } = null!;
    }
}
