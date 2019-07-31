using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDB
{
    [TestClass]
    public class UnitTest1
    {

        public int Sum(int x, int y)
        {
            return x + y;
        }

        [TestMethod]
        public void TestSum()
        {
            var data = TestDAO.GetDataForUnitTest1_Sum();
            foreach(var d in data)
            {
                long a = ((dynamic)d).a;
                long b = ((dynamic)d).b;
                long sum = ((dynamic)d).sum;
            }
            Console.WriteLine(data);
        }
    }
}
