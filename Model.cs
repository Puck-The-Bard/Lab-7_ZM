using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Class
{
    public class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = ClassDb.db");
        }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(e => new {e.StudetnID, e.CourseID});
        }
        

        public DbSet<Student> Students {get; set;}
        public DbSet<Course> Courses {get; set;}
        public DbSet<StudentCourse> StudentCourses {get; set;}
    }

    public class Student
    {
        public int StudentID {get; set;} //pk
        public String FirstName {get; set;}

        public String LastName {get; set;}

        public StudentCourse StudetnCourses {get; set;} //navigation property
    }

    public class Course
    {
        public int courseID {get; set;} //pk

        public string CourseName {get; set;}

        public StudentCourse StudetnCourses {get; set;} //navigation property

    }

    public class StudentCourse //association table
    {
  //      public int StudentCourseID {get; set;}

        public int StudetnID {get; set;}

        public int CourseID {get; set;}

        public Student Student {get; set;}

        public Course Course {get; set;}

    }
}