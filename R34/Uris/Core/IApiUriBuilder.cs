namespace R34.Uris.Core;
public interface IApiUriBuilder
{
    string Build();
    IApiUriBuilder UseJson(bool use = true);
    IEnumerable<Pair<string, string>> Parametrs { get; }
}