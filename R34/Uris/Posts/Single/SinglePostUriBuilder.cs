using R34.Uris.Core;

namespace R34.Uris.Posts.Single;
public class SinglePostUriBuilder : ApiUriBuilder, ISinglePostUriBuilder
{
    public SinglePostUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "post");
    }
    public ISinglePostUriBuilder Id(int id)
    {
        SetValue("id", id.ToString());
        return this;
    }
}
