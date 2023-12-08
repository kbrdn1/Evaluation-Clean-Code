using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperCalculator.UnitTests
{
    [TestClass]
    public class SuperCalculatorTests
    {
        private SuperCalculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _calculator = new SuperCalculator();
        }

        [TestMethod]
        // Arrange
        [DataRow("1,2,3,4", typeof(List<int>))]
        public void ConvertStringToAnArrayOfNumbers_StringOfNumbers_ReturnAnArrayOfNumbers(string stringOfNumbers, Type expectedType)
        {
           // Act
           var arrayOfNumbers = _calculator.ConvertStringToAnArrayOfNumbers(stringOfNumbers);

           // Assert
           Assert.AreEqual(arrayOfNumbers.GetType(), expectedType);
        }

        [TestMethod]
        // Arrange
        [DataRow("1/2/3/4")]
        public void ConvertStringToAnArrayOfNumbers_StringOfNumbers_ReturnAnExceptionIfNotUsedCommaDelimiter(string stringOfNumbers)
        {
              // Act and Assert
              Assert.ThrowsException<CustomException>(() => _calculator.ConvertStringToAnArrayOfNumbers(stringOfNumbers));
        }

        [TestMethod]
        // Arrange
        [DataRow("//./1.2.3.4", typeof(List<int>))]
        public void ConvertStringToAnArrayOfNumbers_StringOfNumbersWithCustomDelimiter_ReturnAnArrayOfNumbers(string stringOfNumbersWithCustomDelimiter, Type expectedType)
        {
            // Act
            var arrayOfNumbers = _calculator.ConvertStringToAnArrayOfNumbers(stringOfNumbersWithCustomDelimiter);

            // Assert
            Assert.AreEqual(arrayOfNumbers.GetType(), expectedType);
        }

        [TestMethod]
        // Arrange
        [DataRow("1,2,3,4,1200")]
        public void ConvertStringToAnArrayOfNumbers_StringOfNumbersWithNumberUpper1000_ReturnAnArrayOfNumbersWith1000ConvertTo0(string stringOfNumbersWithNumberUpper1000)
        {
            // Act
            var StringOfNumbersWithout1000 = _calculator.ConvertStringToAnArrayOfNumbers(stringOfNumbersWithNumberUpper1000);

            // Assert
            Assert.IsFalse(StringOfNumbersWithout1000[4] == 1000);
        }

        [TestMethod]
        // Arrange
        [DataRow("1,2,3,4,-1")]
        public void ConvertStringToAnArrayOfNumbers_StringOfNumbersWithNumberNegative_ReturnAnArrayOfNumbersWithNegativeNumberConvertTo0(string stringOfNumbersWithNumberNegative)
        {
            // Act
            var stringOfNumbersWithoutNegativeNumber = _calculator.ConvertStringToAnArrayOfNumbers(stringOfNumbersWithNumberNegative);

            // Assert
            Assert.IsFalse(stringOfNumbersWithoutNegativeNumber[4] == -1);
        }

        [TestMethod]
        // Arrange
        [DataRow("1,2,3,4", 10)]
        [DataRow("0,1,2,3,4,555", 565)]
        [DataRow("1", 1)]
        [DataRow("3,-2,5", 8)]
        public void Add_StringOfNumbers_ReturnTheSumOfTheNumbers(string stringOfNumbers, int expectedSum)
        {
            // Act
            var sum = _calculator.Add(stringOfNumbers);

            // Assert
            Assert.AreEqual(sum, expectedSum);
        }
    }
}