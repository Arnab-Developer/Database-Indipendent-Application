// ----------------------------------------------------------------+
// File Name:    IStudent.cs
// Description:  This file containing the student interface for dal.
// Developed By: Arnab Roy Chowdhury.
// Date:         4th March 2012.
// ----------------------------------------------------------------+

using System;

namespace Dia.Dal
{
    /// <summary>
    /// The student interface for dal.
    /// </summary>
    public interface IStudent : IDisposable
    {
        /// <summary>
        /// Get all student data from data source.
        /// </summary>
        /// <returns>The student collection.</returns>
        Poco.Students GetData();
    }
}
