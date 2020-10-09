using FanLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class FanOutPutTest
    {
        [TestMethod]
        public void Test_ID()
        {
            int expectedResult = 3;

            FanOutPut testfanid = new FanOutPut("lokale", 22, 44);

            Assert.AreEqual(expectedResult, FanOutPut.idcounter);
        }

        [TestMethod]
        public void Test_NavnForKort()
        {
            FanOutPut TestNavn = new FanOutPut("lll", 20, 45);
            
        }
        
        [TestMethod]
        public void Test_GraderOk()
        {
            FanOutPut TestGrader = new FanOutPut("lokale", 20, 45);
        }

        [TestMethod]
        public void Test_FugtOk()
        {
            FanOutPut fanOutPut_FugtTest = new FanOutPut("lokale", 20, 31);
            
        }


        //Usikker
        [TestMethod]
        public void TestToStringMethod()
        {
            FanOutPut fanOutPutTestToString = new FanOutPut("Lokale", 20, 40);
            Console.WriteLine(fanOutPutTestToString);

        }
    }
}
