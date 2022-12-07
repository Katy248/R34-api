using R34;

var r34 = new Rule34();

var posts = r34.Search(new string[] { "boobs"}, 1, 500);
foreach (var post in posts)
    Console.WriteLine($" Post ID: {post.Id}; Post owner: {post.Owner}; Image url: {post.Image}; Creation date: {post.created_at};");

var comments = r34.GetComments(7086496);
foreach (var comment in comments)
    Console.WriteLine($"Comment ID: {comment.Id}; Creation date: {comment.Creation}; Body:\n{comment.Body}");

var tags = r34.GetTags(100);
foreach (var tag in tags)
    Console.WriteLine($"Tag ID: {tag.Id}; Name: {tag.Name}; Type:\n{tag.Type}");

Console.WriteLine(r34.GetTag(22277).Name);