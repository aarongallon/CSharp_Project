using Canvas.Models;
using Canvas.Services;

namespace Canvas{

    public class CourseHelper
    {
        private CourseService courseService = new CourseService();

        public void CreateCourseRecord(Course? selectedCourse = null)
        {
            Console.WriteLine("What is the code?");
            var code = Console.ReadLine();
            Console.WriteLine("What is name of the course?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the descritption of the course?");
            var description = Console.ReadLine();
            
            bool isNewCourse = false;
            if(selectedCourse == null){
                isNewCourse = true;
                selectedCourse = new Course();
            }

            
                 selectedCourse.Code = code;
                 selectedCourse.Name = name;
                 selectedCourse.Description = description;

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
    }
}