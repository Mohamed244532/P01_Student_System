using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;

namespace P01_StudentSystem.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StudentSystem;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Student configuration
            modelBuilder.Entity<Student>()
                .Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder.Entity<Student>()
                .Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Birthday)
                .IsRequired(false);

            // Course configuration
            modelBuilder.Entity<Course>()
                .Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder.Entity<Course>()
                .Property(e => e.Description)
                .IsUnicode()
                .IsRequired(false);

            // Resource configuration
            modelBuilder.Entity<Resource>()
                .Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder.Entity<Resource>()
                .Property(e => e.Url)
                .IsUnicode(false);

            // Homework configuration
            modelBuilder.Entity<Homework>()
                .Property(e => e.Content)
                .IsUnicode(false);

            // StudentCourse composite key
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }
    }
}
