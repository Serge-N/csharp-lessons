using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace WebBasicTesting.Basics.TestDataAccess
{
    public class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {
            var fileName = "TestData.xlsx";
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static UserData GetTestData(string keyName)
        {
            using var connection = new OleDbConnection(TestDataFileConnection());
            connection.Open();
            var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
            var value = connection.Query<UserData>(query).FirstOrDefault();
            connection.Close();
            return value;
        }
    }
}
