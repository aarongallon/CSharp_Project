// Build for Assignment 1

using Canvas.Models;

namespace Canvas.Services{
    public class CourseService
    {
        public List<Course> courseList= new List<Course>();

         public void Add(Course course)
        {
            courseList.Add(course);
        }

         public List <Course> Courses
        {
            get
            {
                return courseList;
            }
        }
    }
}