using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new SchoolDbContext()) //add data to database
                {
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();
                    
                    //I know I should have made these lists but everytim I make one it thows an error "The entity type 'List<Course>' was not found. Ensure that the entity type has been added to the model."
                    //courses
                    Course English = new Course{CourseName = "English"}; 
                    Course Math = new Course {CourseName = "Math"};
                    db.Add(English);
                    db.Add(Math);
                    
                    //students
                    Student Kevin = new Student{FirstName = "Kevin", LastName = "Shmittywormenyagermanjenson"};
                    db.Add(Kevin);
                    Student Suzy = new Student{FirstName = "Suzy", LastName = "Q"};
                    db.Add(Suzy);
                    Student Tai = new Student{FirstName = "Tai", LastName = "Lung"};
                    db.Add(Tai);
                    Student Jaden = new Student{FirstName = "Jaden", LastName = "Smith"};
                    db.Add(Jaden);

                    db.SaveChanges();
                
                        StudentCourse Link1 = new StudentCourse {Student = Kevin, Course = English};
                        db.Add(Link1);
                        StudentCourse Link2 = new StudentCourse {Student = Suzy, Course = English};
                        db.Add(Link2);
                        StudentCourse Link3 = new StudentCourse {Student = Tai, Course = English};
                        db.Add(Link3);
                        StudentCourse Link4 = new StudentCourse {Student = Suzy, Course = Math};
                        db.Add(Link4);
                        StudentCourse Link5 = new StudentCourse {Student = Jaden, Course = Math}; 
                        db.Add(Link5);

                    db.SaveChanges();
                }

                
        }
    }
}
