using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public bool IsPublished { get; set; }
        public int CategoryId { get; set; }

        public Guid InstructorId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
