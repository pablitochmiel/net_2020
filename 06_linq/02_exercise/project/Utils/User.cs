using System.Diagnostics.CodeAnalysis;

namespace Utils
{
    public class User : Entity
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        
        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }
    }
}