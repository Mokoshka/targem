using System;
using System.Collections.Generic;
using System.Text;

namespace Targem.Calculator.Tokens
{
    public class TokenFactory
    {
        private List<char> AllowedChars;
        private StringBuilder Buffer;
        private bool OperandIsLast;
        private bool OperatorIsLast;

        public TokenFactory(List<char> allowedChars)
        {
            AllowedChars = allowedChars;
            Buffer = new StringBuilder();
            OperandIsLast = false;
            OperatorIsLast = false;
        }

        private bool IsDigital(char? currentChar)
        {
            return currentChar >= '0' && currentChar <= '9';
        }

        private bool IsFractionalSeparator(char? currentChar)
        {
            return currentChar == '.';
        }

        private void OperatorIsCorrect()
        {
            if (OperatorIsLast)
            {
                throw new Exceptions.InvalidExpression("Operator cannot follow a operator");
            }

            OperatorIsLast = true;
            OperandIsLast = false;
        }

        private void OpenBracketIsCorrect()
        {
            if (OperandIsLast)
            {
                throw new Exceptions.InvalidExpression("Open bracket cannot follow a operand");
            }

            OperandIsLast = false;
            OperatorIsLast = false;
        }

        private void CloseBracketIsCorrect()
        {
            if (OperatorIsLast)
            {
                throw new Exceptions.InvalidExpression("Close bracket cannot follow a operator");
            }

            OperandIsLast = false;
            OperatorIsLast = false;
        }

        public AbstractToken Get(char currentChar, char? nextChar)
        {
            switch (currentChar)
            {
                case '+':
                    OperatorIsCorrect();
                    return new AdditionOparator();
                case '/':
                    OperatorIsCorrect();
                    return new DivisionOperator();
                case '*':
                    OperatorIsCorrect();
                    return new MultiplicationOperator();
                case '^':
                    OperatorIsCorrect();
                    return new PowOperator();
                case '-':
                    OperatorIsCorrect();
                    return new SubtractionOperator();
                case '(':
                    OpenBracketIsCorrect();
                    return new OpenBracket();
                case ')':
                    CloseBracketIsCorrect();
                    return new CloseBracket();
                case '|':
                    return new End();
            }

            if (AllowedChars.Contains(currentChar))
            {
                return null;
            }

            if (IsDigital(currentChar) || IsFractionalSeparator(currentChar))
            {
                if (OperandIsLast)
                {
                    throw new Exceptions.InvalidExpression("Operand cannot follow a operand");
                }

                Buffer.Append(currentChar);

                if (IsDigital(nextChar) || IsFractionalSeparator(nextChar))
                {
                    return null;
                }
                else
                {
                    string s = Buffer.ToString();
                    Operand operand = new Operand(s);

                    Buffer.Clear();
                    OperandIsLast = true;
                    OperatorIsLast = false;

                    return operand;
                }
            }

            throw new Exceptions.InvalidCharacter(currentChar);
        }
    }
}
