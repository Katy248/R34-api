namespace R34.Uris.Core;
public interface IObjectListUriBuilder<TUriBuilder> : IApiUriBuilder where TUriBuilder : IApiUriBuilder
{
    TUriBuilder Limit(int limit);
}