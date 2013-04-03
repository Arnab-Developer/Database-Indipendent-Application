// ----------------------------------------------------------------+
// File Name:    Student.cs
// Description:  This file containing the student class for poco.
// Developed By: Arnab Roy Chowdhury.
// Date:         4th March 2012.
// ----------------------------------------------------------------+

namespace Dia.Poco
{
    /// <summary>
    /// The student class for poco.
    /// </summary>
    public class Student : IStudent
    {
        /// <summary>
        /// The student id.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// The student name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The student subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The student age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Creates a new student object with default values.
        /// </summary>
        public Student()
        {
            this.StudentId = 0;
            this.Name = string.Empty;
            this.Subject = string.Empty;
            this.Age = 0;
        }

        /// <summary>
        /// Creates a new student object with value provided by the user.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <param name="name">The student name.</param>
        /// <param name="subject">The student subject.</param>
        /// <param name="age">The student age.</param>
        public Student(int studentId, string name, string subject, byte age)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Subject = subject;
            this.Age = age;
        }

        /// <summary>
        /// Overrides the ToString() method for string representation of student object.
        /// </summary>
        /// <returns>The string representation of student object.</returns>
        public override string ToString()
        {
            return string.Format("Id: {0}\nName: {1}\nSubject: {2}\nage: {3}\n",
                this.StudentId, this.Name, this.Subject, this.Age);
        }
    }
}
