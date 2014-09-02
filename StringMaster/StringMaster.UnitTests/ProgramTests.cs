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
        private static StringBuilder SetConsoleOutputFake()
        {
            var fakeOutput = new StringBuilder();
            var sw = new StringWriter(fakeOutput);
            Console.SetOut(sw);
            return fakeOutput;
        }

        [Test]
        public void Main_EmptyArgs_CallsTheConsoleWithZero()
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();

            //Act
            Program.Main(new[] {""});

            //Assert
            StringAssert.Contains("0", fakeOutput.ToString());
        }

        [Test]
        public void Main_ArgsWithOneNumber_CallsTheConsoleWithSum()
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();

            //Act
            Program.Main(new[] { "1" });

            //Assert
            StringAssert.Contains("1", fakeOutput.ToString());
        }

        [Test]
        public void Main_ArgsWithTwoNumbers_CallsTheConsoleWithSum()
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
        public void Add_StringWithNumbers_Sums(string input, string expected)
        {
            //Arrange
            StringBuilder fakeOutput = SetConsoleOutputFake();

            //Act
            Program.Main(new[] { input });

            //Assert
            StringAssert.Contains(expected, fakeOutput.ToString());
        }
    }
}