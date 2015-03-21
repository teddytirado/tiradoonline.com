using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ClassLibraryNameSpace;

namespace ClassLibraryDebuggerNameSpace
{
    internal class DebugTextWriter : System.IO.TextWriter
    {
        public override void Write(char[] buffer, int index, int count)
        {
            System.Diagnostics.Debug.Write(new String(buffer, index, count));
        }

        public override void Write(string value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.Default; }
        }
    }

    public class Debugger
    {
        public void LogText(string ApplicationName, string logtext)
        {
            Console.SetOut(new DebugTextWriter());
            Console.WriteLine(logtext);

            ClassLibraryRegistry objRegistry = new ClassLibraryRegistry();
            SqlConnection objSQLConnection = new SqlConnection(objRegistry.DatabaseConnectionString);
            objSQLConnection.Open();
            SqlCommand objCommand = new SqlCommand("sp_Logs_insert", objSQLConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@ApplicationName", ApplicationName);
            objCommand.Parameters.AddWithValue("@LogDesc", logtext);
            objCommand.ExecuteNonQuery();
            
            objRegistry = null;
            objCommand.Dispose();
            objSQLConnection.Close();
            objSQLConnection = null;

            //ClassLibraryDataProvider objDataProvider = new ClassLibraryDataProvider();
            //SqlParameter[] parameter = 
            //    {
            //        new SqlParameter("@ApplicationName", ApplicationName),
            //        new SqlParameter("@@LogDesc", logtext)
            //    };


            //DataTable objDataTable = objDataProvider.GetDataTable("sp_Logs_insert", CommandType.StoredProcedure, parameter);

            //objDataProvider = null;

        }

        public string LogTextOut(string ApplicationName, string logtext)
        {
            Console.SetOut(new DebugTextWriter());
            Console.WriteLine(logtext);

            ClassLibraryRegistry objRegistry = new ClassLibraryRegistry();
            SqlConnection objSQLConnection = new SqlConnection(objRegistry.DatabaseConnectionString);
            objSQLConnection.Open();
            SqlCommand objCommand = new SqlCommand("sp_Logs_insert", objSQLConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@ApplicationName", ApplicationName);
            objCommand.Parameters.AddWithValue("@LogDesc", logtext);
            objCommand.ExecuteNonQuery();

            objRegistry = null;
            objCommand.Dispose();
            objSQLConnection.Close();
            objSQLConnection = null;
            
            return logtext + Environment.NewLine;
        }
    }
}
