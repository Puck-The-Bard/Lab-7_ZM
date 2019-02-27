﻿using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
                    
                    //I know I should have made these lists but everytime I make one it thows an error "The entity type 'List<Course>' was not found. Ensure that the entity type has been added to the model."
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
                
                        StudentCourse Link1 = new StudentCourse {Student = Kevin, Course = English, GPA = 2.4};
                        db.Add(Link1);
                        StudentCourse Link2 = new StudentCourse {Student = Suzy, Course = English, GPA = 3.2};
                        db.Add(Link2);
                        StudentCourse Link3 = new StudentCourse {Student = Tai, Course = English, GPA = .6};
                        db.Add(Link3);
                        StudentCourse Link4 = new StudentCourse {Student = Suzy, Course = Math, GPA = 1.7};
                        db.Add(Link4);
                        StudentCourse Link5 = new StudentCourse {Student = Jaden, Course = Math, GPA = 2.2}; 
                        db.Add(Link5);

                    db.SaveChanges();
                    List();

                        db.Remove(Link3); //remove a student from a course

                    db.SaveChanges();
                    List();

                    //Add a transfer student to the roll
                        Student Antonio = new Student {FirstName = "Antonio", LastName = "Montoya"};
                        db.Add(Antonio);
                        StudentCourse LinkAntonio = new StudentCourse {Student = Antonio, Course = Math, GPA = 3.2};
                        db.Add(LinkAntonio);
                    db.SaveChanges();
                    List();

                }



        }

        //METHODS

        //list out contents
        static void List()
        {
            using (var db = new SchoolDbContext()) //add data to database
                {
                    Console.WriteLine("\n=====================\n");
                    foreach(var C in db.Courses.Include(s => s.StudetnCourses).ThenInclude(p => p.Student)) //getting all the databases together
                    {
                        Console.WriteLine($" - {C}");
                        foreach(var S in db.StudentCourses.Where(p => p.Course == C)) //verfying the student is in the course before listing them
                        {
                            Console.WriteLine($"\t{S.Student}");
                            foreach(var GPA in db.StudentCourses.Where(b => b.Student == S.Student && b.Course == C)) //getting each students GPA fore their individual courses
                            {
                                Console.Write($"\tGPA: {GPA}\n");
                            }
                            Console.WriteLine();
                        }

                    }
                }
        }
    }
}