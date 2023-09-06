using R34;

var r34 = new Rule34();

/*var posts = await r34.Search(new string[] { "boobs", "anal" }, limit: 500, deleted: false);
foreach (var post in posts)
    Console.WriteLine($"\nPost ID: {post.Id}; \nPost owner: {post.Owner ?? post.CreatorId}; \nImage url: {post.FileUrl}; \nCreation date: {post.CreatedAt};");
*/
var comments = await r34.GetComments(8537856);
foreach (var comment in comments)
    Console.WriteLine($"Comment ID: {comment.Id}; Creation date: {comment.CreatedAt}; Body:\n{comment.Body}");
/*
var tags = await r34.GetTags(100);
foreach (var tag in tags)
    Console.WriteLine($"Tag ID: {tag.Id}; Name: {tag.Name}; Type:\n{tag.Type}");

var post2 = await r34.GetPost(7086496);
Console.WriteLine($"{post2.FileUrl}, {post2.Tags}");

Console.WriteLine((await r34.GetTag(22277))?.Name ?? "Not found");*/
