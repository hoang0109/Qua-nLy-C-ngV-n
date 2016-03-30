using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
namespace QuanLyCongVan
{
    class ConnectDatabase
    {
        protected static String _connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Database.accdb;Jet OLEDB:Database Password=CATBK123123;";
        static OleDbConnection connection;
        public static void OpenConnection()
        {
            try
            {
                connection = new OleDbConnection(_connectionString);
                connection.Open();
                Console.WriteLine("ket noi thanh cong");
            }
            catch
            {
                Console.WriteLine("ket noi khong thanh cong");
                connection.Close();
            }

        }
        public static void CloseConnection()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
        public static DataTable ExcuQuery(string sql)
        {
            OpenConnection();
            DataTable dt = new DataTable();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            CloseConnection();
            return dt;
        }
        public static void ExcuNonQuery(string sql)
        {
            OpenConnection();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
