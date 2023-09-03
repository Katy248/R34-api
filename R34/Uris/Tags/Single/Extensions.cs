using R34.Uris.Core;

namespace R34.Uris.Tags.Single;
public static class Extensions
{
    public static ISingleTagUriBuilder Tag(this IApiUriBuilder builder)
    {
        return new SingleTagUriBuilder(builder.Parameters);
    }
}
