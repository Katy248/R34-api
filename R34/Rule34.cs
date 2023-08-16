using System.Text.Json;
using System.Xml.Serialization;
using R34.Models;
using R34.Uris.Comments.List;
using R34.Uris.Core;
using R34.Uris.Posts.List;
using R34.Uris.Posts.Single;
using R34.Uris.Tags.List;
using R34.Uris.Tags.Single;

namespace R34;

public class Rule34
{
    private readonly ApiClient _client = new();
    public async Task<IEnumerable<Post>> Search(IEnumerable<string> tags, int pageId = -1, int limit = 500, bool deleted = false, bool ignoreMaxLimit = false)
    {
        var uri = new ApiUriBuilder().PostList()
            .Page(pageId)
            .Tags(tags.Select(tag => FormatTag(tag)))
            .Limit(limit)
            .UseJson()
            .Build();

        var content = await _client.GetContentAsync(uri);

        var posts = JsonSerializer.Deserialize<Post[]>(content);

        if (posts is null)
            return Array.Empty<Post>();

        return posts;
    }
    /// <summary>
    /// Replace all whitespaces with underline.
    /// </summary>
    /// <param name="tag">Tag to format.</param>
    /// <returns>Formatted tag.</returns>
    private static string FormatTag(string tag) =>
        tag.Replace(' ', '_').Replace('\n', '_');
    public async Task<IEnumerable<Comment>> GetComments(long postId)
    {
        var uri = new ApiUriBuilder()
            .CommentList().FromPost(postId).Build();

        var content = await _client.GetContentAsync(uri);

        var commentsContainer = new XmlSerializer(typeof(CommentsContainer)).Deserialize(content) as CommentsContainer;

        if (commentsContainer is null)
            return Array.Empty<Comment>();

        return commentsContainer.Comments;
    }
    public async Task<Post?> GetPost(int id)
    {
        var uri = new ApiUriBuilder().Post().Id(id).UseJson().Build();

        var content = await _client.GetContentAsync(uri);

        var post = JsonSerializer.Deserialize<Post>(content);

        return post;
    }
    public async Task<IEnumerable<Tag>> GetTags(int limit)
    {
        var uri = new ApiUriBuilder().TagList().Limit(limit).Build();

        var content = await _client.GetContentAsync(uri);

        var tagsContainer = new XmlSerializer(typeof(TagsContainer)).Deserialize(content) as TagsContainer;

        if (tagsContainer is null)
            return Array.Empty<Tag>();

        return tagsContainer.Tags;
    }
    public async Task<Tag?> GetTag(int id)
    {
        var uri = new ApiUriBuilder().Tag().Id(id).Build();

        var content = await _client.GetContentAsync(uri);

        var tagsContainer = new XmlSerializer(typeof(TagsContainer)).Deserialize(content) as TagsContainer;

        return tagsContainer?.Tags.FirstOrDefault();
    }
    public async Task<Post> Random(IEnumerable<string>? tags, int limit = 1000)
    {
        if (tags is null)
            while (true)
            {
                var post = await GetPost(Post.GetRandomPostId);
                if (post is not null)
                    return post;
            }
        var posts = (await Search(tags, limit: limit)).ToArray();
        return posts[System.Random.Shared.Next(0, limit - 1)];
    }
}