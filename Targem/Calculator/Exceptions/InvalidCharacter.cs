using System;
namespace Targem.Calculator.Exceptions
{
    public class InvalidCharacter : Exception
    {
        public InvalidCharacter(char value) : base("Invalid character: " + value)
        {
        }
    }
}
