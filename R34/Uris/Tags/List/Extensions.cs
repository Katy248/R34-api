using R34.Uris.Core;

namespace R34.Uris.Tags.List;
public static class Extensions
{
    public static ITagListUriBuilder TagList(this IApiUriBuilder builder)
    {
        return new TagListUriBuilder(builder.Parameters);
    }
}
