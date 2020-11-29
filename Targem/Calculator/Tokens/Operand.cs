using System;
namespace Targem.Calculator.Tokens
{
    public class Operand : AbstractToken, IOperand
    {
        private double Value;

        public Operand(string value) : base()
        {
            Value = Convert.ToDouble(value);
        }

        public Operand(double value) : base()
        {
            Value = value;
        }

        double IOperand.Value => Value;
    }
}
