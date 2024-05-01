//using System.Net.Http.Headers;
using Libray.Canvas; 

namespace Library.Canvas{
public class Person {

    private static int lastId = 0;
    public int Id {get; private set;}
    public string Name {get;set;}

    public Dictionary<int, double> Grades {get; set;}

    //public PersonClassification Classification  {get; set;}

    public Person(){
        Name  = string.Empty;
        Grades = new Dictionary<int, double>();
        Id = ++lastId;

    }

        public override string ToString()
        {
            string v = $"[{Id}] {Name}";
            return v;
        }

        // public enum PersonClassification
        // {
        //     Freshman, Sophmore, Junior, Senior
        // }
    }

}