using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2025_02_03_Workshop_2
{
    internal class Program
    {
        class Student
        {
            private string m_studentName;
            private string m_moduleName;
            private int m_grade;
            public Student(string studentName, int grade, string moduleName)
            {
                this.m_studentName = studentName;
                this.m_moduleName = moduleName;
                this.m_grade = grade;
            }

            public string StudentName
            {
                get { return m_studentName; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Cannot be empty");
                        m_studentName = "NoName";
                    }
                    else
                    {
                        m_studentName = value;
                    }
                }
            }

            public int Grade
            {
                get { return m_grade; }
                set
                {
                    if (value >= 0 & value <= 100)
                    {
                        m_grade = value;
                    }
                    else
                    {
                        Console.WriteLine("Grade must be above or equal 0 and less than  or equal to 100");
                        m_grade = 0;
                    }
                }
            }

            public string ModuleName
            {
                get { return m_moduleName; }
                set
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        Console.WriteLine("Cannot be empty");

                    }
                    else
                    {
                        m_moduleName = value;
                    }
                }
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"The student: {m_studentName} attended the module {m_moduleName} and was marked with {m_grade}.");
            }

            public void ComputeGradeCategory()
            {
                if (m_grade >= 70)
                {
                    Console.WriteLine($"The student {m_studentName} was graded with Merit");
                }
                else if (m_grade > 0)
                {
                    Console.WriteLine($"The student {m_studentName} was graded with Pass");
                }
                else
                {
                    Console.WriteLine($"The student {m_studentName} is missing mark");
                }
            }
        }
        static void Main(string[] args)
        {
            Student student = new Student("Alice", 45, "Object-Oriented Programming");
            student.Grade = 71;
            student.ModuleName = "oop";
            student.StudentName = "charles";
            student.DisplayInfo();
            student.ComputeGradeCategory();
        }
    }
}
