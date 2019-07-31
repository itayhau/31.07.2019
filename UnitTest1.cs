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
            //var data = TestDAO.GetDataForUnitTest1_Sum();
            var data = TestDAO.GetDataForTest("\\DB\\test.data.db",
                "TestDB_UnitTest1_Sum", 
                (reader, records) =>
                {
                    records.Add(new { a = reader.GetValue(1), b = reader.GetValue(2), sum = reader.GetValue(3) });
                });

            var data2 = TestDAO.GetDataForTest<GetDataForUnitTest1_Sum_DataObject>("\\DB\\test.data.db",
                "TestDB_UnitTest1_Sum",
                (reader, records) =>
                {
                    records.Add(new GetDataForUnitTest1_Sum_DataObject { X = (long)reader.GetValue(1),
                        Y = (long)reader.GetValue(2), SUM = (long)reader.GetValue(3) });
                });

            
            foreach (var d in data)
            {
                long a = ((dynamic)d).a;
                long b = ((dynamic)d).b;
                long sum = ((dynamic)d).sum;
            }
            Console.WriteLine(data);
        }
    }
}
