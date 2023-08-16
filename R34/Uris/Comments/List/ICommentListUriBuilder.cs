using R34.Uris.Core;

namespace R34.Uris.Comments.List;

public interface ICommentListUriBuilder : IApiUriBuilder
{
    ICommentListUriBuilder FromPost(long postId);
}
