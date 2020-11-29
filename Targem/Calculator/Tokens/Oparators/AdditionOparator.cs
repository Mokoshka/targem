using System;

namespace Targem.Calculator.Tokens
{
    public class AdditionOparator : AbstractToken, IOperator, IPrioritable
    {
        public AdditionOparator() : base() { }

        public ETokenPriority Priority => ETokenPriority.Low;

        public IOperand Eval(IOperand left, IOperand right)
        {
            double leftValue = left == null ? 0 : left.Value;

            return new Operand(leftValue + right.Value);
        }
    }
}
