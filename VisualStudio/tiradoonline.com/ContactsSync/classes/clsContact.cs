using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibraryNameSpace;
using ClassLibraryDebuggerNameSpace;

namespace ContactsSyncNameSpace
{

    public class clsContact
    {
        public string logString = string.Empty;
        public int totalErrors = 0;
        public Debugger objDebugger = new Debugger();

        /********************************************************************************************************************
         * 
         * THIS WILL DELETE ANY OUTLOOK CONTACTS THAT HAVE BEEN DELETED ALREADY IN CONTACTS TABLE.
         *              
         ***********************************************************************************************************************/
        public string DeleteOutlookContacts(int UserID, ProgressBar objProgressBar)
        {
            logString = string.Empty;
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            logString += objDebugger.LogTextOut("ContactsSync", "DeleteOutlookContacts");
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            totalErrors = 0;

            string connection_String = ConfigurationManager.AppSettings["SQLConnectionString"];

            SqlConnection objSQLConnection = new SqlConnection(connection_String);
            objSQLConnection.Open();
            SqlCommand objCommand = new SqlCommand("sp_Contacts_Active_0_get", objSQLConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@UserID", UserID);

            SqlDataReader objDataReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);

            int contactsDeleted = 0;

            if (objDataReader.HasRows)
            {
                ClassLibraryOutlook objOutlook = new ClassLibraryOutlook();

                while (objDataReader.Read())
                {
                    string ErrorMessage = string.Empty;
                    if (objOutlook.DeleteOutlookContact((string)objDataReader["EntryID"], ref ErrorMessage))
                    {
                        contactsDeleted++;
                        logString += objDebugger.LogTextOut("ContactsSync", "Outlook Contact '" + (string)objDataReader["FileAs"] + "' deleted");
                    }
                    else
                    {
                        totalErrors++;
                        logString += objDebugger.LogTextOut("ContactsSync", ErrorMessage);
                    }

                }

                objOutlook = null;

            }

            objCommand.Dispose();
            objCommand = null;

            objSQLConnection.Close();
            objSQLConnection.Dispose();
            objSQLConnection = null;

            logString += objDebugger.LogTextOut("ContactsSync", Environment.NewLine + "errors: " + totalErrors.ToString());
            logString += objDebugger.LogTextOut("ContactsSync", contactsDeleted.ToString() + " OUTLOOK CONTACTS DELETED.");

            return logString;
        }

        /*********************************************************************************************************************/
        /* THIS WILL INSERT NEW OUTLOOK CONTACTS FROM Contacts TABLE WHERE ENTRYID = '0'                                     */
        /*********************************************************************************************************************/
        public string AddNewOutlookContacts(int UserID, ProgressBar objProgressBar)
        {
            logString = string.Empty;
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            logString += objDebugger.LogTextOut("ContactsSync", "AddNewOutlookContacts");
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            totalErrors = 0;

            string connection_String = ConfigurationManager.AppSettings["SQLConnectionString"];
            SqlConnection objSQLConnection = new SqlConnection(connection_String);
            objSQLConnection.Open();
            SqlCommand objCommand = new SqlCommand("sp_Contacts_0_get", objSQLConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@UserID", UserID);
            SqlDataReader objDataReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);

            int contactsAdded = 0;

            ClassLibraryOutlook objOutlook = new ClassLibraryOutlook();

            while (objDataReader.Read())
            {
                string ErrorMessage = string.Empty;
                
                try
                {
                    if (objOutlook.CreateOutlookContact
                        (
                            (string)objDataReader["EntryID"],
                            (string)objDataReader["FileAs"],
                            (string)objDataReader["FirstName"],
                            (string)objDataReader["LastName"],
                            (string)objDataReader["FullName"],
                            (string)objDataReader["JobTitle"],
                            (string)objDataReader["CompanyName"],
                            (string)objDataReader["Email1Address"],
                            (string)objDataReader["Email2Address"],
                            (string)objDataReader["Email3Address"],
                            (string)objDataReader["WebPage"],
                            (string)objDataReader["IMAddress"],
                            (string)objDataReader["MobileTelephoneNumber"],
                            (string)objDataReader["HomeTelephoneNumber"],
                            (string)objDataReader["BusinessTelephoneNumber"],
                            (string)objDataReader["BusinessFaxNumber"],
                            (string)objDataReader["HomeAddressStreet"],
                            (string)objDataReader["HomeAddressCity"],
                            (string)objDataReader["HomeAddressState"],
                            (string)objDataReader["HomeAddressPostalCode"],
                            (string)objDataReader["BusinessAddressStreet"],
                            (string)objDataReader["BusinessAddressCity"],
                            (string)objDataReader["BusinessAddressState"],
                            (string)objDataReader["BusinessAddressPostalCode"],
                            ref ErrorMessage
                        )
                        )
                    {
                        contactsAdded++;
                        logString += objDebugger.LogTextOut("ContactsSync", "Outlook Contact '" + (string)objDataReader["FileAs"] + "' CREATED");
                    }
                    else
                    {
                        totalErrors++;
                        logString += objDebugger.LogTextOut("ContactsSync", ErrorMessage);
                    }
                }
                catch (Exception ex)
                {
                    logString += objDebugger.LogTextOut("ContactsSync", (string)objDataReader["FileAs"] + " - ERROR: " + ex.Message);
                    totalErrors++;
                }

            }

            objOutlook = null;


            objCommand.Dispose();
            objCommand = null;

            objSQLConnection.Close();
            objSQLConnection.Dispose();
            objSQLConnection = null;

            /*
             DELETE FROM Contacts WHERE ENTRY IS 0, WE DELETE IT BECAUSE IT'S GONNA BE RECREATED AS A NEW OUTLOOK CONTACT THEN ContactSys WILL ADD IT WITH AN ENTRYID
            */

            if (contactsAdded > 0)
            {
                SqlConnection objSQLConnection2 = new SqlConnection(connection_String);
                objSQLConnection2.Open();
                SqlCommand objCommand2 = new SqlCommand("sp_Contacts_EntryID_0_delete", objSQLConnection2);
                objCommand2.Parameters.AddWithValue("@UserID", UserID);
                objCommand2.CommandType = CommandType.StoredProcedure;
                objCommand2.ExecuteNonQuery();

                objCommand2.Dispose();
                objCommand2 = null;

                objSQLConnection2.Close();
                objSQLConnection2 = null;
            }
            objDataReader.Close();
            objDataReader = null;
            objCommand = null;

            logString += objDebugger.LogTextOut("ContactsSync", "errors: " + totalErrors.ToString());
            logString += objDebugger.LogTextOut("ContactsSync", contactsAdded.ToString() + " ContactsOutlookExport added.");
            return logString;
        }

        /*********************************************************************************************************************/
        /* THIS WILL TRUNCATE THE ContactsOutlookExport TABLE AND INSERT ALL OUTLOOK CONTACTS INTO THE ContactsOutlookExport */
        /*********************************************************************************************************************/
        public string ImportOutlookContacts(int UserID, string path, ProgressBar objProgressBar)
        {
            objProgressBar.Value = 1;
            logString = string.Empty;
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            logString += objDebugger.LogTextOut("ContactsSync", "ImportOutlookContacts");
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            totalErrors = 0;

            List<string> entryIDList = new List<string>();

            totalErrors = 0;
            string EntryID = string.Empty;
            string FileAs = string.Empty;
            string FirstName = string.Empty;
            string LastName = string.Empty;
            string FullName = string.Empty;
            string CompanyName = string.Empty;
            string JobTitle = string.Empty;
            string Email1Address = string.Empty;
            string Email2Address = string.Empty;
            string Email3Address = string.Empty;
            string WebPage = string.Empty;
            string IMAddress = string.Empty;
            string MobileTelephoneNumber = string.Empty;
            string HomeTelephoneNumber = string.Empty;
            string BusinessTelephoneNumber = string.Empty;
            string BusinessFaxNumber = string.Empty;
            string HomeAddressStreet = string.Empty;
            string HomeAddressCity = string.Empty;
            string HomeAddressState = string.Empty;
            string HomeAddressPostalCode = string.Empty;
            string BusinessAddressStreet = string.Empty;
            string BusinessAddressCity = string.Empty;
            string BusinessAddressState = string.Empty;
            string BusinessAddressPostalCode = string.Empty;
            bool HasPicture = false;
            DateTime LastModificationTime;

            ClassLibraryOutlook objOutlook = new ClassLibraryOutlook();
            int totalContacts = objOutlook.totalContacts;
            objProgressBar.Maximum = totalContacts;


            //SqlConnection objSQLConnection = new SqlConnection(@"Server=.\SQL2K8;Database=balanceintranet;Integrated Security=false;User Id=balanceintranet_user;Password=balanceintranet;");
            string connection_String = ConfigurationManager.AppSettings["SQLConnectionString"];
            SqlConnection objSQLConnection = new SqlConnection(connection_String);
            objSQLConnection.Open();

            int totalrows = 0;

            SqlCommand objCommand = new SqlCommand("sp_ContactsOutlookExport_delete", objSQLConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.ExecuteNonQuery();
            objCommand = null;

            for (int i = 1; i < totalContacts; i++)
            {
                EntryID = string.Empty;
                FileAs = string.Empty;
                FirstName = string.Empty;
                LastName = string.Empty;
                FullName = string.Empty;
                CompanyName = string.Empty;
                JobTitle = string.Empty;
                Email1Address = string.Empty;
                Email2Address = string.Empty;
                Email3Address = string.Empty;
                WebPage = string.Empty;
                IMAddress = string.Empty;
                MobileTelephoneNumber = string.Empty;
                HomeTelephoneNumber = string.Empty;
                BusinessTelephoneNumber = string.Empty;
                BusinessFaxNumber = string.Empty;
                HomeAddressStreet = string.Empty;
                HomeAddressCity = string.Empty;
                HomeAddressState = string.Empty;
                HomeAddressPostalCode = string.Empty;
                BusinessAddressStreet = string.Empty;
                BusinessAddressCity = string.Empty;
                BusinessAddressState = string.Empty;
                BusinessAddressPostalCode = string.Empty;
                HasPicture = false;
                LastModificationTime = DateTime.Now;
                string ErrorMessage = string.Empty;

                try
                {
                    if (objOutlook.GetOutlookContact
                        (
                            i,
                            path,
                            ref EntryID,
                            ref FileAs,
                            ref FirstName,
                            ref LastName,
                            ref FullName,
                            ref JobTitle,
                            ref CompanyName,
                            ref Email1Address,
                            ref Email2Address,
                            ref Email3Address,
                            ref WebPage,
                            ref IMAddress,
                            ref MobileTelephoneNumber,
                            ref HomeTelephoneNumber,
                            ref BusinessTelephoneNumber,
                            ref BusinessFaxNumber,
                            ref HomeAddressStreet,
                            ref HomeAddressCity,
                            ref HomeAddressState,
                            ref HomeAddressPostalCode,
                            ref BusinessAddressStreet,
                            ref BusinessAddressCity,
                            ref BusinessAddressState,
                            ref BusinessAddressPostalCode,
                            ref HasPicture,
                            ref LastModificationTime,
                            ref ErrorMessage
                        )
                    )
                    {
                        if (EntryID != string.Empty)
                        {
                            entryIDList.Add(EntryID);
                        }

                        objCommand = new SqlCommand("sp_ContactsOutlookExport_insert", objSQLConnection);
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@EntryID", EntryID);
                        objCommand.Parameters.AddWithValue("@UserID", UserID);
                        objCommand.Parameters.AddWithValue("@FileAs", FileAs);
                        objCommand.Parameters.AddWithValue("@FirstName", FirstName);
                        objCommand.Parameters.AddWithValue("@LastName", LastName);
                        objCommand.Parameters.AddWithValue("@FullName", FullName);
                        objCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
                        objCommand.Parameters.AddWithValue("@JobTitle", JobTitle);
                        objCommand.Parameters.AddWithValue("@Email1Address", Email1Address);
                        objCommand.Parameters.AddWithValue("@Email2Address", Email2Address);
                        objCommand.Parameters.AddWithValue("@Email3Address", Email3Address);
                        objCommand.Parameters.AddWithValue("@WebPage", WebPage);
                        objCommand.Parameters.AddWithValue("@IMAddress", IMAddress);
                        objCommand.Parameters.AddWithValue("@MobileTelephoneNumber", MobileTelephoneNumber);
                        objCommand.Parameters.AddWithValue("@HomeTelephoneNumber", HomeTelephoneNumber);
                        objCommand.Parameters.AddWithValue("@BusinessTelephoneNumber", BusinessTelephoneNumber);
                        objCommand.Parameters.AddWithValue("@BusinessFaxNumber", BusinessFaxNumber);
                        objCommand.Parameters.AddWithValue("@HomeAddressStreet", HomeAddressStreet);
                        objCommand.Parameters.AddWithValue("@HomeAddressCity", HomeAddressCity);
                        objCommand.Parameters.AddWithValue("@HomeAddressState", HomeAddressState);
                        objCommand.Parameters.AddWithValue("@HomeAddressPostalCode", HomeAddressPostalCode);
                        objCommand.Parameters.AddWithValue("@BusinessAddressStreet", BusinessAddressStreet);
                        objCommand.Parameters.AddWithValue("@BusinessAddressCity", BusinessAddressCity);
                        objCommand.Parameters.AddWithValue("@BusinessAddressState", BusinessAddressState);
                        objCommand.Parameters.AddWithValue("@BusinessAddressPostalCode", BusinessAddressPostalCode);
                        objCommand.Parameters.AddWithValue("@HasPicture", HasPicture);
                        objCommand.Parameters.AddWithValue("@LastModificationTime", LastModificationTime);

                    }

                    objCommand = null;

                }
                catch (Exception ex)
                {
                    logString += objDebugger.LogTextOut("ContactsSync", i.ToString() + ") " + FileAs + " - ERROR: " + ex.Message);
                    totalErrors++;
                }

                objProgressBar.Value += 1;

                Application.DoEvents();
            }
            objSQLConnection.Close();
            objSQLConnection = null;

            objOutlook = null;

            logString += objDebugger.LogTextOut("ContactsSync", "errors: " + totalErrors.ToString());
            logString += objDebugger.LogTextOut("ContactsSync", totalrows.ToString() + " total Contacts added.");
            return logString;

        }


        /********************************************************************************************************************/
        /*                                                                                                                  */
        /* 1) IT WILL TAKE ANY NEW RECORDS FROM ContactsOutlookExport TABLE AND INSERT INTO CONTACTS TABLE                  */
        /*                                                                                                                  */
        /* 2) THIS WILL COMPARE THE LastModicationFields IN CONTACT AND ContactsOutlookExport TABLES                        */
        /*                                                                                                                  */
        /* if (ContactsDateTime > ContactsOutlookExportDateTime) THEN                                                       */
        /*              TAKE THE FROM Contacts Table AND UPDATE THE OUTLOOK CONTACT                                         */
        /*                                                                                                                  */
        /* if (ContactsDateTime < ContactsOutlookExportDateTime) THEN                                                        */
        /*              UPDATE Contacts Table FROM CONTACTSOUTLOOKEXPORT TABLE                                               */
        /*                                                                                                                   */
        /***********************************************************************************************************************/
        public string ContactsSync(int UserID, ProgressBar objProgressBar)
        {
            logString = string.Empty;
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            logString += objDebugger.LogTextOut("ContactsSync", "ContactsSync");
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            totalErrors = 0;

            string connection_String = ConfigurationManager.AppSettings["SQLConnectionString"];

            SqlConnection objSQLConnection = new SqlConnection(connection_String);
            objSQLConnection.Open();
            SqlCommand objCommand = new SqlCommand("sp_Contacts_Sync_check", objSQLConnection);
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@UserID", UserID);

            SqlDataReader objDataReader = objCommand.ExecuteReader(CommandBehavior.CloseConnection);

            int i = 1;
            int contactsUpdated = 0;

            if (objDataReader.HasRows)
            {
                while (objDataReader.Read())
                {
                    logString += objDebugger.LogTextOut("ContactsSync", i.ToString() + ") " + (string)objDataReader["ContactsFileAs"]);
                    DateTime ContactsDateTime = (DateTime)objDataReader["ContactsDateTime"];
                    DateTime ContactsOutlookExportDateTime = (DateTime)objDataReader["ContactsOutlookExportDateTime"];

                    ClassLibraryOutlook objOutlook = new ClassLibraryOutlook();

                    if (ContactsDateTime > ContactsOutlookExportDateTime)
                    {
                        /****************************************
                            UPDATE OUTLOOK CONTACT
                        /****************************************/
                        string ErrorMessage = string.Empty;

                        try
                        {
                            if (objOutlook.SaveOutlookContact
                                (
                                    (string)objDataReader["EntryID"],
                                    (string)objDataReader["ContactsFileAs"],
                                    (string)objDataReader["ContactsFirstName"],
                                    (string)objDataReader["ContactsLastName"],
                                    (string)objDataReader["ContactsFullName"],
                                    (string)objDataReader["ContactsJobTitle"],
                                    (string)objDataReader["ContactsCompanyName"],
                                    (string)objDataReader["ContactsEmail1Address"],
                                    (string)objDataReader["ContactsEmail2Address"],
                                    (string)objDataReader["ContactsEmail3Address"],
                                    (string)objDataReader["ContactsWebPage"],
                                    (string)objDataReader["ContactsIMAddress"],
                                    (string)objDataReader["ContactsMobileTelephoneNumber"],
                                    (string)objDataReader["ContactsHomeTelephoneNumber"],
                                    (string)objDataReader["ContactsBusinessTelephoneNumber"],
                                    (string)objDataReader["ContactsBusinessFaxNumber"],
                                    (string)objDataReader["ContactsHomeAddressStreet"],
                                    (string)objDataReader["ContactsHomeAddressCity"],
                                    (string)objDataReader["ContactsHomeAddressState"],
                                    (string)objDataReader["ContactsHomeAddressPostalCode"],
                                    (string)objDataReader["ContactsBusinessAddressStreet"],
                                    (string)objDataReader["ContactsBusinessAddressCity"],
                                    (string)objDataReader["ContactsBusinessAddressState"],
                                    (string)objDataReader["ContactsBusinessAddressPostalCode"],
                                    ref ErrorMessage
                                )
                                )
                            {
                                contactsUpdated++;
                                logString += objDebugger.LogTextOut("ContactsSync", i.ToString() + ") Outlook Contact '" + (string)objDataReader["ContactsFileAs"] + "' CREATED");
                            }
                            else
                            {
                                totalErrors++;
                                logString += objDebugger.LogTextOut("ContactsSync", ErrorMessage);
                            }
                        }
                        catch (Exception ex)
                        {
                            logString += objDebugger.LogTextOut("ContactsSync", i.ToString() + ") " + (string)objDataReader["ContactsFileAs"] + ") - ERROR: " + ex.Message);
                            totalErrors++;
                        }
                    }
                    else
                    {
                        logString += objDebugger.LogTextOut("ContactsSync", i.ToString() + ") " + ContactsDateTime.ToLongDateString() + " < " + ContactsOutlookExportDateTime.ToLongDateString());
                        try
                        {

                            SqlConnection objSQLConnection2 = new SqlConnection(connection_String);
                            objSQLConnection2.Open();
                            SqlCommand objCommand2 = new SqlCommand("sp_Contacts_update", objSQLConnection2);
                            objCommand2.CommandType = CommandType.StoredProcedure;
                            objCommand2.Parameters.AddWithValue("@ContactID", (int)objDataReader["ContactID"]);
                            objCommand2.Parameters.AddWithValue("@EntryID", (string)objDataReader["EntryID"]);
                            objCommand2.Parameters.AddWithValue("@FileAs", (string)objDataReader["ContactsOutlookExportFileAs"]);
                            objCommand2.Parameters.AddWithValue("@FirstName", (string)objDataReader["ContactsOutlookExportFirstName"]);
                            objCommand2.Parameters.AddWithValue("@LastName", (string)objDataReader["ContactsOutlookExportLastName"]);
                            objCommand2.Parameters.AddWithValue("@FullName", (string)objDataReader["ContactsOutlookExportFullName"]);
                            objCommand2.Parameters.AddWithValue("@CompanyName", (string)objDataReader["ContactsOutlookExportCompanyName"]);
                            objCommand2.Parameters.AddWithValue("@JobTitle", (string)objDataReader["ContactsOutlookExportJobTitle"]);
                            objCommand2.Parameters.AddWithValue("@Email1Address", (string)objDataReader["ContactsOutlookExportEmail1Address"]);
                            objCommand2.Parameters.AddWithValue("@Email2Address", (string)objDataReader["ContactsOutlookExportEmail2Address"]);
                            objCommand2.Parameters.AddWithValue("@Email3Address", (string)objDataReader["ContactsOutlookExportEmail3Address"]);
                            objCommand2.Parameters.AddWithValue("@WebPage", (string)objDataReader["ContactsOutlookExportWebPage"]);
                            objCommand2.Parameters.AddWithValue("@IMAddress", (string)objDataReader["ContactsOutlookExportIMAddress"]);
                            objCommand2.Parameters.AddWithValue("@MobileTelephoneNumber", (string)objDataReader["ContactsOutlookExportMobileTelephoneNumber"]);
                            objCommand2.Parameters.AddWithValue("@HomeTelephoneNumber", (string)objDataReader["ContactsOutlookExportHomeTelephoneNumber"]);
                            objCommand2.Parameters.AddWithValue("@BusinessTelephoneNumber", (string)objDataReader["ContactsOutlookExportBusinessTelephoneNumber"]);
                            objCommand2.Parameters.AddWithValue("@BusinessFaxNumber", (string)objDataReader["ContactsOutlookExportBusinessFaxNumber"]);
                            objCommand2.Parameters.AddWithValue("@HomeAddressStreet", (string)objDataReader["ContactsOutlookExportHomeAddressStreet"]);
                            objCommand2.Parameters.AddWithValue("@HomeAddressCity", (string)objDataReader["ContactsOutlookExportHomeAddressCity"]);
                            objCommand2.Parameters.AddWithValue("@HomeAddressState", (string)objDataReader["ContactsOutlookExportHomeAddressState"]);
                            objCommand2.Parameters.AddWithValue("@HomeAddressPostalCode", (string)objDataReader["ContactsOutlookExportHomeAddressPostalCode"]);
                            objCommand2.Parameters.AddWithValue("@BusinessAddressStreet", (string)objDataReader["ContactsOutlookExportBusinessAddressStreet"]);
                            objCommand2.Parameters.AddWithValue("@BusinessAddressCity", (string)objDataReader["ContactsOutlookExportBusinessAddressCity"]);
                            objCommand2.Parameters.AddWithValue("@BusinessAddressState", (string)objDataReader["ContactsOutlookExportBusinessAddressState"]);
                            objCommand2.Parameters.AddWithValue("@BusinessAddressPostalCode", (string)objDataReader["ContactsOutlookExportBusinessAddressPostalCode"]);
                            objCommand2.Parameters.AddWithValue("@HasPicture", (bool)objDataReader["ContactsOutlookExportHasPicture"]);
                            objCommand2.Parameters.AddWithValue("@LastModificationTime", (DateTime)objDataReader["ContactsOutlookExportDateTime"]);
                            objCommand2.ExecuteNonQuery();
                            objCommand2.Dispose();
                            objCommand2 = null;

                            objSQLConnection2.Close();
                            objSQLConnection2.Dispose();
                            objSQLConnection2 = null;
                            contactsUpdated++;
                            logString += objDebugger.LogTextOut("ContactsSync", i.ToString() + ") sp_Contacts_update: " + (string)objDataReader["ContactsOutlookExportFileAs"] + " Contact updated.");
                        }
                        catch (Exception ex)
                        {
                            logString += objDebugger.LogTextOut("ContactsSync", i.ToString() + ") - ERROR: " + ex.Message);
                            totalErrors++;
                        }
                    }

                    i++;
                }
                objDataReader.Close();
                objDataReader.Dispose();
                objDataReader = null;
            }
            logString += objDebugger.LogTextOut("ContactsSync", "errors: " + totalErrors.ToString());
            logString += objDebugger.LogTextOut("ContactsSync", contactsUpdated.ToString() + " Contacts updated.");

            return logString;
        }

        /********************************************************************************************************************
     * 
     * THIS WILL DELETE ANY OUTLOOK CONTACTS THAT HAVE BEEN DELETED ALREADY IN CONTACTS TABLE.
     *              
     ***********************************************************************************************************************/
        public string DeleteDuplicateOutlookContacts()
        {
            ClassLibraryOutlook objOutlook = new ClassLibraryOutlook();

            logString = string.Empty;
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            logString += objDebugger.LogTextOut("ContactsSync", "DeleteDuplicateOutlookContacts");
            logString += objDebugger.LogTextOut("ContactsSync", "**********************************************");
            totalErrors = 0;

            logString += objOutlook.DeleteDuplicateOutlookContacts();

            objOutlook = null;

            return logString;
        }
    }
}


