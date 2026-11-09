using System;
using System.Collections.Generic;
using System.Text;

namespace LearnHub.Domain.Entities
{
    public class Lesson
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public string? VideoUrl { get; set; }

        public int Order { get; set; }

        public int SectionId { get; set; }

        public Section Section { get; set; } = null!;
    }
}
