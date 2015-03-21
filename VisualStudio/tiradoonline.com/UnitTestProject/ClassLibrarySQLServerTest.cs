using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryNameSpace;

namespace UnitTestProject
{
    [TestClass]
    public class ClassLibrarySQLServerTest
    {
        [TestMethod]
        public void TestSQLToExcel()
        {
            ClassLibrarySQLServer objExcel = new ClassLibrarySQLServer();
            objExcel.SQLServerName = @".\SQL2K8";
            objExcel.SQLServerDatabaseName = "tiradoonline";
            objExcel.SQLUserName = "tiradoonline_user";
            objExcel.SQLPassword = "Sixpak141414";
            objExcel.OutputDirectory = @"C:\SQL";
            objExcel.ExportStoredProceduresToExcel();
            objExcel = null;

            //Assert.IsNotNull(boolEmail);
        }
    }
}
