
using LearnHub.Domain.Entities;
using LearnHub.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnHub.Infrastructure.Persistence
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category - Course
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Course - Instructor
            modelBuilder.Entity<Course>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Course - Section
            modelBuilder.Entity<Section>()
                .HasOne(s => s.Course)
                .WithMany()
                .HasForeignKey(s => s.CourseId);

            // Section - Lesson
            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Section)
                .WithMany()
                .HasForeignKey(l => l.SectionId);

            // Enrollment - Student
            modelBuilder.Entity<Enrollment>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Enrollment - Enrolled By
            modelBuilder.Entity<Enrollment>()
                .HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(e => e.EnrolledByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Enrollment - Course
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            // Lesson Progress - Enrollment
            modelBuilder.Entity<LessonProgress>()
                .HasOne(lp => lp.Enrollment)
                .WithMany()
                .HasForeignKey(lp => lp.EnrollmentId);

            // Lesson Progress - Lesson
            modelBuilder.Entity<LessonProgress>()
                .HasOne(lp => lp.Lesson)
                .WithMany()
                .HasForeignKey(lp => lp.LessonId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasIndex(e => new { e.StudentId, e.CourseId })
                .IsUnique();

            // Unique Lesson Progress
            modelBuilder.Entity<LessonProgress>()
                .HasIndex(lp => new { lp.EnrollmentId, lp.LessonId })
                .IsUnique();

            // Course Price
            modelBuilder.Entity<Course>()
                .Property(c => c.Price)
                .HasPrecision(10, 2);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<LessonProgress> LessonProgresses { get; set; }
    }
}
