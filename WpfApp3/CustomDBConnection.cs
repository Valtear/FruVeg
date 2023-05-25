using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    internal class CustomDBConnection
    {
        string connectionString;
        string query;
        SqlConnection connection;
        SqlCommand command;
        SqlDataReader reader;
        public CustomDBConnection()
        {
            this.connectionString = null;
            this.query = null;
            this.connection = null;
            this.command = null;
            this.reader = null;
        }
        public string ConnectionString
        {
            get { return this.connectionString; }
            set
            {
                this.connectionString = value;
                this.connection = new SqlConnection(value);
            }
        }
        public string Query
        {
            get { return this.query; }
            set
            {
                this.query = value;
                this.command = new SqlCommand(value, this.connection);
            }
        }
        public SqlDataReader Reader
        {
            get { return this.reader; }
        }
        public void Execute()
        {
            this.reader = command.ExecuteReader();
        }
        public void Open()
        {
            connection.Open();
        }
        public void Close()
        {
            connection.Close();
        }
        public bool Read()
        {
            return this.reader.Read();
        }
    }
}
