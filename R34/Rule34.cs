using System.Net;
using System.Net.Http.Json;
using System.Xml.Serialization;

namespace R34;

public class Rule34
{
    public IEnumerable<Post> Search(IEnumerable<string> tags, int pageId = -1, int limit = 500, bool deleted = false, bool ignoreMaxLimit = false)
    {
        if (!ignoreMaxLimit && limit > 1000 || limit <= 0)
            throw new Exception("Invalid value for limit.");
        if (deleted)
            throw new Exception("To include deleted images not implemented yet.");

        var parameters = new Dictionary<string, string>()
        {
            { "TAGS","" },
            {"LIMIT", limit.ToString() },
        };
        var url = ApiUrl.Search;
        if (pageId != -1)
        {
            parameters.Add("PAGE_ID", pageId.ToString());
            url += "&pid={{PAGE_ID}}";
        }
        var formattedUrl = ParseUrlParameters(url, parameters);
        var response = new HttpClient().GetAsync(formattedUrl).Result;

        if (response.StatusCode != HttpStatusCode.OK) //if res_status != 200 or res_len <= 0:
            yield break;

        var posts = response.Content.ReadFromJsonAsync<Post[]>().Result;

        if (posts is null) yield break;

        foreach (var post in posts)
        {
            yield return post;
        }
    }
    public IEnumerable<Comment> GetComments(Post post) => GetComments(post.Id);
    public IEnumerable<Comment> GetComments(int postId)
    {
        var parameters = new Dictionary<string, string>()
        {
            {"POST_ID", postId.ToString() }
        };
        var formattedUrl = ParseUrlParameters(ApiUrl.Comments, parameters);

        var response = new HttpClient().GetAsync(formattedUrl).Result;

        if (response.StatusCode != HttpStatusCode.OK)
            yield break;

        var text = response.Content.ReadAsStringAsync().Result;

        var comments = new XmlSerializer(typeof(CommentContainer), new Type[] { typeof(Comment) })
            .Deserialize(response.Content.ReadAsStream()) as CommentContainer;

        foreach (var comment in comments.Comments)
        {
            yield return comment;
        }
    }
    public Post? GetPost(int id)
    {
        var parameters = new Dictionary<string, string>()
        {
            {"POST_ID", id.ToString() }
        };
        var formattedUrl = ParseUrlParameters(ApiUrl.GetPost, parameters);

        var response = new HttpClient().GetAsync(formattedUrl).Result;

        if (response.StatusCode != HttpStatusCode.OK)
            return null;

        try
        {
            return response.Content.ReadFromJsonAsync<Post[]>().Result.FirstOrDefault();
        }
        catch (Exception)
        {
            return null;
        }
    }
    public Post Random(IEnumerable<string>? tags, int limit = 1000)
    {
        if (tags is null)
            while (true)
            {
                var post = GetPost(Post.GetRandomPostId);
                if (post is not null) return post;
            }
        var posts = Search(tags, limit: limit).ToArray();
        return posts[System.Random.Shared.Next(0, limit - 1)];
    }
    private string ParseUrlParameters(string url, Dictionary<string, string> parameters)
    {
        foreach (var parameter in parameters)
            url = url.Replace($"{{{parameter.Key}}}", parameter.Value);
        return url;
    }
}
/*//Я в душе не чаю что это должно возвращать, у автора нет документации
    public IEnumerable<Post> GetPool(int poolId, bool fast = true)
    {
        var parameters = new Dictionary<string, string>()
        {
            {"POOL_ID", poolId.ToString() }
        };
        var formattedUrl = ParseUrlParameters(ApiUrl.Pool, parameters);

        var response = new HttpClient().GetAsync(formattedUrl).Result;

        if (response.StatusCode != HttpStatusCode.OK)
            yield break;

        var text = response.Content.ReadAsStringAsync().Result;

        var parser = new HtmlParser();
        var parsed = parser.ParseDocument(text);
        //parsed.All.Where(el => el.)
    }*/