using R34.Uris.Core;

namespace R34.Uris.Posts.Single;

public interface ISinglePostUriBuilder : IApiUriBuilder
{
    ISinglePostUriBuilder Id(int id);
}
