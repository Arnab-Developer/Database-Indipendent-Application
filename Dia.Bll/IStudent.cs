// ----------------------------------------------------------------+
// File Name:    IStudent.cs
// Description:  This file containing the student interface for bll.
// Developed By: Arnab Roy Chowdhury.
// Date:         4th March 2012.
// ----------------------------------------------------------------+

using System;

namespace Dia.Bll
{
    /// <summary>
    /// The student interface for bll.
    /// </summary>
    public interface IStudent : IDisposable
    {
        /// <summary>
        /// Get all student data from dal.
        /// </summary>
        /// <returns>The student collection.</returns>
        Poco.Students GetData();
    }
}
