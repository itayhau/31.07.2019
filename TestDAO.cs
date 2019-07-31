using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestDB
{
    public static class TestDAO
    {

        public static List<T> GetDataForTest<T>(string fileName, string tableName, Action<SQLiteDataReader, List<T>> action)
        {
            Debug.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var a = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<T> records = new List<T>();
            // connect to the Data Base
            using (SQLiteConnection con =
                //new SQLiteConnection("Data Source = C:\\itay\\sqlite\\test.data.db; Version = 3;"))
                new SQLiteConnection($"Data Source = {System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{fileName}; Version = 3;"))
            {

                // open the connection
                con.Open();

                // create a query (suign the connection)
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {tableName}", con))
                {

                    // execut4e the query into the reader
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        // use the reader to read all of the results of the query
                        while (reader.Read())
                        {

                            // pull out the data result using GetValue for dield number
                            //Debug.WriteLine(
                            //$"{reader.GetValue(0)} {reader.GetValue(1)} {reader.GetValue(2)} {reader.GetValue(3)}");
                            //records.Add(new { a = reader.GetValue(1), b = reader.GetValue(2), sum = reader.GetValue(3) });
                            action.Invoke(reader, records);
                        }
                    }

                }

                Console.WriteLine();
            }
            return records;
        }

        public static List<object> GetDataForTest(string fileName, string tableName, Action<SQLiteDataReader, List<object>> action)
        {
            Debug.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var a = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<object> records = new List<object>();
            // connect to the Data Base
            using (SQLiteConnection con =
                //new SQLiteConnection("Data Source = C:\\itay\\sqlite\\test.data.db; Version = 3;"))
                new SQLiteConnection($"Data Source = {System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\{fileName}; Version = 3;"))
            {

                // open the connection
                con.Open();

                // create a query (suign the connection)
                using (SQLiteCommand cmd = new SQLiteCommand($"SELECT * FROM {tableName}", con))
                {

                    // execut4e the query into the reader
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        // use the reader to read all of the results of the query
                        while (reader.Read())
                        {

                            // pull out the data result using GetValue for dield number
                            //Debug.WriteLine(
                            //$"{reader.GetValue(0)} {reader.GetValue(1)} {reader.GetValue(2)} {reader.GetValue(3)}");
                            //records.Add(new { a = reader.GetValue(1), b = reader.GetValue(2), sum = reader.GetValue(3) });
                            action.Invoke(reader, records);
                        }
                    }

                }

                Console.WriteLine();
            }
            return records;
        }
        // SELECT * FROM TestDB_UnitTest1_Sum
        public static List<object> GetDataForUnitTest1_Sum()
        {
            Debug.WriteLine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var a = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            List<object> records = new List<object>();
            // connect to the Data Base
            using (SQLiteConnection con =
                //new SQLiteConnection("Data Source = C:\\itay\\sqlite\\test.data.db; Version = 3;"))
                new SQLiteConnection($"Data Source = {System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\DB\\test.data.db; Version = 3;"))
            {

                // open the connection
                con.Open();

                // create a query (suign the connection)
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM TestDB_UnitTest1_Sum", con))
                {

                    // execut4e the query into the reader
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {

                        // use the reader to read all of the results of the query
                        while (reader.Read())
                        {

                            // pull out the data result using GetValue for dield number
                            //Debug.WriteLine(
                            //$"{reader.GetValue(0)} {reader.GetValue(1)} {reader.GetValue(2)} {reader.GetValue(3)}");
                            records.Add(new { a = reader.GetValue(1), b = reader.GetValue(2), sum = reader.GetValue(3) });
                        }
                    }

                }

                Console.WriteLine();
            }
            return records;
        }
        
    }
}
