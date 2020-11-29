using System;
namespace Targem.Calculator.Tokens
{
    public class OpenBracket : AbstractToken, IBracket, IPrioritable
    {
        public OpenBracket() { }

        public ETokenPriority Priority => ETokenPriority.OpenBracket;
    }
}
