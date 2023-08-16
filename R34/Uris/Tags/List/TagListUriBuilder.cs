using R34.Uris.Core;

namespace R34.Uris.Tags.List;
public class TagListUriBuilder : ApiUriBuilder, ITagListUriBuilder
{
    public TagListUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "tag");
    }

    public ITagListUriBuilder Limit(int limit)
    {
        if (limit > 1000 || limit <= 0)
            return this;

        SetValue("limit", limit.ToString());
        return this;
    }
}
