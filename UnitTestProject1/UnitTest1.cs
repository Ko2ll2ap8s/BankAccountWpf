using BankAccountNS;
using BankAccountWpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace UnitTestProject1
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 5.77;
            double expected = 17.76;
            BankAccount account = new BankAccount("Mr.Roman Abramovich", beginningBalance);
            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr.Roman Abramovich", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WithAmountExceedsBalance_ThrowsException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00;
            BankAccount account = new BankAccount("Mr.Roman Abramovich", beginningBalance);

            // Act & Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WithAmountLessThanZero_ThrowsException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -5.77;
            BankAccount account = new BankAccount("Mr.Roman Abramovich", beginningBalance);

            // Act & Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Credit_WithAmountLessThanZero_ThrowsException()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -5.77;
            BankAccount account = new BankAccount("Mr.Roman Abramovich", beginningBalance);

            // Act & Assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Credit(creditAmount));
        }

    }
}
