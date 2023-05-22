using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R34.Interfaces;

namespace R34.UriBuilders;
public static class Extensions
{
    public static ICommentListUriBuilder CommentList(this IUriBuilder builder)
    {
        return new CommentListUriBuilder(builder.Parametrs);
    }
    public static IPostListUriBuilder PostList(this IUriBuilder builder)
    {
        return new PostListUriBuilder(builder.Parametrs);
    }
    public static ISinglePostUriBuilder Post(this IUriBuilder builder)
    {
        return new SinglePostUriBuilder(builder.Parametrs);
    }
    public static ISingleTagUriBuilder Tag(this IUriBuilder builder)
    {
        return new SingleTagUriBuilder(builder.Parametrs);
    }
    public static ITagListUriBuilder TagList(this IUriBuilder builder)
    {
        return new TagListUriBuilder(builder.Parametrs);
    }
}
