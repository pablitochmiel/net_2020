using System.Diagnostics.CodeAnalysis;

namespace Utils
{
    public class Post : Entity
    {
        public Post(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }

        public string? Title { get; set; }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(UserId)}: {UserId}, {nameof(Title)}: {Title}";
        }
    }
}