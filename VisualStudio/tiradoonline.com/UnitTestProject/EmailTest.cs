using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


using ClassLibraryNameSpace;

namespace UnitTestProject
{
    [TestClass]
    [Ignore]
    public class EmailTest
    {
        [TestMethod]
        [Ignore]
        public void TestEmail()
        {
            ClassLibraryNetworking objNet = new ClassLibraryNetworking();
            objNet.STMP("Theodore Tirado", "teddy@tiradoonline.com", "Theodore Tirado", "teddy@tiradoonline.com", "Test Subject", "TestEmail");

            //Assert.IsNotNull(boolEmail);
        }
    }
}
