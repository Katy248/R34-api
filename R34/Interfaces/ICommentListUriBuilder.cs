namespace R34.Interfaces;

public interface ICommentListUriBuilder : IUriBuilder
{
    ICommentListUriBuilder FromPost(long postId);
}
