using System.IO;
using WebBasicTesting.Basics.TestDataAccess;
using Xunit;

namespace WebBasicTesting.Basics
{
    public class ExcelWriteTest
    {
        [Fact]
        public void CreateSheet()
        {
            // arrange
            var dataAccess = new ExcelDataAccess();

            // act 
            var path = "test.xlsx";
            dataAccess.Create(path);
            bool truth = File.Exists(path);

            // assert
            Assert.True(truth);
        }

        [Fact]
        public void CreateUserFromData()
        {
            // arrange
            var dataAccess = new ExcelDataAccess();

            // act
            var user = dataAccess.CreateUser();
            var knownPassword = "Test@123";
           
            // assert
            Assert.Equal(user.Password, knownPassword);
        }
    }
}
