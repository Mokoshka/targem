using System;
namespace Targem.Calculator.Tokens
{
    public class End : AbstractToken, IPrioritable
    {
        public End() { }

        public ETokenPriority Priority => ETokenPriority.End;
    }
}
