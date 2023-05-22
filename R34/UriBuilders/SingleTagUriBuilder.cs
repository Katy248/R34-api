using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R34.Interfaces;

namespace R34.UriBuilders;
public class SingleTagUriBuilder : UriBuilder, ISingleTagUriBuilder
{
    public SingleTagUriBuilder(IEnumerable<Pair<string, string>> parameters) : base(parameters)
    {
        SetValue("s", "tag");
    }
    public ISingleTagUriBuilder Id(int id)
    {
        SetValue("id", id.ToString());
        return this;
    }
}
