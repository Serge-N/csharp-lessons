using System;
using Xunit;
using BankAccountNS;
using System.Reflection;

namespace BankTests
{
    public class BanlAccountTests
    {
        [Fact]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            BankAccount account = new("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.Equal(expected, actual, 3);
        }

        [Fact]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [Fact]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                Assert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }

        // Tesing  Theories
        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            Assert.True(IsOdd(value));
        }

        bool IsOdd(int value)
        {
            return value % 2 == 1;
        }

        [Fact]
        public void TestPrivateMethod()
        {
            // arrange
            BankAccount objUnderTest = new("Kalusha Banda",24);
            MethodInfo methodInfo = typeof(BankAccount).GetMethod("DebitAmountWithDrawl", BindingFlags.NonPublic | BindingFlags.Instance);
            object[] parameters = { 6 };
            double total = 30;

            //Act
            var withdrawl = methodInfo.Invoke(objUnderTest, parameters);

            // Assert
            Assert.Equal(total, withdrawl);

        }

    }
}
