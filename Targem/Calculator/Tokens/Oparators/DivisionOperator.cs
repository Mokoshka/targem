using System;
namespace Targem.Calculator.Tokens
{
    public class DivisionOperator : AbstractToken, IOperator, IPrioritable
    {
        public DivisionOperator() : base() { }

        public ETokenPriority Priority => ETokenPriority.High;

        public IOperand Eval(IOperand left, IOperand right)
        {
            if (left == null)
            {
                throw new Exceptions.UnexpectedUnaryOperation("division");
            }

            return new Operand(left.Value / right.Value);
        }
    }
}
