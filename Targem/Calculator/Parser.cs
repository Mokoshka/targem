using System;
using System.Collections.Generic;

namespace Targem.Calculator
{
    public class Parser
    {
        private Tokens.TokenFactory TokenFactory;
        private ParserAutomat Automat;
        private List<Tokens.IToken> _Result;
        private Stack<Tokens.IPrioritable> _Stack;
        private bool IsFinish;

        public Parser(List<char> allowedChars)
        {
            TokenFactory = new Tokens.TokenFactory(allowedChars);
            Automat = new ParserAutomat();
            _Result = new List<Tokens.IToken>();
            _Stack = new Stack<Tokens.IPrioritable>();
            IsFinish = false;
        }

        private void AddToken(Tokens.IToken token)
        {
            if (token == null)
            {
                return;
            }

            if (token is Tokens.IOperand)
            {
                _Result.Add(token);
            }

            if (token is Tokens.IPrioritable)
            {
                AddToStack(token as Tokens.IPrioritable);
            }
        }

        public List<Tokens.IToken> Parse(string expression)
        {
            _Stack.Push(new Tokens.End());

            int i = 0;

            while (i < expression.Length - 1)
            {
                Tokens.IToken token = TokenFactory.Get(expression[i], expression[i + 1]);

                i++;

                AddToken(token);
            }

            Tokens.IToken lastToken = TokenFactory.Get(expression[i], '|');
            AddToken(lastToken);
            

            Tokens.IToken endToken = TokenFactory.Get('|', null);
            AddToStack(endToken as Tokens.IPrioritable);

            return IsFinish ? _Result : throw new Exceptions.InvalidExpression("Internal error");
        }

        private void AddToStack(Tokens.IPrioritable token)
        {
            bool isAdded = false;

            while (!isAdded)
            {
                EParserState state = Automat.GetState(token, _Stack.Peek());

                switch (state)
                {
                    case EParserState.ToStack:
                        _Stack.Push(token);
                        isAdded = true;
                        break;
                    case EParserState.StackToResult:
                        _Result.Add(_Stack.Pop());
                        break;
                    case EParserState.RemoveBrackets:
                        _Stack.Pop();
                        isAdded = true;
                        break;
                    case EParserState.End:
                        isAdded = true;
                        IsFinish = true;
                        break;
                    case EParserState.Error:
                        throw new Exceptions.InvalidExpression("Incorrectly placed brackets");
                }
            }
        }
    }
}
