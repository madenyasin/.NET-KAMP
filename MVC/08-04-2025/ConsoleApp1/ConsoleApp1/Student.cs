using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double AverageGrade { get; set; }

        public override string ToString()
        {
            return $"{StudentId}\t- {FirstName}\t {LastName}\t - {Age}\t - {AverageGrade}";
        }

    }
}
