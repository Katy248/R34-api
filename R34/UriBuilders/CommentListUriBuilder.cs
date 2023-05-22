using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R34.Interfaces;

namespace R34.UriBuilders;
public class CommentListUriBuilder : UriBuilder, ICommentListUriBuilder
{
    public CommentListUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "comment");
    }
    public ICommentListUriBuilder FromPost(long postId)
    {
        SetValue("post_id", postId.ToString());
        return this;
    }
}
