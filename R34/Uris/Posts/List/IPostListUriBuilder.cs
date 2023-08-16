using R34.Uris.Core;

namespace R34.Uris.Posts.List;
public interface IPostListUriBuilder : IObjectListUriBuilder<IPostListUriBuilder>
{
    IPostListUriBuilder Page(int page);
    IPostListUriBuilder Tags(IEnumerable<string> tags);
}
