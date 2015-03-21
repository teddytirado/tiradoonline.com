using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ClassLibraryNameSpace
{
    class ClassLibraryContactsSync
    {
        public Microsoft.Office.Interop.Outlook.MAPIFolder getOutlookContacts()
        {
            // Obtain an instance of the Outlook application
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();

            // Access the MAPI namespace
            Microsoft.Office.Interop.Outlook.NameSpace ns = app.GetNamespace("MAPI");

            // Get the user's default contacts folder
            return ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderContacts);        
        }
    }
}
