using System;
using System.Collections.Generic;

namespace Targem.Calculator
{
    public class ParserAutomat
    {
        private Dictionary<Tokens.ETokenPriority, Dictionary<Tokens.ETokenPriority, EParserState>> AutomatStates = new Dictionary<Tokens.ETokenPriority, Dictionary<Tokens.ETokenPriority, EParserState>> {
            {
                Tokens.ETokenPriority.End, new Dictionary<Tokens.ETokenPriority, EParserState>
                {
                    { Tokens.ETokenPriority.End, EParserState.End },
                    { Tokens.ETokenPriority.Low, EParserState.ToStack},
                    { Tokens.ETokenPriority.High, EParserState.ToStack },
                    { Tokens.ETokenPriority.OpenBracket, EParserState.ToStack },
                    { Tokens.ETokenPriority.CloseBracket, EParserState.Error }
                }
            },
            {
                Tokens.ETokenPriority.Low, new Dictionary<Tokens.ETokenPriority, EParserState>
                {
                    { Tokens.ETokenPriority.End, EParserState.StackToResult},
                    { Tokens.ETokenPriority.Low, EParserState.StackToResult },
                    { Tokens.ETokenPriority.High, EParserState.ToStack },
                    { Tokens.ETokenPriority.OpenBracket, EParserState.ToStack },
                    { Tokens.ETokenPriority.CloseBracket, EParserState.StackToResult }
                }
            },
            {
                Tokens.ETokenPriority.High, new Dictionary<Tokens.ETokenPriority, EParserState>
                {
                    { Tokens.ETokenPriority.End, EParserState.StackToResult },
                    { Tokens.ETokenPriority.Low, EParserState.StackToResult },
                    { Tokens.ETokenPriority.High, EParserState.StackToResult },
                    { Tokens.ETokenPriority.OpenBracket, EParserState.ToStack },
                    { Tokens.ETokenPriority.CloseBracket, EParserState.StackToResult }
                }
            },
            {
                Tokens.ETokenPriority.OpenBracket, new Dictionary<Tokens.ETokenPriority, EParserState>
                {
                    { Tokens.ETokenPriority.End, EParserState.Error },
                    { Tokens.ETokenPriority.Low, EParserState.ToStack },
                    { Tokens.ETokenPriority.High, EParserState.ToStack },
                    { Tokens.ETokenPriority.OpenBracket, EParserState.ToStack },
                    { Tokens.ETokenPriority.CloseBracket, EParserState.RemoveBrackets }
                }
            }
        };

        public ParserAutomat() { }

        public EParserState GetState(Tokens.IPrioritable currentToken, Tokens.IPrioritable stackToken)
        {
            Dictionary<Tokens.ETokenPriority, EParserState> stateMap = AutomatStates[stackToken.Priority];

            return stateMap[currentToken.Priority];
        }
    }
}
