using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R34.Interfaces;

namespace R34.UriBuilders;
public class TagListUriBuilder : UriBuilder, ITagListUriBuilder
{
    public TagListUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "tag");
    }

    public ITagListUriBuilder Limit(int limit)
    {
        if (limit > 1000 || limit <= 0)
            return this;

        SetValue("limit", limit.ToString());
        return this;
    }
}
