using R34;

var r34 = new Rule34();

var posts = await r34.Search(new string[] { "boobs", "anal" }, 1, 500, deleted: true);
foreach (var post in posts)
    Console.WriteLine($" Post ID: {post.Id}; Post owner: {post.Owner}; Image url: {post.Image}; Creation date: {post.CreatedAt};");

var comments = await r34.GetComments(7086496);
foreach (var comment in comments)
    Console.WriteLine($"Comment ID: {comment.Id}; Creation date: {comment.Creation}; Body:\n{comment.Body}");

var tags = await r34.GetTags(100);
foreach (var tag in tags)
    Console.WriteLine($"Tag ID: {tag.Id}; Name: {tag.Name}; Type:\n{tag.Type}");

Console.WriteLine((await r34.GetTag(22277))?.Name ?? "Not found");