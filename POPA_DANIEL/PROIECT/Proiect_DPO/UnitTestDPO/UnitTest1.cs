using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Proiect_DPO.Comenzi;
using Proiect_DPO.Evenimente;
using Proiect_DPO.Model;
using Moq;
using Proiect_DPO.Model.Produs;

namespace UnitTestDPO
{
    [TestClass]
    public class UnitTest1
    {
        private Mock<IProdus> _externalMock;

        [TestMethod]
        public void TestMethod1()
        {
            _externalMock = new Mock<IProdus>();
            _externalMock.Setup(p => p.GetCodBare()).Returns("11");
        }

        [Fact]
        public void GetC()
        {
            string b = "12";
        }
       
    }
}
