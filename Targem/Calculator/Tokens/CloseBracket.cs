using System;
namespace Targem.Calculator.Tokens
{
    public class CloseBracket : AbstractToken, IBracket, IPrioritable
    {
        public CloseBracket()
        {
        }

        public ETokenPriority Priority => ETokenPriority.CloseBracket;
    }
}
