﻿namespace Library.Canvas.Models;

public class Student : Person
    {
        public Dictionary<int, double> Grades { get; set; }

        public PersonClassification Classification { get; set; }

        public Student() {
            Grades = new Dictionary<int, double>();
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} - {Classification}";
        }
    }

    public enum PersonClassification
    {
        Freshman, Sophomore, Junior, Senior
    }


