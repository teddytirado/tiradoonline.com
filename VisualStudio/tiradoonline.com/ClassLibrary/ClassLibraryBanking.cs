using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibraryNameSpace; 

namespace ClassLibraryNameSpace
{
    public class ClassLibraryBankingObject
    {
        public ClassLibraryBankingObject()
        {
            BankingList = new List<ClassLibraryBankingObject>();
        }

        // PROPERTIES
        public decimal Amount { get; set; }
        public int? BankingAccountID { get; set; }
        public string BankingAccountName { get; set; }
        public decimal? Balance { get; set; }
        public DateTime BankingDate { get; set; }
        public int BankingID { get; set; }
        public string BankingFile { get; set; }
        public string BankingFileName { get; set; }
        public string Comment { get; set; }
        public DateTime create_dt { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool ReceiveEmails { get; set; }
        public int? SubBankingAccountID { get; set; }
        public decimal TotalBanking { get; set; }
        public int? TransactionID { get; set; }
        public string TransactionName { get; set; }
        public DateTime? update_dt { get; set; }
        public int? UserID { get; set; }

        // LISTS
        public List<ClassLibraryBankingObject> BankingList;
        public List<ClassLibraryBankingObject> BankingAccountList;
    }

    public class ClassLibraryBanking
    {
        // CONSTRUCTOR
        public string ErrorMessage { get; set; }


        // CONSTRUCTOR
        public ClassLibraryBanking()
        {
        }

        // CONSTRUCTOR
        public ClassLibraryBanking(int UserID)
        {
        }



        public static List<ClassLibraryBankingObject> getBankingAccount(int UserID)
        {
            List<ClassLibraryBankingObject> objList = new List<ClassLibraryBankingObject>();

            try
            {
                //DBDataContext db = new DBDataContext(ClassLibraryConfiguration.SQLConnectionString);
                DBDataContext db = new DBDataContext();

                objList = (from rs in db.sp_BankingAccount_active_get(UserID, true, true)
                           select new ClassLibraryBankingObject
                           {
                               BankingAccountID = rs.BankingAccountID,
                               BankingAccountName = rs.BankingAccountName,
                               FullName = rs.BankingAccountName,
                               Balance = rs.Balance,
                               ReceiveEmails = rs.ReceiveEmails
                           }).ToList();

            }
            catch (Exception ex)
            {
                string errorMessage = String.Format("{0}\n\nError in sp_BankingAccount_active_get({1})", ex.ToString(), UserID.ToString());
                ClassLibraryLogs.Log("ClassLibraryBanking", Environment.CurrentDirectory, errorMessage);
            }
            return objList;

        }

        public static List<ClassLibraryBankingObject> getBankingEmailBlast()
        {
            List<ClassLibraryBankingObject> objList = new List<ClassLibraryBankingObject>();

            try
            {

            }
            catch (Exception ex)
            {
                string errorMessage = String.Format("{0}\n\nError in sp_BankingAccount_ReceiveEmail_get()", ex.ToString());
                ClassLibraryLogs.Log("ClassLibraryBanking", Environment.CurrentDirectory, errorMessage);
            }
            return objList;

        }

        public static List<ClassLibraryBankingObject> getBankingEmailBlast_old()
        {
            List<ClassLibraryBankingObject> objList = new List<ClassLibraryBankingObject>();

            try
            {
                //DBDataContext db = new DBDataContext(ClassLibraryConfiguration.SQLConnectionString);
                DBDataContext db = new DBDataContext();

                objList = (from rs in db.sp_BankingAccount_ReceiveEmail_get(null)
                           select new ClassLibraryBankingObject
                           {
                               BankingAccountID = rs.BankingAccountID,
                               FullName = rs.FullName,
                               Email = rs.Email,
                               BankingAccountName = rs.BankingAccountName,
                               Balance = rs.Balance
                           }).ToList();

            }
            catch (Exception ex)
            {
                string errorMessage = String.Format("{0}\n\nError in sp_BankingAccount_ReceiveEmail_get()", ex.ToString());
                ClassLibraryLogs.Log("ClassLibraryBanking", Environment.CurrentDirectory, errorMessage);
            }
            return objList;

        }

        public static List<ClassLibraryBankingObject> getBanking(int BankingAccountID, DateTime BankingDate)
        {
            List<ClassLibraryBankingObject> objList = new List<ClassLibraryBankingObject>();

            try
            {
                //DBDataContext db = new DBDataContext(ClassLibraryConfiguration.SQLConnectionString);
                DBDataContext db = new DBDataContext();

                objList = (from rs in db.sp_Banking_BankingAccountID_BankingDate_get(BankingAccountID, BankingDate)
                           select new ClassLibraryBankingObject{
                        BankingFileName = rs.BankingFileName,
                        BankingID = rs.BankingID,
                        BankingAccountID = rs.BankingAccountID,
                        SubBankingAccountID = rs.SubBankingAccountID,
                        BankingDate = rs.BankingDate,
                        Amount = rs.Payment,
                        TransactionName = rs.Description,
                        Comment = rs.Comment
                           }).ToList();

            }
            catch(Exception ex)
            {
                string errorMessage = String.Format("{0}\n\nError in sp_Banking_BankingAccountID_BankingDate_get({1}, {2})", ex.ToString(), BankingAccountID.ToString(), BankingDate.ToString());
                ClassLibraryLogs.Log("ClassLibraryBanking", Environment.CurrentDirectory, errorMessage);
            }
            return objList;

        }
    }
}
