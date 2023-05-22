using System.Text;

namespace R34;

public static class ApiUrl
{
    public const string APIUrl = "https://api.rule34.xxx/";
    //public const string BaseUrl = "https://rule34.xxx/";

    public static string GetPosts = $"{APIUrl}index.php?page=dapi&s=post&q=index&limit={{LIMIT}}&tags={{TAGS}}";
    public static string GetPost = $"{APIUrl}index.php?page=dapi&s=post&q=index&id={{POST_ID}}";
    public static string Comments = $"{APIUrl}index.php?page=dapi&s=comment&q=index&post_id={{POST_ID}}";
    //public static string UserFavorites = $"{APIUrl}index.php?page=favorites&s=view&id={{USR_ID}}";
    //public static string Pool = $"{APIUrl}index.php?page=pool&s=show&id={{POOL_ID}}";
    //public static string UserPage = $"{APIUrl}index.php?page=account&s=profile&id={{USER_ID}}";
    public static string Tags = $"{APIUrl}index.php?page=dapi&s=tag&q=index";

    //public static string ICame = $"{BaseUrl}index.php?page=icame";
    //public static string RandomPost = $"{BaseUrl}index.php?page=post&s=random";
    //public static string TopMap = $"{BaseUrl}index.php?page=toptags";
    //public static string Stats = $"{BaseUrl}index.php?page=stats";
}
class ApiUrlBuilder
{
    public ApiUrlBuilder(string pageName, string baseUrl = ApiUrl.APIUrl)
    {
        this.pageName = pageName;
        this.baseUrl = baseUrl;
    }
    private readonly string baseUrl;
    private readonly string pageName;
    private string? concatedTags;
    private string? limit;
    private long? id;
    private int? pageId;
    private long? lastId;
    private long? postId;
    public string Build()
    {
        var sb = new StringBuilder(baseUrl)
            .Append(pageName);
        if(concatedTags != null) sb.Append(concatedTags);


        return sb.ToString();
    }
	private string ConcatTags(IEnumerable<string> tags)
	{
		var sb = new StringBuilder();
		foreach (var tag in tags)
			sb.Append('+' + FormatTag(tag));
		return sb.ToString();
	}
	private string FormatTag(string tag) =>
		tag.Replace(' ', '_').Replace('\n', '_');
	private string GetPage()
    {
        return "index.php?page=" + pageName;
    }
    public ApiUrlBuilder AddTags(string[] tags)
    {
        concatedTags = ConcatTags(tags);
        return this;
    }
    public ApiUrlBuilder AddLimit(int limit)
    {
        this.limit = limit.ToString();
        return this;
    }
    public ApiUrlBuilder AddId(long id)
    {
        this.id = id;
        return this;
    }
    public ApiUrlBuilder AddPageId(int pageId)
    {
        this.pageId = pageId;
        return this;
    }
    public ApiUrlBuilder AddLastId(long lastId)
    {
        this.lastId = lastId;
        return this;
    }
    public ApiUrlBuilder AddPostId(long postId)
    {
        this.postId = postId;
        return this;
    }
    public string GetUrl()
    {
        var sb = new StringBuilder(baseUrl);
        sb.Append(GetPage());

        return sb.ToString();
    }
}