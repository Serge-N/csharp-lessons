using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

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

        public void Create(string filePath)
        {
            IXLWorkbook workbook = new XLWorkbook();
            IXLWorksheet worksheet = workbook.AddWorksheet("Test Sheet");
            worksheet.Cell(1, 1).Value = "Hello World!";
            workbook.SaveAs(filePath);
        }

        public UserData CreateUser()
        {
            var file = "TestData.xlsx";
            IXLWorkbook workbook = new XLWorkbook(file);
            IXLWorksheet worksheet = workbook.AddWorksheet("Dataset");

            return new UserData
            {
                Key = worksheet.Cell("A2").Value.ToString(),
                UserName = worksheet.Cell("B2").Value.ToString(),
                Password = worksheet.Cell("C2").Value.ToString(),
            };
        }
    }
}
