using System.Text;

namespace R34.Uris.Core;
public class ApiUriBuilder : IApiUriBuilder
{
    public const string BaseUri = "https://api.rule34.xxx/index.php?page=dapi&q=index";
    public const char Separator = '&';

    protected readonly StringBuilder _uriBuilder = new(BaseUri);
    protected readonly List<Pair<string, string>> _parameters;

    public IEnumerable<Pair<string, string>> Parametrs => _parameters;

    public ApiUriBuilder()
    {
        _parameters ??= new();
    }
    public ApiUriBuilder(IEnumerable<Pair<string, string>> parameters)
    {
        _parameters = new(parameters);
    }

    public void SetValue(string key, string value)
    {
        var currentValue = _parameters.FirstOrDefault(x => x.Key == key);

        if (currentValue is not null)
            currentValue.Value = value;
        else
            _parameters.Add(new Pair<string, string>(key, value));
    }

    public string Build()
    {
        foreach (var arg in _parameters)
            _uriBuilder.Append(value: $"{Separator}{arg.Key}={arg.Value}");

        return _uriBuilder.ToString();
    }

    public IApiUriBuilder UseJson(bool use = true)
    {
        SetValue("json", use ? "1" : "0");
        return this;
    }
}
