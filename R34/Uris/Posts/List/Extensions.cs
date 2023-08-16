using R34.Uris.Core;

namespace R34.Uris.Posts.List;
public static class Extensions
{
    public static IPostListUriBuilder PostList(this IApiUriBuilder builder)
    {
        return new PostListUriBuilder(builder.Parametrs);
    }
}
