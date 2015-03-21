using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using ClassLibraryNameSpace;

namespace ClassLibraryNameSpace
{
    public class ClassLibraryLogs
    {
        public static void Log(string logApplication, string logDirectory, string logText)
        {
            StringBuilder objString = new StringBuilder();
            string logFile = string.Format(@"{0}\{1}-{2}-{3}.txt", logDirectory, DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), DateTime.Now.Year.ToString());
            objString.AppendLine("Date:");
            objString.AppendLine("-------------------------------");
            objString.AppendLine(DateTime.Now.ToString() + Environment.NewLine);
            objString.AppendLine("Application:");
            objString.AppendLine("-------------------------------");
            objString.AppendLine(logApplication + Environment.NewLine);
            objString.AppendLine("Log File:");
            objString.AppendLine("-------------------------------");
            objString.AppendLine(logFile + Environment.NewLine);
            objString.AppendLine("Error:");
            objString.AppendLine("-------------------------------");
            objString.AppendLine(logText + Environment.NewLine);
            objString.AppendLine("-----------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
            logText = objString.ToString();
            objString = null;

            string sSource = logApplication;
            string sLog = "Application";


            ClassLibraryFileIO.WriteFile(logFile, logText + ClassLibraryFileIO.ReadFile(logFile));

            string subject = string.Format("Error: {0}", logApplication);
            ClassLibraryNetworking objNetworking = new ClassLibraryNetworking();
            objNetworking.STMP(ClassLibraryConfiguration.AdministratorName, ClassLibraryConfiguration.LogsEmail, ClassLibraryConfiguration.AdministratorName, ClassLibraryConfiguration.AdministratorEmail, subject, "<pre>" + logText + "</pre>");
            objNetworking = null;

            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);


            DBDataContext db = new DBDataContext();
            db.sp_Logs_insert(logApplication, logText);
            db = null;

            EventLog.WriteEntry(sSource, logText);
            EventLog.WriteEntry(sSource, logText, EventLogEntryType.Warning, 234);


            Console.WriteLine(logText);
        }
    }
}
