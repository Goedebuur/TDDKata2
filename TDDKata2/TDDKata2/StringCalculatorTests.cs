using NUnit.Framework;

namespace TDDKata2
{
    public class StringCalculatorTests
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            StringCalculator stringCalculator = CreateNewStringCalculator();

            int result = stringCalculator.Add(string.Empty);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_IgoreNumbersGreaterThenThousand_Sums()
        {
            //Arrange
            StringCalculator sc = CreateNewStringCalculator();
            const string stringWithThousandOne = "1, 1001";

            //Act
            int result = sc.Add(stringWithThousandOne);

            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof (NegativesNumberException))]
        public void Add_NegativeNumber_Throws()
        {
            //Arrange
            StringCalculator sc = CreateNewStringCalculator();
            const string stringWithNewLine = "-1";

            //Act
            int result = sc.Add(stringWithNewLine);

            //Assert
        }

        [Test]
        public void Add_StringWithNewLine_Sums()
        {
            //Arrange
            StringCalculator sc = CreateNewStringCalculator();
            const string stringWithNewLine = "1\n2,3";

            //Act
            int result = sc.Add(stringWithNewLine);

            //Assert
            Assert.AreEqual(6, result);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Add_StringWithOneNumber_Sums(string input, int expected)
        {
            //Arrange
            StringCalculator sc = CreateNewStringCalculator();
            string stringWithOnePositiveNumber = input;

            //Act
            int result = sc.Add(stringWithOnePositiveNumber);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [Test]
        public void Add_StringWithTwoNumbers_Sums()
        {
            //Arrange
            StringCalculator sc = CreateNewStringCalculator();
            const string stringWithTwoPositiveNumbers = "1,2";

            //Act
            int result = sc.Add(stringWithTwoPositiveNumbers);

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[abc]\n1abc2abc3", 6)]
        public void Add_WithAnyLengthNumberDeliminator_Sums(string input, int expected)
        {
            //Arrange
            StringCalculator sc = CreateNewStringCalculator();
            string stringWithLongDeliminator = input;

            //Act
            int result = sc.Add(stringWithLongDeliminator);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_WithMultipleLongNumberDeliminator_Sums()
        {
            //Arrange
            StringCalculator sc = CreateNewStringCalculator();
            string stringWithMultipleLongDeliminator = "//[**][%%%]\n1**2%%%3";

            //Act
            int result = sc.Add(stringWithMultipleLongDeliminator);

            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_WithMultipleNumberDeliminator_Sums()
        {
            //Arrange
            StringCalculator sc = CreateNewStringCalculator();
            string stringWithMultipleDeliminator = "//[*][%]\n1*2%3";

            //Act
            int result = sc.Add(stringWithMultipleDeliminator);

            //Assert
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_WithNumberDeliminator_Sums()
        {
            //Arrange
            StringCalculator sc = CreateNewStringCalculator();
            string stringWithNewLine = "//;\n1;2";

            //Act
            int result = sc.Add(stringWithNewLine);

            //Assert
            Assert.AreEqual(3, result);
        }

        private StringCalculator CreateNewStringCalculator()
        {
            return new StringCalculator();
        }
    }
}