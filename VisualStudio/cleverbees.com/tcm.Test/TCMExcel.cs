using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using tcm.Models;

namespace tcm.Test
{
    [TestClass]
    public class TCMExcel
    {
        [TestMethod]
        public void ImportExcel()
        {
            
            List<MembersModel> objListMembersModel = Members.ImportExcel(@"C:\Storage\www\cleverbees.com\tcm\uploads\Members.xlsx");

            Assert.IsNotNull(objListMembersModel);
                
        }
    }
}
