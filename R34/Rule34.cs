using R34.Models;
using R34.Uris.Comments.List;
using R34.Uris.Core;
using R34.Uris.Posts.List;
using R34.Uris.Posts.Single;
using R34.Uris.Tags.List;
using R34.Uris.Tags.Single;
using R34.Utilities;

namespace R34;

public class Rule34
{
    private readonly ApiClient _client = new();
    public async Task<PostsContainer> Search(IEnumerable<string> tags, int pageId = -1, int limit = 500, bool deleted = false, bool ignoreMaxLimit = false)
    {
        var uri = new ApiUriBuilder().PostList()
            .Page(pageId)
            .Tags(tags.Select(tag => FormatTag(tag)))
            .Limit(limit)
            .Build();

        var content = await _client.GetContentAsync(uri);

        var posts = content.DeserializeXml<PostsContainer>();

        return posts ?? new();
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

        var commentsContainer = content.DeserializeXml<CommentsContainer>();

        return (commentsContainer?.Entities as IEnumerable<Comment>) ?? Array.Empty<Comment>();
    }
    public async Task<Post?> GetPost(int id)
    {
        var uri = new ApiUriBuilder().Post().Id(id).Build();

        var content = await _client.GetContentAsync(uri);

        var post = content.DeserializeXml<PostsContainer>();

        return post?.Entities.FirstOrDefault();
    }
    public async Task<IEnumerable<Tag>> GetTags(int limit, int page = 0)
    {
        var uri = new ApiUriBuilder().TagList().Limit(limit).Page(page).Build();

        var content = await _client.GetContentAsync(uri);

        var tagsContainer = content.DeserializeXml<TagsContainer>();

        return (tagsContainer as IEnumerable<Tag>) ?? Array.Empty<Tag>();
    }
    public async Task<Tag?> GetTag(int id)
    {
        var uri = new ApiUriBuilder().Tag().Id(id).Build();

        var content = await _client.GetContentAsync(uri);

        var tagsContainer = content.DeserializeXml<TagsContainer>();

        return tagsContainer?.FirstOrDefault();
    }
    public async Task<Tag?> GetTag(string name)
    {
        var uri = new ApiUriBuilder().Tag().Name(name).Build();

        var content = await _client.GetContentAsync(uri);

        var tagsContainer = content.DeserializeXml<TagsContainer>();

        return tagsContainer?.FirstOrDefault();
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
        var posts = (await Search(tags, limit: limit)).Entities.ToArray();
        return posts[System.Random.Shared.Next(0, limit - 1)];
    }
}