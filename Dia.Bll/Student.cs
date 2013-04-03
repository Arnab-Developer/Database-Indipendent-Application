// ----------------------------------------------------------------+
// File Name:    Student.cs
// Description:  This file containing the student class for bll.
// Developed By: Arnab Roy Chowdhury.
// Date:         4th March 2012.
// ----------------------------------------------------------------+

using System;

namespace Dia.Bll
{
    /// <summary>
    /// The student class for bll.
    /// </summary>
    public class Student : IStudent
    {
        private Dal.IStudent _student;
        private bool _isDisposed;

        /// <summary>
        /// Creates a new student object with default value.
        /// </summary>
        public Student()
        {
            this._student = new Dal.Student();
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
        /// Get all student data from dal.
        /// </summary>
        /// <returns>The student collection.</returns>
        /// <exception cref="System.ObjectDisposedException">
        /// Object is already disposed.
        /// </exception>
        public Poco.Students GetData()
        {
            if (!this.IsDisposed)
            {
                return this._student.GetData(); 
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
            this._student.Dispose();
        }
    }
}
