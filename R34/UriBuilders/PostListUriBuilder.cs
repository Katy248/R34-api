using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R34.Interfaces;

namespace R34.UriBuilders;
public class PostListUriBuilder : UriBuilder, IPostListUriBuilder
{
    public PostListUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "post");
    }
    public IPostListUriBuilder Page(int page)
    {
        if (page <= 0)
            return this;

        SetValue("pid", page.ToString());
        return this;
    }

    public IPostListUriBuilder Tags(IEnumerable<string> tags)
    {
        var tagsString = string.Join('+', tags);
        SetValue("tags", tagsString);
        return this;
    }

    public IPostListUriBuilder Limit(int limit)
    {
        if (limit > 1000 || limit <= 0)
            return this;

        SetValue("limit", limit.ToString());
        return this;
    }
}
