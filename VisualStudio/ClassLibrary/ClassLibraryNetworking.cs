using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

using ClassLibraryNameSpace;

namespace ClassLibraryNameSpace
{
    public class ClassLibraryNetworking
    {
        public string ErrorMessage { get; set; }


        public void STMP(string toName, string toAddress, string fromName, string fromEmail, string toSubject, string toBodyText)
        {
            
            MailMessage objMailMessage = new MailMessage();

            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(ClassLibraryConfiguration.STMPServerUserName, ClassLibraryConfiguration.STMPServerPassword);
            SmtpClient objSmtpClient = new SmtpClient(ClassLibraryConfiguration.STMPServerHost, System.Convert.ToInt32(ClassLibraryConfiguration.STMPServerPort));

            //SMTPUserInfo.Domain = SMTPServer;
            objSmtpClient.UseDefaultCredentials = false;
            objSmtpClient.Credentials = SMTPUserInfo;

            //objMailMessage.To.Add(string.Format("{} <{}>", toName, toAddress));
            //objMailMessage.From = new MailAddress(string.Format("{} <{}>", fromName, fromEmail));
            objMailMessage.To.Add(toAddress);
            objMailMessage.From = new MailAddress(fromEmail);
            objMailMessage.Subject = toSubject;
            objMailMessage.Body = toBodyText;
            objMailMessage.IsBodyHtml = true;

            
            objSmtpClient.Send(objMailMessage);

        }

        public string HTTPRequest(string url, NameValueCollection values)
        {
            string responseString = string.Empty;

            try
            {
                var client = new WebClient();
                var response = client.UploadValues(url, values);

                responseString = Encoding.Default.GetString(response);
            }
            catch(Exception ex)
            {
                this.ErrorMessage = ex.ToString();
                string errorMessage = String.Format("{0}\n\nError in HTTPRequest(): URL:({1})", ex.ToString(), url);
                ClassLibraryLogs.Log("ClassLibraryNetworking", Environment.CurrentDirectory, errorMessage);
            }

            return responseString;
        }

    }
}
