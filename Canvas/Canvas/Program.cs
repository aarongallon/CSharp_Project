using System;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Canvas.Models;
using Canvas.Services;

namespace Canvas // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");

            AddCourse();

            Console.WriteLine("Check");
            if(CourseService.Current.Courses != null){
                foreach(Course c in CourseService.Current.Courses){
                    Console.WriteLine(c);
                }
            } else{
                Console.WriteLine("Courses empty");
            }


            
        }

        static void AddCourse(){
            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Code:");
            var code = Console.ReadLine();

            Console.WriteLine("Description:");
            var description = Console.ReadLine();

            Course myCourse;

            myCourse = new Course{Name = name, Code = code, Description = description};
            

            CourseService.Current.Add(myCourse);
        }
        // add roster
        // add assignments
        // add modules


    }

}