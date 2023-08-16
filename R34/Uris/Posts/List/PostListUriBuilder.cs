using R34.Uris.Core;

namespace R34.Uris.Posts.List;
public class PostListUriBuilder : ApiUriBuilder, IPostListUriBuilder
{
    public PostListUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "post");
    }
    public IPostListUriBuilder Page(int page)
    {
        if (page <= 0)
            return this;

        SetValue("pid", page.ToString());
        return this;
    }

    public IPostListUriBuilder Tags(IEnumerable<string> tags)
    {
        var tagsString = string.Join('+', tags);
        SetValue("tags", tagsString);
        return this;
    }

    public IPostListUriBuilder Limit(int limit)
    {
        if (limit > 1000 || limit <= 0)
            return this;

        SetValue("limit", limit.ToString());
        return this;
    }
}
