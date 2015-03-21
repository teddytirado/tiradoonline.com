using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

using ClassLibraryNameSpace;

namespace UnitTestProject
{
    [TestClass]
    [Ignore]
    public class BankingTest
    {
        [TestMethod]
        [Ignore]
        public void GetBankingMethod()
        {
            List<ClassLibraryBankingObject> lsClassLibraryBankingObject = ClassLibraryBanking.getBanking(1097, Convert.ToDateTime("12/1/14"));

            Assert.IsNotNull(lsClassLibraryBankingObject);
        }

        [TestMethod]
        [Ignore]
        public void GetBankingJSON()
        {
            //string webserviceURL = "http://localhost:9999/Banking/GetBanking/";
            string webserviceURL = "http://localhost/banking/banking_preview.asp";

            var values = new NameValueCollection();
            values["BankingAccountID"] = "1097";
            values["BankingDate"] = "12/15/14";

            ClassLibraryNetworking objNetworking = new ClassLibraryNetworking();
                
            var responseString = objNetworking.HTTPRequest(webserviceURL, values);

            //lsClassLibraryBankingObject = new JavaScriptSerializer().Deserialize<List<ClassLibraryBankingObject>>(responseString);

            Assert.IsNotNull(responseString);
        }
    }
}
