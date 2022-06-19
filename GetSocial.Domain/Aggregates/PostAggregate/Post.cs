using GetSocial.Domain.Aggregates.UserProfileAggregate;

namespace GetSocial.Domain.Aggregates.PostAggregate
{
    public class Post
    {
        private readonly List<PostComment> _comments = new List<PostComment>();
        private readonly List<PostInteraction> _interactions = new List<PostInteraction>();
        private Post()
        {
        }
        public Guid Id { get; private set; }
        public Guid UserProfileId { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public string TextContent { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModified { get; private set; }
        public IEnumerable<PostComment> Comments => _comments;
        public IEnumerable<PostInteraction> Interactions => _interactions;

        //Factory method
        public static Post CreatePost(Guid userProfileId, string textContent)
        {
            return new Post
            {
                UserProfileId = userProfileId,
                TextContent = textContent,
                CreatedDate = DateTime.UtcNow,
                LastModified = DateTime.UtcNow
            };
        }

        //Public methods
        public void UpdatePost(string newText)
        {
            TextContent = newText;
            LastModified = DateTime.UtcNow;
        }

        public void AddPostComment(PostComment newComment)
        {
            _comments.Add(newComment);
        }

        public void RemovePostComment(PostComment comment)
        {
            _comments.Remove(comment);
        }

        public void AddPostInteraction(PostInteraction newInteraction)
        {
            _interactions.Add(newInteraction);
        }

        public void RemovePostInteraction(PostInteraction interaction)
        {
            _interactions.Remove(interaction);
        }
    }
}
