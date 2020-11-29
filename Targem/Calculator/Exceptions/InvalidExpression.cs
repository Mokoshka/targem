using System;
namespace Targem.Calculator.Exceptions
{
    public class InvalidExpression : Exception
    {
        public InvalidExpression(string reason) : base("Invalid expression. Reason: " + reason)
        {
        }
    }
}
