using R34.Uris.Core;

namespace R34.Uris.Comments.List;
public class CommentListUriBuilder : ApiUriBuilder, ICommentListUriBuilder
{
    public CommentListUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "comment");
    }
    public ICommentListUriBuilder FromPost(long postId)
    {
        SetValue("post_id", postId.ToString());
        return this;
    }
}
