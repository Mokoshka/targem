using System;
using System.Collections.Generic;
namespace Targem.Calculator
{
    public class Calculator
    {
        private Parser Parser;

        public Calculator()
        {
            Parser = new Parser(new List<char> { ' ' });
        }

        public double Calculate(string expression)
        {
            List<Tokens.IToken> tokens = Parser.Parse(expression);

            return Eval(tokens);
        }

        private double Eval(List<Tokens.IToken> tokens)
        {
            Stack<Tokens.IOperand> stack = new Stack<Tokens.IOperand>();

            foreach (Tokens.IToken token in tokens)
            {
                if (token is Tokens.IOperand)
                {
                    stack.Push(token as Tokens.IOperand);
                }

                if (token is Tokens.IOperator)
                {
                    Tokens.IOperand right = stack.Pop();
                    Tokens.IOperand left = stack.Count == 0 ? null : stack.Pop();

                    stack.Push((token as Tokens.IOperator).Eval(left, right));
                }
            }

            return stack.Pop().Value;
        }
    }
}
