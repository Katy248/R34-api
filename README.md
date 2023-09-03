# R34

Fully stolen from [this][sourse_rep].

## Description  

Simple C# realization of [Rule34 API][site].

## Using

```c#
using R34;

var r34 = new Rule34();

var posts = r34.Search(new string[] { "sex", "boobs", "naked_woman" }, 1, 12);
foreach (var post in posts)
    Console.WriteLine($" Post Id: {post.Id}; File url: {post.FileUrl};");

var comments = r34.GetComments(7086496);
foreach (var comment in comments)
    Console.WriteLine($"Comment ID: {comment.Id}; Body:\n{comment.Body}");
```

[sourse_rep]: https://github.com/b3yc0d3/rule34Py
[site]: https://rule34.xxx