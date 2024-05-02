using Library.Canvas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Canvas;
public class StudentDTO
{
    
    public StudentDTO()
    {
        Name = string.Empty;
    }

     public StudentDTO(Student c)
        {
            this.Id = c.Id;
            this.Name = c.Name;
            this.Classification = c.Classification;
        }


    public int Id { get; set; }
    public string Name { get; set; }

    public PersonClassification Classification{get; set; }

    public override string ToString()
    {
        return $"[{Id}] {Name} - {Classification}";
    }
    

}
