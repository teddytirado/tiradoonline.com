using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibraryNameSpace
{
    public class ClassLibraryDataProvider
    {
        private static string ConnectionString;

        public ClassLibraryDataProvider()
        {
            ClassLibraryRegistry objRegistry = new ClassLibraryRegistry();
            ConnectionString = objRegistry.DatabaseConnectionString;
            objRegistry = null;
        }

        public DataTable GetDataTable(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            DataTable result = new DataTable();

            SqlConnection objSQLConnection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand (commandText, objSQLConnection);

            foreach (SqlParameter parameter in parameters)
            {
                Command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
            }

            SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);

            try
            {
                DataAdapter.Fill(result);
            }

            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }


            return result;
        }

        public DataTable GetDataTable(string commandText, CommandType commandType)
        {
            DataTable result = new DataTable();

            SqlConnection objSQLConnection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand(commandText, objSQLConnection);


            SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);

            try
            {
                DataAdapter.Fill(result);
            }

            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }


            return result;
        }

        public static DataSet GetDataSet(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            DataSet result = new DataSet();

            SqlConnection objSQLConnection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand(commandText, objSQLConnection);

            foreach (SqlParameter parameter in parameters)
            {
                Command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
            }

            SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);

            try
            {
                DataAdapter.Fill(result);
            }

            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }


            return result;
        }

        public static object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            object result;

            SqlConnection objSQLConnection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand(commandText, objSQLConnection);

            foreach (SqlParameter parameter in parameters)
                Command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);

            try
            {
                if (objSQLConnection.State == ConnectionState.Closed)
                    objSQLConnection.Open();
                result = Command.ExecuteScalar();
            }

            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }

            return result;
        }

        public static int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            int result;

            SqlConnection objSQLConnection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand(commandText, objSQLConnection);

            foreach (SqlParameter parameter in parameters)
                Command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);

            try
            {
                if (objSQLConnection.State == ConnectionState.Closed)
                    objSQLConnection.Open();
                result = Command.ExecuteNonQuery();
            }

            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }


            return result;
        }


        public static DataRow GetDataRow(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            System.Data.DataTable result = new DataTable();

            SqlConnection objSQLConnection = new SqlConnection(ConnectionString);

            SqlCommand Command = new SqlCommand(commandText, objSQLConnection);

            foreach (SqlParameter parameter in parameters)
                Command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);

            SqlDataAdapter DataAdapter = new SqlDataAdapter(Command);

            try
            {
                DataAdapter.Fill(result);
            }

            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }


            return (result.Rows.Count > 0) ? result.Rows[0] : null;
        }
    }
}
