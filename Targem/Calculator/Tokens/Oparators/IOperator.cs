using System;
namespace Targem.Calculator.Tokens
{
    public interface IOperator
    {
        public IOperand Eval(IOperand left, IOperand right);
    }
}
