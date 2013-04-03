// ----------------------------------------------------------------+
// File Name:    IStudent.cs
// Description:  This file containing the student interface for poco.
// Developed By: Arnab Roy Chowdhury.
// Date:         4th March 2012.
// ----------------------------------------------------------------+

namespace Dia.Poco
{
    /// <summary>
    /// The student interface for poco.
    /// </summary>
    public interface IStudent
    {
        /// <summary>
        /// The student id.
        /// </summary>
        int StudentId { get; set; }

        /// <summary>
        /// The student name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The student subject.
        /// </summary>
        string Subject { get; set; }

        /// <summary>
        /// The student age.
        /// </summary>
        int Age { get; set; }
    }
}
