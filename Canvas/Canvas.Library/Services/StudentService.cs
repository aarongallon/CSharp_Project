using Library.Canvas;
using System.Collections.Generic;
using System.Linq;

namespace Canvas.Services
{
    public class StudentService
    {
        private static StudentService _instance;
        private static readonly object _lock = new object();
        private List<Person> studentList = new List<Person>
        {
            new Person() { Name = "test" },
            new Person() { Name = "test" },
            new Person() { Name = "test" },
        };

        // Private constructor ensures no external instantiation.
        private StudentService() { }

        // Static method to get the singleton instance with thread safety.
        public static StudentService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new StudentService();
                        }
                    }
                }
                return _instance;
            }
        }

        public static StudentService Current{
            get{
                if (_instance == null){
                    _instance= new StudentService();
                }
                return _instance;
            }
        }

        public void Add(Person student)
        {
            studentList.Add(student);
        }

        public void Remove(Person student)
        {
            studentList.Remove(student);
        }

        public List<Person> Students
        {
            get { return studentList; }
        }

        public IEnumerable<Person> Search(string query)
        {
            return studentList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }
        public Person? GetById(int id)
        {
            return studentList.FirstOrDefault(s=>s.Id==id);
        }
    }
}
