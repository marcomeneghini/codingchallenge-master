using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionLine.CodingChallenge
{
    public interface IObjectIndex<T>
    {
        IEnumerable<T> Find(SearchOptions searchOptions);
    }
}
