using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R34.Models;
public class EntityContainer<T> : Collection<T>
{
    public virtual IEnumerable<T> Entities => Items;
}
