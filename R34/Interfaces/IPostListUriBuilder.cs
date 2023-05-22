using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R34.Interfaces;
public interface IPostListUriBuilder : IObjectListUriBuilder<IPostListUriBuilder>
{
    IPostListUriBuilder Page(int page);
    IPostListUriBuilder Tags(IEnumerable<string> tags);
}
