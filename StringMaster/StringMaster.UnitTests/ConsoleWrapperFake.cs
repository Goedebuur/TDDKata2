namespace StringMaster.UnitTests
{
    public class ConsoleWrapperFake : IConsole
    {

        private readonly string _userInput;

        public ConsoleWrapperFake (string userInput)
        {
            _userInput = userInput;
        }
        public string ReadLine()
        {
            return _userInput;
        }
    }
}