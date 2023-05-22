using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R34.Interfaces;
public interface IUriBuilder
{
    string Build();
    IUriBuilder UseJson(bool use = true);
    IEnumerable<Pair<string, string>> Parametrs { get; }
}