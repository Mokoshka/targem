using System;
namespace Targem.Calculator.Tokens
{
    public class MultiplicationOperator : AbstractToken, IOperator, IPrioritable
    {
        public MultiplicationOperator() : base() { }

        public ETokenPriority Priority => ETokenPriority.High;

        public IOperand Eval(IOperand left, IOperand right)
        {
            if (left == null)
            {
                throw new Exceptions.UnexpectedUnaryOperation("multiplication");
            }

            return new Operand(left.Value * right.Value);
        }
    }
}
