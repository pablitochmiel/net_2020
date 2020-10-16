using System.Diagnostics.CodeAnalysis;

namespace Utils
{
    public class Comment : Entity
    {
        public Comment(int postId)
        {
            PostId = postId;
        }

        public int PostId { get; }

        public string? Title { set; get; }
        public string? Text { set; get; }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(PostId)}: {PostId}, {nameof(Title)}: {Title}, {nameof(Text)}: {Text}";
        }
    }
}