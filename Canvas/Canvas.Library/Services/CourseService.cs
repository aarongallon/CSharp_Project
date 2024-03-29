// Build for Assignment 1

using Libray.Canvas;

namespace Canvas.Services
{
    public class CourseService
    {
        private  List<Course> courseList= new List<Course>();
        private static CourseService? _instance;

        public static CourseService Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CourseService();
                }
                return _instance;
            }
        }

        private CourseService()
        {
            courseList = new List<Course>();
        }

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

         public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper())
            || s.Description.ToUpper().Contains(query.ToUpper())
            || s.Code.ToUpper().Contains(query.ToUpper()));
        }
    }
}