using System;
namespace Targem.Calculator.Exceptions
{
    public class UnexpectedUnaryOperation : Exception
    {
        public UnexpectedUnaryOperation(string operation): base("Unexpected unary operation: " + operation)
        {
        }
    }
}
