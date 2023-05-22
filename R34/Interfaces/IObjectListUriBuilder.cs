using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R34.Interfaces;
public interface IObjectListUriBuilder<TUriBuilder> : IUriBuilder where TUriBuilder : IUriBuilder
{
    TUriBuilder Limit(int limit);
}