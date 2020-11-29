using System;
namespace Targem.Calculator.Tokens
{
    public interface IOperand : IToken
    {
        public double Value
        {
            get;
        }
    }
}
