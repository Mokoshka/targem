using System;
namespace Targem.Calculator.Tokens
{
    public class PowOperator : AbstractToken, IOperator, IPrioritable
    {
        public PowOperator() : base() { }

        public ETokenPriority Priority => ETokenPriority.Low;

        public IOperand Eval(IOperand left, IOperand right)
        {
            if (left == null)
            {
                throw new Exceptions.UnexpectedUnaryOperation("pow");
            }

            return new Operand(Math.Pow(left.Value, right.Value));
        }
    }
}
