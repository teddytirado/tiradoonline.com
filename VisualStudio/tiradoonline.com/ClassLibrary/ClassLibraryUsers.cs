using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ClassLibraryNameSpace
{
    public class ClassLibraryUsers
    {
        public bool CreateUser(string username, string password, string email)
        {
            //Library.tiradointeractiveMembership.MembershipLib objWebService = new Library.tiradointeractiveMembership.MembershipLib();
            //bool boolWebService = objWebService.CreateUser(username, password, email);
            //objWebService = null;
            //return boolWebService;
            return true;
        }

        public DataTable GetUsers()
        {
            SqlConnection objSQLConnection = new SqlConnection();
            SqlCommand objSQLCommand = new SqlCommand("sp_Users_get", objSQLConnection);
            objSQLCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSQLCommand);
                DataTable objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                return objDataTable;
            }
            catch (SqlException objSqlException)
            {
                string errorstring = objSqlException.ToString();
                return null;
            }
            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }
        }

        //public string GetUserID(string user_name)
        //{
        //    Library.tiradointeractiveWebServices.MembershipLib objWebService = new Library.tiradointeractiveWebServices.MembershipLib();
        //    string stringUserID = objWebService.GetUserIDByUserName(user_name);
        //    objWebService = null;
        //    return stringUserID;
        //}

        public bool ValidateUser(string user_name, string password)
        {

            //Library.tiradointeractiveWebServices.MembershipLib objWebService = new Library.tiradointeractiveWebServices.MembershipLib();
            //string teststring = user_name.ToString() + ", " + password.ToString();

            //bool objUserBool = objWebService.ValidateUser(user_name, password, "/");
            //return objUserBool;
            //return true;
            SqlConnection objSQLConnection = new SqlConnection();
            SqlCommand objSQLCommand = new SqlCommand("sp_Users_Validate", objSQLConnection);
            objSQLCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            parameterUserID.Value = user_name;
            objSQLCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterPassword = new SqlParameter("@Password", SqlDbType.VarChar);
            parameterPassword.Value = password;
            objSQLCommand.Parameters.Add(parameterPassword);

            try
            {
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSQLCommand);
                DataTable objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                if (objDataTable.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException objSqlException)
            {
                string errorstring = objSqlException.ToString();
                return false;
            }
            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }
        }
    }
}
