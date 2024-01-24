// Build for Assignment 1

using Canvas.Models;

namespace Canvas.Services{
    public class CourseService{
        private IList<Course> courses;

        private string? query;
        private static object _lock;
        private static CourseService instance;
        public static CourseService Current {
            get {
                // Program does not work if lock is used
                // ask abt this in office hours
                //if(instance == null){
                    //lock(_lock){
                        if(instance == null){
                            instance = new CourseService();
                        }
                    //}
                //}
                return instance;
            }
        }

        public IEnumerable<Course> Courses {
            get{
                return courses.Where(
                    c => 
                        c.Name.ToUpper().Contains(query ?? string.Empty)
                        || c.Code.ToUpper().Contains(query ?? string.Empty));
            }
        }

        public IEnumerable<Course> Search(string query){
            this.query = query;
            return Courses;
        }
        private CourseService(){
            courses = new List<Course>();
        }

        public void Add(Course course){
            
            courses.Add(course);
        }
    }
}