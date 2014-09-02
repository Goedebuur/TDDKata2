using System;
using System.IO;
using System.Text;

using NUnit.Framework;
using Moq;

namespace StringMaster.UnitTests
{
    [TestFixture]
    public class ProgramTests
    {
        private const string _someValue = "1";
        private const string _secondSomeValue = "1,2";

        private static StringBuilder SetConsoleOutputFake()
        {
            var fakeOutput = new StringBuilder();
            var sw = new StringWriter(fakeOutput);
            Console.SetOut(sw);
            return fakeOutput;
        }

        [Test]
        public void Main_EmptyArgs_CallsConsoleWithZero()
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();

            //Act
            Program.Main(new[] {""});

            //Assert
            StringAssert.Contains("0", fakeOutput.ToString());
        }

        [Test]
        public void Main_ArgsWithOneNumber_CallsConsoleWithSum()
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();

            //Act
            Program.Main(new[] { "1" });

            //Assert
            StringAssert.Contains("1", fakeOutput.ToString());
        }

        [Test]
        public void Main_ArgsWithTwoNumbers_CallsConsoleWithSum()
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();

            //Act
            Program.Main(new[] { "1,2" });

            //Assert
            StringAssert.Contains("3", fakeOutput.ToString());
        }

        [TestCase("1,2,3", "6")]
        [TestCase("1,2,3,4", "10")]
        public void Main_ArgsWithMultipleNumbers_CallsConsoleWithSum(string input, string expected)
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();

            //Act
            Program.Main(new[] { input });

            //Assert
            StringAssert.Contains(expected, fakeOutput.ToString());
        }

        [Test]
        public void Main_UserInputsSomeValue_CallsConsoleWithSum()
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();
            Program.ConsoleWrapper = ConsoleWrapper(new [] {_someValue, string.Empty});

            //Act
            Program.Main(new string[] { });


            //Assert
            StringAssert.Contains("The result is 1", fakeOutput.ToString());

        }

        [Test]
        public void Main_UserInputsSomeValue_CallsConsoleWithQuestionForNextInput()
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();
            Program.ConsoleWrapper = ConsoleWrapper(new []{_someValue, string.Empty});

            //Act
            Program.Main(new string[]{});


            //Assert
            StringAssert.Contains("another input please", fakeOutput.ToString());

        }

        [Test]
        public void Main_UserInputsTwoValues_CallsConsoleWithSums()
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();
            Program.ConsoleWrapper = ConsoleWrapper(new[] { _someValue, _secondSomeValue, string.Empty });


            //Act
            Program.Main(new string[] { });


            //Assert
            StringAssert.Contains("The result is 1", fakeOutput.ToString());
            StringAssert.Contains("The result is 3", fakeOutput.ToString());

        }

        [Test]
        public void Main_UserInputsEmptyValue_NoResultOnConsole()
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();
            Program.ConsoleWrapper = ConsoleWrapper(new[] { string.Empty });


            //Act
            Program.Main(new string[] { });


            //Assert
            StringAssert.IsMatch(string.Empty, fakeOutput.ToString());


        }

        private static ConsoleWrapperFake ConsoleWrapper(string[] userInput)
        {
            return new ConsoleWrapperFake(userInput);
        }
    }
}