using NUnit.Framework;

namespace StringMaster.UnitTests
{
    public class ConsoleWrapperFake : IConsole
    {

        private readonly string[] _userInput;
        private int _times;

        public ConsoleWrapperFake (string[] userInput)
        {
            _userInput = userInput;
            _times = 0;
        }
        public string ReadLine()
        {
            var result = _userInput.Length-1 < _times ? _userInput[_userInput.Length -1] : _userInput[_times];
            _times++;
            return result;
        }
    }
}