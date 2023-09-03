using R34.Uris.Core;

namespace R34.Uris.Comments.List;
public static class Extensions
{
    public static ICommentListUriBuilder CommentList(this IApiUriBuilder builder)
    {
        return new CommentListUriBuilder(builder.Parameters);
    }
}
