using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenPop.Pop3;
using System.Data;
using System.Collections;
using System.IO;

namespace ClassLibraryNameSpace
{
    public class ClassLibraryPOP3
    {
        public int POP3EmailFolderID = 1001;
        /// <summary>
        /// Example showing:
        ///  - how to fetch all messages from a POP3 server
        /// </summary>
        /// <param name="hostname">Hostname of the server. For example: pop3.live.com</param>
        /// <param name="port">Host port to connect to. Normally: 110 for plain POP3, 995 for SSL POP3</param>
        /// <param name="useSsl">Whether or not to use SSL to connect to server</param>
        /// <param name="username">Username of the user on the server</param>
        /// <param name="password">Password of the user on the server</param>
        /// <returns>All Messages on the POP3 server</returns>
        public DataTable POPEmailMessages(object txtLogs, object progressbarPOP3, string hostname, int port, bool useSsl, string username, string password)
        {
            try
            {
                Pop3Client pop3Client;
                pop3Client = new Pop3Client();
                pop3Client.Connect(hostname, port, useSsl);

                // Authenticate ourselves towards the server
                pop3Client.Authenticate(username, password);

                // Get the number of messages in the inbox
                int messageCount = pop3Client.GetMessageCount();
                //progressbarPOP3.Minimum = 0;
                //progressbarPOP3.Maximum = messageCount;

                Console.WriteLine("Total Emails: " + messageCount.ToString());

                // We want to download all messages
                int count = pop3Client.GetMessageCount();
                DataTable dtMessages = new DataTable();
                dtMessages.Columns.Add("MessageID");
                dtMessages.Columns.Add("Date");
                dtMessages.Columns.Add("DateSent");
                dtMessages.Columns.Add("FromName");
                dtMessages.Columns.Add("FromEmail");
                dtMessages.Columns.Add("SenderName");
                dtMessages.Columns.Add("SenderEmail");
                dtMessages.Columns.Add("Subject");
                dtMessages.Columns.Add("MessageBodyText");
                int counter = 0;

                DBDataContext objDB = new DBDataContext();

                try {
                    for (int i = count; i >= 1; i--)
                    {

                        OpenPop.Mime.Message message = pop3Client.GetMessage(i);

                        string MessageID = message.Headers.MessageId;
                        string MessageDateTime = message.Headers.Date;
                        DateTime MessageDateSent = message.Headers.DateSent;
                        string MessageFromName = message.Headers.From.MailAddress.DisplayName;
                        string MessageFromEmail = message.Headers.From.MailAddress.Address;
                        string MessageSubject = message.Headers.Subject;
                        string MessageBodyText = string.Empty;

                        dtMessages.Rows.Add();
                        dtMessages.Rows[dtMessages.Rows.Count - 1]["MessageID"] = MessageID;
                        dtMessages.Rows[dtMessages.Rows.Count - 1]["Date"] = MessageDateTime;
                        dtMessages.Rows[dtMessages.Rows.Count - 1]["DateSent"] = MessageDateSent;
                        dtMessages.Rows[dtMessages.Rows.Count - 1]["FromName"] = MessageFromName;
                        dtMessages.Rows[dtMessages.Rows.Count - 1]["FromEmail"] = MessageFromEmail;
                        dtMessages.Rows[dtMessages.Rows.Count - 1]["Subject"] = MessageSubject;

                        OpenPop.Mime.MessagePart html = message.FindFirstHtmlVersion();

                        if (html != null)
                        {
                            // Save the plain text to a file, database or anything you like
                            MessageBodyText = html.GetBodyAsText();
                            dtMessages.Rows[dtMessages.Rows.Count - 1]["MessageBodyText"] = MessageBodyText;
                            //html.Save(new FileInfo(@"c:\emails\" + message.Headers.MessageId + ".txt"));
                        }

                        //objDB.sp_POP3Email_insert(this.POP3EmailFolderID, MessageID, MessageDateSent, MessageFromName, MessageFromEmail, MessageSubject, MessageBodyText);
                        //progressbarPOP3.Value++;
                        counter++;
                    }
                }
                catch (Exception exc)
                {
                    string eString = exc.ToString();
                    return null;
                }

                return dtMessages;
            }
            catch (Exception ex)
            {
                string e = ex.ToString();
                return null;
            }

        }
    }
}
