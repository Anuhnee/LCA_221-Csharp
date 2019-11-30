using System;
using System.Collections.Generic;
using System.Text;

namespace Database_Practice
{
    class Student
    {
        public int Id { get; private set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        
        public Student(String FirstName, String LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
