using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BackboneDL;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        List<Employee> emp = new List<Employee>();

        [TestMethod]
        public void TestMethod1(List<Employee> emp)
        {
            
            this.emp = emp;
        }
    }
}
