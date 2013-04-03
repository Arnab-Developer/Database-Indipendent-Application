// -----------------------------------------------------------+
// File Name:    Student.cs
// Description:  This file containing the student class for dal.
// Developed By: Arnab Roy Chowdhury.
// Date:         4th March 2012.
// -----------------------------------------------------------+

using System.Data;
using System;

namespace Dia.Dal
{
    /// <summary>
    /// The student class for dal.
    /// </summary>
    public class Student : IStudent
    {
        private Common _common;
        private bool _isDisposed;

        /// <summary>
        /// Creates a new student object with default value.
        /// </summary>
        public Student()
        {
            this._common = new Common();
        }

        /// <summary>
        /// Gets the value to indicate weather the object is live or disposed.
        /// </summary>
        public bool IsDisposed
        {
            get
            {
                lock (this)
                {
                    return this._isDisposed;
                }
            }
        }

        /// <summary>
        /// Get all student data from data source.
        /// </summary>
        /// <returns>The student collection.</returns>
        /// <exception cref="System.ObjectDisposedException">
        /// Object is already disposed.
        /// </exception>
        public Poco.Students GetData()
        {
            if (!this.IsDisposed)
            {
                IDataReader dr = this._common.ExecuteReader();

                int studentIdOrdinal = dr.GetOrdinal("StudentId");
                int nameOrdinal = dr.GetOrdinal("Name");
                int subjectOrdinal = dr.GetOrdinal("Subject");
                int ageOrdinal = dr.GetOrdinal("Age");

                Poco.Students students = new Poco.Students();
                while (dr.Read())
                {
                    Poco.IStudent student = new Poco.Student()
                    {
                        StudentId = (int)dr.GetValue(studentIdOrdinal),
                        Name = dr.GetString(nameOrdinal),
                        Subject = dr.GetString(subjectOrdinal),
                        Age = (int)dr.GetValue(ageOrdinal)
                    };
                    students.Add(student);
                }

                return students; 
            }
            else
            {
                throw new ObjectDisposedException("Object is already disposed.");
            }
        }

        /// <summary>
        /// Dispose the object.
        /// </summary>
        public void Dispose()
        {
            lock (this)
            {
                this.CleanUp();
                this._isDisposed = true;
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Clean up the unmanaged recources.
        /// </summary>
        protected virtual void CleanUp()
        {
            this._common.Dispose();
        }
    }
}
