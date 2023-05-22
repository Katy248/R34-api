using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R34.Interfaces;

namespace R34.UriBuilders;
public class SinglePostUriBuilder : UriBuilder, ISinglePostUriBuilder
{
    public SinglePostUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "post");
    }
    public ISinglePostUriBuilder Id(int id)
    {
        SetValue("id", id.ToString());
        return this;
    }
}
