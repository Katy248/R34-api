
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using R34.Models;
using R34.UriBuilders;

namespace R34;

public class Rule34
{
    private readonly ApiClient _client = new();
    public async Task<IEnumerable<Post>> Search(IEnumerable<string> tags, int pageId = -1, int limit = 500, bool deleted = false, bool ignoreMaxLimit = false)
    {
        var uri = new UriBuilders.UriBuilder().PostList()
            .Page(pageId)
            .Tags(tags.Select(tag => FormatTag(tag)))
            .Limit(limit)
            .UseJson()
            .Build();

        var response = await _client.Execute(uri);

        var content = await response.ReadAsStringAsync();
        
        var posts = JsonSerializer.Deserialize<Post[]>(await response.ReadAsStreamAsync());

        if (posts is null) return Array.Empty<Post>();

        return posts;
    }
    private string FormatTag(string tag) => 
        tag.Replace(' ', '_').Replace('\n', '_');
    public async Task<IEnumerable<Comment>> GetComments(Post post) => await GetComments(post.Id);
    public async Task<IEnumerable<Comment>> GetComments(long postId)
    {
        var uri = new UriBuilders.UriBuilder()
            .CommentList().FromPost(postId).UseJson().Build();

        var response = await _client.Execute(uri);

        var body = await response.ReadAsStringAsync();


        var commentsContainer = new XmlSerializer(typeof(CommentsContainer)).Deserialize(await response.ReadAsStreamAsync()) as CommentsContainer;
        //var comments = JsonSerializer.Deserialize<Comment[]>(await response.ReadAsStreamAsync());

        if (commentsContainer is null)
            return Array.Empty<Comment>();

        return commentsContainer.Comments;
    }
    public async Task<Post?> GetPost(int id)
    {
        var uri = new UriBuilders.UriBuilder().Post().Id(id).UseJson().Build();

        var response = await _client.Execute(uri);

        var post = JsonSerializer.Deserialize<Post>(await response.ReadAsStreamAsync());

        return post;
    }
    public async Task<IEnumerable<Tag>> GetTags(int limit)
    {
        var uri = new UriBuilders.UriBuilder().TagList().Limit(limit).UseJson().Build();

        var response = await _client.Execute(uri);

        var body = await response.ReadAsStringAsync();

        var tagsContainer = new XmlSerializer(typeof(TagsContainer)).Deserialize(await response.ReadAsStreamAsync()) as TagsContainer;
        //var tags = JsonSerializer.Deserialize<Tag[]>(await response.ReadAsStreamAsync());
        
        if (tagsContainer is null)
            return Array.Empty<Tag>();

        return tagsContainer.Tags;
    }
    public async Task<Tag?> GetTag(int id)
    {
        var uri = new UriBuilders.UriBuilder().Tag().Id(id).UseJson().Build();

        var response = await _client.Execute(uri);

        var body = await response.ReadAsStringAsync();

        //var tag = JsonSerializer.Deserialize<Tag>(await response.ReadAsStreamAsync());
        var tagsContainer = new XmlSerializer(typeof(TagsContainer)).Deserialize(await response.ReadAsStreamAsync()) as TagsContainer;


        return tagsContainer?.Tags.FirstOrDefault();
    }
    public async Task<Post> Random(IEnumerable<string>? tags, int limit = 1000)
    {
        if (tags is null)
            while (true)
            {
                var post = await GetPost(Post.GetRandomPostId);
                if (post is not null) return post;
            }
        var posts = (await Search(tags, limit: limit)).ToArray();
        return posts[System.Random.Shared.Next(0, limit - 1)];
    }
}