namespace R34;

public static class ApiUrl
{
    public const string APIUrl = "https://api.rule34.xxx/";
    public const string BaseUrl = "https://rule34.xxx/";
    public static string Search = $"{APIUrl}index.php?page=dapi&s=post&q=index&limit={{LIMIT}}&tags={{TAGS}}";
    public static string Comments = $"{APIUrl}index.php?page=dapi&s=comment&q=index&post_id={{POST_ID}}";
    public static string UserFavorites = $"{APIUrl}index.php?page=favorites&s=view&id={{USR_ID}}";
    public static string GetPost = $"{APIUrl}index.php?page=dapi&s=post&q=index&id={{POST_ID}}";
    public static string Pool = $"{APIUrl}index.php?page=pool&s=show&id={{POOL_ID}}";
    public static string UserPage = $"{APIUrl}index.php?page=account&s=profile&id={{USER_ID}}";

    public static string ICame = $"{BaseUrl}index.php?page=icame";
    public static string RandomPost = $"{BaseUrl}index.php?page=post&s=random";
    public static string TopMap = $"{BaseUrl}index.php?page=toptags";
    public static string Stats = $"{BaseUrl}index.php?page=stats";
}
