namespace Test.Types
{
    internal class WithDependencies
    {
        public BaseOne BaseOne { get; }
        public BaseTwo BaseTwo { get; }
        public BaseThree BaseThree { get; }

        public WithDependencies(BaseOne baseOne, BaseTwo baseTwo, BaseThree baseThree)
        {
            BaseOne = baseOne;
            BaseTwo = baseTwo;
            BaseThree = baseThree;
        }
    }
}