using R34.Uris.Core;

namespace R34.Uris.Posts.Single;
public static class Extensions
{
    public static ISinglePostUriBuilder Post(this IApiUriBuilder builder)
    {
        return new SinglePostUriBuilder(builder.Parameters);
    }
}
