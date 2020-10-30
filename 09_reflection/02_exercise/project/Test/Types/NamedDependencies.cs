namespace Test.Types
{
    internal class NamedDependencies
    {
        public Base One { get; }
        public Base Two { get; }
        public Base Three { get; }

        public NamedDependencies(Base one, Base two, Base three)
        {
            One = one;
            Two = two;
            Three = three;
        }
    }
}