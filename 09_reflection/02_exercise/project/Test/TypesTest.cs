using System;
using Test.Types;
using Xunit;

namespace Test
{
    public class TypesTest
    {
        [Fact]
        public void HasBaseType()
        {
            Assert.NotNull(new Base());
        }

        [Fact]
        public void HasDerivedType()
        {
            Assert.NotNull(new Derived());
        }

        [Fact]
        public void HasPrivateConstructorType()
        {
            Assert.NotNull(PrivateConstructor.Instance);
        }

        [Fact]
        public void HasThrowingConstructorType()
        {
            var exception = Assert.Throws<Exception>(() => new ThrowingConstructor());
            Assert.Equal("Exception from constructor!", exception.Message);
        }

        [Fact]
        public void HasBaseOneType()
        {
            Assert.NotNull(new BaseOne());
        }

        [Fact]
        public void HasDerivedOneType()
        {
            Assert.NotNull(new DerivedOne());
        }

        [Fact]
        public void HasBaseTwoType()
        {
            Assert.NotNull(new BaseTwo());
        }

        [Fact]
        public void HasDerivedTwoType()
        {
            Assert.NotNull(new DerivedTwo());
        }

        [Fact]
        public void HasBaseThreeType()
        {
            Assert.NotNull(new BaseThree());
        }

        [Fact]
        public void HasDerivedThreeType()
        {
            Assert.NotNull(new DerivedThree());
        }

        [Fact]
        public void HasTypeWithSimpleDependencies()
        {
            var withDependencies = new WithDependencies(new DerivedOne(), new DerivedTwo(), new DerivedThree());
            Assert.NotNull(withDependencies);
            Assert.IsType<DerivedOne>(withDependencies.BaseOne);
            Assert.IsType<DerivedTwo>(withDependencies.BaseTwo);
            Assert.IsType<DerivedThree>(withDependencies.BaseThree);
        }

        [Fact]
        public void HasTypeWithNamedDependencies()
        {
            var withDependencies =
                new NamedDependencies(new DerivedOne(), new DerivedTwo(), new DerivedThree());
            Assert.NotNull(withDependencies);
            Assert.IsType<DerivedOne>(withDependencies.One);
            Assert.IsType<DerivedTwo>(withDependencies.Two);
            Assert.IsType<DerivedThree>(withDependencies.Three);
        }
    }
}