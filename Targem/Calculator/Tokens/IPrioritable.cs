using System;
namespace Targem.Calculator.Tokens
{
    public interface IPrioritable : IToken
    {
        public ETokenPriority Priority
        {
            get;
        }
    }
}
