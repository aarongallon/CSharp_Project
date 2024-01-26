namespace Canvas{

    public class CourseHelper
    {
        private CourseService courseService = new CourseService();

        public void CreateCourseRecord()
        {
            Console.WriteLine("What is the code?");
            var code = Console.ReadLine();
            Console.WriteLine("What is naem of the course?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the descritption of the course?");
            var description = Console.ReadLine();\

            var course = new Course
            {
                Code = code,
                Name = name,
                Description = description

            };

            courseService.Add(course);

            courseService.courseList.ForEach(Console.WriteLine);
        }
    }
}