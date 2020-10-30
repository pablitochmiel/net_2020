namespace Test.Types
{
    internal class PrivateConstructor : Base
    {
        private PrivateConstructor()
        {
        }

        public static PrivateConstructor Instance { get; } = new PrivateConstructor();
    }
}