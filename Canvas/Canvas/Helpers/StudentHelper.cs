using Canvas.Models;
using Canvas.Services;
using static Canvas.Models.Person;

namespace Canvas.Helpers{

    internal class StudentHelper
    {
        private StudentService studentService = new StudentService();
        public void CreateStudentRecord()
        {
            //list for adding students


Console.WriteLine("What is the name of the studet?");
var name = Console.ReadLine();
Console.WriteLine("What is the id of the student?");
var id = Console.ReadLine();
Console.WriteLine("What is the Classification of the student? (F)reshman, S(O)phmore, (J)unior, (S)enior");
var classification = Console.ReadLine();
PersonClassification classEnum = PersonClassification.Freshman;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
if (classification.Equals("O", StringComparison.InvariantCultureIgnoreCase))
{
    classEnum = PersonClassification.Sophmore;
}
else if (classification.Equals("J", StringComparison.InvariantCultureIgnoreCase))
{
    classEnum = PersonClassification.Junior;
}
else if (classification.Equals("S", StringComparison.InvariantCultureIgnoreCase))
{
    classEnum = PersonClassification.Senior;
}
#pragma warning restore CS8602 // Dereference of a possibly null reference.


var student = new Person
{
    Id = int.Parse(id ?? "0"),
    Name = name ?? string.Empty,
    Classification = classEnum
};

studentService.Add(student);
//add student to a list
        }

public void ListStudents(){
    studentService.Students.ForEach(Console.WriteLine);
}

public void SearchStudents()
{
    Console.WriteLine("Enter a query");
    var query = Console.ReadLine() ?? string.Empty;

    studentService.Search(query).ToList().ForEach(Console.WriteLine);
}

    }
}