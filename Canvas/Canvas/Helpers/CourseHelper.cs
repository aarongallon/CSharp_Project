using System.Runtime.CompilerServices;
using Canvas.Helpers;
using Canvas.Models;
using Canvas.Services;

namespace Canvas{

    public class CourseHelper
    {
        private CourseService courseService;
        private StudentService studentService;

        public CourseHelper(StudentService ssrvc )
        {
            studentService = ssrvc;
            courseService = CourseService.Current;
        }

        public void CreateCourseRecord(Course? selectedCourse = null)
        {
            Console.WriteLine("What is the code?");
            var code = Console.ReadLine();
            Console.WriteLine("What is name of the course?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the descritption of the course?");
            var description = Console.ReadLine();

            Console.WriteLine("Which students should be enrolled in this course? ('Q' to quit"); 
            var roster = new List<Person>();
            bool continueAdding = true;
            while(continueAdding)
            {
                   studentService.Students.Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                   var selection = "Q";
                    if(studentService.Students.Any(s => !roster.Any(s2 => s2.Id == s.Id)))
                    {
                     selection = Console.ReadLine() ?? string.Empty;
                    }
                

                   if(selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase) || !studentService.Students.Any(s => !roster.Any(s2 => s2.Id == s.Id))){
                    continueAdding = false;
                   }
                   else
                   {
                    var selectedId = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectedId );

                    if(selectedStudent!=null){
                        roster.Add(selectedStudent);
                    }
                   }
                   
            }
            
            bool isNewCourse = false;
            if(selectedCourse == null){
                isNewCourse = true;
                selectedCourse = new Course();
            }

            
                 selectedCourse.Code = code;
                 selectedCourse.Name = name;
                 selectedCourse.Description = description;
                 selectedCourse.Roster = new List<Person>();
                 selectedCourse.Roster = roster;

                 if(isNewCourse)
                 {
                    courseService.Add(selectedCourse);
                 }
        }


       public void UpdateCourseRecord(){
         Console.WriteLine("Select course to update: ");
         ListCourses();

         var selection = Console.ReadLine();

        var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
       
        if(selectedCourse != null)
        {
            CreateCourseRecord(selectedCourse);
        }
    }

        

        public void ListCourses(){
            courseService.Courses.ForEach(Console.WriteLine);
        }

        public void SearchCourses()
        {
            Console.WriteLine("Enter a query");
            var query = Console.ReadLine() ?? string.Empty;
            courseService.Search(query).ToList().ForEach(Console.WriteLine);
        }
    }
}