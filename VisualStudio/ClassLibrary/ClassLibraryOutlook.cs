using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ClassLibraryNameSpace
{
    public class ClassLibraryOutlook
    {
        public int totalContacts;

        /***************************************************/
        /* CONSTRUCTOR                                      */
        /* - INITIALIZE TOTAL NUMBER OF OUTLOOK CONTACTS */
        /***************************************************/
        public ClassLibraryOutlook()
        {
            Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Outlook.NameSpace ns = app.GetNamespace("MAPI");
            Outlook.MAPIFolder contacts = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);
            
            this.totalContacts = contacts.Items.Count;

            app = null;
            ns = null;
            contacts = null;
        }

        /****************************************/
        /* DELETE OUTLOOK CONTACT                */
        /* - pass it OUTLOOK ENTRYID             */
        /****************************************/
        public bool DeleteOutlookContact(string EntryID, ref string ErrorMessage)
        {
            bool boolContactDeleted = true;

            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();

            Microsoft.Office.Interop.Outlook.MAPIFolder Folder_Contacts = (Microsoft.Office.Interop.Outlook.MAPIFolder)
            outlookApp.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts);


            Microsoft.Office.Interop.Outlook.Items searchFolder = Folder_Contacts.Items;
            if (Folder_Contacts.Items.Count > 0)
            {
                foreach (Microsoft.Office.Interop.Outlook.ContactItem contact in searchFolder)
                {
                    if (contact.EntryID.Contains(EntryID))
                    {
                        try
                        {
                            contact.Delete();
                            boolContactDeleted = true;
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage += "ERROR: " + ex.Message + Environment.NewLine;
                            boolContactDeleted = false;
                        }
                    }
                }
            }

            Folder_Contacts = null;
            outlookApp = null;
            return boolContactDeleted;
        }

        /****************************************/
        /* CREATE OUTLOOK CONTACT               */
        /****************************************/
        public bool CreateOutlookContact
                (
                    string EntryID, 
                    string FileAs,
                    string FirstName,
                    string LastName,
                    string FullName,
                    string JobTitle,
                    string CompanyName,
                    string Email1Address,
                    string Email2Address,
                    string Email3Address,
                    string WebPage,
                    string IMAddress,
                    string MobileTelephoneNumber,
                    string HomeTelephoneNumber,
                    string BusinessTelephoneNumber,
                    string BusinessFaxNumber,
                    string HomeAddressStreet,
                    string HomeAddressCity,
                    string HomeAddressStateName,
                    string HomeAddressPostalCode,
                    string BusinessAddressStreet,
                    string BusinessAddressCity,
                    string BusinessAddressStateName,
                    string BusinessAddressPostalCode,
                    ref string ErrorMessage
                )
        {
            bool boolContactAdded = true;

            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
            outlookApp.Session.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts);

            try
            {
                Microsoft.Office.Interop.Outlook.ContactItem contact = (Outlook.ContactItem)outlookApp.CreateItem(Outlook.OlItemType.olContactItem);

                contact.FileAs = FileAs;
                contact.FirstName = FirstName;
                contact.LastName = LastName;
                contact.FullName = FullName;
                contact.CompanyName = CompanyName;
                contact.JobTitle = JobTitle;
                contact.Email1Address = Email1Address;
                contact.Email2Address = Email2Address;
                contact.Email3Address = Email3Address;
                contact.WebPage = WebPage;
                contact.IMAddress = IMAddress;
                contact.MobileTelephoneNumber = MobileTelephoneNumber;
                contact.HomeTelephoneNumber = HomeTelephoneNumber;
                contact.BusinessTelephoneNumber = BusinessTelephoneNumber;
                contact.BusinessFaxNumber = BusinessFaxNumber;
                contact.HomeAddressStreet = HomeAddressStreet;
                contact.HomeAddressCity = HomeAddressCity;
                contact.HomeAddressState = HomeAddressStateName;
                contact.HomeAddressPostalCode = HomeAddressPostalCode;
                contact.BusinessAddressStreet = BusinessAddressStreet;
                contact.BusinessAddressCity = BusinessAddressCity;
                contact.BusinessAddressState = BusinessAddressStateName;
                contact.BusinessAddressPostalCode = BusinessAddressPostalCode;

                contact.Save();

                contact = null;

                boolContactAdded = true;
            }
            catch (Exception ex)
            {
                ErrorMessage += "ERROR: " + ex.Message + Environment.NewLine;
                boolContactAdded = false;
            }

            outlookApp = null;
            return boolContactAdded;
        }

    /****************************************/
    /* CREATE OUTLOOK CONTACT                */
    /****************************************/
        public bool SaveOutlookContact
                (
                    string EntryID,
                    string FileAs,
                    string FirstName,
                    string LastName,
                    string FullName,
                    string JobTitle,
                    string CompanyName,
                    string Email1Address,
                    string Email2Address,
                    string Email3Address,
                    string WebPage,
                    string IMAddress,
                    string MobileTelephoneNumber,
                    string HomeTelephoneNumber,
                    string BusinessTelephoneNumber,
                    string BusinessFaxNumber,
                    string HomeAddressStreet,
                    string HomeAddressCity,
                    string HomeAddressStateName,
                    string HomeAddressPostalCode,
                    string BusinessAddressStreet,
                    string BusinessAddressCity,
                    string BusinessAddressStateName,
                    string BusinessAddressPostalCode,
                    ref string ErrorMessage
                )
        {
            bool boolContactUpdated = true;

            Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();

            Outlook.MAPIFolder Folder_Contacts = (Outlook.MAPIFolder)
            outlookApp.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);

            try
            {
                Outlook.Items searchFolder = Folder_Contacts.Items;

                foreach (Microsoft.Office.Interop.Outlook.ContactItem contact in searchFolder)
                {
                    if (contact.EntryID.Contains(EntryID))
                    {
                        contact.FileAs = FileAs;
                        contact.FirstName = FirstName;
                        contact.LastName = LastName;
                        contact.FullName = FullName;
                        contact.CompanyName = CompanyName;
                        contact.JobTitle = JobTitle;
                        contact.Email1Address = Email1Address;
                        contact.Email2Address = Email2Address;
                        contact.Email3Address = Email3Address;
                        contact.WebPage = WebPage;
                        contact.IMAddress = IMAddress;
                        contact.MobileTelephoneNumber = MobileTelephoneNumber;
                        contact.HomeTelephoneNumber = HomeTelephoneNumber;
                        contact.BusinessTelephoneNumber = BusinessTelephoneNumber;
                        contact.BusinessFaxNumber = BusinessFaxNumber;
                        contact.HomeAddressStreet = HomeAddressStreet;
                        contact.HomeAddressCity = HomeAddressCity;
                        contact.HomeAddressState = HomeAddressStateName;
                        contact.HomeAddressPostalCode = HomeAddressPostalCode;
                        contact.BusinessAddressStreet = BusinessAddressStreet;
                        contact.BusinessAddressCity = BusinessAddressCity;
                        contact.BusinessAddressState = BusinessAddressStateName;
                        contact.BusinessAddressPostalCode = BusinessAddressPostalCode;

                        contact.Save();
                    }
                }

                boolContactUpdated = true;
            }
            catch (Exception ex)
            {
                ErrorMessage += "ERROR: " + ex.Message + Environment.NewLine;
                boolContactUpdated = false;
            }

            outlookApp = null;
            return boolContactUpdated;
        }

    
        /****************************************/
        /* GET OUTLOOK CONTACT                */
        /****************************************/
        public bool GetOutlookContact
                (
                    int itemNumber,
                    string ContactPhotoPath,
                    ref string EntryID,
                    ref string FileAs,
                    ref string FirstName,
                    ref string LastName,
                    ref string FullName,
                    ref string JobTitle,
                    ref string CompanyName,
                    ref string Email1Address,
                    ref string Email2Address,
                    ref string Email3Address,
                    ref string WebPage,
                    ref string IMAddress,
                    ref string MobileTelephoneNumber,
                    ref string HomeTelephoneNumber,
                    ref string BusinessTelephoneNumber,
                    ref string BusinessFaxNumber,
                    ref string HomeAddressStreet,
                    ref string HomeAddressCity,
                    ref string HomeAddressState,
                    ref string HomeAddressPostalCode,
                    ref string BusinessAddressStreet,
                    ref string BusinessAddressCity,
                    ref string BusinessAddressState,
                    ref string BusinessAddressPostalCode,
                    ref bool HasPicture,
                    ref DateTime LastModificationTime,
                    ref string ErrorMessage
                )
        {
            bool boolGetOutlookContact = true;

            Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Outlook.NameSpace ns = app.GetNamespace("MAPI");
            Outlook.MAPIFolder contacts = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);

            try
            {
                Outlook.ContactItem contact = (Outlook.ContactItem)contacts.Items[itemNumber];

                if (!string.IsNullOrEmpty(contact.EntryID)) EntryID = contact.EntryID;
                if (!string.IsNullOrEmpty(contact.FileAs)) FileAs = contact.FileAs;
                if (!string.IsNullOrEmpty(contact.FirstName)) FirstName = contact.FirstName;
                if (!string.IsNullOrEmpty(contact.LastName)) LastName = contact.LastName;
                if (!string.IsNullOrEmpty(contact.FullName)) FullName = contact.FirstName + " " + contact.LastName;
                if (!string.IsNullOrEmpty(contact.CompanyName)) CompanyName = contact.CompanyName;
                if (!string.IsNullOrEmpty(contact.JobTitle)) JobTitle = contact.JobTitle;
                if (!string.IsNullOrEmpty(contact.Email1Address)) Email1Address = contact.Email1Address;
                if (!string.IsNullOrEmpty(contact.Email2Address)) Email2Address = contact.Email2Address;
                if (!string.IsNullOrEmpty(contact.Email3Address)) Email3Address = contact.Email3Address;
                if (!string.IsNullOrEmpty(contact.WebPage)) WebPage = contact.WebPage;
                if (!string.IsNullOrEmpty(contact.IMAddress)) IMAddress = contact.IMAddress;
                if (!string.IsNullOrEmpty(contact.MobileTelephoneNumber)) MobileTelephoneNumber = contact.MobileTelephoneNumber;
                if (!string.IsNullOrEmpty(contact.HomeTelephoneNumber)) HomeTelephoneNumber = contact.HomeTelephoneNumber;
                if (!string.IsNullOrEmpty(contact.BusinessTelephoneNumber)) BusinessTelephoneNumber = contact.BusinessTelephoneNumber;
                if (!string.IsNullOrEmpty(contact.BusinessFaxNumber)) BusinessFaxNumber = contact.BusinessFaxNumber;
                if (!string.IsNullOrEmpty(contact.HomeAddressStreet)) HomeAddressStreet = contact.HomeAddressStreet;
                if (!string.IsNullOrEmpty(contact.HomeAddressCity)) HomeAddressCity = contact.HomeAddressCity;
                if (!string.IsNullOrEmpty(contact.HomeAddressState)) HomeAddressState = contact.HomeAddressState;
                if (!string.IsNullOrEmpty(contact.HomeAddressPostalCode)) HomeAddressPostalCode = contact.HomeAddressPostalCode;
                if (!string.IsNullOrEmpty(contact.BusinessAddressStreet)) BusinessAddressStreet = contact.BusinessAddressStreet;
                if (!string.IsNullOrEmpty(contact.BusinessAddressCity)) BusinessAddressCity = contact.BusinessAddressCity;
                if (!string.IsNullOrEmpty(contact.BusinessAddressState)) BusinessAddressState = contact.BusinessAddressState;
                if (!string.IsNullOrEmpty(contact.BusinessAddressPostalCode)) BusinessAddressPostalCode = contact.BusinessAddressPostalCode;
                if (!string.IsNullOrEmpty(contact.LastModificationTime.ToString())) LastModificationTime = contact.LastModificationTime;
                HasPicture = contact.HasPicture;

                if (HasPicture)
                {
                    foreach (Microsoft.Office.Interop.Outlook.Attachment att in contact.Attachments)
                    {
                        string picturePath = "";

                        if (att.DisplayName == "ContactPicture.jpg")
                        {
                            try
                            {
                                picturePath = System.IO.Path.GetDirectoryName(ContactPhotoPath) + "\\" + EntryID + ".jpg";
                                if (!System.IO.File.Exists(picturePath))
                                    att.SaveAsFile(picturePath);
                            }
                            catch
                            {
                                picturePath = "";
                            }
                        }
                    }                        //contact.Attachments["ContactPicture.jpg"].SaveAsFile(@"{some_path}\ContactPicture.jpg")
                }
                
                contact = null;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

            app = null;
            ns = null;
            contacts = null;

            return boolGetOutlookContact;
        }


        /****************************************/
        /* GET OUTLOOK CONTACT                */
        /****************************************/
        public string DeleteDuplicateOutlookContacts()
        {
            Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Outlook.NameSpace ns = app.GetNamespace("MAPI");
            Outlook.MAPIFolder contacts = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);

            ClassLibraryDebuggerNameSpace.Debugger objDebugger = new ClassLibraryDebuggerNameSpace.Debugger();

            string results = string.Empty;

            int x = 1;
            string entryid = string.Empty;
            string fileas = string.Empty;
            string ErrorMessage = string.Empty;

            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("EntryID", typeof(string));
                table.Columns.Add("FileAs", typeof(string)); 
                
                foreach (Outlook.ContactItem contact in contacts.Items)
                {
                    entryid = contact.EntryID;
                    fileas = contact.FileAs;
                    table.Rows.Add(entryid, fileas);
                    //results += objDebugger.LogTextOut("ClassLibraryOutlook", x.ToString() + ") " + entryid + " - " + fileas + Environment.NewLine);
                    x++;
                }

                DataView view = table.DefaultView;
                view.Sort = "FileAs ASC";
                DataTable t = view.ToTable();;

                string tempFileAs = string.Empty;
                int totalDuplicates = 0;
                for (int y = 0; y < t.Rows.Count; y++)
                {
                    //results += objDebugger.LogTextOut("ClassLibraryOutlook", y.ToString() + ") " + t.Rows[y][1].ToString() + " (" + t.Rows[y][0].ToString() + "). ");

                    if ((string)tempFileAs != (string)t.Rows[y][1].ToString())
                    {
                        tempFileAs = t.Rows[y][1].ToString();
                    }
                    else
                    {
                        results += objDebugger.LogTextOut("ClassLibraryOutlook", y.ToString() + ") Duplicate " + t.Rows[y][1].ToString() + " (" + t.Rows[y][0].ToString() + ") found. ");
                        totalDuplicates++;
                        try
                        {
                            results += objDebugger.LogTextOut("ClassLibraryOutlook", y.ToString() + ") Deleting Duplicate (" + t.Rows[y][0].ToString() + ")");
                            bool deleteOutlookContact = DeleteOutlookContact((string)t.Rows[y][0].ToString(), ref ErrorMessage);
                        }
                        catch (Exception ex)
                        {
                            results += objDebugger.LogTextOut("ClassLibraryOutlook", y.ToString() + ") Deleting Duplicate (" + t.Rows[y][0].ToString() + ") FAILED" + Environment.NewLine + ex.Message);
                        }
                    }

                }
                string s = string.Empty;

                
                table = null;

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                results += objDebugger.LogTextOut("ClassLibraryOutlook", x.ToString() + ") " + entryid + " - " + fileas + " " + ErrorMessage + Environment.NewLine);

            }
            objDebugger = null;


            app = null;
            ns = null;
            contacts = null;

            return results;
        }
    }
}
