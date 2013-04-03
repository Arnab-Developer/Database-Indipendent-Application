// ---------------------------------------------------------------------------+
// File Name:    Common.cs
// Description:  This file containing the Common class for common database works.
// Developed By: Arnab Roy Chowdhury.
// Date:         4th March 2012.
// ---------------------------------------------------------------------------+

using System.Configuration;
using System.Data;
using System.Data.Common;
using System;

namespace Dia.Dal
{
    // Common database works.
    internal class Common : IDisposable
    {
        private IDbConnection _con;
        private IDbCommand _cmd;
        private IDataReader _dr;
        private DbProviderFactory _factory;
        private ConnectionStringSettings _conStngInstitute;
        private bool _isDisposed;

        public Common()
        {
            this._conStngInstitute = ConfigurationManager.ConnectionStrings["conInstitute"];
            this._factory = DbProviderFactories.GetFactory(this._conStngInstitute.ProviderName);
            this._con = this._factory.CreateConnection();
            this._con.ConnectionString = this._conStngInstitute.ConnectionString;
            this._cmd = this._con.CreateCommand();
            this._isDisposed = false;
        }

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

        // Database independent work and returns a IDataReader type object to the caller.
        public IDataReader ExecuteReader()
        {
            if (!this.IsDisposed)
            {
                this._cmd.CommandText = "SELECT * FROM Students";

                this._con.Open();
                this._dr = this._cmd.ExecuteReader();

                return this._dr; 
            }
            else
            {
                throw new ObjectDisposedException("Object is already disposed.");
            }
        }

        public void Dispose()
        {
            if (this.IsDisposed)
            {
                lock (this)
                {
                    this.CleanUp();
                    this._isDisposed = true;
                    GC.SuppressFinalize(this);
                }
            }
        }

        protected virtual void CleanUp()
        {
            if (this._con != null)
            {
                this._con.Dispose();
            }

            if (this._cmd != null)
            {
                this._cmd.Dispose();
            }

            if (this._dr != null)
            {
                this._dr.Dispose();
            }
        }
    }
}
