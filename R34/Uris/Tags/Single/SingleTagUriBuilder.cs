using R34.Uris.Core;

namespace R34.Uris.Tags.Single;
public class SingleTagUriBuilder : ApiUriBuilder, ISingleTagUriBuilder
{
    public SingleTagUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "tag");
    }
    public ISingleTagUriBuilder Id(int id)
    {
        SetValue("id", id.ToString());
        return this;
    }
}
