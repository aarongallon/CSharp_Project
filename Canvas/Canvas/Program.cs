using System.ComponentModel;
using System.Runtime.CompilerServices;
using Canvas.Helpers;
using Canvas.Models;
using Canvas.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var studentHelper = new StudentHelper();
        var courseHelper = new CourseHelper();

        bool cont = true;

        while (cont)
        {
            Console.WriteLine("Choose an action");
            Console.WriteLine("1. Add a student enrollment");
            Console.WriteLine("2. Update a studetnt");
            Console.WriteLine("3. List students");
            Console.WriteLine("4. Search for student");
            Console.WriteLine("5. Add course");
            Console.WriteLine("6. Exit");
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
                else if (result == 6)
                {
                    cont = false;
                }

            }
        }



        Console.WriteLine("Check");
        if (CourseService.Current.Courses != null)
        {
            foreach (Course c in CourseService.Current.Courses)
            {
                Console.WriteLine(c);
            }
        }
        else
        {
            Console.WriteLine("Courses empty");
        }

        void AddCourse()
        {
            Console.WriteLine("Name:");
            var name = Console.ReadLine();

            Console.WriteLine("Code:");
            var code = Console.ReadLine();

            Console.WriteLine("Description:");
            var description = Console.ReadLine();

            Course myCourse;

            myCourse = new Course { Name = name, Code = code, Description = description };


            CourseService.Current.Add(myCourse);
        }
    }
}