using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;

namespace Excercise
{
    static class rozszerzenia
    {
        public static void wypisz(this string str)
        {
            Console.WriteLine(str);
        }
    }
    class Program
    {

        delegate bool FindStudent(Student std);


        class Student
        {
            public int StudentID { get; set; }
            public String StudentName { get; set; }
            public int Age { get; set; }
        }
        public delegate void Print(int value);
        private string exchange(string o, string input, string n)
        {
            string newString = "";
            for (int i = 0; i < o.Count(); i++)
            {
                
            }
            return newString;
        }
        static void Main(string[] args)
        {
            
            
        }

    }
}
         