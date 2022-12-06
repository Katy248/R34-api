using R34;

var r34 = new Rule34();

var posts = r34.Search(new string[] { "anal"}, 1, 12);
foreach (var post in posts)
{
    Console.WriteLine($"- Post {post.Id} -");
    Console.WriteLine($"Post owner: {post.Owner}; Image url: {post.Image}; Creation date: {post.created_at};");
    Console.WriteLine($"Tags: {post.tags}");
    Console.WriteLine("--");
}
var comments = r34.GetComments(7086496);
foreach (var comment in comments)
{
    Console.WriteLine($"- Comment to post {comment.PostId} -");
    Console.WriteLine($"ID: {comment.Id}; Creation date: {comment.Creation}; Body");
    Console.WriteLine($"\t{comment.Body}");
    Console.WriteLine("--");
}
//var posts2 = r34.GetPool(23299);
Console.Error.WriteLine(r34.Random(new string[] { "-anal", "-futanari", "-gay" }, 10)?.Image);