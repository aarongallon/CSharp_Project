﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using Canvas;
using Canvas.Helpers;
using Canvas.Models;
using Canvas.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var studentSrvc= new StudentService();
        var studentHelper = new StudentHelper(studentSrvc);
        var courseHelper = new CourseHelper(studentSrvc);

        bool cont = true;

        while (cont)
        {
            Console.WriteLine("Choose an action");
            Console.WriteLine("1. Add a student enrollment");
            Console.WriteLine("2. Update a studetnt");
            Console.WriteLine("3. List students");
            Console.WriteLine("4. Search for student");
            Console.WriteLine("5. Add course");
            Console.WriteLine("6. update a course");
            Console.WriteLine("7. List all courses");
            Console.WriteLine("8. Search for course");
            Console.WriteLine("9. Exit");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    //if they choose 1 we will create a student record
                    studentHelper.AddOrUpdateStudent();
                }
                else if (result == 2)
                {
                    studentHelper.UpdateStudentRecord();
                }
                else if (result == 3)
                {
                    studentHelper.ListStudents();
                }
                else if (result == 4)
                {
                    studentHelper.SearchStudents();

                }
                else if (result == 5)
                {
                    courseHelper.CreateCourseRecord();
                }
                else if(result == 6)
                {
                    courseHelper.UpdateCourseRecord();
                }
                else if(result == 7)
                {
                    courseHelper.ListCourses();
                }
                else if(result == 8)
                {
                    courseHelper.SearchCourses();
                
                }
                else if (result == 9)
                {
                    cont = false;
                }

            }
        }
        
    }
}