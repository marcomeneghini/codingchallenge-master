using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionLine.CodingChallenge
{
    public interface IObjectIndexScanner<T> // TODO: ,K> where K are the specific search criteria 
    {
        // TODO: make SearchOptions Generic 
        List<T> GetObjects(IEnumerable<IObjectIndex<T>> indexes, SearchOptions searchOptions);
    }
}
