using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
using System.Text;
using System.IO;
using System.Net;
using System.Configuration;
using System.Globalization;
using System.Threading;
using ClassLibraryNameSpace;

namespace BankingEmailBlast
{
    class Program
    {
        static void Main(string[] args)
        {
            string errorMessage = string.Empty;

            string bankingURL = ConfigurationManager.AppSettings["BankingURL"].ToString();
            ClassLibraryNetworking objNetworking = new ClassLibraryNetworking();
            string emailBlastResults = string.Empty;

            try
            {
                List<ClassLibraryBankingObject> objBanking = ClassLibraryBanking.getBankingEmailBlast();
                string subject = string.Empty;

                Console.WriteLine(objBanking.Count.ToString());
                foreach (var item in objBanking)
                {

                    string bankingDate = string.Format("{0}/{1}/{2}", DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Year.ToString());
                    var values = new NameValueCollection();
                    values["BankingAccountID"] = item.BankingAccountID.ToString();
                    values["BankingDate"] = bankingDate;
                    ThreadPool.QueueUserWorkItem(delegate { emailBlastResults = objNetworking.HTTPRequest(bankingURL, values); });

                    Console.WriteLine(String.Format("HTTPRequest: {0}?BankingAccountID={1}&BankingDate={2}", bankingURL, item.BankingAccountID.ToString(), item.BankingDate.ToString()));
                    string subjDate = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTime.Now.Month) + " " + DateTime.Now.Year.ToString();
                    subject = string.Format("intranet.tiradoonline.com -- {0} : {1} Transactions ({2})", item.BankingAccountName, subjDate, item.Balance.ToString());
                    string str = string.Empty;
                    Console.WriteLine("Email to: " + item.Email);
                    Console.WriteLine("Subject: " + subject);
                    objNetworking.STMP(item.FullName, item.Email, ClassLibraryConfiguration.AdministratorName, ClassLibraryConfiguration.AdministratorEmail, subject, emailBlastResults);
                    Console.WriteLine("Email Sent: " + item.Email + Environment.NewLine);
                    Thread.Sleep(10000);
                    //Console.Read();

                }
                objBanking = null;
                subject = "BankingEmailBlast ran successfully";
                objNetworking.STMP(ClassLibraryConfiguration.AdministratorName, ClassLibraryConfiguration.LogsEmail, ClassLibraryConfiguration.AdministratorName, ClassLibraryConfiguration.AdministratorEmail, subject, subject);
                Console.WriteLine(subject);
                Environment.Exit(0);


                //ClassLibraryLogs.Log("BankingEmailBlast", Environment.CurrentDirectory, logText);
            }
            catch (Exception ex)
            {
                ClassLibraryLogs.Log("BankingEmailBlast", Environment.CurrentDirectory, ex.ToString());
            }

            Environment.Exit(0);

        }
    }
}
