using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

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

        [Serializable]
        class Student
        {
            public int StudentID { get; set; }
            public String StudentName { get; set; }
            public int Age { get; set; }
            public List<string> lista = new List<string>() { "aaaa", "oooo" };
            public Cat cat = new Cat();
        }
        [Serializable]
        class Cat
        {
            public int id { get; set; }
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
            BinaryFormatter bf = new BinaryFormatter();
            Student s = new Student();
            s.Age = 19;
            s.StudentID = 1;
            s.StudentName = "piotr";
            using (Stream fStream = new FileStream("lineInfo.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                bf.Serialize(fStream,s );
            }

        }

    }
}
         