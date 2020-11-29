using System;
namespace Targem.Calculator
{
    public enum EParserState
    {
        ToStack,
        End,
        StackToResult,
        RemoveBrackets,
        Error
    }
}
