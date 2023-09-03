using R34.Uris.Core;

namespace R34.Uris.Tags.Single;

public interface ISingleTagUriBuilder : IApiUriBuilder
{
    ISingleTagUriBuilder Id(int id);
    ISingleTagUriBuilder Name(string name);
}