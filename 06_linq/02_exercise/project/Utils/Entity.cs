using System.Diagnostics.CodeAnalysis;

namespace Utils
{
    public class Entity
    {
        private static int _id;

        protected Entity()
        {
            Id = _id++;
        }

        public int Id { get; }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}";
        }
    }
}