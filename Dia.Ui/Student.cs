// ----------------------------------------------------------------+
// File Name:    Student.cs
// Description:  This file containing the student class for UI.
// Developed By: Arnab Roy Chowdhury.
// Date:         4th March 2012.
// ----------------------------------------------------------------+

using System;

namespace Dia.Ui
{
    class Student
    {
        static void Main(string[] args)
        {
            Poco.Students students = null;

            using (Bll.IStudent student = new Bll.Student())
            {
                students = student.GetData(); 
            }

            if (students != null)
            {
                if (students.Count > 0)
                {
                    foreach (Poco.Student st in students)
                    {
                        Console.WriteLine(st);
                    }  
                }
            }

            Console.ReadKey(true);
        }
    }
}
