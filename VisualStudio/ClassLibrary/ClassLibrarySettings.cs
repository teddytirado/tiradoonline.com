using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace ClassLibraryNameSpace
{
    public class ClassLibrarySettings
    {
        public int SettingID;
        public string UserID;
        public string defaultURL;
        public string ResumeDOC;
        public string ResumePDF;
        public string SMTPHost;
        public string SMTPPort;
        public string SMTPUserName;
        public string SMTPPassword;
        public string POP3Host;
        public string POP3UserName;
        public string POP3Password = string.Empty;
        public string EmailFromAddress;
        public string EmailFromName;

        public void UpdateResumeDOC(string strResumeDoc)
        {
            SqlConnection objSQLConnection = new SqlConnection();
            SqlCommand objSQLCommand = new SqlCommand("UPDATE Settings SET ResumeDOC = '" + strResumeDoc + "'", objSQLConnection);
            objSQLConnection.Open();
            objSQLCommand.ExecuteNonQuery();
            objSQLConnection.Close();
            objSQLConnection = null;
        }

        public void UpdateResumePDF(string strResumePDF)
        {
            SqlConnection objSQLConnection = new SqlConnection();
            SqlCommand objSQLCommand = new SqlCommand("UPDATE Settings SET ResumePDF = '" + strResumePDF + "'", objSQLConnection);
            objSQLConnection.Open();
            objSQLCommand.ExecuteNonQuery();
            objSQLConnection.Close();
            objSQLConnection = null;
        }

        public void Update()
        {
            SqlConnection objSQLConnection = new SqlConnection();
            SqlCommand objSQLCommand = new SqlCommand("sp_Settings_update", objSQLConnection);
            objSQLCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            //parameterUserID.Value = ConfigurationManager.AppSettings["defaultUserID"].ToString();
            objSQLCommand.Parameters.Add(parameterUserID);

            SqlParameter parameterdefaultURL = new SqlParameter("@defaultURL", SqlDbType.VarChar);
            parameterdefaultURL.Value = this.defaultURL;
            objSQLCommand.Parameters.Add(parameterdefaultURL);

            //SqlParameter parameterResumeDOC = new SqlParameter("@ResumeDOC", SqlDbType.VarChar);
            //parameterResumeDOC.Value = this.ResumeDOC;
            //objSQLCommand.Parameters.Add(parameterResumeDOC);

            //SqlParameter parameterResumePDF = new SqlParameter("@ResumePDF", SqlDbType.VarChar);
            //parameterResumePDF.Value = this.ResumePDF;
            //objSQLCommand.Parameters.Add(parameterResumePDF);

            SqlParameter parameterSMTPHost = new SqlParameter("@SMTPHost", SqlDbType.VarChar);
            parameterSMTPHost.Value = this.SMTPHost;
            objSQLCommand.Parameters.Add(parameterSMTPHost);

            SqlParameter parameterSMTPUserName = new SqlParameter("@SMTPUserName", SqlDbType.VarChar);
            parameterSMTPUserName.Value = this.SMTPUserName;
            objSQLCommand.Parameters.Add(parameterSMTPUserName);

            SqlParameter parameterSMTPPassword = new SqlParameter("@SMTPPassword", SqlDbType.VarChar);
            parameterSMTPPassword.Value = this.SMTPPassword;
            objSQLCommand.Parameters.Add(parameterSMTPPassword);

            SqlParameter parameterPOP3Host = new SqlParameter("@POP3Host", SqlDbType.VarChar);
            parameterPOP3Host.Value = this.POP3Host;
            objSQLCommand.Parameters.Add(parameterPOP3Host);

            SqlParameter parameterPOP3UserName = new SqlParameter("@POP3UserName", SqlDbType.VarChar);
            parameterPOP3UserName.Value = this.POP3UserName;
            objSQLCommand.Parameters.Add(parameterPOP3UserName);

            SqlParameter parameterPOP3Password = new SqlParameter("@POP3Password", SqlDbType.VarChar);
            parameterPOP3Password.Value = this.POP3Password;
            objSQLCommand.Parameters.Add(parameterPOP3Password);

            SqlParameter parameterEmailFromAddress = new SqlParameter("@EmailFromAddress", SqlDbType.VarChar);
            parameterEmailFromAddress.Value = this.EmailFromAddress;
            objSQLCommand.Parameters.Add(parameterEmailFromAddress);

            SqlParameter parameterEmailFromName = new SqlParameter("@EmailFromName", SqlDbType.VarChar);
            parameterEmailFromName.Value = this.EmailFromName;
            objSQLCommand.Parameters.Add(parameterEmailFromName);

            try
            {
                objSQLConnection.Open();
                objSQLCommand.ExecuteNonQuery();
                // Return Identity of Snippet
                //objMovieStruct.MovieDBReturnValue = int.Parse(parameterReturnValue.Value.ToString());
            }
            catch (SqlException objSqlException)
            {
                string errorstring = objSqlException.Errors[0].ToString();
                //string RedirectURL = "/ErrorPage.aspx?ErrorMessage=";
                //HttpContext.Current.Response.Redirect(RedirectURL);                
            }
            finally
            {
                if (objSQLConnection.State == ConnectionState.Open)
                {
                    objSQLConnection.Close();
                    objSQLConnection = null;
                }
            }
            //return objMovieStruct;
        }

        public void GetRows_UserID(string p_UserID)
        {
            SqlConnection objSQLConnection = new SqlConnection();
            SqlCommand objSQLCommand = new SqlCommand("sp_Settings_UserID_get", objSQLConnection);
            objSQLCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter parameterUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            parameterUserID.Value = p_UserID; ;
            objSQLCommand.Parameters.Add(parameterUserID);

            try
            {
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(objSQLCommand);
                DataTable objDataTable = new DataTable();
                objSqlDataAdapter.Fill(objDataTable);
                this.defaultURL = objDataTable.Rows[0]["defaultURL"].ToString();
                this.ResumeDOC = objDataTable.Rows[0]["ResumeDOC"].ToString();
                this.ResumePDF = objDataTable.Rows[0]["ResumePDF"].ToString();
                this.SMTPPort = objDataTable.Rows[0]["SMTPPort"].ToString();
                this.SMTPHost = objDataTable.Rows[0]["SMTPHost"].ToString();
                this.SMTPUserName = objDataTable.Rows[0]["SMTPUserName"].ToString();
                this.SMTPPassword = objDataTable.Rows[0]["SMTPPassword"].ToString();
                this.POP3Host = objDataTable.Rows[0]["POP3Host"].ToString();
                this.POP3UserName = objDataTable.Rows[0]["POP3UserName"].ToString();
                this.POP3Password = objDataTable.Rows[0]["POP3Password"].ToString();
                this.EmailFromAddress = objDataTable.Rows[0]["EmailFromAddress"].ToString();
                this.EmailFromName = objDataTable.Rows[0]["EmailFromName"].ToString();
            }
            catch (SqlException objSqlException)
            {
                string errorstring = objSqlException.Errors[0].ToString();
                //string RedirectURL = "/ErrorPage.aspx?ErrorMessage=";
                //HttpContext.Current.Response.Redirect(RedirectURL);
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
