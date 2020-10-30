using System;
using System.Reflection;
using Test.Types;
using Utils;
using Xunit;

namespace Test
{
    public class ContainerTest
    {
        private readonly IContainer _container = new Container();

        [Fact]
        public void CanMapBaseToDerived()
        {
            _container.Map<Base, Derived>();
            var created = _container.Create<Base>();
            Assert.IsType<Derived>(created);
        }

        [Fact]
        public void CanMapBaseToDerivedUsingTypeApi()
        {
            _container.Map(typeof(Base), typeof(Derived));
            var created = _container.Create(typeof(Base));
            Assert.IsType<Derived>(created);
        }

        [Fact]
        public void CannotMapUsingTypeApiWhenParametersAreNull()
        {
            {
                var e = Assert.Throws<ArgumentNullException>(() => _container.Map(null!, null!));
                Assert.Equal("from", e.ParamName);
            }
            {
                var e = Assert.Throws<ArgumentNullException>(() => _container.Map(typeof(Base), null!));
                Assert.Equal("into", e.ParamName);
            }
        }

        [Fact]
        public void CannotCreateWhenConstructorIsPrivate()
        {
            _container.Map<Base, PrivateConstructor>();
            var exception = Assert.Throws<Exception>(() => _container.Create<Base>());
            Assert.Equal("Cannot find constructor!", exception.Message);
        }

        [Fact]
        public void CannotCreateWhenConstructorThrows()
        {
            _container.Map<Base, ThrowingConstructor>();
            var exception = Assert.Throws<TargetInvocationException>(() => _container.Create<Base>());
            Assert.Equal("Exception from constructor!", exception.InnerException?.Message);
        }

        [Fact]
        public void CannotCreateWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => _container.Create(null));
        }

        [Fact]
        public void CreatesWithConstructorDependencies()
        {
            _container.Map<BaseOne, DerivedOne>();
            _container.Map<BaseTwo, DerivedTwo>();
            _container.Map<BaseThree, DerivedThree>();

            var created = _container.Create<WithDependencies>();

            Assert.IsType<DerivedOne>(created?.BaseOne);
            Assert.IsType<DerivedTwo>(created!.BaseTwo);
            Assert.IsType<DerivedThree>(created!.BaseThree);
        }

        [Fact]
        public void CreatesWithNamedConstructorDependencies()
        {
            _container.Map<Base, DerivedOne>("one");
            _container.Map<Base, DerivedTwo>("two");
            _container.Map<Base, DerivedThree>("three");

            var created = _container.Create<NamedDependencies>();

            Assert.IsType<DerivedOne>(created?.One);
            Assert.IsType<DerivedTwo>(created!.Two);
            Assert.IsType<DerivedThree>(created!.Three);
        }

        [Fact]
        public void FallbackToUnnamed()
        {
            _container.Map<Base, Derived>();
            Assert.NotNull(_container.Create<Base>("foo"));
        }

        [Fact]
        public void NoFallbackToUnnamedWhenNamedProvided()
        {
            _container.Map<Base, Derived>("foo");
            var exception = Assert.Throws<Exception>(() => _container.Create<Base>("bar"));
            Assert.Equal("Missing name 'bar'!", exception.Message);
        }

        [Fact]
        public void SupportsSingletons()
        {
            _container.Map<Base, Derived>(singleton: true);

            Assert.Equal(_container.Create<Base>(), _container.Create<Base>());
        }

        [Fact]
        public void FallbackToUnnamedForSingleton()
        {
            _container.Map<Base, Derived>(singleton: true);
            Assert.NotNull(_container.Create<Base>("foo"));
        }

        [Fact]
        public void NoFallbackToUnnamedWhenNamedProvidedForSingleton()
        {
            _container.Map<Base, Derived>("foo", true);

            var exception = Assert.Throws<Exception>(() => _container.Create<Base>("bar"));
            Assert.Equal("Missing name 'bar'!", exception.Message);
        }

        [Fact]
        public void CannotMapToTypeThatIsNotInherited()
        {
            var exception =
                Assert.Throws<Exception>(() => _container.Map(typeof(BaseOne), typeof(BaseTwo)));
            Assert.Equal("Cannot map from BaseOne into BaseTwo!", exception.Message);
        }
    }
}