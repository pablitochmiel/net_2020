using System;

namespace Test.Types
{
    internal class ThrowingConstructor : Base
    {
        public ThrowingConstructor()
        {
            throw new Exception("Exception from constructor!");
        }
    }
}