using System;
namespace Targem.Calculator.Tokens
{
    public class SubtractionOperator : AbstractToken, IOperator, IPrioritable
    {
        public SubtractionOperator() : base() { }

        public ETokenPriority Priority => ETokenPriority.Low;

        public IOperand Eval(IOperand left, IOperand right)
        {
            double leftValue = left == null ? 0 : left.Value;

            return new Operand(leftValue - right.Value);
        }
    }
}
